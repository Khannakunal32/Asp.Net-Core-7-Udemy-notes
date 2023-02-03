namespace ClassLibrary1
{
    //target class
    public class Product
    {
        // properties
        public double ProductCost { get; set; }
        public double DiscontPercentage { get; set; }

        Dictionary<int, string> customers = new Dictionary<int, string>()
        {
            {101, "kunal" },
            {102, "chhavi" },
            {103, "buddy" }
        };


        // creating anohther properity of product class with use of dictionary
        public void showCustomers()
        {
            //for each loop foor dictionary
            foreach (KeyValuePair<int, string> i in customers)
            {
                Console.WriteLine(i.Key + ", " + i.Value);
            };

            // geting value based on key
            string customerEx = customers[101];
            Console.WriteLine("\nValue at 101 " + customerEx);

            //Keys
            Dictionary<int, string>.KeyCollection keys = customers.Keys;
            Console.WriteLine("\nKeys:");

            foreach (int i in keys)
            {
                Console.WriteLine(i);
            }

            // duplicate key exception
            try
            {
                customers.Add(102, "Megha");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }

            //Remove
            try
            {

                customers.Remove(101);
            }
            finally
            {
                Console.WriteLine("\nremoved key 101 sucessfully");
            }

        }


        // creating anohther properity of product class with use of list of objects

        public void workingWithList()
        {
            // creating an empty collection of of list of Book
            List<Book> books = new List<Book>();

            // loop to read data from input

            string choice;
            do
            {
                Console.Write("Enter book id: ");
                int bid = int.Parse(Console.ReadLine());

                Console.Write("Enter book title: ");
                string btitle = Console.ReadLine();

                Console.Write("Enter book date of manufacture (yyyy-mm-dd): ");
                DateTime bdat = DateTime.Parse(Console.ReadLine());

                // creating a new object of Book class
                Book bookDetail = new Book()
                {
                    BookId = bid,
                    BookTitle = btitle,
                    DateOfManufacture = bdat,
                };

                // Add book obj to colleciton
                books.Add(bookDetail);

                Console.WriteLine("Product added successfully");

                Console.Write("\nDo you want to enter more books data ? ");
                choice = Console.ReadLine();
            }
            while (choice != "no" && choice != "NO" && choice != "n" && choice != "No" && choice != "nO" && choice != "N");

            // outputting the list
            Console.WriteLine("\nBooks");
            foreach (Book book in books)
            {
                Console.WriteLine(book.BookId + " " + book.BookTitle + " " + book.DateOfManufacture);
            }



        }


    }
}