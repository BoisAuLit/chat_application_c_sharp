namespace Chatroom.GUI
{
    partial class AuthentificationForm
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
			this.userNameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.confirmButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// userNameLabel
			// 
			this.userNameLabel.AutoSize = true;
			this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNameLabel.Location = new System.Drawing.Point(36, 81);
			this.userNameLabel.Name = "userNameLabel";
			this.userNameLabel.Size = new System.Drawing.Size(83, 20);
			this.userNameLabel.TabIndex = 0;
			this.userNameLabel.Text = "Username";
			this.userNameLabel.Click += new System.EventHandler(this.label1_Click);
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordLabel.Location = new System.Drawing.Point(41, 120);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(78, 20);
			this.passwordLabel.TabIndex = 1;
			this.passwordLabel.Text = "Password";
			this.passwordLabel.Click += new System.EventHandler(this.passwordLabel_Click);
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNameTextBox.Location = new System.Drawing.Point(158, 75);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(199, 26);
			this.userNameTextBox.TabIndex = 2;
			this.userNameTextBox.Text = "bohao";
			this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextField_TextChanged);
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordTextBox.Location = new System.Drawing.Point(158, 114);
			this.passwordTextBox.MaxLength = 14;
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(199, 26);
			this.passwordTextBox.TabIndex = 3;
			this.passwordTextBox.Text = "123";
			// 
			// confirmButton
			// 
			this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.confirmButton.Location = new System.Drawing.Point(23, 191);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(96, 34);
			this.confirmButton.TabIndex = 4;
			this.confirmButton.Text = "Confirm";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetButton.Location = new System.Drawing.Point(145, 191);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(96, 34);
			this.resetButton.TabIndex = 5;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exitButton.Location = new System.Drawing.Point(261, 191);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(96, 34);
			this.exitButton.TabIndex = 6;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// messageTextBox
			// 
			this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageTextBox.ForeColor = System.Drawing.Color.Blue;
			this.messageTextBox.Location = new System.Drawing.Point(45, 12);
			this.messageTextBox.Multiline = true;
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.Size = new System.Drawing.Size(312, 57);
			this.messageTextBox.TabIndex = 7;
			this.messageTextBox.TextChanged += new System.EventHandler(this.errorTextBox_TextChanged);
			// 
			// AuthentificationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(385, 261);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.userNameTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.userNameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "AuthentificationForm";
			this.Text = "Authentification";
			this.Load += new System.EventHandler(this.AuthentificationForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.TextBox messageTextBox;
	}
}

