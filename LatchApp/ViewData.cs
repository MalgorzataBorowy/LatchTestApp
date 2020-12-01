using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using LatchApp.DataAccess;
using LatchApp.Model;

namespace LatchApp
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();
        }

        private static string connString = Properties.Settings.Default.connString;
        private ComponentRepository componentRepository = new ComponentRepository(connString);
        private LatchRepository latchRepository = new LatchRepository(connString);
        private TestRepository testRepository = new TestRepository(connString);

        private enum View
        {
            Component,
            Latch,
            Test,
        }

        private string table = "", column = "";     // strings with table name and name of column with ids

        // Method for filling the DataGridView with db table data
        private void ViewDataFromTable(View table)
        {
            dataGridView1.DataSource = null;    // Ensures that DataGridView columns are in the order as in the db

            switch (table)
            {
                case View.Component:
                    dataGridView1.DataSource = componentRepository.GetAll();
                    break;

                case View.Latch:
                    dataGridView1.DataSource = latchRepository.GetAll();
                    break;

                case View.Test:
                    dataGridView1.DataSource = testRepository.GetAll();
                    break;
            }
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].ReadOnly = true;   // Column with primary keys (ids) in dgv cannot be changed by a user
        }

        // Method for removing selected rows from a table
        private void RemoveRowsFromTable(View view, string column)
        {
            /*foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);

            }*/

            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string queryString = $"DELETE FROM sql_latch_tests1.{view} WHERE {column} = 0 ";
                foreach (DataGridViewRow oneRow in dataGridView1.SelectedRows)
                {
                    if (oneRow.Selected)
                    {
                        string idToRemove = oneRow.Cells[0].Value.ToString();
                        queryString += $"or {column} = {idToRemove} ";
                    }
                }

                if(dataGridView1.SelectedRows.Count>0)  // if any rows are selected execute the SQL query
                {
                    try
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(queryString, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Rows removed");
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Message.ToLower().Contains("foreign"))   // if there are referenced elements to the selected row
                        {
                            MessageBox.Show("You have a reference record in other table");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                        ViewDataFromTable(View.Component);   // Refresh DataGridView
                    }
                }
                
            }
        }

        // Show data from selected table in DataGridView
        private void BtnComponentView_Click(object sender, EventArgs e)
        {
            /*table = "components";
            column = "component_id";*/
            ViewDataFromTable(View.Component);   
        }
        private void BtnLatchView_Click(object sender, EventArgs e)
        {
            /*table = "latches";
            column = "latch_id";*/
            ViewDataFromTable(View.Latch);
        }

        private void BtnTestView_Click(object sender, EventArgs e)
        {
            /*table = "tests";
            column = "test_id";*/
            ViewDataFromTable(View.Test);
        }

        // Removing selected rows from selected db table
        private void BtnRemoveRow_Click(object sender, EventArgs e)
        {
            RemoveRowsFromTable(table, column);           
        }

        // Introducing changes to db data
        private void BtnSubmitChanges_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oneRow in dataGridView1.Rows)
            {
                // If the row is not empty - if there is a value of id
                if (oneRow.Cells[0].Value != null)
                {
                    // Initialization of query parameters
                    string queryString = "", componentId = "", type = "", status = "", latchId = "", testId = "", endTime = "", date = "", cycles = "", videoLink = "", comments = "";
                    
                    switch(table)   // Create a SQL query for selected table
                    {
                        case "components":
                            componentId = oneRow.Cells[0].Value.ToString();
                            type = oneRow.Cells[1].Value.ToString();
                            status = oneRow.Cells[2].Value.ToString().ToLower();
                            queryString = $"UPDATE sql_latch_tests1.components SET type = '{type}', status = {status} WHERE component_id = {componentId};";
                            break;

                        case "latches":
                            latchId = oneRow.Cells[0].Value.ToString();
                            type = oneRow.Cells[1].Value.ToString();
                            componentId = oneRow.Cells[2].Value.ToString();
                            queryString = $"UPDATE sql_latch_tests1.latches SET type = '{type}', component_id = {componentId} WHERE latch_id = {latchId};";
                            break;
                        case "tests":
                            testId = oneRow.Cells[0].Value.ToString();
                            latchId = oneRow.Cells[1].Value.ToString();
                            endTime = oneRow.Cells[2].Value.ToString();
                            date = Convert.ToDateTime(oneRow.Cells[3].Value).ToString("yyyy-MM-dd");
                            status = oneRow.Cells[4].Value.ToString().ToLower();
                            cycles = oneRow.Cells[5].Value.ToString();
                            videoLink = oneRow.Cells[6].Value.ToString().Replace("\\", "\\\\");
                            comments = oneRow.Cells[7].Value.ToString();
                            queryString = $"UPDATE sql_latch_tests1.tests SET latch_id = {latchId}, end_time = '{endTime}', date = '{date}', status = {status}, cycles = {cycles}, video_link = '{videoLink}', comments = '{comments}' WHERE test_id = {testId};";
                            break;
                    }


                    using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
                    {
                        try
                        {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(queryString, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (MySqlException ex)
                        {
                            // Exception - latch assignd to component id that does not exist
                            if (ex.Message.ToString().ToLower().Contains("foreign") && table == "latches")
                            {
                                MessageBox.Show("Element does not exist.");
                            }
                            // Exception - multiple tests declared for the same latch
                            else if (ex.Message.ToString().ToLower().Contains("foreign") && table == "tests")
                            {
                                MessageBox.Show("Latch does not exist or multiple tests for the same latch id.");
                            }
                            else
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
            ViewDataFromTable(View.Component);   // Refresh the data grid view
        }

        // Close the window
        private void BtnFinishView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
