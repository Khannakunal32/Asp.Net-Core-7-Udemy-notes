namespace ClassLibrary1
{
    // creating delegate type event that can be called without any name 
    public delegate void MydelegateType(int a, int b);

    public class Class1
    {

        // creating envent
        public event MydelegateType myEvent;

        public void RaiseEvent(int a, int b)
        {

            // raise event
            if (this.myEvent != null)
            {
                this.myEvent(a, b);
            }
        }

    }
}

// Note for lambda expression
// same as delegate but we dont have to use delegate keyword

// Note for delegate
// anonymous methods can be used anywhere within the method, to create Instantly without defining a method at class level
// Advantage: we need not create a named method to quickly handle an event
// it cannot be called without a delegate or event
// it cannot contain jump statements like go to break or continue
// it can access local variable and parameter of outer methods 
// it is maninly used for event handler
// it can't access ref or out parameter of an outer method 