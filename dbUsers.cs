using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;




namespace Esto
{
    class dbUsers
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=ecole";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void AddUser(Utilisateurs std)
        {
            string sql = "INSERT INTO users VALUES(NULL,@nomUser,@passUser,@accesUser)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nomUser", MySqlDbType.VarChar).Value = std.Username;
            cmd.Parameters.Add("@passUser", MySqlDbType.VarChar).Value = std.Password;
            cmd.Parameters.Add("@accesUser", MySqlDbType.VarChar).Value = std.Acces;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute avec succes . ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Pas inserer. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateUser(Utilisateurs std, string idu)
        {
            string sql = "UPDATE users SET username = @nomUser, password = @passUser, mode_d_acces = @accesUser WHERE idu = @code";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = idu;
            cmd.Parameters.Add("@nomUser", MySqlDbType.VarChar).Value = std.Username;
            cmd.Parameters.Add("@passUser", MySqlDbType.VarChar).Value = std.Password;
            cmd.Parameters.Add("@accesUser", MySqlDbType.VarChar).Value = std.Acces;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Mise a jour avec succes. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateRoot(string pass, string idu)
        {
            string sql = "UPDATE users SET password = @passUser WHERE idu = @code";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = idu;
            cmd.Parameters.Add("@passUser", MySqlDbType.VarChar).Value = pass;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Mise a jour avec succes. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteUser(string id)
        {
            string sql = "DELETE FROM users WHERE idu = @code";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = id;
            try
            {
                if (MessageBox.Show("Voulez vous supprimer ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("suppression avec succees. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Pas supprimmer. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dvg)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dvg.DataSource = tbl;
            con.Close();
        }

    }
}
