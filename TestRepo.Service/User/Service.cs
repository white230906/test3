using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateUser(Request.UserRequest request)
    {
        var isEmailQuery = _dbContext.Users.Where(u => u.Email == request.Email);
        var isEmailExist = await isEmailQuery.AnyAsync();
        if (isEmailExist)
        {
            throw new Exception("Email already exists");
        }
        var newUser = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User"
        };
        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return Response.Message.CreateSuccess;
    }

    public async Task<Base.Response.PageResult<Response.UserResponse>> ListUsers(string? searchTerm, int pageIndex, int pageSize)
    {
        var query =  _dbContext.Users.Where(u => true);
        if (searchTerm != null)
        {
            query = _dbContext.Users.Where(u => u.Email == searchTerm);
        }
        query  = query.OrderBy(u => u.Email);
        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        var selectedQuery = query.Select(u => new Response.UserResponse()
        {
            Email = u.Email,
            Password = u.Password,
            Role = u.Role
        });
        var pageResult = await selectedQuery.ToListAsync();
        var totalItems =  pageResult.Count;
        var result = new Base.Response.PageResult<Response.UserResponse>()
        {
            Items = pageResult,
            totalItems = totalItems,
            pageIndex = pageIndex,
            pageSize = pageSize
        };
        return result;
        
    }
}