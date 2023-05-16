namespace TrafficLights;
// З проєктуванням просто біда. Спробуйте подивитись на програми колег
public class TrafficLightsPrinter : ITrafficLightsPrinter
{
    private readonly TrafficLights _trafficLights;

    public TrafficLightsPrinter(TrafficLights trafficLights)
    {
        _trafficLights = trafficLights;
    }
    public void Print()
    {
        Console.Clear();

        Console.WriteLine($"Current time: {_trafficLights.CurrentTime}s.");

        PrintHeader();
        
        for (int i = 0; i < _trafficLights.Directions.Count; i++)
        {
            var spaces = _trafficLights.Directions[i].Length;
            Console.Write("|");
            if ((_trafficLights.CurrentTime/_trafficLights.T+i) % 2 == 0)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("G");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("R");
            }

            for (int j = 0; j < spaces-1; j++)
            {
                Console.Write(" ");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("|");
    }

    private void PrintHeader()
    {
        foreach(var d in _trafficLights.Directions)
        {
            Console.Write($"|{d}");
        }
        Console.WriteLine("|");
    }
}
