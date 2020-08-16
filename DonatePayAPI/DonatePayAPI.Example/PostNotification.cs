using System;
using System.Windows.Forms;

namespace DonatePayAPI.Example
{
    public partial class PostNotification : Form
    {
        private DonatePay.API api;
        public DonatePay.Structs.Notification output;
        public PostNotification(DonatePay.API api)
        {
            this.api = api;
            InitializeComponent();
        }

        private void Button_cancel_Click(object sender, EventArgs e) => Close();

        private void Button_ok_Click(object sender, EventArgs e)
        {
            output = api.Notification(textBox_name.Text, textBox_sum.Text, textBox_comment.Text, DateTime.Now, checkBox_notification.Checked);
            Close();
        }

        private void TextBox_sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }
    }
}
