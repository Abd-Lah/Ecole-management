using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;




namespace Esto
{
    class dbEcoleFilliere
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
        public static void AddFilliere(Filliere std)
        {
            string sql = "INSERT INTO filliere VALUES(@FilliereCode,@DepartementCode,@FilliereNom)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@FilliereCode", MySqlDbType.VarChar).Value = std.Codefill;
            cmd.Parameters.Add("@DepartementCode", MySqlDbType.VarChar).Value = std.Codedepart;
            cmd.Parameters.Add("@FilliereNom", MySqlDbType.VarChar).Value = std.Nomfill;
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
       
        public static void DeleteFilliere(string code)
        {
            string sql = "DELETE FROM filliere WHERE codefill = @code";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            try
            {
                if (MessageBox.Show("Attention cette operation va supprimmer toutes les etudiantes de cette filliere?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbEcoleEtudiant.DeleteEtudiantByFill(code);
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
        public static void DeleteFilliereByDepart(string code)
        {
            string sql = "DELETE FROM filliere WHERE codedepart = @code";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Pas supprimer. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

    }
}
