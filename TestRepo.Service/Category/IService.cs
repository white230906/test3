namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CategoryRequest categoryRequest);
    public Task<List<Response.CategoryResponse>> GetAllCategories();
    public Task<List<Response.CategoryResponse>> GetAllChildrenByParentId(Guid parentId);
}