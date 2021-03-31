
namespace StudentMIS.Models  
{  
    public class TeacherData
    {  
        private TeacherDataStoreContext context;  
  
        public string username { get; set; }

        public string id { get;set; }
 
        public int courseId { get;set; }
        
        public int semester { get;set; }
        
        public int year { get;set; }
    }  
}