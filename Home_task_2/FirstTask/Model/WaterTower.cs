using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Model
{
    public class WaterTower
    {
        public int maxVolume { get; private set; }
        public int currentVolume { get; private set; }
        //public bool isPumpOn { get;private set; }
        private Pump pump;

        //public List<User> Users { get; set; }

        public WaterTower(int maxVolume, Pump pump)
        {
            if (maxVolume <= 0)
                throw new Exception("Max volume must be greater than zero!");
            this.maxVolume = maxVolume;
            this.currentVolume = 0;
            //this.isPumpOn = false;
            this.pump = pump;
        }

        public void GoNextStep()
        {
            if (pump.isPumpOn)
            {
                currentVolume += pump.GetCurrentState();
                //currentVolume = currentVolume > maxVolume ? maxVolume : currentVolume;


                currentVolume += pump.GetCurrentState();
                if (currentVolume >= maxVolume) DeactivatePump();
            }

        }
        public int Drain(int volume, User user)
        {
            if (currentVolume - volume < 0)
            {
                int x = currentVolume;
                currentVolume = 0;
                ActivatePump();
                return x;
            }
            currentVolume -= volume;
            return volume;

        }
        private void ActivatePump()
        {
            pump.isPumpOn = true;
        }
        private void DeactivatePump()
        {
            pump.isPumpOn = false;
            currentVolume = maxVolume;
        }
        public override string ToString()
        {
            return $"Flow rate: {this.pump.flowRate}, power: {this.pump.power}, water count: {this.currentVolume}";
        }
    }
}
