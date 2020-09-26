using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class SQLDB
    {
        public const string CONST_USER_ID = "";
        public string connStr = "Data Source=DESKTOP-P3O3JQE\\VIRAJ;Initial Catalog=prayasdb;Persist Security Info=True;User ID=sa;Password=User@123";
        private SqlTransaction sqlTrans;
        private SqlConnection sqlConn = null;
        public static string DataSource = "";
        public static string InitialCatalog = "";
        public static string UserID = "";
        public static string Password = "";


        public SQLDB()
        {
            this.connStr = "Data Source=DESKTOP-P3O3JQE\\VIRAJ;Initial Catalog=prayasdb;Persist Security Info=True;User ID=sa;Password=User@123";
        }

        public void BeginTransaction()
        {
            sqlTrans = dbConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            sqlTrans.Commit();
        }

        public void RollbackTransaction()
        {
            sqlTrans.Rollback();
        }

        public void CloseConnection()
        {
            dbConnection.Close();
        }

        private SqlConnection dbConnection
        {
            get
            {

                if (sqlConn == null)
                {
                    sqlConn = new SqlConnection();
                    try
                    {
                        if (sqlConn.State == ConnectionState.Open)
                            sqlConn.Close();

                        sqlConn.ConnectionString = connStr;

                        if (sqlConn.State == ConnectionState.Closed)
                        {
                            sqlConn.Open();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                return sqlConn;
            }
        }

        public SqlDataReader getSqlDataReader(string strQuery, ArrayList alParams)
        {
            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand();
                    objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandTimeout = 0;
                    objCommand.CommandText = strQuery;

                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    SqlDataReader sqlDR = objCommand.ExecuteReader();
                    objCommand.Parameters.Clear();
                    return sqlDR;
                }
            }
            catch
            {
                return null;
            }

        }

        public DataSet getSqlDataSet(string strQuery, ArrayList alParams)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand();
                    objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandTimeout = 0;
                    objCommand.CommandText = strQuery;
                    objCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter sqlDR = new SqlDataAdapter(objCommand);
                    sqlDR.Fill(ds);
                    objCommand.Parameters.Clear();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                string meassge = ex.ToString();
                return null;
            }

        }



        public DataTable getDataTable(string strQuery, ArrayList alParams)
        {
            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand();
                    objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandTimeout = 0;
                    objCommand.CommandText = strQuery;
                    objCommand.Parameters.Clear();
                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter daSQL = new SqlDataAdapter(objCommand);
                    DataTable dt = new DataTable();

                    daSQL.Fill(dt);
                    objCommand.Parameters.Clear();
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public DataTable getDataTableQuery(string strQuery, ArrayList alParams)
        {
            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand();
                    objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandText = strQuery;
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandTimeout = 0;
                    objCommand.Parameters.Clear();
                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter daSQL = new SqlDataAdapter(objCommand);
                    DataTable dt = new DataTable();

                    daSQL.Fill(dt);
                    objCommand.Parameters.Clear();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                string meassge = ex.ToString();
                return null;
            }

        }

        public string runExecuteQuery(string strQuery, ArrayList alParams)
        {

            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandText = strQuery;

                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    objCommand.ExecuteNonQuery();
                    objCommand.Parameters.Clear();
                    return "done";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string ExecuteStoreProcedure(string strQuery, ArrayList alParams)
        {
            try
            {
                using (var con = new SqlConnection(connStr))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand objCommand = new SqlCommand(strQuery, con, sqlTrans);
                    objCommand.CommandText = strQuery;
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandTimeout = 0;
                    foreach (SqlParameter param in alParams)
                    {
                        objCommand.Parameters.Add(param);
                    }

                    objCommand.ExecuteNonQuery();

                    objCommand.Parameters.Clear();

                    return "done";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

            }
        }

    }
}