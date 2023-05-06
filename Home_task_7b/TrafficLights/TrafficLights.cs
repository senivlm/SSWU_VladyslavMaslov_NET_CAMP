using System.Collections.ObjectModel;

namespace TrafficLights;

public class TrafficLights
{
    private List<string> _directions;
    private int _t;
    private int _cuurentTime = 0;

    public int T => _t;

    public int CurrentTime => _cuurentTime;

    public ReadOnlyCollection<string> Directions => _directions.AsReadOnly();

    public TrafficLights(List<string> directions, int t = 1)
    {
        _t = t;
        _directions = directions;
    }

    public void UpdateDelay(int t)
    {
        _t = t;
    }

    public void RunTrafficAndPrint(ITrafficLightsPrinter printer)
    {
        printer.Print();
        Thread.Sleep(_t*1000);
        _cuurentTime += _t;
    }
}