namespace Chatroom.GUI
{
	partial class ChoosingTopicForm
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
			this.chooseTopicLabel = new System.Windows.Forms.Label();
			this.topicListBox = new System.Windows.Forms.ListBox();
			this.createTopicButton = new System.Windows.Forms.Button();
			this.createTopicTextBox = new System.Windows.Forms.TextBox();
			this.joinTopicButton = new System.Windows.Forms.Button();
			this.quitButton = new System.Windows.Forms.Button();
			this.logOutButton = new System.Windows.Forms.Button();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// chooseTopicLabel
			// 
			this.chooseTopicLabel.AutoSize = true;
			this.chooseTopicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseTopicLabel.Location = new System.Drawing.Point(90, 42);
			this.chooseTopicLabel.Name = "chooseTopicLabel";
			this.chooseTopicLabel.Size = new System.Drawing.Size(195, 24);
			this.chooseTopicLabel.TabIndex = 0;
			this.chooseTopicLabel.Text = "Please choose a topic";
			this.chooseTopicLabel.Click += new System.EventHandler(this.label1_Click);
			// 
			// topicListBox
			// 
			this.topicListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.topicListBox.FormattingEnabled = true;
			this.topicListBox.ItemHeight = 24;
			this.topicListBox.Location = new System.Drawing.Point(51, 87);
			this.topicListBox.Name = "topicListBox";
			this.topicListBox.Size = new System.Drawing.Size(300, 244);
			this.topicListBox.TabIndex = 1;
			this.topicListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// createTopicButton
			// 
			this.createTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createTopicButton.Location = new System.Drawing.Point(218, 458);
			this.createTopicButton.Name = "createTopicButton";
			this.createTopicButton.Size = new System.Drawing.Size(133, 31);
			this.createTopicButton.TabIndex = 2;
			this.createTopicButton.Text = "Create topic";
			this.createTopicButton.UseVisualStyleBackColor = true;
			this.createTopicButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// createTopicTextBox
			// 
			this.createTopicTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createTopicTextBox.Location = new System.Drawing.Point(42, 458);
			this.createTopicTextBox.Name = "createTopicTextBox";
			this.createTopicTextBox.Size = new System.Drawing.Size(140, 29);
			this.createTopicTextBox.TabIndex = 3;
			this.createTopicTextBox.TextChanged += new System.EventHandler(this.createTopicTextBox_TextChanged);
			// 
			// joinTopicButton
			// 
			this.joinTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.joinTopicButton.Location = new System.Drawing.Point(137, 337);
			this.joinTopicButton.Name = "joinTopicButton";
			this.joinTopicButton.Size = new System.Drawing.Size(133, 31);
			this.joinTopicButton.TabIndex = 4;
			this.joinTopicButton.Text = "Join topic";
			this.joinTopicButton.UseVisualStyleBackColor = true;
			this.joinTopicButton.Click += new System.EventHandler(this.joinTopicButton_Click);
			// 
			// quitButton
			// 
			this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.quitButton.Location = new System.Drawing.Point(218, 511);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(133, 31);
			this.quitButton.TabIndex = 5;
			this.quitButton.Text = "Quit application";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// logOutButton
			// 
			this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logOutButton.Location = new System.Drawing.Point(42, 511);
			this.logOutButton.Name = "logOutButton";
			this.logOutButton.Size = new System.Drawing.Size(140, 31);
			this.logOutButton.TabIndex = 6;
			this.logOutButton.Text = "Log out";
			this.logOutButton.UseVisualStyleBackColor = true;
			// 
			// messageTextBox
			// 
			this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageTextBox.Location = new System.Drawing.Point(51, 383);
			this.messageTextBox.Multiline = true;
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.Size = new System.Drawing.Size(300, 52);
			this.messageTextBox.TabIndex = 7;
			this.messageTextBox.TextChanged += new System.EventHandler(this.messageTextBox_TextChanged);
			// 
			// ChoosingTopicForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 584);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.logOutButton);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.joinTopicButton);
			this.Controls.Add(this.createTopicTextBox);
			this.Controls.Add(this.createTopicButton);
			this.Controls.Add(this.topicListBox);
			this.Controls.Add(this.chooseTopicLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "ChoosingTopicForm";
			this.Text = "ChoosingTopicForm";
			this.Load += new System.EventHandler(this.ChoosingTopicForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label chooseTopicLabel;
		private System.Windows.Forms.ListBox topicListBox;
		private System.Windows.Forms.Button createTopicButton;
		private System.Windows.Forms.TextBox createTopicTextBox;
		private System.Windows.Forms.Button joinTopicButton;
		private System.Windows.Forms.Button quitButton;
		private System.Windows.Forms.Button logOutButton;
		private System.Windows.Forms.TextBox messageTextBox;
	}
}