using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonatePayAPI.Example
{
    public partial class PostNotification : Form
    {
        private DonatePay.API api;
        public DonatePay.Structs.Notification output;
        public PostNotification(DonatePay.API API)
        {
            api = API;
            InitializeComponent();
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            output = api.Notification(textBox_name.Text, textBox_sum.Text, textBox_comment.Text, DateTime.Now, checkBox_notification.Checked);
            this.Close();
        }

        private void TextBox_sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
