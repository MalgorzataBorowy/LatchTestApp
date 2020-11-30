using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LatchApp.Model
{
    public class LatchModel : ILatchModel
    {
        public int LatchID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Latch type is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Latch type must be between 1 and 20 characters")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Component ID is required")]
        public int ComponentID { get; set; }
    }
}
