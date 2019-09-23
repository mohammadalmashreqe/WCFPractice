using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    class DAL
    {

        static DAL Instance;
        static SqlConnection sqlConnection;
        static string ConnectionString = @"Data Source=LP-MOHAMMADYM\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";
        /// <summary>
        /// constructer to establish the connection
        /// </summary>

        private DAL(String conString)
        {
            try
            {
                sqlConnection = new SqlConnection(conString);
            }
            catch (Exception ex)
            {


            }
        }


        public static DAL getConInstance()
        {
            if (sqlConnection == null)



                Instance = new DAL(ConnectionString);


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
            try
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
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


    }
}
