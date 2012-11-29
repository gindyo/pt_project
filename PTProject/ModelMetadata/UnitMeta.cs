using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PTProject.ModelMetadata
{
    public class UnitMeta
    {
        [Required]
        [DisplayName("Title")]
        public string title { get; set; }
        [DisplayName("Type")]
        public string type { get; set; }
        [DisplayName("Unit Id")]
        public int unit_id { get; set; }

        [DisplayName("In Progress")]
        public bool in_progress { get; set; }

        [DisplayName("Approved")]
        public bool approved { get; set; }

        [DisplayName("Unit Can Be Searched")]
        public bool can_be_searched { get; set; }
    }
}