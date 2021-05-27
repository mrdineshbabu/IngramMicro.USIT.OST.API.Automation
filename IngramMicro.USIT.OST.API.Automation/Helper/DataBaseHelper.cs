//-----------------------------------------------------------------------
// <copyright file="DataBaseHelper.cs" company="Microsoft Services">
//     Copyright (c) Microsoft Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.OracleClient;
    //using Oracle.DataAccess.Client;
    //using Oracle.DataAccess.Types;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// DataBase Helper Class
    /// </summary>
    public class DataBaseHelper
    {
        /// <summary>
        /// Gets or sets the data base connection string.
        /// </summary>
        /// <value>The data base connection string.</value>
        
        public static string DBConnection { get; set; }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns>data in data table</returns>
        /// <exception cref="Exception">There is something wrong about the query result, please check it.
        /// or
        /// Query execution failed with Reason : + ex.Message + ex.StackTrace</exception>
        public static DataTable ExecuteQuery(string sqlQuery, string DataBaseConnString)
        {            
            using (SqlConnection sqlConnection = new SqlConnection(DataBaseConnString))
            {                
                DateTime startime = DateTime.Now;
                try
                {
                    DataSet dataset = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, DataBaseConnString);
                    int tOut = sqlDataAdapter.SelectCommand.CommandTimeout;
                    sqlDataAdapter.SelectCommand.CommandTimeout = 7200;
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count == 0)
                    {
                        throw new Exception("There is something wrong about the query result, please check it.");
                    }

                    return dataset.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception("Query execution failed with Reason :" + ex.Message + ex.StackTrace);
                }
                finally
                {
                    DateTime endtime = DateTime.Now;
                    var diff = endtime - startime;
                }
            }
        }        

        

        public static DataTable ExecuteOracleQuery(string oracleQuery, string DataBaseConnString)
        {
            try
            {
                DataTable oracleQueryresults = new DataTable();

                using (OracleConnection connection = new OracleConnection(DataBaseConnString))

                {
                    OracleCommand command = new OracleCommand(oracleQuery, connection);
                    connection.Open();
                   
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        oracleQueryresults.Load(reader);
                    }                   

                    return oracleQueryresults;
                    //connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Query execution failed with Reason :" + ex.Message + ex.StackTrace);
            }
        }

    }
}