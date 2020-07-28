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

        private void SetCBIdsList(string queryString, ComboBox cbName, string columnName)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {                
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        DataTable ids = new DataTable();
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                        dataAdapter.Fill(ids);
                        cbName.Items.Clear();
                        foreach (DataRow id in ids.Rows)
                        {
                            cbName.Items.Add(id[columnName].ToString());
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
        }
        
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
                    cbComponentID.ResetText();
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

        private void btnFinishAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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

        private void btnComponentAddConfirm_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string type = (rbType1Comp.Checked && !rbType2Comp.Checked) ? rbType1Comp.Text : rbType2Comp.Text;
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
                        MessageBox.Show($"Error\nSQL Message: {ex}");
                    }
                    finally
                    {
                        connection.Close();
                        ClearForm("componentAdd");
                    }
                }
            }
        }
        private void btnLatchAddConfirm_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            {
                string type = (rbLatchShort.Checked && !rbLatchLong.Checked) ? rbLatchShort.Text : rbLatchLong.Text;
                var component_id = cbComponentID.SelectedItem;
                string queryString = $"INSERT INTO sql_latch_tests1.latches (type, component_id) VALUES('{type}',{component_id})";
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    try
                    {
                        if (cbComponentID.SelectedIndex == -1)
                        {
                            throw new Exception("Select the tested component");
                        }
                        if (!rbLatchShort.Checked && !rbLatchLong.Checked)
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
                        MessageBox.Show($"Error\nSQL Message: {ex}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
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
                if (tbVideoLinkTest.Text!="")
                {
                    command.Parameters.AddWithValue("@video_link", tbVideoLinkTest.Text);
                }
                command.Parameters.AddWithValue("@comments", tbCommentsTest.Text);
                command.Connection = connection;
                try
                {
                    if(tbVideoLinkTest.Text == "")
                    {
                        throw new Exception("Add a link to video recording");
                    }
                    if(cbLatchIDTest.SelectedIndex == -1)
                    {
                        throw new Exception("Select the tested latch");
                    }
                    if(!rbStatusPassedTest.Checked && !rbStatusNotPassedTest.Checked)
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
                    MessageBox.Show($"Error\nSQL Message: {ex}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                finally
                {
                    connection.Close();
                    queryString = $"SELECT latch_id FROM sql_latch_tests1.latches WHERE latch_id NOT IN (SELECT latch_id FROM sql_latch_tests1.tests);";
                    SetCBIdsList(queryString, cbLatchIDTest, "latch_id");
                }


            }
        }
    }
}
