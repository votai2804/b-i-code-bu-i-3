using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitapvenha
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private Employee employee;
        public Form2(Form1 form1, Employee employee = null)
        {
            InitializeComponent();
            this.form1 = form1;
            this.employee = employee;

            if (employee != null)
            {
                txtmsnv.Text = employee.MSNV;
                txtten.Text = employee.TenNV;
                txtluong.Text = employee.LuongCoBan.ToString();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            if (employee == null)
            {
                // Thêm nhân viên mới
                employee = new Employee
                {
                    MSNV = txtmsnv.Text,
                    TenNV = txtten.Text,
                    LuongCoBan = decimal.TryParse(txtluong.Text, out decimal salary) ? salary : 0
                };
                form1.AddOrUpdateEmployee(employee);
            }
            else
            {
                // Sửa nhân viên
                employee.MSNV = txtmsnv.Text;
                employee.TenNV = txtten.Text;
                employee.LuongCoBan = decimal.TryParse(txtluong.Text, out decimal salary) ? salary : 0;
                form1.AddOrUpdateEmployee(employee);
            }

            this.Close();
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
