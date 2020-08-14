using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        [DisplayName("Status")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public string UserId { get; set; }

        [Required]
        [DisplayName("Created At")]
        public DateTime DateCreated { get; set; }
        [DisplayName("Date Resolved")]
        public string DateResolved { get; set; }

        [DisplayName("Response Time")]
        public TimeSpan ResponseDate { get; set; }

        [DisplayName("Responded At")]
        public string RespondedDate { get; set; }

        [DisplayName("Resolved At")]
        public TimeSpan ResolvedDate { get; set; }

        [DisplayName("Updated At")]
        public DateTime UpdatedAt { get; set; }

        [DisplayName("Departments")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [DisplayName("Issues")]
        public int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issue { get; set; }

        [DisplayName("Device")]
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Devices Device { get; set; }
      
        [Required]
        public string Subject { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [DisplayName("Assign To")]
        public int ITStaffId { get; set; }
        [ForeignKey("ITStaffId")]
        public virtual ITStaff ITStaff { get; set; }

        [DisplayName("Resolved By")]
        public string ResolvedBy { get; set; }

        public string Resolution { get; set; }
       
        public string DepartmentOwner  { get; set; }

        public int LevelId { get; set; }
        [DisplayName("Priority")]
        public virtual Level Level { get; set; }
        public Boolean isCancel { get; set; }

        //[Required(ErrorMessage = "You must enter the reason for delay.")]
        [Display(Name = "Reason for delay")]
       
        public string ReasonForHigh { get; set; }


        public int step { get; set; }

        public string OtherIssue { get; set; }

        public string OtherDevice { get; set; }

        public string ResponseInterval { get; set; }

        public string ResolutionInterval { get; set; }

        public string PhotoUrl { get; set; }


    }
}
