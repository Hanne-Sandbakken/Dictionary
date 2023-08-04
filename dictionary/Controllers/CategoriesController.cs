using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dictionary.Data;
using dictionary.Dto.Category;
using AutoMapper;
using dictionary.Contracts;

namespace dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {

            var categories = await _categoriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCategoryDto>>(categories);
            return Ok(records);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDetailsDto>> GetCategory(int id)
        {
            var category = await _categoriesRepository.GetDetails(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<GetCategoryDetailsDto>(category);

            return Ok(categoryDto);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (id != updateCategoryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var category = await _categoriesRepository.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryDto, category);

            try
            {
                await _categoriesRepository.UpdateAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CreateCategoryDto createCategoryDro)
        {
            var category = _mapper.Map<Category>(createCategoryDro);

            await _categoriesRepository.AddAsync(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoriesRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _categoriesRepository.Exists(id);
        }
    }
}
