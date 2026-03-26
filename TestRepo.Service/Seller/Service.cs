using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<string> CreateSeller(Request.SellerRequest sellerRequest)
    {
        var isEmailQuery = _dbContext.Users.Where(x => x.Email == sellerRequest.Email);
        var isEmailExit = await isEmailQuery.AnyAsync();
        if (isEmailExit)
        {
            throw new Exception("Email is already in use");
        }

        var user = new Repository.Entity.User()
        {
            Email = sellerRequest.Email,
            Password = sellerRequest.Password,
            Role = "Seller"
        };
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        var seller = new Repository.Entity.Seller()
        {
            UserId = user.Id,
            TaxCode = sellerRequest.TaxCode,
            CompanyName = sellerRequest.CompanyName,
            CompanyAddress = sellerRequest.CompanyAddress,
        };
        _dbContext.Add(seller);
        await _dbContext.SaveChangesAsync();
        return Response.Message.CreateSuccess;
    }
}