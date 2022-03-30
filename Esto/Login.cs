using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Esto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=ecole";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Username from users", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            usname.DataSource = ds.Tables[0];
            usname.DisplayMember = "Username";
            
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=ecole";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                if (usname.Text == "" || pass.Text == "")
                {
                    MessageBox.Show("Entrez le mot de passe ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from users where Username = @name and Password = @pass", con);
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = usname.Text;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        DbDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        MessageBox.Show("Connection avec succes");
                        Gestion f = new Gestion((string)reader["mode_d_acces"]);
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show(" Mot de passe incorrect ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                   
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
