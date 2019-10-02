using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ServiceReference1.IEmployeeService")]
    public interface IEmployeeService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IEmployeeService/getEmployees", ReplyAction = "http://tempuri.org/IEmployeeService/getEmployeesResponse")]
        System.Collections.Generic.List<WcfServiceLibrary1.Employee> getEmployees();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IEmployeeService/getEmployee", ReplyAction = "http://tempuri.org/IEmployeeService/getEmployeeResponse")]
        WcfServiceLibrary1.Employee getEmployee(int ID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IEmployeeService/editEmployeeByID", ReplyAction = "http://tempuri.org/IEmployeeService/editEmployeeByIDResponse")]
        bool editEmployeeByID(int id, WcfServiceLibrary1.Employee newVal);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IEmployeeService/insertEmployee", ReplyAction = "http://tempuri.org/IEmployeeService/insertEmployeeResponse")]
        bool insertEmployee(WcfServiceLibrary1.Employee newEmp);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IEmployeeService/deleteEmployee", ReplyAction = "http://tempuri.org/IEmployeeService/deleteEmployeeResponse")]
        bool deleteEmployee(int ID);
    }


    [DataContract]
    public class Employee
    {
        int id = 0;
        string  name = "";
        int  age = 0;
        

        [DataMember]
        public string  Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id= value; }
        }
        [DataMember]
        public int  Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
