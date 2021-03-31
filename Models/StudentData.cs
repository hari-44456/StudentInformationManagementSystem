
namespace StudentMIS.Models  
{  
    public class StudentData
    {  
        private StudentDataStoreContext context;  
  
        public string prn { get; set; }

        public string name { get;set; }
 
        public string department { get;set; }
        
        public string currentYear { get;set; }
    }  
}