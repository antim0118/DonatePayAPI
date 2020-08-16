namespace DonatePayAPI.Example
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_apikey = new System.Windows.Forms.TextBox();
            this.button_user = new System.Windows.Forms.Button();
            this.button_transactions = new System.Windows.Forms.Button();
            this.button_notification = new System.Windows.Forms.Button();
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key:";
            this.textBox_apikey.Location = new System.Drawing.Point(66, 12);
            this.textBox_apikey.Name = "textBox_apikey";
            this.textBox_apikey.Size = new System.Drawing.Size(229, 20);
            this.textBox_apikey.TabIndex = 1;
            this.button_user.Location = new System.Drawing.Point(12, 38);
            this.button_user.Name = "button_user";
            this.button_user.Size = new System.Drawing.Size(65, 23);
            this.button_user.TabIndex = 2;
            this.button_user.Text = "(get) /user";
            this.button_user.UseVisualStyleBackColor = true;
            this.button_user.Click += new System.EventHandler(this.Button_user_Click);
            this.button_transactions.Location = new System.Drawing.Point(83, 38);
            this.button_transactions.Name = "button_transactions";
            this.button_transactions.Size = new System.Drawing.Size(102, 23);
            this.button_transactions.TabIndex = 3;
            this.button_transactions.Text = "(get) /transactions";
            this.button_transactions.UseVisualStyleBackColor = true;
            this.button_transactions.Click += new System.EventHandler(this.Button_transactions_Click);
            this.button_notification.Location = new System.Drawing.Point(191, 38);
            this.button_notification.Name = "button_notification";
            this.button_notification.Size = new System.Drawing.Size(104, 23);
            this.button_notification.TabIndex = 4;
            this.button_notification.Text = "(post) /notification";
            this.button_notification.UseVisualStyleBackColor = true;
            this.button_notification.Click += new System.EventHandler(this.Button_notification_Click);
            this.richTextBox_output.Location = new System.Drawing.Point(12, 67);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.Size = new System.Drawing.Size(283, 149);
            this.richTextBox_output.TabIndex = 5;
            this.richTextBox_output.Text = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 228);
            this.Controls.Add(this.richTextBox_output);
            this.Controls.Add(this.button_notification);
            this.Controls.Add(this.button_transactions);
            this.Controls.Add(this.button_user);
            this.Controls.Add(this.textBox_apikey);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(323, 267);
            this.Name = "Form1";
            this.Text = "DonatePayApi Example";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_apikey;
        private System.Windows.Forms.Button button_user;
        private System.Windows.Forms.Button button_transactions;
        private System.Windows.Forms.Button button_notification;
        private System.Windows.Forms.RichTextBox richTextBox_output;
    }
}

