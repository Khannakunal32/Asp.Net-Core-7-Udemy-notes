using ClassLibrary1;
// we have to import the namespace of another project in solution as name of namespace is different
namespace interfaceExample
{
    internal class Program
    {

        /// <summary>
        /// Interface - it is a set of abstract methods that must be implemented by the child class, in short interface is a complete abstract class with only abstract method 
        /// 
        /// The child class that implemen6ts the interface must implement all methods of the interface
        /// 
        /// The child class must implement all interface method with same signature 
        /// interface methods are by default public and abstract 
        /// you can't create object for interface 
        /// you can create reference variable for the interface 
        /// the reference variable of interface type can only store the address of objects of anyone of the corresponding child classes 
        /// you can implement multiple interfaces in the same child class multiple inheritance 
        /// an interface can be child of another interface 
        /// interface can not be inherited from another classes
        /// ***** A class can not be parent of a interface but abastract classes can be inherited form another classes
        /// An interface can be child of another interface
        /// cannot create an object for an abstract class or an interface
        /// 
        /// noraml class canhave all fields, but cannot have abstract methods
        /// In abastract method we can include all type of method
        /// In interface we can only create non-static events, abstract methods, nonstatic auto-implemented  properties
        /// all interferaces methodsa re abastract by default
        /// </summary>


        // first go AbstractClassEmployee to see abstract class then see the use of it same implementation in interfces in IEmployee.cs in classLibrary1

        public class NullableExample
        {
            public int x { get; set; }
        }

        public class NullableExampleLogic
        {

            // by type ? infront we let the class and variable accept null 
            public NullableExample? GetExample()
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            //creating object of manager interface
            ManagerInterface mgr1 = new ManagerInterface(102, "Kunal", "Delhi", "CEO");
            Console.WriteLine(mgr1.EmpID);
            Console.WriteLine(mgr1.EmpName);
            Console.WriteLine(mgr1.Location);
            Console.WriteLine(mgr1.GetHealthInsuranceAmountInterface());


            /// className = non-nullable (null values are not accepted
            /// className? = nullable (accepts null values)
            NullableExampleLogic NullLogic = new NullableExampleLogic();
            NullableExample? NullEx = NullLogic.GetExample();

            if (NullEx != null)
            {
                Console.WriteLine(NullEx.x);
            }
        }
    }




}