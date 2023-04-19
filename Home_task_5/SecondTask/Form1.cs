using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using task_2.Models;
using Task_2.Models;
using Task_2.Models.ServiceModels;
using Task_2.View;
using Task_2.View.ServiceView;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            Store.UpdateStoreList();
            GetStores();
            Models.Basket.LoadBasketData();

            BoxHandler.LoadShopBoxes();
        }

        private void GetStores()
        {
            var data = Store.StoreList;

            dataGridView1.DataSource = data.Select(s => new
            {
                Назва = s.Name,
                Адреса = s.Address,
                Кількість_підрозділів = s.DepartmentList.Count
            }).ToList();
        }

        private void find_parkings_Click(object sender, EventArgs e)
        {
            try
            {
                var storeData = new StoreData();

                StoreDataView storeDataView = new StoreDataView(storeData);
                Hide();
                storeDataView.ShowDialog();
                Show();

                if (string.IsNullOrWhiteSpace(storeData.Name) || string.IsNullOrEmpty(storeData.Address))
                    throw new Exception("Ви не ввели інформацію!");

                Store store = new Store(storeData);
                Store.StoreList.Add(store);

                Store.SaveStores();

                GetStores();
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
                Store.StoreList.RemoveAt(GetSelectedStoreId());
                Store.SaveStores();

                GetStores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Store GetSelectedStore()
        {
            return Store.StoreList[dataGridView1.CurrentCell.RowIndex];
        }
        private int GetSelectedStoreId() => dataGridView1.CurrentCell.RowIndex;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StoreView storeView = new StoreView(GetSelectedStore(), GetSelectedStore().Name);

                Hide();
                storeView.ShowDialog();
                Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                View.Basket basket = new View.Basket();
                basket.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PackedBoxes packedBoxes = new PackedBoxes();
            packedBoxes.ShowDialog();
        }
    }
}