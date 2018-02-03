namespace Chatroom.GUI
{
	partial class ConfigurationForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ipTextBox = new System.Windows.Forms.TextBox();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.confirmButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// userNameLabel
			// 
			this.userNameLabel.AutoSize = true;
			this.userNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNameLabel.Location = new System.Drawing.Point(92, 43);
			this.userNameLabel.Name = "userNameLabel";
			this.userNameLabel.Size = new System.Drawing.Size(265, 22);
			this.userNameLabel.TabIndex = 1;
			this.userNameLabel.Text = "Authentification server configuration";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(30, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Authentification server Ip address";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(77, 138);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(201, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "Authentification server port";
			// 
			// ipTextBox
			// 
			this.ipTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ipTextBox.Location = new System.Drawing.Point(298, 97);
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.Size = new System.Drawing.Size(112, 26);
			this.ipTextBox.TabIndex = 4;
			this.ipTextBox.Text = "127.0.0.1";
			// 
			// portTextBox
			// 
			this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portTextBox.Location = new System.Drawing.Point(298, 138);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(112, 26);
			this.portTextBox.TabIndex = 5;
			this.portTextBox.Text = "11000";
			// 
			// confirmButton
			// 
			this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.confirmButton.Location = new System.Drawing.Point(43, 187);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(96, 34);
			this.confirmButton.TabIndex = 6;
			this.confirmButton.Text = "Confirm";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetButton.Location = new System.Drawing.Point(180, 187);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(96, 34);
			this.resetButton.TabIndex = 7;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exitButton.Location = new System.Drawing.Point(314, 187);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(96, 34);
			this.exitButton.TabIndex = 8;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// ConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 248);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.portTextBox);
			this.Controls.Add(this.ipTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.userNameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "ConfigurationForm";
			this.Text = "ConfigurationForm";
			this.Load += new System.EventHandler(this.ConfigurationForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label userNameLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ipTextBox;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Button confirmButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Button exitButton;
	}
}