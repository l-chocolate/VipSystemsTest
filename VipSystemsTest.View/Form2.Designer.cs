namespace VipSystemsTest.View
{
    partial class Form2
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
            pb_userPicture = new PictureBox();
            lb_ClientName = new Label();
            cb_MovType = new ComboBox();
            label1 = new Label();
            lb_AccessDateAndTime = new Label();
            lb_LastEntryDateAndTime = new Label();
            lb_NumberOfAccesses = new Label();
            bt_Confirm = new Button();
            lb_LastExitDateAndTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_userPicture).BeginInit();
            SuspendLayout();
            // 
            // pb_userPicture
            // 
            pb_userPicture.Location = new Point(12, 12);
            pb_userPicture.Name = "pb_userPicture";
            pb_userPicture.Size = new Size(222, 227);
            pb_userPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_userPicture.TabIndex = 0;
            pb_userPicture.TabStop = false;
            // 
            // lb_ClientName
            // 
            lb_ClientName.AutoSize = true;
            lb_ClientName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_ClientName.Location = new Point(439, 23);
            lb_ClientName.Name = "lb_ClientName";
            lb_ClientName.Size = new Size(63, 25);
            lb_ClientName.TabIndex = 1;
            lb_ClientName.Text = "label1";
            // 
            // cb_MovType
            // 
            cb_MovType.FlatStyle = FlatStyle.Flat;
            cb_MovType.FormattingEnabled = true;
            cb_MovType.Items.AddRange(new object[] { "Entrada", "Saída" });
            cb_MovType.Location = new Point(439, 68);
            cb_MovType.Name = "cb_MovType";
            cb_MovType.Size = new Size(201, 23);
            cb_MovType.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(335, 71);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 3;
            label1.Text = "Tipo de registro";
            // 
            // lb_AccessDateAndTime
            // 
            lb_AccessDateAndTime.AutoSize = true;
            lb_AccessDateAndTime.Location = new Point(439, 105);
            lb_AccessDateAndTime.Name = "lb_AccessDateAndTime";
            lb_AccessDateAndTime.Size = new Size(38, 15);
            lb_AccessDateAndTime.TabIndex = 4;
            lb_AccessDateAndTime.Text = "label2";
            // 
            // lb_LastEntryDateAndTime
            // 
            lb_LastEntryDateAndTime.AutoSize = true;
            lb_LastEntryDateAndTime.Location = new Point(439, 140);
            lb_LastEntryDateAndTime.Name = "lb_LastEntryDateAndTime";
            lb_LastEntryDateAndTime.Size = new Size(38, 15);
            lb_LastEntryDateAndTime.TabIndex = 5;
            lb_LastEntryDateAndTime.Text = "label2";
            // 
            // lb_NumberOfAccesses
            // 
            lb_NumberOfAccesses.AutoSize = true;
            lb_NumberOfAccesses.Location = new Point(439, 217);
            lb_NumberOfAccesses.Name = "lb_NumberOfAccesses";
            lb_NumberOfAccesses.Size = new Size(38, 15);
            lb_NumberOfAccesses.TabIndex = 6;
            lb_NumberOfAccesses.Text = "label2";
            // 
            // bt_Confirm
            // 
            bt_Confirm.Location = new Point(735, 184);
            bt_Confirm.Name = "bt_Confirm";
            bt_Confirm.Size = new Size(102, 55);
            bt_Confirm.TabIndex = 7;
            bt_Confirm.Text = "Confirmar";
            bt_Confirm.UseVisualStyleBackColor = true;
            bt_Confirm.Click += bt_Confirm_Click;
            // 
            // lb_LastExitDateAndTime
            // 
            lb_LastExitDateAndTime.AutoSize = true;
            lb_LastExitDateAndTime.Location = new Point(439, 180);
            lb_LastExitDateAndTime.Name = "lb_LastExitDateAndTime";
            lb_LastExitDateAndTime.Size = new Size(38, 15);
            lb_LastExitDateAndTime.TabIndex = 8;
            lb_LastExitDateAndTime.Text = "label2";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 251);
            Controls.Add(lb_LastExitDateAndTime);
            Controls.Add(bt_Confirm);
            Controls.Add(lb_NumberOfAccesses);
            Controls.Add(lb_LastEntryDateAndTime);
            Controls.Add(lb_AccessDateAndTime);
            Controls.Add(label1);
            Controls.Add(cb_MovType);
            Controls.Add(lb_ClientName);
            Controls.Add(pb_userPicture);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pb_userPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_userPicture;
        private Label lb_ClientName;
        private ComboBox cb_MovType;
        private Label label1;
        private Label lb_AccessDateAndTime;
        private Label lb_LastEntryDateAndTime;
        private Label lb_NumberOfAccesses;
        private Button bt_Confirm;
        private Label lb_LastExitDateAndTime;
    }
}