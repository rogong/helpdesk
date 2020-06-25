using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Dtos
{
    public class RequestToReturnDto
    {

        public int Id { get; set; }
    
        public string Status { get; set; }

        public string UserId { get; set; }

        public string DateCreated { get; set; }

        public string ResponseDate { get; set; }

        public string RespondedDate { get; set; }
        public string ResolvedDate { get; set; }
        public string UpdatedAt { get; set; }

        public string Department { get; set; }
    
        public string Issue { get; set; }
      
        public string Device { get; set; }
     
        public string Subject { get; set; }
     
        public string Message { get; set; }
        
        public string ITStaff { get; set; }

        public string ResolvedBy { get; set; }

        public string Resolution { get; set; }

        public string DepartmentOwner { get; set; }

        public string isCancel { get; set; }

        public int ResponseTimeTaken()
        {
            return Int32.Parse(ResponseDate);
        }


    }
}
