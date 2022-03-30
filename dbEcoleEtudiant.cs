using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;




namespace Esto
{
    class dbEcoleEtudiant
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
        public static void AddEtudiant(Etudiant std)
        {
            string sql = "INSERT INTO etudiant VALUES(NULL, @EtudiantNom, @EtudiantPrenom, @EtudiantDepartement, @EtudiantFilliere)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EtudiantNom", MySqlDbType.VarChar).Value = std.Nom;
            cmd.Parameters.Add("@EtudiantPrenom", MySqlDbType.VarChar).Value = std.Prenom;
            cmd.Parameters.Add("@EtudiantDepartement", MySqlDbType.VarChar).Value = std.Departement;
            cmd.Parameters.Add("@EtudiantFilliere", MySqlDbType.VarChar).Value = std.Filliere;
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
        public static void UpdateEtudiant(Etudiant std, string ide)
        {
            string sql = "UPDATE etudiant SET Nom = @EtudiantNom, Prenom = @EtudiantPrenom,codedepart = @EtudiantDepartement,codefill = @EtudiantFilliere WHERE ide = @EtudiantIde";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@EtudiantIde", MySqlDbType.VarChar).Value = ide;
            cmd.Parameters.Add("@EtudiantNom", MySqlDbType.VarChar).Value = std.Nom;
            cmd.Parameters.Add("@EtudiantPrenom", MySqlDbType.VarChar).Value = std.Prenom;
            cmd.Parameters.Add("@EtudiantDepartement", MySqlDbType.VarChar).Value = std.Departement;
            cmd.Parameters.Add("@EtudiantFilliere", MySqlDbType.VarChar).Value = std.Filliere;
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
        public static void DeleteEtudiant(string ide)
        {
            string sql = "DELETE FROM etudiant WHERE ide = @EtudiantIde";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EtudiantIde", MySqlDbType.VarChar).Value = ide;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("suppression avec succees. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static void DeleteEtudiantByDepart(string code)
        {
            string sql = "DELETE FROM etudiant WHERE codedepart = @code";
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
                MessageBox.Show("Pas supprimmer. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteEtudiantByFill(string code)
        {
            string sql = "DELETE FROM etudiant WHERE codefill = @code";
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
                MessageBox.Show("Pas supprimmer. ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
