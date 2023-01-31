using Microsoft.AspNetCore.Mvc.ModelBinding;
using QSIT.Models;
using System.ComponentModel.DataAnnotations;

namespace QSIT.ViewModels
{
    public class FormViewModel
    {
        public int Id { get; set; }
        [Required]
        [Range(minimum: 0.01, maximum: 99,ErrorMessage ="Zero Not Allow")]
        [RegularExpression(@"^[0.01-99]\d{0,1}(\.\d{1,3})?%?$", ErrorMessage = "Must Range from 0.01 to 99 ")]
        public double Raduis { get; set; }
        public bool Geo_Fencing { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{1,3})?%?$",ErrorMessage = "Zero Not Allow , Accept Max 3 digits or 3 decimal")]
        public double Location { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{1,3})?%?$", ErrorMessage = "Zero Not Allow , Accept Max 3 digits or 3 decimal")]
        public int Time { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{1,3})?%?$", ErrorMessage = "Zero Not Allow , Accept Max 3 digits or 3 decimal")]
        public int Duration { get; set; }

        public string? MapName { get; set; }

        public string? MapSubTypeName{get; set;}

        public int MapTypeId { get; set; }
        public IEnumerable<Map_Type>? Map_Types { get; set; }

        public int MapSupTypeId { get; set; }
        public IEnumerable<Map_Sub_Type>? Map_Sub_Types { get; set; } = new List<Map_Sub_Type>();
    }
}
