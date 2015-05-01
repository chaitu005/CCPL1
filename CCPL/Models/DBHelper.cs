using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace CCPL.Models
{
    public class DBHelper
    {
        // Get count of some table on specified column value    
private string _webConfigKey = "";
        private SqlConnection _sqlConnection;
        
        //Constructor to pass nothing
        public DBHelper()
        {
            _webConfigKey = "connection_string";
            string con = System.Configuration.ConfigurationManager.AppSettings[_webConfigKey];
            _sqlConnection = new SqlConnection(con);
        }

        //Constructor to pass web config key
        public DBHelper(string webConfigConnectionKey)
        {
            _webConfigKey = webConfigConnectionKey;
            string con = System.Configuration.ConfigurationManager.AppSettings[_webConfigKey];
            _sqlConnection = new SqlConnection(con);
        }

        //Constructor to pass Sql connection
        public DBHelper(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        //Getting Connection String
        public void getConnectionString()
        {
            _sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings[_webConfigKey]);
        }
        
        //Opening Connection 
        private void OpenConnection()
        {
            _sqlConnection.Open();
        }

        //Closing Connection
        private void CloseConnection()
        {
            _sqlConnection.Close();
        }

        //Create SQL Command
        private SqlCommand CreateSqlCommand(string strQuery)
        {
            return new SqlCommand(strQuery,_sqlConnection);
        }

        //Execute non query and return integer and pass string query
        public int executeNonQuery(string strQuery)
        {
            try
            {
                OpenConnection();
                return CreateSqlCommand(strQuery).ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally {
                CloseConnection();
            }
        }


        //Execute non query and return integer and pass sql command
        public int executeNonQuery(SqlCommand sqlQuery)
        {
            try
            {
                OpenConnection();
                return sqlQuery.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }


        //Execute query and return data table when you pass string query
        public DataTable executeQuery(string strQuery)
        {
            try
            {
                DataTable dtResult = new DataTable();
                OpenConnection();
                dtResult.Load(CreateSqlCommand(strQuery).ExecuteReader());
                return dtResult;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }

        }
        
        //Execute query and return data table when you pass string query
        public DataTable executeQuery(SqlCommand sqlQuery)
        {
            try
            {
                DataTable dtResult = new DataTable();
                OpenConnection();
                dtResult.Load(sqlQuery.ExecuteReader());
                return dtResult;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }

        }

        //Execute query and return string when you pass string query
        public string executeScalar(string tableName, string primaryKeyColumnName, string primaryKeyValue,string returnColumn)
        {
            try
            {
                string strQuery = "SELECT TOP 1 " + returnColumn + " FROM " + tableName + " WHERE " + primaryKeyColumnName + " = '" + primaryKeyValue + "' ;";
                OpenConnection();
                return CreateSqlCommand(strQuery).ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }

        }

        // Get count of some table on specified column value    
        public int getCount(string tableName, string columnName, string columnValue)
        {
            return Convert.ToInt32(executeScalar(tableName, columnName, columnValue, "Count(*)"));
        }

        //Get Web Config Value
        public string GetWebConfigValue(string webConfigKey)
        {
            return System.Configuration.ConfigurationManager.AppSettings[webConfigKey];
        }
    }
}