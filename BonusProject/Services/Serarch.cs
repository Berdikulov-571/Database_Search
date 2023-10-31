﻿using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BonusProject.Services
{
    public class Serarch
    {
        public static List<string> GetTableNames(string shart)
        {
            string connectionString = $"Server=(localdb)\\MSSQLLocalDB;Database=StudyCenterDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> tableNames = connection.Query<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", CommandType.StoredProcedure).ToList();

                List<string> resultStr = new List<string>();

                foreach (string i in tableNames)
                {
                    string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{i}'";

                    List<string> res = connection.Query<string>(query).ToList();

                    foreach (string s in res)
                    {
                        string sql = $"select * from {i} where {s} = '{shart}'";

                        try
                        {
                            List<string> result = connection.Query<string>(sql).ToList();

                            if (result.Count != 0)
                            {
                                resultStr.AddRange(result);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return resultStr;
            }

        }
    }
}