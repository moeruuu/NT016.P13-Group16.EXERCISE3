using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace exer3
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            addcb();
        }

        private void cbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void addcb()
        {
            cbday.Items.Clear();

            for (int i = 1; i < 32; i++)
            {

                cbday.Items.Add(i);
            }
            for (int i = 1; i < 13; i++)
            {
                cbmonth.Items.Add(i);
            }
            for (int i = 1900; i <= 2024; i++)
            {
                cbyear.Items.Add(i);
            }
            cbday.SelectedIndex = 0;
            cbmonth.SelectedIndex = 0;
            cbyear.SelectedIndex = 124;
        }

        private void cbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmonth.SelectedIndex == 3 || cbmonth.SelectedIndex == 5 || cbmonth.SelectedIndex == 8 || cbmonth.SelectedIndex == 10)
            {
                if (cbday.SelectedIndex == 30)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }

            }
            if (cbmonth.SelectedIndex == 1)
            {
                if (cbday.SelectedIndex >= 29)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
        }

        private void cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            long year = Convert.ToInt64(cbyear.SelectedIndex);
            if (year % 4 != 0)
            {
                if (cbday.SelectedIndex >= 28 && cbmonth.SelectedIndex == 1)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
            else
            {
                if (cbday.SelectedIndex >= 29 && cbmonth.SelectedIndex == 1)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {

        }
    }
}
