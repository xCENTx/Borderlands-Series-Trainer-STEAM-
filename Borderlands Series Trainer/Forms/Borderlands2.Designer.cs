
namespace MultipleGameTrainerSource.Forms
{
    partial class Borderlands2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoneyTextBox = new System.Windows.Forms.TextBox();
            this.MoneyButton = new System.Windows.Forms.Button();
            this.lbl_Money = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FreezeMoney_checkBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MoneyTextBox
            // 
            this.MoneyTextBox.Location = new System.Drawing.Point(44, 42);
            this.MoneyTextBox.Name = "MoneyTextBox";
            this.MoneyTextBox.Size = new System.Drawing.Size(86, 20);
            this.MoneyTextBox.TabIndex = 5;
            // 
            // MoneyButton
            // 
            this.MoneyButton.Location = new System.Drawing.Point(141, 40);
            this.MoneyButton.Name = "MoneyButton";
            this.MoneyButton.Size = new System.Drawing.Size(56, 23);
            this.MoneyButton.TabIndex = 4;
            this.MoneyButton.Text = "SEND";
            this.MoneyButton.UseVisualStyleBackColor = true;
            this.MoneyButton.Click += new System.EventHandler(this.MoneyButton_Click);
            // 
            // lbl_Money
            // 
            this.lbl_Money.AutoSize = true;
            this.lbl_Money.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Money.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Money.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.lbl_Money.Location = new System.Drawing.Point(12, 9);
            this.lbl_Money.Name = "lbl_Money";
            this.lbl_Money.Size = new System.Drawing.Size(85, 24);
            this.lbl_Money.TabIndex = 6;
            this.lbl_Money.Text = "Money: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.FreezeMoney_checkBox);
            this.panel1.Location = new System.Drawing.Point(30, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 64);
            this.panel1.TabIndex = 7;
            // 
            // FreezeMoney_checkBox
            // 
            this.FreezeMoney_checkBox.AutoSize = true;
            this.FreezeMoney_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreezeMoney_checkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.FreezeMoney_checkBox.Location = new System.Drawing.Point(85, 6);
            this.FreezeMoney_checkBox.Name = "FreezeMoney_checkBox";
            this.FreezeMoney_checkBox.Size = new System.Drawing.Size(94, 17);
            this.FreezeMoney_checkBox.TabIndex = 0;
            this.FreezeMoney_checkBox.Text = "UNLIMITED";
            this.FreezeMoney_checkBox.UseVisualStyleBackColor = true;
            this.FreezeMoney_checkBox.CheckedChanged += new System.EventHandler(this.FreezeMoney_checkBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Eridium: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Location = new System.Drawing.Point(30, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 64);
            this.panel2.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.checkBox1.Location = new System.Drawing.Point(85, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "UNLIMITED";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Borderlands2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(477, 237);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MoneyTextBox);
            this.Controls.Add(this.MoneyButton);
            this.Controls.Add(this.lbl_Money);
            this.Controls.Add(this.panel1);
            this.Name = "Borderlands2";
            this.Text = "Borderlands2";
            this.Load += new System.EventHandler(this.Borderlands2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.Button MoneyButton;
        private System.Windows.Forms.Label lbl_Money;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox FreezeMoney_checkBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}