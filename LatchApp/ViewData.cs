﻿using System;
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
                            dataGridView1.DataSource = null;
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dataGridView1.DataSource = dataTable;
                            dataGridView1.AutoResizeColumns();
                            dataReader.Close();
                            dataGridView1.Columns[0].ReadOnly = true;
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
            foreach (DataGridViewRow oneRow in dataGridView1.Rows)
            {
                if (oneRow.Cells[0].Value != null)
                {
                    string queryString = "", componentId = "", type = "", status = "", latchId = "", testId = "", endTime = "", date = "", cycles = "", videoLink = "", comments = "";
                    switch(table)
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
                            date = oneRow.Cells[3].Value.ToString();
                            status = oneRow.Cells[4].Value.ToString().ToLower();
                            cycles = oneRow.Cells[5].Value.ToString();
                            videoLink = oneRow.Cells[6].Value.ToString();
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
                            if (ex.Message.ToString().ToLower().Contains("foreign") && table == "latches")
                            {
                                MessageBox.Show("Element does not exist.");
                            }
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
        }

        private void BtnFinishView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
