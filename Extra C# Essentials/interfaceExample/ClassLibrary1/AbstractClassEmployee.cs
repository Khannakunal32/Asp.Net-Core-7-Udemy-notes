using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Abstract class employee with abstract methods and non abstract
    /// </summary>
    //internal class AbstractClassEmployee
    //{
    //}

    public abstract class AbstractClassEmployee
    {
        //fields (interface cannot contain field)
        private int _empID;
        protected string _location;
        private string _empName;

        //constructor of parent class (interface cannot contain constrcutor)
        public AbstractClassEmployee(int _empId, string _empName, string _location)
        {
            this._empID = _empId;
            this._empName = _empName;
            this._location = _location;
        }

        //abstract method
        public abstract string GetHealthInsuranceAmount();

        // properties
        public int EmpID
        {
            set { _empID = value; }
            get { return _empID; }
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
    }


}
