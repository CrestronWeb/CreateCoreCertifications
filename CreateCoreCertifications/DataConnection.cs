using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CreateCoreCertifications
{
    internal class DataConnection
    {
        #region Properties

        private string ConnectionString { get; set; }
        private SqlConnection Connection { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Emtpty Constructor
        /// </summary>
        internal DataConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Training"].ConnectionString.ToString();
            Connection = new SqlConnection(ConnectionString);
        }

        #endregion

        #region Generic Database Connection Methods

        #region Open Close and Dispose Methods

        /// <summary>
        /// Method to Open the Database Connection
        /// </summary>
        internal void Open()
        {
            Connection.Open();
        }

        /// <summary>
        /// Method to Close the Database Connection
        /// </summary>
        internal void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Method to Dispose of the Database Connection
        /// </summary>
        internal void Dispose()
        {
            Connection.Dispose();
        }

        #endregion

        #region Execute No Reader Methods

        /// <summary>
        /// Method to Execute a Stored Procedure without Parameters
        /// </summary>
        /// <param name="commandName">Name of the Stored Procedure to Execute</param>
        internal void ProcedureExecuteNoReader(string commandName)
        {
            try
            {
                // Define the Command Object
                SqlCommand command = new SqlCommand();
                command.Connection = this.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandName;
                command.CommandTimeout = 0;
                // Execute the Command Object
                command.ExecuteNonQuery();
                // Clean Up the Command Object
                command.Dispose();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' Without Parameters: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call Without Parameters: " + e.ToString());
            }
        }

        /// <summary>
        /// Method to Execute a Stored Procedure with Parameters
        /// </summary>
        /// <param name="commandName">Name of the Stored Procedure to Execute</param>
        /// <param name="parameters">Array of Parameters to Pass the Stored Procedure</param>
        internal void ProcedureExecuteNoReader(string commandName, SqlParameter[] parameters)
        {
            try
            {
                // Define the Command Object
                SqlCommand command = new SqlCommand();
                command.Connection = this.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandName;
                command.CommandTimeout = 0;
                // Add the Parameters to the Command
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                // Execute the Command Object
                command.ExecuteNonQuery();
                // Clean Up the Command Object
                command.Dispose();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
            }
        }

        #endregion

        #region Execute Reader Methods

        /// <summary>
        /// Method to Execute a Stored Procedure without Paramters and Return a Data Reader
        /// </summary>
        /// <param name="commandName">Name of the Stored Procedure to Execute</param>
        /// <returns>Data Reader</returns>
        internal SqlDataReader ProcedureExecuteReader(string commandName)
        {
            try
            {
                // Define the Command Object
                SqlCommand command = new SqlCommand();
                command.Connection = this.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandName;
                command.CommandTimeout = 0;
                // Execute the Command Object
                SqlDataReader reader = command.ExecuteReader();
                // Clean up and Return the Results
                command.Dispose();
                return reader;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' Without Parameters: " + e.ToString());
                SqlDataReader reader = null;
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' Without Parameters: " + e.ToString());
                SqlDataReader reader = null;
                return reader;
            }
        }

        /// <summary>
        /// Method to Execute a Stored Procedure with Parameters and Return a Data Reader
        /// </summary>
        /// <param name="commandName">Name of the Stored Procedure to Execute</param>
        /// <param name="parameters">Array of Parameters to Pass the Stored Procedure</param>
        /// <returns>Data Reader</returns>
        internal SqlDataReader ProcedureExecuteReader(string commandName, SqlParameter[] parameters)
        {
            try
            {
                // Define the Command Object
                SqlCommand command = new SqlCommand();
                command.Connection = this.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandName;
                command.CommandTimeout = 0;
                // Add the Parameters to the Command
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                // Execute the Command Object
                SqlDataReader reader = command.ExecuteReader();
                // Clean Up and Return the Results
                command.Dispose();
                return reader;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
                SqlDataReader reader = null;
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
                SqlDataReader reader = null;
                return reader;
            }
        }

        /// <summary>
        /// Method to Execute a Stored Procedure with Parameters and Return a Data Reader
        /// </summary>
        /// <param name="commandName">Name of the Stored Procedure to Execute</param>
        /// <param name="parameters">Array of Parameters to Pass the Stored Procedure</param>
        /// <returns>Data Reader</returns>
        internal SqlCommand ProcedureExecuteNonQuery(string commandName, SqlParameter[] parameters)
        {
            try
            {
                // Define the Command Object
                SqlCommand command = new SqlCommand();
                command.Connection = this.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commandName;
                command.CommandTimeout = 0;
                // Add the Parameters to the Command
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
                return command;
            }
            catch (SqlException e)
            {
                Console.WriteLine("ProcedureExecuteNonQuery:Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("ProcedureExecuteNonQuery:Error Occurred Making Stored Procedure Call '" + commandName + "' With Parameters: " + e.ToString());
                return null;
            }
        }

        #endregion

        #endregion
    }
}
