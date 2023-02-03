// 1. Create a C# console solution 
//2. Add-> project -> class of C#
// 3. Create normal methods (see class.cs in classLibraray1 project in this solution
// 4. add refrence to the main console solution of classLibrary1
// 5. Create and add a new class item to this console application to create it as an extensionmethod of classLibraray (see ProdcutExtesion.cs) then come back again
// 6. import necessary file as below and create object and use extension


// to excess the extension method we must import the namespace of it
// also we must import the referenced class whose extension is made
using ClassLibrary1;
using ExtensionMethodExampleImportThis;


namespace ExtensionMethodExample
{
    internal class Program
    {


        static void Main(string[] args)
        {
            //create object
            Product p = new Product()
            {
                ProductCost = 1000,
                DiscontPercentage = 2000
            };

            // Calling the extension
            Console.WriteLine(p.GetDiscount());
            p.showCustomersHelper();
            p.workingWithList();
            Console.ReadLine();

        }
    }
}

// With this we can add features to classLibrary without modifying the origin class also we can do for predefine classs like string int32 console and make their extensions 
// the extension method must be made static that it will be added to the specified clas as non static method
// this keyword can not be used in static mehtod thus we create a reference as parameter
// extension method does not support method overloading
// This concept can't be used to create fields, properties, or event
// static class of extension method can't be inner class