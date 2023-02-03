using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// all methods are abstract and public by default in interface
    /// </summary>
    /// 
    //interface
    public interface IInterfaceClassEmployee
    {


        //abstract methods
        string GetHealthInsuranceAmountInterface();

        //auto-properties
        int EmpID
        {
            get; set;
        }
        string EmpName
        {
            get; set;
        }

        string Location
        {
            get; set;
        }
    }
}
