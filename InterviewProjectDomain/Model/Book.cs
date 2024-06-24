using System.ComponentModel.DataAnnotations;

namespace InterviewProjectDomain.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; } 
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? Year { get; set; }
        public string? PlaceOfPublication { get; set; }


        // MLA citation property
        public string MlaCitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. *{Title}*. {Publisher}, {Year}.";
            }
        }


        // Chicago citation property
        public string ChicagoCitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. {Title}. {PlaceOfPublication}: {Publisher}, {Year}.";
            }
        }
    }
}