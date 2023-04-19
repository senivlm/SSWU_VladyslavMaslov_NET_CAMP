using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_2.Models;

namespace Task_2.View
{
    public partial class PackedBoxes : Form
    {
        public PackedBoxes()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            GetBoxes();
        }
        private void GetBoxes()
        {
            dataGridView1.DataSource = BoxHandler.ShopBoxes.Select(s => new
            {
                Магазин= s.Name,
                Кількість_товарів = s.DepartmentBoxes.Select(ss=>ss.Boxs.Count).Sum(),
                Розмір = s.Size.ToString()
            }).ToList();
        }
    }
}