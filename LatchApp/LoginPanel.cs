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
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    try
                    {
                        if (txtLogin.Text == "" || txtPassword.Text == "")
                        {
                            throw new Exception("Enter username and password.");
                        }
                        command.Connection = connection;
                        string queryString = $"SELECT username, password FROM login.users WHERE username = @username and password = @password;";
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("username", txtLogin.Text);
                        command.Parameters.AddWithValue("password", txtPassword.Text);
                        connection.Open();
                        MySqlDataReader row = command.ExecuteReader();
                        if(!row.HasRows)
                        {
                            row.Close();
                            throw new Exception("Data not found");
                        }
                        while (row.Read())
                        {
                            MessageBox.Show($"Welcome, {row["username"].ToString()}. You are logged in.");
                        }
                        row.Close();
                        Form frm = new Navigation();
                        frm.Show();
                        this.Hide();
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
        }
        private void BtnLoginExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
