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
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void BtnConfirmLogin_Click (object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    if (txtLogin.Text == "" || txtPassword.Text == "")  // if login and password are empty throw an exception
                    {
                        throw new Exception("Enter username and password.");
                    }
                    command.Connection = connection;
                    string queryString = $"SELECT username, password FROM login.users WHERE username = @username and password = @password;";
                    command.CommandText = queryString;
                    command.Parameters.AddWithValue("username", txtLogin.Text);
                    command.Parameters.AddWithValue("password", txtPassword.Text);
                    connection.Open();
                    MySqlDataReader row = command.ExecuteReader();  // Read row from db table with matching logind and password
                    if (!row.HasRows)   // if there are not any matching results
                    {
                        row.Close();
                        throw new Exception("Data not found");
                    }
                    while (row.Read())  // if there is a match, sent a welcome message
                    {
                        MessageBox.Show($"Welcome, {row["username"].ToString()}. You are logged in.");
                    }
                    row.Close();
                    
                    Form frm = new Navigation();
                    frm.Show();     // If the user is logged in, open a Navigation form
                    this.Hide();    // Hide login panel
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }                        
        }
        private void BtnLoginExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
