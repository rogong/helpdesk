using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Models
{
    public class AssignRequest
    {
        public int Id { get; set; }
        public int ITStaffId { get; set; }
        [ForeignKey("ITStaffId")]
        public virtual ITStaff ITStaff { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
