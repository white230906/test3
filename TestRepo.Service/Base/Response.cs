namespace TetPee.Service.Base;

public class Response
{
   public class PageResult<T>
   {
      public List<T> Items { get; set; } = new List<T>();
      public int totalItems { get; set; }
      public int pageSize { get; set; }
      public int pageIndex { get; set; }
   }
}