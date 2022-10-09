using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.Data
{
    public class MeetingTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? InsertUserDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateUserDate { get; set; }
    }
}
