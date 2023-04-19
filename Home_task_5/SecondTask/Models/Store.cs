using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_2.Models;
using Task_2.Models.ServiceModels;

namespace task_2.Models
{
    public class Store
    {
        public const string STORE_DATA = "storeData.json";
        public static List<Store> StoreList = new List<Store>();

        public string Name { get; set; }
        public string Address { get; set; }
        public List<Department> DepartmentList { get; set; }

        public Store(string name, string address)
        {
            Name = name;
            Address = address;
            DepartmentList = new List<Department>();
        }

        public Store(StoreData storeData) : this(storeData.Name, storeData.Address) { }
        public Store() { }
        public Department AddDepartment(string name)
        {
            var department = new Department (name);
            DepartmentList.Add(department);
            return department;
        }

        //public SubDepartment AddSubDepartment(string name)
        //{
        //    var department = new SubDepartment { DepartmentName = name, DepartmentList = new List<Department>() };
        //    DepartmentList.Add(department);
        //    return department;
        //}
        public static List<Store> GetStoreList()
        {
            if (File.Exists("storeData.json"))
            {
                return JsonConvert.DeserializeObject<List<Store>>(File.ReadAllText(STORE_DATA));
            }
            return new List<Store>();
        }
        public static Store GetStore(string name)
        {
            var stores = GetStoreList();
            return stores.First(s => s.Name == name);
        }

        public static Store GetStore(int id)
        {
            return GetStoreList()[id];
        }

        public static void UpdateStoreList()
        {
            StoreList = GetStoreList();
        }


        public static void SaveStores()
        {
            File.WriteAllText(STORE_DATA, JsonConvert.SerializeObject(StoreList));
        }

        //public static void AddStore(Store store)
        //{
        //    var stores = GetStoreList();
        //    stores.Add(store);
        //    SaveStores(stores);
        //}
        //public static void DeleteStore(int id)
        //{
        //    var stores = GetStoreList();
        //    stores.RemoveAt(id);
        //    SaveStores(stores);
        //}
        //public static void UpdateStore(int id, Store store)
        //{
        //    var stores = GetStoreList();
        //    stores[id] = store;
        //    SaveStores(stores);
        //}
    }
}