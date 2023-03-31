using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Model
{
    public class Pump
    {
        // мощность насоса в ваттах
        public int power { get; private set; }
        // скорость потока воды в литрах в минуту
        public int flowRate { get; private set; }
        // состояние насоса
        public bool isPumpOn  = true;

        public Pump(int power, int flowRate)
        {
            if (power <= 0 || flowRate <= 0)
                throw new Exception("invalid arguments");
            this.power = power;
            this.flowRate = flowRate;
        }
        public void TurnOn() => isPumpOn = true;
        public void TurnOff() => isPumpOn = false;

        public int GetCurrentState()
        {
            return isPumpOn ? flowRate : 0;
        }
    }
}