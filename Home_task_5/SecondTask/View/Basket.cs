using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Task_2.View
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            LoadBasketData();
        }
        private void LoadBasketData()
        {
            var source = Models.Basket.ProductList;

            dataGridView1.DataSource = source.Select(s => new
            {
                Назва_товару = s.Product.Name,
                Розмір = s.Product.Size.ToString(),
                Із_якого_магазину = s.FullPath
            }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Basket.ProductList.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                Models.Basket.SaveBasketData();

                LoadBasketData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void find_parkings_Click(object sender, EventArgs e)
        {
            Models.BoxHandler.PackBoxes();

            LoadBasketData();
        }
    }
}