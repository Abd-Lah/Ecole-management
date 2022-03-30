using System;
using System.Windows.Forms;

namespace Esto.Forms
{
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textNom.Text = textPass.Text = string.Empty;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (textNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nom d utilisateur est vide ");
                return;
            }
            if (textPass.Text.Trim().Length < 8)
            {
                MessageBox.Show("Le mot de passe doit etre superieure ou egal 8 caractere ");
                return;
            }
            if (comboBoxAcces.Text.Trim().Length == 0)
            {
                MessageBox.Show("Selectionner le mode d acces ! ");
                return;
            }

            Utilisateurs std = new Utilisateurs(textNom.Text.Trim(), textPass.Text,comboBoxAcces.Text.Trim());
            dbUsers.AddUser(std);
            Clear();
            Display();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dbUsers.DeleteUser(dataGridViewUser.CurrentRow.Cells[0].Value.ToString());
                Clear();
                Display();    
            }
            catch (Exception)
            {
                MessageBox.Show("Selectionner une ligne !");
            }
        }

        private void BdtUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.CurrentRow.Cells[0].Value.ToString() == "1")
            {
                if (textPass.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Le mot de passe doit etre superieure ou egal 8 caractere");
                    return;
                }
                try
                {
                    if (MessageBox.Show("Voulez vous modifier ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string std = textPass.Text;
                        dbUsers.UpdateRoot(std, dataGridViewUser.CurrentRow.Cells[0].Value.ToString());
                        Clear();
                        Display();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Selectionner une ligne !");
                }
            }
            else
            {
                if (textNom.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Nom d utilisateur est vide ");
                    return;
                }
                if (textPass.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Le mot de passe doit etre superieure ou egal 8 caractere");
                    return;
                }
                if (comboBoxAcces.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Selectionner le mode d acces ! ");
                    return;
                }
                try
                {
                    if (MessageBox.Show("Voulez vous modifier ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Utilisateurs std = new Utilisateurs(textNom.Text.Trim(), textPass.Text, comboBoxAcces.Text);
                        dbUsers.UpdateUser(std, dataGridViewUser.CurrentRow.Cells[0].Value.ToString());
                        Clear();
                        Display();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Selectionner une ligne !");
                }
            }
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            dbUsers.DisplayAndSearch("SELECT * FROM users WHERE username LIKE '%" + textSearch.Text + "%'", dataGridViewUser);
        }
        public void Display()
        {
            dbUsers.DisplayAndSearch("SELECT * FROM users", dataGridViewUser);
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            Display();
            comboBoxAcces.Items.Add("SUPPER");
            comboBoxAcces.Items.Add("NORMAL");
        }
        private void DataGridViewUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.CurrentRow.Cells[0].Value.ToString() == "1")
            {
                label1.Hide();
                textNom.Hide();
                label3.Hide();
                comboBoxAcces.Hide();
                btnDelete.Hide();
                btnAdd.Hide();
            }
            else
            {
                label1.Show();
                textNom.Show();
                label3.Show();
                comboBoxAcces.Show();
                btnDelete.Show();
                btnAdd.Show();
            }
            try
            {
                textNom.Text = dataGridViewUser.CurrentRow.Cells[1].Value.ToString();
                textPass.Text = dataGridViewUser.CurrentRow.Cells[2].Value.ToString();
                comboBoxAcces.Text = dataGridViewUser.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
