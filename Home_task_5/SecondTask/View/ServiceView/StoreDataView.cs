using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_2.Models.ServiceModels;

namespace Task_2.View.ServiceView
{
    public partial class StoreDataView : Form
    {
        StoreData storeData;
        public StoreDataView(StoreData storeData)
        {
            InitializeComponent();
            this.storeData = storeData;

            textBox1.Text = storeData.Name;
            textBox2.Text = storeData.Address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    throw new Exception("Ви пропустили якесь поле!!!");

                this.storeData.Name = textBox1.Text;
                this.storeData.Address = textBox2.Text;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}