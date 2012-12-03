using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PTProject.ModelMetadata
{
    public class UserMeta
    {
        [Required]
        [Display(Name = "Email")]
        string email { get; set; }
    }
}