using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateCategory(Request.CategoryRequest categoryRequest)
    {
        var isNameQuery = _dbContext.Categories.Where(x => x.Name == categoryRequest.Name);
        var isNameExist = await isNameQuery.AnyAsync();
        if (isNameExist)
        {
            throw new Exception("Category already exists");
        }

        var newCategory = new Repository.Entity.Category()
        {
            Name = categoryRequest.Name,
            ParentId = categoryRequest.ParentId
        };
        _dbContext.Add(newCategory);
        await _dbContext.SaveChangesAsync();
        return Response.Message.CreateSuccess;
    }

    public async Task<List<Response.CategoryResponse>> GetAllCategories()
    {
        var query = _dbContext.Categories.Where(x => true);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.CategoryResponse()
        {
            Id = x.Id,
            Name = x.Name
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.CategoryResponse>> GetAllChildrenByParentId(Guid parentId)
    {
        var query = _dbContext.Categories.Where(x => x.ParentId == parentId);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.CategoryResponse()
        {
            Id = x.Id,
            Name = x.Name
        });
        var result = await selectedQuery.ToListAsync();
        return result;

    }
}