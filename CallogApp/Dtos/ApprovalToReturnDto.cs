using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Dtos
{
    public class ApprovalToReturnDto
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string DateCreated { get; set; }
        public string Name { get; set; }     
        public string Requester { get; set; }
        public string PaymentMode { get; set; }
       
        public string Currency { get; set; }
        
        public string LeagerName { get; set; }
       
        public double AnnualBudget { get; set; }
        public double YTD { get; set; }
        public double CurrentRequest { get; set; }
        public double YTDPercent { get; set; }
        public string Beneficiary { get; set; }
        public string JobDescription { get; set; }
      
        public string Reason { get; set; }
   
        public double TotalCost { get; set; }
     
        public string AdvanceRequired { get; set; }
      
        public string PreparedBy { get; set; }
      
        public string CheckedBy { get; set; }
       
        public string AuthorisedBy { get; set; }
       
        public string ApprovedBy { get; set; }

        public string Department { get; set; }
       
        public string ApprovalLevel { get; set; }

        public string  ApprovedStatus { get; set; }
    }
}
