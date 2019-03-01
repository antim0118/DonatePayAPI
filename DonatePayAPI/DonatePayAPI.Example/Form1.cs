using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonatePayAPI.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            richTextBox_output.Size = new Size(Width - 40, Height - 118);
        }

        private static DonatePay.API api;
        private void InitApi()
        {
            if (api == null || api.APIKey != textBox_apikey.Text)
                api = new DonatePay.API(textBox_apikey.Text);
        }

        private void Button_user_Click(object sender, EventArgs e)
        {
            InitApi();

            var user = api.User;
            richTextBox_output.Clear();
            richTextBox_output.AppendText("\t==User==\n\n");
            richTextBox_output.AppendText("Status=" + user.Status + "\n");
            if (user.Status == DonatePay.Enums.Status.Success)
            {
                richTextBox_output.AppendText("data{\n");
                richTextBox_output.AppendText(" avatar=" + user.data.avatar + "\n");
                richTextBox_output.AppendText(" balance=" + user.data.balance + "\n");
                richTextBox_output.AppendText(" cashout_sum=" + user.data.cashout_sum + "\n");
                richTextBox_output.AppendText(" id=" + user.data.id + "\n");
                richTextBox_output.AppendText(" name=" + user.data.name + "\n");
                richTextBox_output.AppendText("}\n");
            }
            if(user.Status == DonatePay.Enums.Status.Error && user.message != null)
                richTextBox_output.AppendText("message=" + user.message + "\n");
        }

        private void Button_transactions_Click(object sender, EventArgs e)
        {
            InitApi();

            var transactions = api.Transactions();
            richTextBox_output.Clear();
            richTextBox_output.AppendText("\t==Transactions==\n\n");
            richTextBox_output.AppendText("Status=" + transactions.Status + "\n");
            if (transactions.Status == DonatePay.Enums.Status.Success)
            {
                richTextBox_output.AppendText("sum=" + transactions.sum + "\n");
                richTextBox_output.AppendText("count=" + transactions.count + "\n");

                for (int i = 0; i < transactions.data.Length; i++)
                {
                    var data = transactions.data[i];
                    richTextBox_output.AppendText("\ndata #"+i+" {\n");
                    richTextBox_output.AppendText(" id=" + data.id + "\n");
                    richTextBox_output.AppendText(" what=" + data.what + "\n");
                    richTextBox_output.AppendText(" sum=" + data.sum + "\n");
                    richTextBox_output.AppendText(" commission=" + data.commission + "\n");
                    richTextBox_output.AppendText(" status=" + data.status + "\n");
                    richTextBox_output.AppendText(" Type=" + data.Type + "\n");
                    richTextBox_output.AppendText(" comment=" + data.comment + "\n");

                    richTextBox_output.AppendText("  created_at{\n");
                    richTextBox_output.AppendText("  date=" + data.created_at.date + "\n");
                    richTextBox_output.AppendText("  timezone=" + data.created_at.timezone + "\n");
                    richTextBox_output.AppendText("  timezone_type=" + data.created_at.timezone_type + "\n");
                    richTextBox_output.AppendText(" }\n");

                    richTextBox_output.AppendText("}\n");
                }
            }
            if (transactions.Status == DonatePay.Enums.Status.Error && transactions.message != null)
                richTextBox_output.AppendText("message=" + transactions.message + "\n");
        }

        private void Button_notification_Click(object sender, EventArgs e)
        {
            InitApi();

            PostNotification notification = new PostNotification(api);
            notification.ShowDialog();
            if(notification.output != null)
            {
                richTextBox_output.Clear();
                richTextBox_output.AppendText("\t==Notification==\n\n");
                richTextBox_output.AppendText("Status=" + notification.output.Status + "\n");
                richTextBox_output.AppendText("message=" + notification.output.message + "\n");
            }
        }
    }
}
