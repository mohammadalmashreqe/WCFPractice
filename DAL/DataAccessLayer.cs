using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccessLayer
    {

        static DataAccessLayer Instance;
        static SqlConnection sqlConnection;
         static string ConnectionString= "";
        /// <summary>
        /// constructer to establish the connection
        /// </summary>

        private DataAccessLayer(String conString)
        {
            try
            {
                sqlConnection = new SqlConnection(conString);
            }
            catch (Exception ex)
            {


            }
        }


        public static DataAccessLayer getConInstance()
        {
            if (sqlConnection == null)
                Instance = new DataAccessLayer(ConnectionString);


            return Instance;

        }

        /// <summary>
        /// method to open the connection 
        /// </summary>

        public bool Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// method to close the connection 
        /// </summary>
        public bool Close()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
                return true;
            }
            else
                return false;
        }


        /// <summary>
        ///method to read data from database
        /// </summary>

        public DataTable SelectData(string stored_proc, SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();






                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = stored_proc;
                sqlCommand.Connection = sqlConnection;


                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlCommand.Parameters.Add(param[i]);
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {




            }
            return null;

        }


        /// <summary>
        ///method to delete insert update to database 
        /// </summary>


        public bool myExcute(string stored_proc, SqlParameter[] param)
        {
            int x = -1;
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = stored_proc;
                sqlCommand.Connection = sqlConnection;
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlCommand.Parameters.Add(param[i]);
                }
                x = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {



            }



            if (x > 0)
                return true;
            else
                return false;

        }


        /// <summary>
        ///method to test connection 
        /// </summary>
       /* public static bool TestCon(string constring)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                if (con.State == ConnectionState.Open || con.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter( @"LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.Close();
                #endregion
                throw ex;
            }
        }*/

        /// <summary>
        ///method to change  connection string 
        /// </summary>
        //public static bool changeConnectioString(string value)
        //{
        //    try
        //    {
        //        if (TestCon(value))


        //        {
        //            StreamWriter sw2 = new StreamWriter( @"\constring.txt");
        //            sw2.Write(value);
        //            sw2.Close();
        //            return true;
        //        }
        //        else
        //            return false;
        //    }

        //    catch (Exception ex)
        //    {
        //        #region Format excepton and write details to the log file 
        //        StreamWriter sw = new StreamWriter( @"LogFile.txt", true);
        //        sw.WriteLine(DateTime.Now);
        //        sw.WriteLine("message : ");
        //        sw.WriteLine("");
        //        sw.WriteLine("");
        //        sw.WriteLine(ex.Message);
        //        sw.WriteLine("------------------------------------------------------------------------------------");
        //        sw.WriteLine("");
        //        sw.WriteLine("");
        //        sw.WriteLine("stack trace :");
        //        sw.WriteLine("");
        //        sw.WriteLine("");
        //        sw.WriteLine(ex.StackTrace);
        //        sw.WriteLine("------------------------------------------------------------------------------------");
        //        sw.WriteLine("");
        //        sw.WriteLine("");

        //        sw.Close();
        //        #endregion

        //        throw ex;

        //    }

        //}
    }
}
