using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    class Program
    {
        private const string welcome = @"Welcome to Service Oriented Assistant!
Please use one of following commands:
  time
  city CityName
  weather
  remember Something to remember
  done index
  todo
  quit
";
        static void Main(string[] args)
        {
            Console.WriteLine(welcome);

            var ts = new TimeService.TimeServiceClient();
            var ws = new WeatherService.WeatherServiceClient();
            var td = new TodoService.TodoServiceClient();

            while (true)
            {
                Console.Write("soa> ");
                string cmd = Console.ReadLine();

                if (cmd.StartsWith("time"))
                {
                    Console.WriteLine("Current time is: " + ts.CurrentTime().ToString("H:mm:ss"));
                }
                if (cmd.StartsWith("city"))
                {
                    string city = cmd.Substring(5);
                    var res = ws.SetCity(city);
                    if (res != null)
                    {
                        Console.WriteLine("Current city set to " + res.Name);
                    }
                    else
                    {
                        Console.WriteLine("Unable to set current city as requested. Try another name");
                    }
                }
                if (cmd.StartsWith("weather"))
                {
                    var weather = ws.GetWeatherForecast();
                    if(weather != null)
                    {
                        foreach(var w in weather)
                        {
                            var wl = String.Format("{0} - {1}, temperature {2}C, pressure {3}hPa, humidity {4}%", w.Date, w.Weather, w.Temperature, w.Pressure, w.Humidity);
                            Console.WriteLine(wl);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please set current city before requesting weather");
                    }
                }
                if (cmd.StartsWith("remember"))
                {
                    string todo = cmd.Substring(9);
                    Console.WriteLine("Remembered. Id = " + td.RememberTodo(todo).ToString());
                }
                if (cmd.StartsWith("done"))
                {
                    int id = int.Parse(cmd.Substring(5));
                    Console.WriteLine(td.MarkDone(id) ? "Marked as done" : "Unable to mark as done");
                }
                if (cmd.StartsWith("todo"))
                {
                   foreach(var t in td.GetTodos())
                    {
                        Console.WriteLine(t.Id.ToString() + ": " + (t.Done ? "[DONE]" : "[UNDONE]") + " " + t.Task);
                    }
                }


                if (cmd.StartsWith("quit")) Environment.Exit(0);
            }
        }
    }
}
