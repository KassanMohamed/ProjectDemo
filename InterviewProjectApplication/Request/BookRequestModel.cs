using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Request
{
    public class BookRequestModel
    {
        [Required]
        public string? Publisher { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? AuthorLastName { get; set; }
        [Required]
        public string? AuthorFirstName { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public string? PlaceOfPublication { get; set; }
    }
}
