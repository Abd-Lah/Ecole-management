using System;
using System.Drawing;
using System.Windows.Forms;

namespace Esto
{
    public partial class Gestion : Form
    {
        private string mode;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Gestion(string mode)
        {
            this.mode = mode;
            InitializeComponent();
            random = new Random();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTiltleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }
        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51,51,76);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void Btndepart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDepartement(), sender);
        }

        private void Btnetude_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormEtudiant(), sender);
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormFilliere(), sender);
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormUsers(), sender);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
            Login L = new Login();
            L.Show();
        }
        private void Gestion_Load(object sender, EventArgs e)
        {
            if(mode != "ROOT" && mode != "SUPPER")
            {
                btndepart.Hide();
                btnFill.Hide(); 
                btnUsers.Hide();
            }else if(mode == "SUPPER")
            {
                btnUsers.Hide();
            }
        }

        private void Gestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

       
    }
}
