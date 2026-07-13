
using System.Runtime.InteropServices.Marshalling;

namespace CourseCsharp
{
    internal class Program
    {
        public class TemperaturerChangedEventsArgs:EventArgs
        {
            public double OldTemperature { get; }
            public double NewTemperature { get; }

            public double Difference { get; }

            public TemperaturerChangedEventsArgs(double oldTemperature, double newTemperature)
            {
                OldTemperature = oldTemperature;
                NewTemperature = newTemperature;
                Difference = newTemperature - oldTemperature ;
            }
        }

        public class Thermostat  
        {
            public event EventHandler<TemperaturerChangedEventsArgs> OnTempraturechanged;

            private double OldTemprature;
            private double CurrentTemprature;

            public void SetTemprature(double newTemprature)
            {
                if(newTemprature!=CurrentTemprature)
                {
                    OldTemprature = CurrentTemprature;
                    CurrentTemprature = newTemprature;
                    OnTempratureChanged(OldTemprature, CurrentTemprature);
                }
            }

            private void OnTempratureChanged(double OldTemprature, double CurrentTemprature)
            {
                OnTempratureChanged(new TemperaturerChangedEventsArgs(OldTemprature,CurrentTemprature));
            }

            protected virtual void OnTempratureChanged(TemperaturerChangedEventsArgs e)
            {
                OnTempraturechanged?.Invoke(this, e);
            }




        }

        public class Display
        {

            public void Subscribe(Thermostat thermostat)
            {
                thermostat.OnTempraturechanged += HandleTempratureChange;
            }
            public void HandleTempratureChange(object sender, TemperaturerChangedEventsArgs e)
            {
                Console.WriteLine("\n\n Temprature Change : ");
                Console.WriteLine($"Temprature changed from {e.OldTemperature} ℃");
                Console.WriteLine($"Temprature changed to {e.NewTemperature} ℃");
                Console.WriteLine($"Temprature Difference to {e.Difference} ℃");
            }
        }

        public class Printer
        {
            public void Subscribe(Thermostat thermostat)
            {
                thermostat.OnTempraturechanged += PrinterHandleTempratureChange;
            }
            public void PrinterHandleTempratureChange(object sender, TemperaturerChangedEventsArgs e)
            {
                Console.WriteLine($"New Temprature is Changed = {e.NewTemperature}");
            }
        }






        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Printer printer = new Printer();
            Display display = new Display();

            display.Subscribe(thermostat);
            printer.Subscribe(thermostat);


            thermostat.SetTemprature(25);

            thermostat.SetTemprature(30);

            thermostat.SetTemprature(35);
            thermostat.SetTemprature(50);



            Console.ReadLine();
        }
    }
}
