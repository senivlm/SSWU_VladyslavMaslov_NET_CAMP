using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using task_2.Models;

namespace Task_2.Models
{
    public class Box
    {
        public string Name { get; set; }
        public task_2.Models.Size Size { get; set; }
        public Product InnerProduct { get; set; }
        public Box(string name, task_2.Models.Size size)
        {
            Name = name;
            Size = size;
        }
    }

    public class DepartmentBox
    {
        public string Name { get; set; }
        public List<Box> Boxs { get; set; }
        public Size Size { get; set; }
        public DepartmentBox (string name)
        {
            Name = name;
            Boxs = new List<Box>();
        }
    }
    public class ShopBox
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public List<DepartmentBox> DepartmentBoxes { get; set; }
        public ShopBox(string name)
        {
            Name = name;
            DepartmentBoxes = new List<DepartmentBox>();
        }
    }


    public static class BoxHandler
    {
        public const string BOXES_DATA = "boxes.json";
        public static List<ShopBox> ShopBoxes = new List<ShopBox>();

        private static Size CalculateOptimalBoxSize(List<Box> boxes)
        {
            float maxX = 0;
            float maxY = 0;
            float maxZ = 0;

            foreach (var box in boxes)
            {
                if (box.Size.x > maxX)
                {
                    maxX = box.Size.x;
                }

                if (box.Size.y > maxY)
                {
                    maxY = box.Size.y;
                }

                if (box.Size.z > maxZ)
                {
                    maxZ = box.Size.z;
                }
            }
            return new Size(maxX, maxY, maxZ);
        }
                    public static void PackBoxes()
        {

            var source = Models.Basket.ProductList;

            List<List<BasketItem>> groupedByShopBasketItems = source
                .GroupBy(item => item.ShopName)
                .Select(group => group.ToList())
                .ToList();

            foreach (var shopBasketItems in groupedByShopBasketItems)
            {
                ShopBox box = new ShopBox(shopBasketItems.First().ShopName);

                List<List<BasketItem>> groupedByFullPath = shopBasketItems
                    .GroupBy(item => item.FullPath)
                    .Select(group => group.ToList())
                    .ToList();

                foreach (var GroupItem in groupedByFullPath)
                {
                    var groupBox = new DepartmentBox(GroupItem.First().FullPath);
                    foreach (var Item in GroupItem)
                    {
                        groupBox.Boxs.Add(new Box(Item.Product.Name, Item.Product.Size) { InnerProduct = Item.Product });
                    }
                    groupBox.Size = CalculateOptimalBoxSize(groupBox.Boxs);//треба знайти оптимальний розмір коробки, щоби туди вмістились всі коробки, що всередині(написати алгоритм)

                    box.DepartmentBoxes.Add(groupBox);
                }

                box.Size = CalculateOptimalBoxSize(box.DepartmentBoxes);//треба знайти оптимальний розмір коробки, щоби туди вмістились всі коробки, що всередині(написати алгоритм)
                BoxHandler.ShopBoxes.Add(box);
            }

            SaveShopBoxes();
            Models.Basket.ProductList.Clear();
        }

        private static Size CalculateOptimalBoxSize(List<DepartmentBox> departmentBoxes)
        {
            float maxX = 0;
            float maxY = 0;
            float maxZ = 0;

            foreach (var box in departmentBoxes)
            {
                if (box.Size.x > maxX)
                {
                    maxX = box.Size.x;
                }

                if (box.Size.y > maxY)
                {
                    maxY = box.Size.y;
                }

                if (box.Size.z > maxZ)
                {
                    maxZ = box.Size.z;
                }
            }
            return new Size(maxX, maxY, maxZ);
        }

        public static void SaveShopBoxes()
        {
            File.WriteAllText(BOXES_DATA, JsonConvert.SerializeObject(ShopBoxes));
        }

        public static void LoadShopBoxes()
        {
            try
            {
                ShopBoxes = JsonConvert.DeserializeObject<List<ShopBox>>(File.ReadAllText(BOXES_DATA));
            }
            catch { ShopBoxes = new List<ShopBox>(); }
        }
    }
}