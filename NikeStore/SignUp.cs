using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NikeStore
{

    public partial class SignUp : Form
    {
        SqlConnection connect = new SqlConnection(@" Data Source =.\sqlexpress;Initial Catalog = account; Integrated Security = True; Encrypt=False");
        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (connect.State != ConnectionState.Open) {
                try
                {
                    connect.Open();
                    String checkUsername = "SELECT * FROM admin WHERE username = '" + signup_username.Text.Trim() + "'";

                    using (SqlCommand checkUser = new SqlCommand(checkUsername, connect)) {

                        SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show(signup_username.Text + "is already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else { 
                        string insertData = " INSERT into admin (email, username, password)"+
                                "VALUES(@email, @username, @password)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect)) {
                                cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Form1 f1 = new Form1();
                                f1.Show();
                                this.Hide();
                            }
                        }
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting Database " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    connect.Close();
                }
            }
        }

        private void signup_showcases_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showpass.Checked)
            {
                signup_password.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
            }
        }
    }
}
