using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WcfServiceLibrary1
{
    public class EmployeeService : IEmployeeService
    {
         bool IEmployeeService.insertEmployee(Employee newEmp)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                if (dal != null)
                    dal.Close();

            }


        }

        bool IEmployeeService.editEmployeeByID(int id, Employee newVal)
        {
            DAL dal = null;
            try
            {
                
                dal = DAL.getConInstance();
                SqlParameter[] param = new SqlParameter[3];
                dal.Open();
                param[0] = new SqlParameter("@_name", newVal.Name);
                param[1] = new SqlParameter("@_age", newVal.Age);
                param[2] = new SqlParameter("@_ID", id);
                return dal.myExcute("SP_updateEmployee", param);

            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                if (dal != null)
                    dal.Close();
            }
        }

        Employee IEmployeeService.getEmployee(int ID)
        {
            DAL dal = null;

            try
            {
                Employee Result = new Employee();
                dal = DAL.getConInstance();
                SqlParameter[] param = new SqlParameter[1];
                dal.Open();
                param[0] = new SqlParameter("@_ID", ID);
                DataTable data = dal.SelectData("SP_getEmployee", param);
                Result.Name = data.Rows[0]["name"].ToString();
                Result.Age = int.Parse(data.Rows[0]["age"].ToString());
                Result.ID= int.Parse(data.Rows[0]["ID"].ToString());

                return Result;



            }
            catch (Exception ex)
            {
                throw new Exception();

            }
            finally
            {
                if (dal != null)
                    dal.Close();
            }
        }

        List<Employee> IEmployeeService.getEmployees()
        {
            DAL dal = null;
            try
            {
                List<Employee> Result = new List<Employee>();
                dal = DAL.getConInstance();
                dal.Open();
                DataTable data = dal.SelectData("SP_getAllEmployee", null);

                foreach (DataRow row in data.Rows)
                {
                    Employee TempEmp = new Employee();
                    string name = row["name"].ToString();
                    string age = row["age"].ToString();
                    string id = row["ID"].ToString();
                    TempEmp.Age = int.Parse(age);

                    TempEmp.ID = int.Parse(id);
                    TempEmp.Name = name;
                    Result.Add(TempEmp);


                }
               
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                if (dal != null)
                    dal.Close();
            }

        }

        bool IEmployeeService.deleteEmployee(int ID)
        {
            DAL dal = null;
            try
            {

                dal = DAL.getConInstance();
                SqlParameter[] param = new SqlParameter[1];
                dal.Open();
                
                param[0] = new SqlParameter("@_ID", ID);
                return dal.myExcute("SP_deleteEmployee", param);

            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                if (dal != null)
                    dal.Close();
            }

        }
    }
}
