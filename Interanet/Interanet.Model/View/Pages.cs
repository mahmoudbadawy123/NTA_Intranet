using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View
{
    public class Page
    {
        [Required]
        public Int32 TotalElements { get; set; }
        [Required]
        public Int32 PageNumber { get; set; }
        [Required]
        public Int32 Size { get; set; } = 5;

        public string Filter { get; set; } 
        

    }
}
