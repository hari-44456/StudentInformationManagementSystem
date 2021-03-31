
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentMIS.Models {
    public class StudentStoreContext {
        public string ConnectionString {get;set;}
        public StudentStoreContext(string connectionString) {
            this.ConnectionString=connectionString;
        }

        private MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }

        public StudentData GetStudentDetails(string username) {
            StudentData stu=new StudentData();
            MySqlConnection conn= GetConnection();
            conn.Open();


             string query = "select * from studentdata where name=@v1";
            MySqlCommand cmd= new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@v1",username);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) {
                stu.prn=reader.GetString(0);
                stu.name=reader.GetString(1);
                stu.department=reader.GetString(2);
                stu.currentYear=reader.GetString(3);
            }
            return stu;
        }


    }
}