using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Model
{
    public interface Pump
    {
        int power { get; }
        int flowRate { get; }
        bool isPumpOn { get; }
        bool Toggle();
        void TurnOn();
        void TurnOff();
        int GetCurrentState();
        string ListenPump();
    }
    public class ElectricPump : Pump
    {
        public int power { get; private set; }
        public int flowRate { get; private set; }
        public bool isPumpOn { get; private set; } = true;

        public ElectricPump(int power, int flowRate)
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
        public bool Toggle() => isPumpOn = !isPumpOn;

        public string ListenPump()
        {
            return "*creaks, creaks*";
        }
    }

    public class ManualPump : Pump
    {
        public int power { get; private set; }
        public int flowRate { get; private set; }
        public bool isPumpOn { get; private set; } = false;

        public ManualPump(int power, int flowRate)
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
        public bool Toggle()=>isPumpOn =! isPumpOn;

        public string ListenPump()
        {
            return "bzhzhzh, bzhzhzh, bzhzhzh...";
        }
    }

    public class SolarPump : Pump
    {
        public int power { get; private set; }
        public int flowRate { get; private set; }
        public bool isPumpOn { get; private set; } = false;

        public SolarPump(int power, int flowRate)
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

        public bool Toggle()=>isPumpOn =! isPumpOn;

        public string ListenPump()
        {
            return "*no sounds*";
        }
    }

}