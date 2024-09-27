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
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>(); // Danh sách nhân viên

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = employees;
        }

        private void bntcn(object sender, EventArgs e)
        {

        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee selectedEmployee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem;
                Form2 form2 = new Form2(this, selectedEmployee);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee selectedEmployee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem;
                employees.Remove(selectedEmployee);
                dataGridView1.DataSource = null; // Cập nhật lại nguồn dữ liệu
                dataGridView1.DataSource = employees;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void bntthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddOrUpdateEmployee(Employee employee)
        {
            if (!employees.Contains(employee))
            {
                employees.Add(employee);
            }
            else
            {
                int index = employees.IndexOf(employee);
                employees[index] = employee; // Cập nhật nhân viên
            }

            dataGridView1.DataSource = null; // Cập nhật lại nguồn dữ liệu
            dataGridView1.DataSource = employees;
        }
        
    }
    public class Employee
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCoBan { get; set; }
    }
}
