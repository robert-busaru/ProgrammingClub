using System.ComponentModel.DataAnnotations;

namespace ProgrammingClub.Models
{
    public class CodeSnippet
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public int IdMember { get; set; }
        public DateTime Revision { get; set; }
        public int IdSnippetPreviousVersion { get; set; }
        public bool IsPublished { get; set; }

    }
}
