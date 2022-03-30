using System;
using System.Windows.Forms;

namespace Esto.Forms
{
    public partial class FormDepartement : Form
    {
        public FormDepartement()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textNom.Text = textCode.Text = string.Empty;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (textNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nom de departement est vide ");
                return;
            }
            if (textCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Code de departement est vide ");
                return;
            }

            Departement std = new Departement(textCode.Text.Trim(), textNom.Text.Trim());
            dbEcoleDepartement.AddDepartement(std);
            Clear();
            Display();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez vous supprimer ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbEcoleDepartement.DeleteDepartement(dataGridViewDepart.CurrentRow.Cells[0].Value.ToString());
                    Clear();
                    Display();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selectionner une ligne !");
            }
        }


        private void FormDepartement_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            dbEcoleDepartement.DisplayAndSearch("SELECT * FROM departement", dataGridViewDepart);
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            dbEcoleEtudiant.DisplayAndSearch("SELECT * FROM departement WHERE codedepart LIKE '%" + textSearch.Text + "%'", dataGridViewDepart);
        }

        private void DataGridViewDepart_Click(object sender, EventArgs e)
        {
            try
            {
                textCode.Text = dataGridViewDepart.CurrentRow.Cells[0].Value.ToString();
                textNom.Text = dataGridViewDepart.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
