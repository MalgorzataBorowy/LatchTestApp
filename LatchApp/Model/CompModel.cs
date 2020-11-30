using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LatchApp.Model
{
    public class CompModel : IComponentModel
    {
        public int ComponentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Component type is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Component type must be between 1 and 20 characters")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Component status is required")]
        public bool Status { get; set; }
    }
}
