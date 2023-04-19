using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_2.Models;

namespace Task_2.View
{
    public partial class StoreView : Form
    {
        Store store;
        string path;
        public StoreView(Store store, string path)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            shopNameLbl.Text = store.Name;

            this.store = store;
            this.path = path;

            LoadDepartmentData();
        }

        private void LoadDepartmentData()
        {
            var source = store.DepartmentList;

            dataGridView1.DataSource = source.Select(s => new
            {
                Назва_відділу = s.DepartmentName,
                Кількість_товарів = $"{s.DepartmentList.Count}",
                Кількість_підрозділів = $"{s.Products.Count}"
            }).ToList();
        }

        private void find_parkings_Click(object sender, EventArgs e)
        {
            try
            {
                string DepName = Interaction.InputBox("Введіть назву розділу:");
                Department monoDepartment = new Department(DepName);

                store.DepartmentList.Add(monoDepartment);

                Store.SaveStores();
                LoadDepartmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Department department = store.DepartmentList[dataGridView1.CurrentCell.RowIndex];

                DepartmentView departmentView = new DepartmentView(department, path);

                Hide();
                departmentView.ShowDialog();
                Show();
                LoadDepartmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                store.DepartmentList.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                Store.SaveStores();
                LoadDepartmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}