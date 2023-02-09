namespace ControllerExample.Properties.Controller.Models
{
    /// <summary>
    /// we are creating an object to pass to the Json fnc in controller as it takes object and converts into json object
    /// </summary>
    public class Person
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public int? age { get; set; }


    }
}
