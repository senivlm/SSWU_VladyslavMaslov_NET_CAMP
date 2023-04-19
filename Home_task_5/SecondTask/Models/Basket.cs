using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_2.Models;
using Task_2.Models.ServiceModels;

namespace Task_2.Models
{
    public class BasketItem
    {
        public string ShopName { get; set; }
        public string FullPath { get; set; }
        public Product Product { get; set; }
    }
    public class Basket
    {
        public const string BASKET_DATA = "basket.json";

        public static List<BasketItem> ProductList { get; set; }

        public static void LoadBasketData()
        {
            if (File.Exists(BASKET_DATA))
            {
                ProductList = JsonConvert.DeserializeObject<List<BasketItem>>(File.ReadAllText(BASKET_DATA));
            }
            else
            {
                ProductList = new List<BasketItem>();
            }
        }
        public static void SaveBasketData() => File.WriteAllText(BASKET_DATA, JsonConvert.SerializeObject(ProductList));

    }
}