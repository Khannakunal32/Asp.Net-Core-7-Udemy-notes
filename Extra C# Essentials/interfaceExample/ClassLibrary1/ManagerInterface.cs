namespace ClassLibrary1
{
    public class ManagerInterface : IInterfaceClassEmployee
    {
        //fields
        private string _departmentName;
        private string _empName;
        private string _location;
        private int _empId;

        // constructor of child class with use of base keyword to add features of abstract class
        public ManagerInterface(int empId, string empName, string location, string departmentName)
        {
            _departmentName = departmentName;
            _empName = empName;
            _location = location;
            _empId = empId;

        }

        public int EmpID
        {
            set { _empId = value; }
            get { return _empId; }
        }
        public string EmpName
        {
            set { _empName = value; }
            get { return _empName; }
        }

        public string Location
        {
            set { _location = value; }
            get { return _location; }
        }


        // Implementing in case of interface class of previous function
        public string GetHealthInsuranceAmountInterface()
        {
            return "Additional Health insurance for manager is 1000";

        }


    }
}
