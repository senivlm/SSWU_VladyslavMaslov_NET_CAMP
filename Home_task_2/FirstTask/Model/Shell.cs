using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Model
{
    public class Shell
    {// Порушена інкапсуляція класу!!!!
        public List<WaterTower> waterTowerList;
        public List<User> users;

        public Shell()
        {
            waterTowerList = new List<WaterTower>();
            users = new List<User>();
        }
        
        public void GoNextStep()
        {
            foreach(var tower in waterTowerList) 
            {
                tower.GoNextStep();
            }
        }
    }
}
