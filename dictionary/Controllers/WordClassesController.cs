using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dictionary.Data;
using dictionary.Dto.WordClass;
using AutoMapper;
using dictionary.Contracts;

namespace dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordClassesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWordClassRepository _wordClassesRepository;

        public WordClassesController(IMapper mapper, IWordClassRepository wordClassesRepository)
        {
            _mapper = mapper;
            _wordClassesRepository = wordClassesRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWordClassDto>>> GetWordClasses()
        {

            var wordClasses = await _wordClassesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetWordClassDto>>(wordClasses);
            return Ok(records);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetWordClassDetailsDto>> GetWordClass(int id)
        {
            var wordClass = await _wordClassesRepository.GetDetails(id);

            if (wordClass == null)
            {
                return NotFound();
            }

            var wordClassDto = _mapper.Map<GetWordClassDetailsDto>(wordClass);

            return Ok(wordClassDto);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWordClass(int id, UpdateWordClassDto updateWordClassDto)
        {
            if (id != updateWordClassDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var wordClass = await _wordClassesRepository.GetAsync(id);

            if (wordClass == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWordClassDto, wordClass);

            try
            {
                await _wordClassesRepository.UpdateAsync(wordClass);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WordClassExists(id))
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
        public async Task<ActionResult<WordClass>> PostWordClass(CreateWordClassDto createWordClassDro)
        {
            var wordClass = _mapper.Map<WordClass>(createWordClassDro);

            await _wordClassesRepository.AddAsync(wordClass);
            return CreatedAtAction("GetWordClass", new { id = wordClass.Id }, wordClass);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWordClass(int id)
        {
            var wordClass = await _wordClassesRepository.GetAsync(id);
            if (wordClass == null)
            {
                return NotFound();
            }

            await _wordClassesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WordClassExists(int id)
        {
            return await _wordClassesRepository.Exists(id);
        }
    }
}
