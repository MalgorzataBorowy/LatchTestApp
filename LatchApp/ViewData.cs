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
        private View currentView;

        // Method for filling the DataGridView with db table data
        private void ViewDataFromTable(View view)
        {
            dataGridView1.DataSource = null;    // Ensures that DataGridView columns are in the order as in the db

            switch (view)
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
        private void RemoveRowsFromTable(View view)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    switch (view)
                    {
                        case View.Component:
                            componentRepository.DeleteById(id);
                            break;

                        case View.Latch:
                            latchRepository.DeleteById(id);
                            break;

                        case View.Test:
                            testRepository.DeleteById(id);
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
                
            }
            MessageBox.Show("Rows removed");
            ViewDataFromTable(view);
        }

        // Show data from selected table in DataGridView
        private void BtnComponentView_Click(object sender, EventArgs e)
        {
            currentView = View.Component;
            ViewDataFromTable(View.Component);   
        }
        private void BtnLatchView_Click(object sender, EventArgs e)
        {
            currentView = View.Latch;
            ViewDataFromTable(View.Latch);
        }

        private void BtnTestView_Click(object sender, EventArgs e)
        {
            currentView = View.Test;
            ViewDataFromTable(View.Test);
        }

        // Removing selected rows from selected db table
        private void BtnRemoveRow_Click(object sender, EventArgs e)
        {
            RemoveRowsFromTable(currentView);           
        }

        // Introducing changes to db data
        private void BtnSubmitChanges_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null) return;

                    switch (currentView)
                    {
                        case View.Component:
                            CompModel componentModel = new CompModel();
                            componentModel.ComponentID = Convert.ToInt32(row.Cells[0].Value);
                            componentModel.Type = row.Cells[1].Value.ToString();
                            componentModel.Status = Convert.ToBoolean(row.Cells[2].Value);
                            componentRepository.Update(componentModel);
                            break;

                        case View.Latch:
                            LatchModel latchModel = new LatchModel();
                            latchModel.LatchID = Convert.ToInt32(row.Cells[0].Value);
                            latchModel.Type = row.Cells[1].Value.ToString();
                            latchModel.ComponentID = Convert.ToInt32(row.Cells[2].Value);
                            latchRepository.Update(latchModel);
                            break;

                        case View.Test:
                            TestModel testModel = new TestModel();
                            testModel.TestID = Convert.ToInt32(row.Cells[0].Value);
                            testModel.LatchID = Convert.ToInt32(row.Cells[1].Value);
                            testModel.EndTime = Convert.ToDateTime(row.Cells[2].Value);
                            testModel.Date = Convert.ToDateTime(row.Cells[3].Value);
                            testModel.Status = Convert.ToBoolean(row.Cells[4].Value);
                            testModel.Cycles = Convert.ToInt32(row.Cells[5].Value);
                            testModel.VideoLink = row.Cells[6].Value.ToString().Replace("\\", "\\\\");
                            testModel.Comments = row.Cells[7].Value.ToString();
                            testRepository.Update(testModel);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            
            ViewDataFromTable(currentView);   // Refresh the data grid view
        }

        // Close the window
        private void BtnFinishView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
