using ClassLibrary1;

namespace AnonymousFunctions
{

    // anonymous funcions are name-less methods that can be called with deligate variable
    internal class Program
    {

        static void Main(string[] args)
        {

            // create obj of class1 where delegate is defined
            Class1 delegateExample = new Class1();

            // creating event delegate event in main function namelessly
            // syntax 
            //EventName += delegate(param1, param2,....){

            //}

            delegateExample.myEvent += delegate (int a, int b)
            {
                Console.WriteLine(a + ", " + b);
            };


            // createing anonymous even using lambda expression
            delegateExample.myEvent += (int a, int b) =>
            {
                Console.WriteLine(a + b);
            };

            // calling back the method to execute using raise event
            delegateExample.RaiseEvent(10, 20);

        }
    }
}