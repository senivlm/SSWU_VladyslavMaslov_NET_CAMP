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
using Task_2.Models;
using static System.Windows.Forms.AxHost;

namespace Task_2.View
{
    public partial class DepartmentView : Form
    {
        Department department;
        string path;
        public DepartmentView(Department department, string path)
        {
            InitializeComponent();
            this.department = department;
            this.path = $"{path}/{department.DepartmentName}";

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;


            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.ForeColor = Color.Black;

            Text = department.DepartmentName;

            LoadDepartmentData();
            LoadProductData();
        }
        private void LoadDepartmentData()
        {
            var source = department.DepartmentList;

            dataGridView1.DataSource = source.Select(s => new
            {
                Назва_відділу = s.DepartmentName,
                Кількість_товарів = $"{s.DepartmentList.Count}",
                Кількість_підрозділів = $"{s.Products.Count}"
            }).ToList();
        }
        private void LoadProductData()
        {
            var source = department.Products;

            dataGridView2.DataSource = source.Select(s => new
            {
                Назва = s.Name,
                Розмір = s.Size.ToString()
            }).ToList();
        }
        private void find_parkings_Click(object sender, EventArgs e)
        {
            try
            {
                string DepName = Interaction.InputBox("Введіть назву розділу:");
                Department monoDepartment = new Department(DepName);

                department.DepartmentList.Add(monoDepartment);

                Store.SaveStores();
                LoadDepartmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Department department1 = department.DepartmentList[dataGridView1.CurrentCell.RowIndex];

                DepartmentView departmentView = new DepartmentView(department1, path);

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                department.DepartmentList.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                Store.SaveStores();
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
                Product product = new Product(Interaction.InputBox("Введіть назву товару"), new task_2.Models.Size(
                    float.Parse(Interaction.InputBox("Введіть x:")),
                    float.Parse(Interaction.InputBox("Введіть y:")),
                    float.Parse(Interaction.InputBox("Введіть z:"))
                    ));

                department.Products.Add(product);

                Store.SaveStores();

                LoadProductData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Basket.ProductList.Add(new BasketItem
                {
                    ShopName = path.Split('/')[0],
                    FullPath = path,
                    Product = department.Products[dataGridView2.CurrentCell.RowIndex]
                });

                Models.Basket.SaveBasketData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                department.Products.RemoveAt(dataGridView2.CurrentCell.RowIndex);
                Store.SaveStores();

                LoadProductData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}