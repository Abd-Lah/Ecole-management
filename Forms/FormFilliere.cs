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
    public partial class FormFilliere : Form
    {
        public FormFilliere()
        {
            InitializeComponent();
        }


        public void Clear()
        {
            textNom.Text = textCode.Text = comoboxDepart.Text = string.Empty;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (textNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nom de Filliere est vide ");
                return;
            }
            if (textCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Code de Filliere est vide ");
                return;
            }
            if (comoboxDepart.Text.Trim().Length == 0)
            {
                MessageBox.Show("Code de departement est vide ");
                return;
            }

            Filliere std = new Filliere(textCode.Text.Trim(),comoboxDepart.Text.Trim(), textNom.Text.Trim());
            dbEcoleFilliere.AddFilliere(std);
            Clear();
            Display();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez vous supprimer ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbEcoleFilliere.DeleteFilliere(dataGridViewFill.CurrentRow.Cells[0].Value.ToString());
                    Clear();
                    Display();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selectionner une ligne !");
            }
        }

       
        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            dbEcoleEtudiant.DisplayAndSearch("SELECT * FROM filliere WHERE codefill LIKE '%" + textSearch.Text + "%'", dataGridViewFill);
        }

        private void FormFilliere_Load(object sender, EventArgs e)
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
            }
        }
        public void Display()
        {
            dbEcoleFilliere.DisplayAndSearch("SELECT * FROM filliere", dataGridViewFill);
        }

        private void DataGridViewFill_Click(object sender, EventArgs e)
        {
            try
            {
                textNom.Text = dataGridViewFill.CurrentRow.Cells[2].Value.ToString();
                textCode.Text = dataGridViewFill.CurrentRow.Cells[0].Value.ToString();
                comoboxDepart.Text = dataGridViewFill.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
           
        }
    }
}
