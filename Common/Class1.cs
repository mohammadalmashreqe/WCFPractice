using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> getEmployees();



        [OperationContract]
        Employee getEmployee(int ID);

        [OperationContract]
        bool editEmployeeByID(int id, Employee newVal);

        [OperationContract]
        bool insertEmployee(Employee newEmp);
        [OperationContract]
        bool deleteEmployee(int ID);



    }


    [DataContract]
    public class Employee
    {
        int id = 0;
        string name = "";
        int age = 0;


        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
