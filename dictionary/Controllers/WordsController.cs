using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dictionary.Data;
using AutoMapper;
using dictionary.Dto.WordClass;
using dictionary.Repository;

namespace dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWordRepositoy _wordRepository;

        public WordsController(IMapper mapper, IWordRepositoy wordRepository)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordDto>>> GetWords()
        {
          //if (_wordRepository.Words == null)
          //{
          //    return NotFound();
          //}
          //  return await _wordRepository.Words.ToListAsync();

            var words = await _wordRepository.GetAllAsync();
            var records = _mapper.Map<List<GetWordClassDto>>(wordClasses);
            return Ok(records);
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
          if (_wordRepository.Words == null)
          {
              return NotFound();
          }
            var word = await _wordRepository.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _wordRepository.Entry(word).State = EntityState.Modified;

            try
            {
                await _wordRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
          if (_wordRepository.Words == null)
          {
              return Problem("Entity set 'DictionaryDbContext.Words'  is null.");
          }
            _wordRepository.Words.Add(word);
            await _wordRepository.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            if (_wordRepository.Words == null)
            {
                return NotFound();
            }
            var word = await _wordRepository.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _wordRepository.Words.Remove(word);
            await _wordRepository.SaveChangesAsync();

            return NoContent();
        }

        private bool WordExists(int id)
        {
            return (_wordRepository.Words?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
