using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    public class EmployeeService : IEmployeeService
    {
        public bool insertEmployee(Employee newEmp)
        {
            DAL dal = null; 
            try
            {
                dal = DAL.getConInstance();
                SqlParameter[] param = new SqlParameter[2];
                dal.Open();
                param[0] = new SqlParameter("@_name", newEmp.Name);
                param[1] = new SqlParameter("@_age", newEmp.Age);
                dal.myExcute("SP_ADDEmployee", param);
                dal.Close();
            }
            catch (Exception ex)
            {
          

            }
            finally
            {
                if(dal!=null)
                dal.Close();
            }
            return false ;
        }

        bool IEmployeeService.editEmployeeByID(int id, Employee newVal)
        {
            try
            {

         

            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        Employee IEmployeeService.getEmployee(int ID)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        List<Employee> IEmployeeService.getEmployees()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }
    }
}
