using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LatchApp.Model
{
    class TestModel : ITestModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Latch ID is required")]
        public int TestID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Latch ID is required")]
        public int LatchID { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "End time is required")]
        public DateTime EndTime { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Test status is required")]
        public bool Status { get;set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Number of cycles is required")]
        public int Cycles { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Video link is required")]
        [RegularExpression(@"([A-Z]:)?\\.*\", ErrorMessage = "Video link is incorrect")]
        public string VideoLink { get; set; }

        public string Comments { get; set; }
    }
}
