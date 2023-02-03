namespace ClassLibrary1
{
    internal class ManagerAbastract : AbstractClassEmployee
    {
        //field
        private string _departmentName;
        private string _empName;
        private string _location;
        private int _empId;

        // constructor of child class with use of base keyword to add features of abstract class
        public ManagerAbastract(int empId, string empName, string location, string departmentName) : base(empId, empName, location)
        {
            _departmentName = departmentName;
            _empName = empName;
            _location = location;
            _empId = empId;

        }

        // Overiding in case of abstract clas of previous function
        public override string GetHealthInsuranceAmount()
        {
            return "Additional Health insurance for manager is 1000";
        }

        //properties not required to implement all properties of abastract in child class
        public int EmpId
        {
            get { return _empId; }
            set { _empId = value; }
        }
    }
}
