using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using MultipleGameTrainerSource.Forms;



namespace MultipleGameTrainerSource
{
    public partial class Form1 : Form
    {
        ///Fields and Imports
        #region

        private IconButton currentBtn;
        private Panel rightBorderBtn;
        private Form currentChildForm;
        
        //Drag Form
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        ///Main Form
        #region

        //Constructor
        public Form1()
        {
            InitializeComponent();
            rightBorderBtn = new Panel();
            rightBorderBtn.Size = new Size(7,60);
            panelMenu.Controls.Add(rightBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(204, 255, 0);
        }

        #endregion

        ///Methods
        #region

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(210, 103, 0);
                currentBtn.ForeColor = color;
                
                //Right Border Button
                rightBorderBtn.BackColor = color;
                rightBorderBtn.Location = new Point(255,currentBtn.Location.Y);
                rightBorderBtn.Size = new System.Drawing.Size(75, 75);
                rightBorderBtn.Visible = true;
                rightBorderBtn.BringToFront();
                //Icon Current Child Form
                //iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //iconCurrentChildForm.IconColor = color;
            }

        }

        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(138, 69, 10);
                currentBtn.ForeColor = Color.Gainsboro;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            rightBorderBtn.Visible = false;
            //iconCurrentChildForm.IconChar = IconChar.Home;
            //iconCurrentChildForm.IconColor = Color.Black;
            lblTitleChildForm.Text = "Home";

        }

        #endregion

        ///Game  Selection Buttons
        #region

        private void Borderlands1_Button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new BorderlandsGOTYEnhanced());
        }

        private void Borderlands2_Button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new Borderlands2());
        }

        private void BorderlandsPreSequel_Button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new BorderlandsPreSequel());
        }

        private void Borderlands3_Button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new Borderlands3());
        }

        #endregion

        ///Form Controls
        #region

        //Drag Form
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Close App Button
        private void iconPictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.iconPictureBox1.BackColor = Color.Red;
        }

        private void iconPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.iconPictureBox1.BackColor = Color.FromArgb(210, 103, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Minimize
        private void iconPictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.iconPictureBox2.BackColor = Color.Gray;
        }

        private void iconPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.iconPictureBox2.BackColor = Color.FromArgb(210, 103, 0);
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        //Home Button
        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            this.btnHome.BackColor = Color.Gray;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            this.btnHome.BackColor = Color.FromArgb(210, 103, 0);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        #endregion

        #region //Links

        //UPDATE LINK
        private void UpdateCheck_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xCENTx/Borderlands-Series-Trainer-STEAM-");
        }

        //Github Icon Click
        private void iconPictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xCENTx");
        }

        //Dicord Server Icon Click
        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/XzAF9JMPkh");
        }

        //Youtube Icon Click
        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCi1ukdgWPkoM4MbKCg7mowg");
        }

        #endregion

    }
}
