using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceWinform.CSharpConsole
{

    // Declare a delegate type for Squaring a number

    /*
     delegate int SquareDelegate (int x);

     static int SquareMethod(int x)
     {
     return x*x;
     }
     
     static void main()
     {
      SquareDelegate square = new SquareDelegate(SquareMethod);

      int result = square(5);

      Console.WriteLine("The Square Of 5 is : "+result);]

      Console.ReadKey();
    
     }

     */

    class clsDelegateTypes
    {
        /*
             Function Delegate

                static Func<int, int> squre = SquareMethod;

                static int SquareMethod(int x)
                {
                    return x * x;
                }

        */

        /*static void main()
        {
            int result = square(5);

            Console.WriteLine("The Square Of 5 is : " + result);]

            Console.ReadKey();

        }*/

        //------------------------------------------------------------------------

        // Action Delegate  
        /* static void Main()
         {

             Action parameterlessAction = ParameterlessMethod;

             Action<int> actionWithOneParameter = ActionWithOneParameterMethod;

             Action<string, int> actionWithMultipleParameters =
                 ActionWithMultipleParametersMethod;


             parameterlessAction();

             actionWithOneParameter(42);

             actionWithMultipleParameters("Hello, World!", 100);

             Console.ReadKey();
         }



         static void ParameterlessMethod()
         {
             Console.WriteLine("This is a parameterless Action.");
         }

         static void ActionWithOneParameterMethod(int number)
         {
             Console.WriteLine($"The number is: {number}");
         }

         static void ActionWithMultipleParametersMethod(string message, int number)
         {
             Console.WriteLine($"{message} - {number}");
         }*/

        //  

        // Predicate Delegate


      /*  static Predicate<int> IsEvenPrdicate = IsEven;


        static bool IsEven(int x)
        {
            return (x % 2 == 0);
        
        }

        static void main()
        {
            bool result = IsEvenPrdicate(5);


            Console.WriteLine("Is Number 5 Even ?  " + result);

            Console.ReadKey();
        }
*/

        //
    }
}
