using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cosmetics_Bll;
using Cosmetics_Dal.Models;
using CosmeticsDTO;
using System.Collections.Generic;

namespace Cosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBLL categoryBLL;
        private readonly IMapper mapper;

        public CategoryController(ICategoryBLL _categoryBLL)
        {
            categoryBLL = _categoryBLL;

            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            List<Categories> list = categoryBLL.GetAllCategories();
            var dtoLines = mapper.Map<IEnumerable<CategoryDTO>>(list);
            return Ok(dtoLines);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> Get(int id)
        {
            var category = categoryBLL.GetCategoriesById(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} does not exist.");
            }
            return Ok(mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest("Category data payload cannot be empty.");
            }

            Categories category = mapper.Map<Categories>(newCategory);
            if (category == null)
            {
                return StatusCode(500, "Mapping failed. Please check AutoMapper profile configurations.");
            }

            // Fixed: Changed from AddCategories to addCategories to match your interface
            categoryBLL.addCategories(category);
            return Ok("Category created successfully.");
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryDTO updateCategory)
        {
            if (updateCategory == null)
            {
                return BadRequest("Update payload data cannot be null.");
            }

            Categories category = mapper.Map<Categories>(updateCategory);

            if (category == null)
            {
                return StatusCode(500, "Failed to parse data payload onto model entity.");
            }

            try
            {
                categoryBLL.UpdateCategories(category);
                return Ok("Category updated successfully.");
            }
            catch (System.ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryBLL.DeleteCategories(id);
            return Ok("Category deleted successfully.");
        }
    }
}