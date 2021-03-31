
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentMIS.Models {

    public class LoginStoreContext {
    
        public string ConnectionString {get;set;}

        public LoginStoreContext()  
        {  
            this.ConnectionString=null;  
        }   

        public LoginStoreContext(string connectionString) {
            this.ConnectionString=connectionString;
        }

        private MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }

        public bool IsValidAdmin(string username,string password) {

            MySqlConnection connection = GetConnection();
            connection.Open();
            string query = "select * from login where username=@val1 and password=@val2 and role=\"admin\"";
            MySqlCommand cmd= new MySqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@val1",username);
            cmd.Parameters.AddWithValue("@val2",password);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader.HasRows;
        }

        public string IsValidTeacher(string username,string password) {
            
            MySqlConnection connection = GetConnection();
            connection.Open();
            string query = "select * from teacherdata where username=@val1";
            MySqlCommand cmd= new MySqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@val1",username);
            cmd.Parameters.AddWithValue("@val2",password);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();
            string name="Invalid";
            while(reader.Read())
                name=reader["username"].ToString();
            return name;
        }

        public string IsValidStudent(string username,string password) {
            
            MySqlConnection connection = GetConnection();
            connection.Open();
            string query = "select * from login where username=@val1 and password=@val2 and role=\"student\"";
            MySqlCommand cmd= new MySqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@val1",username);
            cmd.Parameters.AddWithValue("@val2",password);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();
            string name="Invalid";
            while(reader.Read())
                name=reader["username"].ToString();
            return name;
        }
    }
}