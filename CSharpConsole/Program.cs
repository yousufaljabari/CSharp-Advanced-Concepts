
using System.Runtime.InteropServices.Marshalling;

namespace CourseCsharp
{
    internal class Program
    {
        /// <summary>
        /// Tembrature Example using EventsArgs
        /// </summary>
        public class TemperaturerChangedEventsArgs : EventArgs
        {
            public double OldTemperature { get; }
            public double NewTemperature { get; }

            public double Difference { get; }

            public TemperaturerChangedEventsArgs(double oldTemperature, double newTemperature)
            {
                OldTemperature = oldTemperature;
                NewTemperature = newTemperature;
                Difference = newTemperature - oldTemperature;
            }
        }

        public class Thermostat
        {
            public event EventHandler<TemperaturerChangedEventsArgs> OnTempraturechanged;

            private double OldTemprature;
            private double CurrentTemprature;

            public void SetTemprature(double newTemprature)
            {
                if (newTemprature != CurrentTemprature)
                {
                    OldTemprature = CurrentTemprature;
                    CurrentTemprature = newTemprature;
                    OnTempratureChanged(OldTemprature, CurrentTemprature);
                }
            }

            private void OnTempratureChanged(double OldTemprature, double CurrentTemprature)
            {
                OnTempratureChanged(new TemperaturerChangedEventsArgs(OldTemprature, CurrentTemprature));
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

        //static void Main(string[] args)
        //{
        //    Thermostat thermostat = new Thermostat();
        //    Printer printer = new Printer();
        //    Display display = new Display();

        //    display.Subscribe(thermostat);
        //    printer.Subscribe(thermostat);


        //    thermostat.SetTemprature(25);

        //    thermostat.SetTemprature(30);

        //    thermostat.SetTemprature(35);
        //    thermostat.SetTemprature(50);



        //    Console.ReadLine();
        //}


        /// <summary>
        /// Publisher Example using object 
        /// </summary>
        
        public class NewsAritcle
        {
            public string Title { get; }
            public string Content { get; }

            public NewsAritcle(string title, string content)
            {
                Title = title;
                Content = content;
            }
        }

        public class NewsPublisher
        {
            public event EventHandler<NewsAritcle> NewNewsPublisher;

            public void PublishNews(string Tilte, string Content)
            {
                var Article = new NewsAritcle(Tilte, Content);
                OnNewsPublished(Article);

            }

            protected virtual void OnNewsPublished(NewsAritcle newsAritcle)
            {
                NewNewsPublisher?.Invoke(this, newsAritcle);
            }

        }

        public class NewsSubscriber
        {
            public string name { get; }

            public NewsSubscriber(string name)
            {
                this.name = name;
            }
            public void Subscribe(NewsPublisher publisher)
            {
                publisher.NewNewsPublisher += HandleNewNews;
            }

            public void UnSubscribe(NewsPublisher publisher)
            {
                publisher.NewNewsPublisher -= HandleNewNews;
            }

            public void HandleNewNews(object sender, NewsAritcle Aritcle)
            {
                Console.WriteLine($"{name} received a new news article : ");
                Console.WriteLine($"TItle : {Aritcle.Title}");
                Console.WriteLine($"Content : {Aritcle.Content}");
                Console.ReadLine();
            }


        }

          /*static void Main(string[] args)
        {
            NewsPublisher publisher = new NewsPublisher();
            NewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");

            subscriber1.Subscribe(publisher);



            NewsSubscriber subscriber2 = new NewsSubscriber("Subscriber 2");
            subscriber2.Subscribe(publisher);


            publisher.PublishNews("Breaking News", "A significant event just happened!");

            publisher.PublishNews("Tech Update", "New gadgets are hitting the market.");

            // Unsubscribe a subscriber (e.g., subscriber1)
            subscriber1.UnSubscribe(publisher);

            publisher.PublishNews("Weather Forecast", "Expect sunny weather for the weekend.");

            // Unsubscribe another subscriber (e.g., subscriber2)
            subscriber2.UnSubscribe(publisher);

            publisher.PublishNews("Final Edition", "Last news update for today.");




        }
          */


        /// <summary>
        /// Order Example
        /// </summary>
        /*
        Learned and implemented the Publisher–Subscriber pattern using C# Events and Delegates through an Order Example.
        */
        public class OrderEventArgs : EventArgs
        {
            public int OrderID { get; }
            public int OrderTotalPrice { get; }
            public string ClientEmail { get; }

            public OrderEventArgs(int OrderID, int OrderTotalPrice, string ClientEmail)
            {
                this.OrderID = OrderID;
                this.OrderTotalPrice = OrderTotalPrice;
                this.ClientEmail = ClientEmail;
            }


        }

        public class Order
        {
            public event EventHandler<OrderEventArgs> OnOrderCreated;

            public void Create(int OrderID, int OrderTotalPrice, string ClientEmail)
            {
                Console.WriteLine("New Order Created , now will notify everyone by raising the event.\n");
                if (OnOrderCreated != null)
                {
                    OnOrderCreated(this, new OrderEventArgs(OrderID, OrderTotalPrice, ClientEmail));
                }

            }
        }

        public class EmailService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleNewOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleNewOrder;
            }

            public void HandleNewOrder(object sender, OrderEventArgs e)
            {
                Console.WriteLine("-------- Email Service --------");
                Console.WriteLine($"Order ID: {e.OrderID}");
                Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
                Console.WriteLine($"Email: {e.ClientEmail}");
                Console.WriteLine("Send an Email\n");
            }
        }

        public class SMSService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleNewOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleNewOrder;
            }


            public void HandleNewOrder(object sender, OrderEventArgs e)
            {
                Console.WriteLine("-------- SMS Service --------");
                Console.WriteLine($"Order ID: {e.OrderID}");
                Console.WriteLine("Send an SMS\n");
            }
        }

        public class ShippingService
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCreated += HandleNewOrder;
            }

            public void UnSubscribe(Order order)
            {
                order.OnOrderCreated -= HandleNewOrder;
            }

            public void HandleNewOrder(object sender, OrderEventArgs e)
            {
                Console.WriteLine("-------- Shipping Service --------");
                Console.WriteLine($"Order ID: {e.OrderID}");
                Console.WriteLine("Prepare order for shipping\n");
            }
        }

        /*static void Main(string[] args)
        {
            
            Order order = new Order();

            
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            ShippingService shippingService = new ShippingService();

            
            emailService.Subscribe(order);
            smsService.Subscribe(order);
            shippingService.Subscribe(order);

            // Create a new order
            order.Create(
                1001,
                250,
                "client@gmail.com"
            );

            Console.ReadKey();
        }
*/

        /// <summary>
        /// Order Example
        /// </summary>










    }
}
