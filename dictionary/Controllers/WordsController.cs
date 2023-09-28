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
using dictionary.Dto.Word;
using dictionary.Contracts;
using dictionary.HeinzelnisseApi;

namespace dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IHeinzelnisseApi _heinzelnisseApi;
        private readonly IMapper _mapper;
        private readonly IWordsRepository _wordRepository;

        public WordsController(IMapper mapper, IWordsRepository wordRepository, IHeinzelnisseApi heinzelnisseApi)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
            _heinzelnisseApi = heinzelnisseApi;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWordDto>>> GetDatabaseWords()
        {
            var words = await _wordRepository.GetAllAsync();
            var records = _mapper.Map<List<GetWordDto>>(words);
            return Ok(records);
        }

        // GET: api/Words
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<GetWordDto>>> GetWords(string search)
        {
            //Hent resultater fra Heinzelnisse API
            var searchResult = await _heinzelnisseApi.GetDetails(search);

            var resultDto = searchResult.Select(result => new GetWordDto
            {
                no = result.no,
                de = result.de,
            });
            return Ok(resultDto);

           ////henter ordene fra eget repository
           // var wordsFromRepo = await _wordRepository.GetAllAsync();
           // var records = _mapper.Map<List<GetWordDto>>(wordsFromRepo);


           // //Legg til resultatene fra API i din eksisterende liste
           // records.AddRange(searchResult.Select(result => new GetWordDto
           // {
           //     //mapper relevant informasjon fra søket til din GetWordDto
           //     no = result.no,
           //     de = result.de,
           // }));
           // return Ok(records);

        }

        //// GET: api/Words/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GetWordDetailsDto>> GetWord(int id)
        //{
        //    var word = await _wordRepository.GetDetails(id);

        //    if (word == null)
        //    {
        //        return NotFound();
        //    }
            
        //    var wordDto = _mapper.Map<GetWordDetailsDto>(word);
        //    return Ok(wordDto);
        //}

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, UpdateWordDto updateWordDto)
        {
            if (id != updateWordDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var word = await _wordRepository.GetAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWordDto, word);

            try
            {
                await _wordRepository.UpdateAsync(word);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WordExist(id))
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
        public async Task<ActionResult<Word>> PostWord(CreateWordDto createWordDto)
        {
            var word = _mapper.Map<Word>(createWordDto);

            await _wordRepository.AddAsync(word);
            return CreatedAtAction("GetWord", new {id = word.Id}, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word = await _wordRepository.GetAsync(id);
            if (word == null)
            {
                return NotFound();
            }
            await _wordRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> WordExist(int id)
        {
            return await _wordRepository.Exists(id);
        }
    }
}
