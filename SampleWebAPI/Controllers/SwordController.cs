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
    public class SwordController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;

        public SwordController(ISword swordDAL, IMapper mapper)
        {
            _swordDAL = swordDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SwordReadDTO>> Get()
        {
            var result = await _swordDAL.GetAll();
            var swordDTO = _mapper.Map<IEnumerable<SwordReadDTO>>(result);
            return swordDTO;
        }

        [HttpGet("{id}")]
        public async Task<SwordReadDTO> Get(int id)
        {
            var result = await _swordDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan {id} tidak ditemukan");
            var swordDto = _mapper.Map<SwordReadDTO>(result);
            return swordDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _swordDAL.Delete(id);
                return Ok($"Data Sword dengan id {id} berhasil dihapus");
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
                await _swordDAL.DeleteElementInSw(id);
                return Ok($"Data Element Sword dengan id {id} berhasil dihapus");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        [HttpPost("SwType")]
        public async Task<ActionResult> AddSwordType(SwordTypeCreateDTO swordTypeCreateDTO)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordTypeCreateDTO);
                var result = await _swordDAL.AddSwordType(newSword);
                var swordReadDto = _mapper.Map<SwordTypeReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("SW N ELE")]
        public async Task<ActionResult> AddToExistingElement(SwordAddToExistingElementDTO swordAddToExistingElementDTO)
        {
            try
            {

                var newSword = _mapper.Map<Sword>(swordAddToExistingElementDTO);
                var result = await _swordDAL.AddToExistingElement(newSword);
                var swordReadDto = _mapper.Map<SwordElementReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDTO)

        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordCreateDTO);
                var result = await _swordDAL.Insert(newSword);
                var swordReadDto = _mapper.Map<SwordReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(SwordReadDTO swordReadDTO)
        {
            try
            {
                var updateSw = new Sword
                {
                    Id = swordReadDTO.Id,
                    Name = swordReadDTO.Name,
                    Weight = swordReadDTO.Weight,
                    SamuraiId = swordReadDTO.SamuraiId
                    
                };
                var result = await _swordDAL.Update(updateSw);
                return Ok(swordReadDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("SwordType")]

        public async Task<IEnumerable<SwordTypeDTO>> GetSwordType(int page)
        {
            var result = await _swordDAL.GetSwordType();
            var swordDTO = _mapper.Map<IEnumerable<SwordTypeDTO>>(result);
            var pagination = swordDTO.Skip((page - 1) * 10).Take(10).ToList();
            return pagination;
        }
      

        [HttpGet("SwordAll")]

        public async Task<IEnumerable<SwordWithAllDTO>> GetSwordAll()
        {
            var result = await _swordDAL.GetSwordAll();
            var swordDTO = _mapper.Map<IEnumerable<SwordWithAllDTO>>(result);
            return swordDTO;
        }



        [HttpGet("ByName")]
        public async Task<IEnumerable<SwordReadDTO>> GetByName(string name)
        {
            List<SwordReadDTO> swordReadDTOs = new List<SwordReadDTO>();
            var result = await _swordDAL.GetByName(name);
            foreach (var re in result)
            {
                swordReadDTOs.Add(new SwordReadDTO
                {
                    Id = re.Id,
                    Name = re.Name,
                    Weight = re.Weight,
                    SamuraiId = re.SamuraiId
                });
            }
            return swordReadDTOs;
        }

    }
}
