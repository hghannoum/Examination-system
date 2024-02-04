using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace db_2024
{
    class DataLayer
    {
        string server_name;
        string database_name;
        SqlConnection con;
        public bool IsValid = false;
        public DataLayer(string ServerName, string DataBaseName)
        {
            server_name = ServerName;
            database_name = DataBaseName;
            VerifyConnection();
        }

        private void VerifyConnection()
        {
            con = new SqlConnection(@"Data Source=" + server_name + ";Initial Catalog=" + database_name + ";Integrated Security=True");
            try
            {
                con.Open();
                con.Close();
                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
        }

        public void SetServerName(string ServerName)
        {
            server_name = ServerName;
            VerifyConnection();
        }

        public string GetServerName()
        {
            return server_name;
        }

        public void SetDataBaseName(string DataBaseName)
        {
            database_name = DataBaseName;
            VerifyConnection();
        }

        public string GetDataBaseName()
        {
            return database_name;
        }
        
        public int ExecuteActionCommand(string CommandText)
        {
            int rep = 0;
            
            if ((IsValid) && (CommandText.Length>0))
            {
                con.Open();                
                SqlCommand com = new SqlCommand(CommandText, con);
                try
                {
                    rep = com.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
            }
            return rep;
        }

        public object GetValue(string SqlText)
        {
            if ((IsValid)&&(SqlText.Length>0))
            {
                object v=null;
                SqlCommand com = new SqlCommand(SqlText, con);
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }

        public DataTable GetData(string SqlText, string name)
        {
            DataTable dt = new DataTable(); 
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.Text;
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }


        //Stored Procedures Overloads

        public DataTable GetData(string SqlText, object[,] Parameters, string name)
        {
            DataTable dt = new DataTable();
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.GetLength(0); i++)
                    com.Parameters.Add(new SqlParameter(Parameters[i, 0].ToString(), Parameters[i, 1]));
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }

        public object GetValue(string SqlText, object[,] Parameters)
        {
            if ((IsValid) && (SqlText.Length > 0))
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.GetLength(0) ; i++)
                    com.Parameters.Add(new SqlParameter(Parameters[i, 0].ToString(), Parameters[i, 1]));
                object v = null;
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }

        public int ExecuteActionCommand(string CommandText, object[,] Parameters)
        {
            int rep = 0;

            if (IsValid && CommandText.Length > 0)
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(CommandText, con))
                {
                    com.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < Parameters.GetLength(0); i++)
                    {
                        // Check if the parameter is an output parameter
                        if (Parameters[i, 2] != null && (bool)Parameters[i, 2])
                        {
                            // If it's an output parameter, add it with ParameterDirection.Output
                            com.Parameters.Add(new SqlParameter(
                                Parameters[i, 0].ToString(),
                                SqlDbType.Int) // Adjust the SqlDbType based on the type of your output parameter
                            {
                                Direction = ParameterDirection.Output
                            });
                        }
                        else
                        {
                            // Otherwise, add it as usual
                            com.Parameters.Add(new SqlParameter(
                                Parameters[i, 0].ToString(),
                                Parameters[i, 1]));
                        }
                    }

                    rep = com.ExecuteNonQuery();

                    // Retrieve the values of output parameters
                    for (int i = 0; i < Parameters.GetLength(0); i++)
                    {
                        if (Parameters[i, 2] != null && (bool)Parameters[i, 2])
                        {
                            Parameters[i, 1] = com.Parameters[Parameters[i, 0].ToString()].Value;
                        }
                    }
                }

                con.Close();
            }

            return rep;
        }

    }
}
