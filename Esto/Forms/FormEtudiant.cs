using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esto.Forms
{
    public partial class FormEtudiant : Form
    {
        List<Filliere> filliere = new List<Filliere>();
        List<Departement> departement = new List<Departement>();
        public FormEtudiant()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textNom.Text = textPrenom.Text = comoboxDepart.Text = comboxFill.Text = string.Empty;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (textNom.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nom est vide ");
                return;
            }
            if (textPrenom.Text.Trim().Length < 3)
            {
                MessageBox.Show("Prenom est vide ");
                return;
            }
            if (comoboxDepart.Text.Trim().Length == 0)
            {
                MessageBox.Show("departement est vide ");
                return;
            }
            if (comboxFill.Text.Trim().Length == 0)
            {
                MessageBox.Show("filliere est vide ");
                return;
            }

            Etudiant std = new Etudiant(textNom.Text.Trim(), textPrenom.Text.Trim(), comoboxDepart.Text.Trim(), comboxFill.Text.Trim());
            dbEcoleEtudiant.AddEtudiant(std);
            Clear();
            Display();
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            dbEcoleEtudiant.DisplayAndSearch("SELECT * FROM etudiant WHERE nom LIKE '%" + textSearch.Text + "%'", dataGridViewEtud);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try{
                if (MessageBox.Show("Voulez vous supprimer ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbEcoleEtudiant.DeleteEtudiant(dataGridViewEtud.CurrentRow.Cells[0].Value.ToString());
                    Clear();
                    Display();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Selectionner une ligne !");
            }
            
        }

        private void BdtUpdate_Click(object sender, EventArgs e)
        {
            if (textNom.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nom est vide ");
                return;
            }
            if (textPrenom.Text.Trim().Length < 3)
            {
                MessageBox.Show("Prenom est vide ");
                return;
            }
            if (comoboxDepart.Text.Trim().Length == 0)
            {
                MessageBox.Show("departement est vide ");
                return;
            }
            if (comboxFill.Text.Trim().Length == 0)
            {
                MessageBox.Show("filliere est vide ");
                return;
            }
            try {
                if (MessageBox.Show("Voulez vous modifier ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Etudiant std = new Etudiant(textNom.Text.Trim(), textPrenom.Text.Trim(), comoboxDepart.Text.Trim(), comboxFill.Text.Trim());
                    dbEcoleEtudiant.UpdateEtudiant(std, dataGridViewEtud.CurrentRow.Cells[0].Value.ToString());
                    Clear();
                    Display();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selectionner une ligne !");
            }
        }

        private void FormEtudiant_Load(object sender, EventArgs e)
        {
            Display();
            string sql = "datasource=localhost;port=3306;username=root;password=;database=ecole";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from departement", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comoboxDepart.Items.Add(dr["codedepart"]);
                departement.Add(new Departement()
                {
                    Nomdepart = (string)dr["nomdepart"],
                    Codedepart = (string)dr["codedepart"]  
                });
            }
            con.Close();
            con.Open();
            MySqlCommand cmdf = new MySqlCommand("select * from filliere", con);
            MySqlDataReader drf = cmdf.ExecuteReader();
            while (drf.Read())
            {
                filliere.Add(new Filliere()
                {
                    Codedepart = (string)drf["codedepart"],
                    Codefill = (string)drf["codefill"],
                    Nomfill = (string)drf["nomfill"]
                });
            }
            con.Close();
        }
        private string[] GetFilliereBycodedepart(string cdepart)
        {
            return filliere.Where(line =>line.Codedepart == cdepart).Select(l => l.Codefill).ToArray();
        }

        private void ComoboxDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxFill.Items.Clear();
            string cdepart = departement[comoboxDepart.SelectedIndex].Codedepart;
            string[] fill = GetFilliereBycodedepart(cdepart);
            foreach (string f in fill)
            {
                comboxFill.Items.Add(f);
            }
        }
        public void Display()
        {
            dbEcoleEtudiant.DisplayAndSearch("SELECT * FROM etudiant", dataGridViewEtud);
        }

        private void DataGridViewEtud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewEtud_Click(object sender, EventArgs e)
        {
            try {
                textNom.Text = dataGridViewEtud.CurrentRow.Cells[1].Value.ToString();
                textPrenom.Text = dataGridViewEtud.CurrentRow.Cells[2].Value.ToString();
                comoboxDepart.Text = dataGridViewEtud.CurrentRow.Cells[3].Value.ToString();
                comboxFill.Text = dataGridViewEtud.CurrentRow.Cells[4].Value.ToString();
            }catch(Exception){
                return;
            }
            
        }
    }
}
