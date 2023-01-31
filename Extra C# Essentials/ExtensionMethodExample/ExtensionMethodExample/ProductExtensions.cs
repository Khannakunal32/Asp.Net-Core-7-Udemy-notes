using ClassLibrary1;

namespace ExtensionMethodExampleImportThis
{
    //to get the method and work of product file of external project that we have create in this solution and use reference to connect with the main console applicaiton
    //internal class ProductExtensions


    // we create a static class


    /// <summary>
    /// below is the syntax of creating and using an extension ie using components of another class 
    /// 
    /// static class ClassName 
    /// {
    ///  public static return type MethodName(this ClassNae parameterName, ...)
    ///  {
    ///  method body here
    ///  }
    /// }
    /// 
    /// Here we use this key word as we can't use this keyword inside class so we create and instance of the using classname and pass as parameterName to use in this current class
    /// </summary>
    public static class ProductExtensions
    {
        public static double GetDiscount(this Product product)
        {
            return product.ProductCost * product.DiscontPercentage / 100;

        }
    }
}
