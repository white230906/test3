using Microsoft.AspNetCore.Mvc;
using TetPee.Repository.Entity;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IService _categoryService;
    
    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CategoryRequest request)
    {
        var newCategory = await _categoryService.CreateCategory(request);
        return Ok(newCategory);
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        var newCategory = await _categoryService.GetAllCategories();
        return Ok(newCategory);
    }
    [HttpGet("{parentId}/children")]
    public async Task<IActionResult> GetAllChildrenByParentId(Guid parentId)
    {
        var newCategory = await _categoryService.GetAllChildrenByParentId(parentId);
        return Ok(newCategory);
    }
}