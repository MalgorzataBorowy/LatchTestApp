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
        
        public string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
        public string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string GenerateSHA265Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }

        private void BtnConfirmLogin_Click (object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connString))
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    if (txtLogin.Text == "" || txtPassword.Text == "")  // if login and password are empty throw an exception                   
                        throw new Exception("Enter username and password.");
                    
                    string queryString = $"SELECT username, salt, hash FROM login.users WHERE username = @username;";                    
                    command.Connection = connection;
                    command.CommandText = queryString;
                    command.Parameters.AddWithValue("username", txtLogin.Text);
                    connection.Open();
                    MySqlDataReader row = command.ExecuteReader();  // Read row from db table with matching login
                    if (!row.HasRows)   // if there are not any matching results
                    {
                        row.Close();
                        throw new Exception("User not found");
                    }
                    row.Read();
                    string salt = row["salt"].ToString();   //read the salt
                    string hashedPassword = GenerateSHA265Hash(txtPassword.Text, salt);     //hash the entered password using salt from db
                    if (hashedPassword != row["hash"].ToString())   //compare hashed passwords
                        throw new Exception("Incorrect password");

                    MessageBox.Show($"Welcome, {row["username"].ToString()}. You are logged in.");
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
