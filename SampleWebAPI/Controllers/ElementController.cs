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
    public class ElementController : ControllerBase
    {
        private readonly IElement _elementDAL;
        private readonly IMapper _mapper;

        public ElementController(IElement elementDAL, IMapper mapper)
        {
            _elementDAL = elementDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ElementReadDTO>> Get()
        {
            var result = await _elementDAL.GetAll();
            var elementDT = _mapper.Map<IEnumerable<ElementReadDTO>>(result);
            return elementDT;
        }

        [HttpGet("{id}")]
        public async Task<ElementReadDTO> Get(int id)
        {
            var result = await _elementDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var eleDT = _mapper.Map<ElementReadDTO>(result);
            return eleDT;

        }
        [HttpPost]
        public async Task<ActionResult> Post(ElementCreateDTO elementcreate)
        {
            try
            {
                var newElement = _mapper.Map<Element>(elementcreate);
                var result = await _elementDAL.Insert(newElement);
                var elRead = _mapper.Map<ElementReadDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, elRead);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<ActionResult> Put(ElementReadDTO elementReadDTO)
        {
            try
            {
                var upElement = new Element
                {
                    Id = elementReadDTO.Id,
                    ElementName = elementReadDTO.ElementName
                };
                var result = await _elementDAL.Update(upElement);
                return Ok(elementReadDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _elementDAL.Delete(id);
                return Ok($"Data samurai dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteElementInSw")]
        public async Task<ActionResult> DeleteElementInSw(int id)
        {
            try
            {
                await _elementDAL.DeleteElementInSw(id);
                return Ok($"Data Element Sword dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("ByName")]
        public async Task<IEnumerable<ElementReadDTO>> GetByName(string name)
        {
            List<ElementReadDTO> elementReadDTOs = new List<ElementReadDTO>();
            var result = await _elementDAL.GetByName(name);
            foreach (var re in result)
            {
                elementReadDTOs.Add(new ElementReadDTO
                {
                    Id= re.Id,
                    ElementName = re.ElementName
                });
                
            }
            return elementReadDTOs;
        }


    }
}
