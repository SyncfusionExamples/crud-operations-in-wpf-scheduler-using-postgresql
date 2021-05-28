using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchedulerSample.Helper
{
   public static class ConnectPSQL
    {
        public static string connectionString = @"Server=localhost;Port=5432;User id=postgres;Password=postgres;Database=SchedulerDB";

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public static NpgsqlConnection GetDBConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public static DataTable GetDataTable(string PSQL_Text)
        {
            NpgsqlConnection cn_connection = GetDBConnection();
            DataTable table = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(PSQL_Text, cn_connection);
            adapter.Fill(table);
            return table;
        }

        public static void ExecutePSQLQuery(string PSQLQuery)
        {
            NpgsqlCommand cmd_Command = new NpgsqlCommand(PSQLQuery, GetDBConnection());
            cmd_Command.ExecuteNonQuery();
        }

        public static void CloseDBConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
