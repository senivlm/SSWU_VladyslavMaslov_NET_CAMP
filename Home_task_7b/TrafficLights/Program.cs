
using TrafficLights;

public class Program
{
    public static void Main(string[] args)
    {

        int delay = -1;
        while (delay < 1)
        {
            Console.Clear();
            Console.Write("Set delay:");
            var s = Console.ReadLine();
            // Ви ж не перевіряєте булівську змінну. Тому могли просто парсити
            Int32.TryParse(s, out delay);
        }
        
        int time = -1;
        while (time < 1)
        {
            Console.Clear();
            Console.Write("Set timer:");
            var s = Console.ReadLine();
            Int32.TryParse(s, out time);
        }
        
        var directions = new List<string>() { "N-S", "E-W", "S-N", "W-E"};
        var lights = new TrafficLights.TrafficLights(directions, delay);

        while (time-- > 0)
        {// Порушення принципу Єдиної відповідальності.
            lights.RunTrafficAndPrint(new TrafficLightsPrinter(lights));
        }
    }
}
