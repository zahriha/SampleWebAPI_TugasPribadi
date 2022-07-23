using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwordElementController : ControllerBase
    {
        private readonly IElementSword _swordElement;
        private readonly IMapper _mapper;

        public SwordElementController(IElementSword swordElement, IMapper mapper)
        {
            _swordElement = swordElement;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Post(ElementSwordDTO elementSwordDTO)

        {
            try
            {
                var newSword = _mapper.Map<ElementSword>(elementSwordDTO);
                var result = await _swordElement.Insert(newSword);
                var swordReadDto = _mapper.Map<ElementSwordReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.ElementId }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("ElemenSw")]
        public async Task<ActionResult> AddElementSword(ElementSwordDTO elementSwordDTO)

        {
            try
            {
                var newSword = _mapper.Map<ElementSword>(elementSwordDTO);
                var result = await _swordElement.AddElementSword(newSword);
                var swordReadDto = _mapper.Map<ElementSwordReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.ElementId }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet]
        public async Task<IEnumerable<ElementSwordReadDTO>> Get()
        {
            var result = await _swordElement.GetAll();
            var eleSwDT = _mapper.Map<IEnumerable<ElementSwordReadDTO>>(result);
            return eleSwDT;

        }

        [HttpDelete("DeleteElementInSword")]
        public async Task<ActionResult> DeleteElementInSw(int id)
        {
            try
            {
                await _swordElement.DeleteElementInSword(id);
                return Ok($"Data Element Sword dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
    }
}
