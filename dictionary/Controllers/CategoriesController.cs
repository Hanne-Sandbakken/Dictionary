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

namespace dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DictionaryDbContext _context;
        private readonly IMapper _mapper;


        //injecting our DbContext to our Controller:
        //Don't need a new instance of the _context in each controller, because it gets handeled in Program.cs.
        //in that way we can just inject it to the controller like this:
        public CategoriesController(DictionaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            ////er ikke med på udemy-kurset helt enda. derfor kommentert ut
          //if (_context.Categories == null)
          //{
          //    return NotFound();
          //}

          //is the same as saying Select * from Categories.
          var categories = await _context.Categories.ToListAsync();
            var records = _mapper.Map<List<GetCategoryDto>>(categories);
            return Ok(records);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDetailsDto>> GetCategory(int id)
        {
            ////er ikke med på Udemy-kurset enda. derfor kommentert ut. 
          //if (_context.Categories == null)
          //{
          //    return NotFound();
          //}
            var category = await _context.Categories.Include(query => query.Words)
                .FirstOrDefaultAsync(query => query.Id == id);

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

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryDto, category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
            ////er ikke satt inn enda på udemykurset:
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'DictionaryDbContext.Categories'  is null.");
            //}

            //convert into the datatype Category from the datatype coming in(createCategoryDto):
            var category = _mapper.Map<Category>(createCategoryDro);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ////ikke med på udemy-kurset enda. Derfor kommentert ut.
            //if (_context.Categories == null)
            //{
            //    return NotFound();
            //}
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
