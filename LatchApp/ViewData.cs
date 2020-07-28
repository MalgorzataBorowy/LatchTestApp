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

namespace LatchApp
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();
        }

        private string table = "", column = "";

        private void ViewDataFromTable(string table)
        {
            string queryString = $"SELECT * FROM sql_latch_tests1.{table};";
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {                
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dataGridView1.DataSource = dataTable;
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("The requested order could not be loaded into the form.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        private void RemoveRowsFromTable(string table, string column)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string queryString = $"DELETE FROM sql_latch_tests1.{table} WHERE {column} = 0 ";
                foreach (DataGridViewRow oneRow in dataGridView1.SelectedRows)
                {
                    if (oneRow.Selected)
                    {
                        string idToRemove = oneRow.Cells[0].Value.ToString();
                        queryString += $"or {column} = {idToRemove} ";
                    }
                }
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryString, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Done");
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.ToLower().Contains("foreign"))
                    {
                        MessageBox.Show("You have a reference record in other table");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    connection.Close();
                    ViewDataFromTable(table);
                }
            }
        }

        private void BtnComponentView_Click(object sender, EventArgs e)
        {
            table = "components";
            column = "component_id";
            ViewDataFromTable(table);
        }
        private void BtnLatchView_Click(object sender, EventArgs e)
        {
            table = "latches";
            column = "latch_id";
            ViewDataFromTable(table);
        }

        private void BtnTestView_Click(object sender, EventArgs e)
        {
            table = "tests";
            column = "test_id";
            ViewDataFromTable(table);
        }
        private void BtnRemoveRow_Click(object sender, EventArgs e)
        {
            RemoveRowsFromTable(table, column);           
        }
        private void BtnSubmitChanges_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Message");
        }

        private void BtnFinishView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
