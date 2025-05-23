namespace ProgrammingClub.Models
{
    public class CodeSnippet
    {
        public uint IdCodeSnippet { get; set; }
        public string Title { get; set; }
        public string ContentCode {  get; set; }
        public int IdMember { get; set; }
        public DateTime Revision {  get; set; }
        public int IdSnippetPreviousVersion { get; set; }
        public bool IsPublished { get; set; }

    }
}
