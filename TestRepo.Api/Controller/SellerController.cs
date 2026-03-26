using Microsoft.AspNetCore.Mvc;
using TetPee.Service.JwtService;
using TetPee.Service.Seller;
using IService = TetPee.Service.Seller.IService;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class SellerController: ControllerBase
{
    private readonly IService _sellerService;
    public  SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSeller(Request.SellerRequest sellerRequest)
    {
        var newSeller = await _sellerService.CreateSeller(sellerRequest);
        return Ok(newSeller);
    }
}