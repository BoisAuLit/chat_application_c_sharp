namespace Chatroom.GUI
{
	partial class ChatroomForm
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
			this.quitButton = new System.Windows.Forms.Button();
			this.postButton = new System.Windows.Forms.Button();
			this.postTextBox = new System.Windows.Forms.TextBox();
			this.chatroomTextBox = new System.Windows.Forms.TextBox();
			this.chooseTopicButton = new System.Windows.Forms.Button();
			this.logOutButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// quitButton
			// 
			this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.quitButton.Location = new System.Drawing.Point(558, 531);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(158, 42);
			this.quitButton.TabIndex = 1;
			this.quitButton.Text = "Quit application";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
			// 
			// postButton
			// 
			this.postButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.postButton.Location = new System.Drawing.Point(558, 458);
			this.postButton.Name = "postButton";
			this.postButton.Size = new System.Drawing.Size(158, 37);
			this.postButton.TabIndex = 2;
			this.postButton.Text = "Post";
			this.postButton.UseVisualStyleBackColor = true;
			this.postButton.Click += new System.EventHandler(this.postButton_Click);
			// 
			// postTextBox
			// 
			this.postTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.postTextBox.Location = new System.Drawing.Point(55, 432);
			this.postTextBox.Multiline = true;
			this.postTextBox.Name = "postTextBox";
			this.postTextBox.Size = new System.Drawing.Size(469, 85);
			this.postTextBox.TabIndex = 3;
			this.postTextBox.TextChanged += new System.EventHandler(this.postTextBox_TextChanged);
			// 
			// chatroomTextBox
			// 
			this.chatroomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chatroomTextBox.Location = new System.Drawing.Point(55, 44);
			this.chatroomTextBox.Multiline = true;
			this.chatroomTextBox.Name = "chatroomTextBox";
			this.chatroomTextBox.Size = new System.Drawing.Size(635, 361);
			this.chatroomTextBox.TabIndex = 0;
			this.chatroomTextBox.TextChanged += new System.EventHandler(this.chatroomTextBox_TextChanged);
			// 
			// chooseTopicButton
			// 
			this.chooseTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseTopicButton.Location = new System.Drawing.Point(264, 531);
			this.chooseTopicButton.Name = "chooseTopicButton";
			this.chooseTopicButton.Size = new System.Drawing.Size(216, 42);
			this.chooseTopicButton.TabIndex = 4;
			this.chooseTopicButton.Text = "Choose another topic";
			this.chooseTopicButton.UseVisualStyleBackColor = true;
			// 
			// logOutButton
			// 
			this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logOutButton.Location = new System.Drawing.Point(55, 531);
			this.logOutButton.Name = "logOutButton";
			this.logOutButton.Size = new System.Drawing.Size(158, 42);
			this.logOutButton.TabIndex = 5;
			this.logOutButton.Text = "Log out";
			this.logOutButton.UseVisualStyleBackColor = true;
			this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
			// 
			// ChatroomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(756, 585);
			this.Controls.Add(this.logOutButton);
			this.Controls.Add(this.chooseTopicButton);
			this.Controls.Add(this.postTextBox);
			this.Controls.Add(this.postButton);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.chatroomTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "ChatroomForm";
			this.Text = "ChatroomForm";
			this.Load += new System.EventHandler(this.ChatroomForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button quitButton;
		private System.Windows.Forms.Button postButton;
		private System.Windows.Forms.TextBox postTextBox;
		private System.Windows.Forms.TextBox chatroomTextBox;
		private System.Windows.Forms.Button chooseTopicButton;
		private System.Windows.Forms.Button logOutButton;
	}
}