
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentMIS.Models {
    public class TeacherDataStoreContext {
        public string ConnectionString {get;set;}
        public TeacherDataStoreContext(string connectionString) {
            this.ConnectionString=connectionString;
        }

        private MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }

        public TeacherData GetTeacherDetails(string username) {
            TeacherData stu=new TeacherData();
            MySqlConnection conn= GetConnection();
            conn.Open();


             string query = "select * from teacherdata where username=@v1";
            MySqlCommand cmd= new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@v1",username);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) {
                stu.username=reader.GetString(0);
                stu.id=reader.GetString(1);
                stu.courseId=reader.GetInt32(2);
                stu.year=reader.GetInt32(3);
                stu.semester=reader.GetInt32(4);
            }
            return stu;
        }

        public List<Course> GetCourses() {
            List<Course> list=new List<Course>();
            MySqlConnection con=GetConnection();
            con.Open();

            string query="select * from course";
            MySqlCommand cmd=new MySqlCommand(query,con);

            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()) {
                list.Add(new Course(){
                    courseId=reader.GetInt32(0),
                    title=reader.GetString(1),
                    department=reader.GetString(2),
                    credits=reader.GetInt32(3)
                });
            }
            return list;    
        }

        public void AddCourse(int courseId,string title,string department,int credits) {
            MySqlConnection con=GetConnection();
            con.Open();

            string query="insert into course values(@v1,@v2,@v3,@v4)";
            MySqlCommand cmd=new MySqlCommand(query,con);

            cmd.Parameters.AddWithValue("@v1",courseId);
            cmd.Parameters.AddWithValue("@v2",title);
            cmd.Parameters.AddWithValue("@v3",department);
            cmd.Parameters.AddWithValue("@v4",credits);

            cmd.ExecuteNonQuery();
        }

        public Course GetCourseDetails(int courseId) {
            Course c=new Course();
            MySqlConnection con=GetConnection();
            con.Open();


            string query="select * from course where courseID=@v1";
            MySqlCommand cmd=new MySqlCommand(query,con);

            cmd.Parameters.AddWithValue("@v1",courseId);
            cmd.Prepare();

            var reader= cmd.ExecuteReader();
            if(reader.Read()) {
                 c.courseId=reader.GetInt32(0);
                c.title=reader.GetString(1);
                c.department=reader.GetString(2);
                c.credits=reader.GetInt32(3);
            }
            return c;
        }

        public void UpdateCourse(int courseId,string title,string department,int credits) {
            MySqlConnection con=GetConnection();
            con.Open();

             string query="update course set title=@v1,department=@v2,credits=@v3 where courseId=@v4";
            MySqlCommand cmd=new MySqlCommand(query,con);

            cmd.Parameters.AddWithValue("@v1",title);
            cmd.Parameters.AddWithValue("@v2",department);
            cmd.Parameters.AddWithValue("@v3",credits);
            cmd.Parameters.AddWithValue("@v4",courseId);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void DeleteCourse(int courseId) {
            MySqlConnection con=GetConnection();
            con.Open();


            string query="delete from course where courseID=@v1";
            MySqlCommand cmd=new MySqlCommand(query,con);

            cmd.Parameters.AddWithValue("@v1",courseId);
            cmd.Prepare();

           cmd.ExecuteNonQuery();
        }
    }
}