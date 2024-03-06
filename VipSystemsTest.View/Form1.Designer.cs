namespace VipSystemsTest.View
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_CPF = new Panel();
            bt_CPF = new Button();
            tb_CPF = new TextBox();
            label1 = new Label();
            panel_senha = new Panel();
            tb_password = new MaskedTextBox();
            bt_password = new Button();
            label2 = new Label();
            panel_secondValidation = new Panel();
            bt_secondLevel = new Button();
            tb_secondLevel = new TextBox();
            lb_secondLevel = new Label();
            panel_CPF.SuspendLayout();
            panel_senha.SuspendLayout();
            panel_secondValidation.SuspendLayout();
            SuspendLayout();
            // 
            // panel_CPF
            // 
            panel_CPF.Controls.Add(bt_CPF);
            panel_CPF.Controls.Add(tb_CPF);
            panel_CPF.Controls.Add(label1);
            panel_CPF.Location = new Point(12, 12);
            panel_CPF.Name = "panel_CPF";
            panel_CPF.Size = new Size(770, 101);
            panel_CPF.TabIndex = 0;
            // 
            // bt_CPF
            // 
            bt_CPF.Location = new Point(315, 62);
            bt_CPF.Name = "bt_CPF";
            bt_CPF.Size = new Size(72, 23);
            bt_CPF.TabIndex = 2;
            bt_CPF.Text = "OK";
            bt_CPF.UseVisualStyleBackColor = true;
            bt_CPF.Click += bt_CPF_Click;
            // 
            // tb_CPF
            // 
            tb_CPF.Location = new Point(208, 33);
            tb_CPF.Name = "tb_CPF";
            tb_CPF.Size = new Size(299, 23);
            tb_CPF.TabIndex = 1;
            tb_CPF.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 15);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Digite o CPF";
            // 
            // panel_senha
            // 
            panel_senha.Controls.Add(tb_password);
            panel_senha.Controls.Add(bt_password);
            panel_senha.Controls.Add(label2);
            panel_senha.Location = new Point(12, 119);
            panel_senha.Name = "panel_senha";
            panel_senha.Size = new Size(770, 98);
            panel_senha.TabIndex = 1;
            panel_senha.Visible = false;
            // 
            // tb_password
            // 
            tb_password.Location = new Point(208, 33);
            tb_password.Name = "tb_password";
            tb_password.Size = new Size(299, 23);
            tb_password.TabIndex = 4;
            tb_password.TextAlign = HorizontalAlignment.Center;
            tb_password.UseSystemPasswordChar = true;
            // 
            // bt_password
            // 
            bt_password.Location = new Point(315, 62);
            bt_password.Name = "bt_password";
            bt_password.Size = new Size(72, 23);
            bt_password.TabIndex = 3;
            bt_password.Text = "OK";
            bt_password.UseVisualStyleBackColor = true;
            bt_password.Click += bt_password_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 15);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 0;
            label2.Text = "Digite a senha";
            // 
            // panel_secondValidation
            // 
            panel_secondValidation.Controls.Add(bt_secondLevel);
            panel_secondValidation.Controls.Add(tb_secondLevel);
            panel_secondValidation.Controls.Add(lb_secondLevel);
            panel_secondValidation.Location = new Point(12, 223);
            panel_secondValidation.Name = "panel_secondValidation";
            panel_secondValidation.Size = new Size(770, 96);
            panel_secondValidation.TabIndex = 2;
            panel_secondValidation.Visible = false;
            // 
            // bt_secondLevel
            // 
            bt_secondLevel.Location = new Point(315, 62);
            bt_secondLevel.Name = "bt_secondLevel";
            bt_secondLevel.Size = new Size(72, 23);
            bt_secondLevel.TabIndex = 4;
            bt_secondLevel.Text = "OK";
            bt_secondLevel.UseVisualStyleBackColor = true;
            bt_secondLevel.Click += bt_secondLevel_Click;
            // 
            // tb_secondLevel
            // 
            tb_secondLevel.Location = new Point(208, 33);
            tb_secondLevel.Name = "tb_secondLevel";
            tb_secondLevel.Size = new Size(299, 23);
            tb_secondLevel.TabIndex = 1;
            tb_secondLevel.TextAlign = HorizontalAlignment.Center;
            // 
            // lb_secondLevel
            // 
            lb_secondLevel.AutoSize = true;
            lb_secondLevel.Location = new Point(208, 15);
            lb_secondLevel.Name = "lb_secondLevel";
            lb_secondLevel.Size = new Size(40, 15);
            lb_secondLevel.TabIndex = 0;
            lb_secondLevel.Text = "TEXTO";
            lb_secondLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 330);
            Controls.Add(panel_secondValidation);
            Controls.Add(panel_senha);
            Controls.Add(panel_CPF);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel_CPF.ResumeLayout(false);
            panel_CPF.PerformLayout();
            panel_senha.ResumeLayout(false);
            panel_senha.PerformLayout();
            panel_secondValidation.ResumeLayout(false);
            panel_secondValidation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_CPF;
        private TextBox tb_CPF;
        private Label label1;
        private Panel panel_senha;
        private Label label2;
        private Panel panel_secondValidation;
        private TextBox tb_secondLevel;
        private Label lb_secondLevel;
        private Button bt_CPF;
        private Button bt_password;
        private Button bt_secondLevel;
        private MaskedTextBox tb_password;
    }
}
