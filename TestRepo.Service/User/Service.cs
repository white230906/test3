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
        // var user = _dbContext.Users.FirstOrDefault(u => u.Email == request.Email);
        // if (user != null)
        // {
        //     throw new Exception("User already exists");
        // }
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
            Role = "USer"
        };
        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return Response.Message.CreateSuccess;
    }
}