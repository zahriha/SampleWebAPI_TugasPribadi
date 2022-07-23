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
    public class TypeElController : ControllerBase
    {
        private readonly ITypeEl _typeSw;
        private readonly IMapper _mapper;

        public TypeElController(ITypeEl typeSw, IMapper mapper)
        {
            _typeSw = typeSw;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeReadDTO>> Get()
        {
            var result= await _typeSw.GetAll();
            var typeReadDTOs = _mapper.Map<IEnumerable<TypeReadDTO>>(result);
            return typeReadDTOs;
        }

        [HttpGet("{id}")]
        public async Task<TypeReadDTO> Get(int id)
        {
            var result= await _typeSw.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan {id} tidak ditemukan");
            var typeDt = _mapper.Map<TypeReadDTO>(result);
            return typeDt;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _typeSw.Delete(id);
                return Ok($"Data dengan id {id} berhasil dihapus");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(TypeCreateDTO typeCreateDTO)
        {
            try
            {
                var newType = _mapper.Map<TypeEl>(typeCreateDTO);
                var result = await _typeSw.Insert(newType);
                var TypeReadDt = _mapper.Map<TypeReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, TypeReadDt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
              
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(TypeReadDTO typeReadDTO)
        {
            try
            {
                var updateType = new TypeEl
                {
                    Id = typeReadDTO.Id,
                    TypeE = typeReadDTO.TypeE,
                    SwordId = typeReadDTO.SwordId
                };
                var result = await _typeSw.Update(updateType);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
