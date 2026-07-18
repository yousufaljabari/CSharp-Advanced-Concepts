using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceWinform.CSharpConsole
{
    public class Logger
    {
        public delegate void LogAction(string Message);

        private LogAction _logAction;

        public Logger(LogAction logAction)
        {
            _logAction = logAction;
        }

        public void Log(string Message)
        {
            _logAction(Message);
        }

    }





    public delegate void MyDelegate(string message);
    internal class Program
    {
        // Method For Multicast Delegation : reference multiple methods and invoke them in a single call.
        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message);
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }

        
    


        //Method One And Two 
        public static void LogToScreen(string Message)
        {
            Console.WriteLine(Message);
        }

        public static void LogToFile(string Message)
        {
            string FileName = "Log.txt";
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(Message);
            }
        }


        // This Main method demonstrates how to use the delegate
        /*
             {
                 Logger Logger1 = new Logger(LogToScreen);
                 Logger Logger2 = new Logger(LogToFile);
                 Logger1.Log("This message will be displayed on the screen ");
                 Logger2.Log("This message will be Logged in a File");
                 MulticastDelegateExample();
        
            MyDelegate myDelegate = Method1;

            myDelegate += Method2;

          
            myDelegate("Hello, world!");

            myDelegate -= Method1;

            myDelegate("Another message.");

             }
        */
    }


}
