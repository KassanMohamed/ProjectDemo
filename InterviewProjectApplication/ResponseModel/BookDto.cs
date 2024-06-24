using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.ResponseModel
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public decimal? Price { get; set; }
        public int? Year { get; set; }

        public string MlaCitation { get; set; }

        public string ChicagoCitation { get; set; }
    }
}
