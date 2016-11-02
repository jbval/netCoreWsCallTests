namespace ConsoleApplication.Entities
{
    public class Message
    {
        public string AuthorizationToken { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public bool IsImportant { get; set; }
    }
}