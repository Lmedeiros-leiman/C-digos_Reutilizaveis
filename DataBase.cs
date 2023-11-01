using System.Data;
using MySql.Data.MySqlClient;

namespace learningNETwebApp.Models;


public static class DataBase
{
    private static MySqlConnection? _connection = null;
    private static string _connectionString = "Server=localhost;Database=webapplication;User ID=root;Password=root";

    public static DataTable Query(string query = "" )
    {
        OpenConnection();
        DataTable dataTable = new DataTable();
        if (_connection == null) { return dataTable;} // so pra calar a boca do editor.
        
        _connection.Open();

        query = "SELECT * FROM URLs";
        MySqlDataAdapter adapter = new MySqlDataAdapter(new MySqlCommand(query, _connection));

        
        adapter.Fill(dataTable);
        
        CloseConnection();
        return dataTable;
    }

    private static bool OpenConnection()
    {
        
            

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                _connection = conn;
                return true;
            }

            return false;
    }
    private static bool CloseConnection()
    {
        if (_connection == null)
        { // evitar problemas ao expandir esse script.
            return true;
        }

        _connection.Close();
        _connection = null;
        
        return true;
    }
    
}