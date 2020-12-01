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
    public partial class AddData : Form
    {
        public AddData()
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


        // Method for reading ids from sql table and saving them to ComboBox list
        private void SetCBIdsList(IEnumerable<int> ids, ComboBox cbName)
        {
            cbName.Items.Clear();
            foreach (var id in ids)
                cbName.Items.Add(id.ToString());
        }

        // Method for clearing fields in a form
        private void ClearForm(View view)
        {
            switch (view)
            {
                case View.Component:
                    rbStatusCompNotPassed.Checked = false;
                    rbStatusCompPassed.Checked = false;
                    rbStatusCompNotTested.Checked = false;
                    rbType1Comp.Checked = false;
                    rbType2Comp.Checked = false;
                    break;
                case View.Latch:
                    rbLatchLong.Checked = false;
                    rbLatchShort.Checked = false;
                    cbComponentID.ResetText();  //Clear text field from ComboBox
                    break;
                case View.Test:
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
                return ofdVideoLink.FileName;
            else
                return null;
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
            SetCBIdsList(latchRepository.GetReferenceIds(), cbComponentID);
        }
        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            gbTestAdd.Visible = true;
            gbComponentAdd.Visible = false;
            gbLatchAdd.Visible = false;
            SetCBIdsList(testRepository.GetReferenceIds(), cbLatchIDTest);
        }

        // Add a component to db table
        private void btnComponentAddConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                CompModel componentModel = new CompModel();
                componentModel.Type = (rbType1Comp.Checked && !rbType2Comp.Checked) ? rbType1Comp.Text : rbType2Comp.Text;
                componentModel.Status = (rbStatusCompNotPassed.Checked && !rbStatusCompPassed.Checked) ? false : true;
                componentRepository.Add(componentModel);
                MessageBox.Show("Component added to db");
                ClearForm(View.Component);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Add a latch to db table
        private void btnLatchAddConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                LatchModel latchModel = new LatchModel();
                latchModel.Type = (rbLatchShort.Checked && !rbLatchLong.Checked) ? rbLatchShort.Text : rbLatchLong.Text;
                latchModel.ComponentID = Int32.Parse(cbComponentID.SelectedItem.ToString());
                latchRepository.Add(latchModel);
                MessageBox.Show("Latch added to db");
                ClearForm(View.Component);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Add a test to db table
        private void btnTestAddConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                TestModel testModel = new TestModel();
                testModel.LatchID = Int32.Parse(cbLatchIDTest.SelectedItem.ToString());
                testModel.EndTime = dtpEndTimeTest.Value;
                testModel.Date = dtpDateTest.Value;
                testModel.Status = (rbStatusPassedTest.Checked && !rbStatusNotPassedTest.Checked) ? true : false;
                testModel.Cycles = (int)nudCyclesTest.Value;
                testModel.VideoLink = tbVideoLinkTest.Text;
                testModel.Comments = tbCommentsTest.Text;

                testRepository.Add(testModel);
                MessageBox.Show("Test added to db");
                ClearForm(View.Test);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Browse for video file
        private void BtnAddBrowse_Click(object sender, EventArgs e)
        {
            string title = "Browse for Video Recordings";
            tbVideoLinkTest.Text = GetFilePath(title, "mp4");
        }

        // Select file to load component data to db
        private void BtnAddFile_Click(object sender, EventArgs e)
        {
            string title = "Browse for a file to load";
            txtAddDataCompFile.Text = GetFilePath(title, "csv");
        }

        private void BtnAddDataCompLoad_Click(object sender, EventArgs e)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(txtAddDataCompFile.Text);
            while ((line = file.ReadLine()) != null)
            {                
                string[] values = line.Split(';');
                CompModel componentModel = new CompModel();
                componentModel.ComponentID = Int16.Parse(values[0].ToString());
                componentModel.Type = values[1].ToString();
                componentModel.Status = Convert.ToBoolean(Int16.Parse(values[2].ToString()));
                try
                {
                    componentRepository.Add(componentModel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            MessageBox.Show("Components added to db");
            file.Close();
        }

        private void btnFinishAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
