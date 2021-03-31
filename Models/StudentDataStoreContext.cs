
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentMIS.Models {
    
    public class StudentDataStoreContext {
        public string ConnectionString {get;set;}
        public StudentDataStoreContext(string connectionString) {
            this.ConnectionString=connectionString;
        }

        private MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }

        public List<StudentData> GetAllStudents() {
            List<StudentData> list=new List<StudentData>();
            using (MySqlConnection conn= GetConnection()) {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from studentData where role=\"student\"",conn);

                using (var reader=cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new StudentData () { 
                            prn=reader["prn"].ToString(),
                            name=reader["name"].ToString(),
                            department=reader["department"].ToString(),
                            currentYear=reader["currentYear"].ToString()
                        });
                    } 

                }
            }
            return list;
        }

        public void AddStudent(string prn,string name,string department,string currentYear) {
            MySqlConnection conn=GetConnection();
            conn.Open();
            MySqlCommand cmd=new MySqlCommand("insert into studentdata(prn,name,department,currentYear,role) values(@v1,@v2,@v3,@v4,@v5)",conn);

            cmd.Parameters.AddWithValue("@v1",prn);
            cmd.Parameters.AddWithValue("@v2",name);
            cmd.Parameters.AddWithValue("@v3",department);
            cmd.Parameters.AddWithValue("@v4",currentYear);
            cmd.Parameters.AddWithValue("@v5","student");
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}