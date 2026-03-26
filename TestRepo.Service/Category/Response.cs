namespace TetPee.Service.Category;

public class Response
{
    public static class Message
    {
        public static string CreateSuccess = "Created";
    }
    public class CategoryResponse
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}