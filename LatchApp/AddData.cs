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
using System.Collections;

namespace LatchApp
{
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
        }

        // Method for reading ids from sql table and saving them to ComboBox list
        private void SetCBIdsList(string queryString, ComboBox cbName, string columnName)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    DataTable ids = new DataTable();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(ids);  // Fill the 'ids' DataTable with ids from sql
                    cbName.Items.Clear();
                    foreach (DataRow id in ids.Rows)
                    {
                        cbName.Items.Add(id[columnName].ToString());    // Add id to ComboBox list
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        // Method for clearing fields in a form
        private void ClearForm(string formName)
        {
            switch (formName)
            {
                case "componentAdd":
                    rbStatusCompNotPassed.Checked = false;
                    rbStatusCompPassed.Checked = false;
                    rbStatusCompNotTested.Checked = false;
                    rbType1Comp.Checked = false;
                    rbType2Comp.Checked = false;
                    break;
                case "latchAdd":
                    rbLatchLong.Checked = false;
                    rbLatchShort.Checked = false;
                    cbComponentID.ResetText();  //Clear text field from ComboBox
                    break;
                case "testAdd":
                    cbLatchIDTest.ResetText();  
                    dtpEndTimeTest.Value = DateTime.Now;
                    dtpDateTest.Value = DateTime.Now;
                    rbStatusNotPassedTest.Checked = false;
                    rbStatusPassedTest.Checked = false;
                    tbVideoLinkTest.Clear();
                    tbCommentsTest.Clear();
                    nudCyclesTest.Value = 500;
                    break;
            }            
        }

        // Method for selecting and returning a path to a file
        private string GetFilePath(string title, string extension)
        {
            OpenFileDialog ofdVideoLink = new OpenFileDialog
            {
                InitialDirectory = @"E:\",
                Title = title,

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = extension,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (ofdVideoLink.ShowDialog() == DialogResult.OK)
            {
                return ofdVideoLink.FileName;
            }
            else
            {
                return null;
            }             
        }

        // Select and show a form (three buttons)
        private void btnComponentAdd_Click(object sender, EventArgs e)
        {
            gbComponentAdd.Visible = true;
            gbLatchAdd.Visible = false;
            gbTestAdd.Visible = false;
        }
        private void btnLatchAdd_Click(object sender, EventArgs e)
        {
            gbLatchAdd.Visible = true;
            gbComponentAdd.Visible = false;
            gbTestAdd.Visible = false;
            string queryString = $"SELECT component_id FROM sql_latch_tests1.components;";
            SetCBIdsList(queryString, cbComponentID, "component_id");
        }
        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            gbTestAdd.Visible = true;
            gbComponentAdd.Visible = false;
            gbLatchAdd.Visible = false;
            string queryString = $"SELECT latch_id FROM sql_latch_tests1.latches WHERE latch_id NOT IN (SELECT latch_id FROM sql_latch_tests1.tests);";
            SetCBIdsList(queryString, cbLatchIDTest, "latch_id");
        }

        // Add a component to db table
        private void btnComponentAddConfirm_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string type = (rbType1Comp.Checked && !rbType2Comp.Checked) ? rbType1Comp.Text : rbType2Comp.Text; // Select a type from two options
                string status = (rbStatusCompNotPassed.Checked && !rbStatusCompPassed.Checked) ? "true" : "false";
                string queryString = $"INSERT INTO sql_latch_tests1.components (type, status) VALUES ('{type}',{status});";
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Component added to db");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                        ClearForm("componentAdd");
                    }
                }
            }
        }
        // Add a latch to db table
        private void btnLatchAddConfirm_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string type = (rbLatchShort.Checked && !rbLatchLong.Checked) ? rbLatchShort.Text : rbLatchLong.Text;
                var component_id = cbComponentID.SelectedItem;  //Value of selected id from ComboBox
                string queryString = $"INSERT INTO sql_latch_tests1.latches (type, component_id) VALUES('{type}',{component_id})";
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    try
                    {
                        if (cbComponentID.SelectedIndex == -1) // Check if a list item is selected
                        {
                            throw new Exception("Select the tested component");
                        }
                        if (!rbLatchShort.Checked && !rbLatchLong.Checked) // Check if any RadioButton is checked
                        {
                            throw new Exception("Select type");
                        }
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Latch added to db");
                        ClearForm("latchAdd");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        // Add a test to db table
        private void btnTestAddConfirm_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                MySqlCommand command = new MySqlCommand();
                string queryString = "INSERT INTO sql_latch_tests1.tests (`latch_id`,`end_time`,`date`,`status`,`cycles`,`video_link`,`comments`) VALUES (@latch_id, @end_time, @date, @status, @cycles, @video_link, @comments);";
                command.CommandText = queryString;
                int status = (rbStatusPassedTest.Checked && !rbStatusNotPassedTest.Checked) ? 1 : 0;
                command.Parameters.AddWithValue("@latch_id", cbLatchIDTest.SelectedItem);
                command.Parameters.AddWithValue("@end_time", dtpEndTimeTest.Value);
                command.Parameters.AddWithValue("date", dtpDateTest.Value);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@cycles", nudCyclesTest.Value);
                command.Parameters.AddWithValue("@video_link", tbVideoLinkTest.Text);
                command.Parameters.AddWithValue("@comments", tbCommentsTest.Text);
                command.Connection = connection;
                try
                {
                    if(tbVideoLinkTest.Text == "")  // Check if the TextBox with video link is filled
                    {
                        throw new Exception("Add a link to video recording");
                    }
                    if(cbLatchIDTest.SelectedIndex == -1) // Check if a list item is selected
                    {
                        throw new Exception("Select the tested latch");
                    }
                    if(!rbStatusPassedTest.Checked && !rbStatusNotPassedTest.Checked) // Check if any RadioButton is checked
                    {
                        throw new Exception("Select status");
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Test added to db");
                    ClearForm("testAdd");

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    connection.Close();
                    queryString = $"SELECT latch_id FROM sql_latch_tests1.latches WHERE latch_id NOT IN (SELECT latch_id FROM sql_latch_tests1.tests);";
                    SetCBIdsList(queryString, cbLatchIDTest, "latch_id");   // Update ComboBox list with latch ids
                }
            }
        }
        // Browse for video file
        private void BtnAddBrowse_Click(object sender, EventArgs e)
        {
            string title = "Browse for Video Recordings";
            tbVideoLinkTest.Text = GetFilePath(title,"mp4");
        }

        // Select file to load component data to db
        private void BtnAddFile_Click(object sender, EventArgs e)
        {
            string title = "Browse for a file to load";
            txtAddDataCompFile.Text = GetFilePath(title, "csv");            
        }
        // Load component data to db
        private void BtnAddDataCompLoad_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string queryString = $"LOAD DATA LOCAL INFILE '{txtAddDataCompFile.Text.ToString()}' INTO TABLE sql_latch_tests1.components FIELDS TERMINATED BY ',';";
                using (MySqlCommand command = new MySqlCommand(queryString,connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void btnFinishAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
