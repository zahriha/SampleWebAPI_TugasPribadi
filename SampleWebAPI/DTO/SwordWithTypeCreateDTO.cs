using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SwordWithTypeCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ElementReadDTO> Elements { get; set; }=new List<ElementReadDTO>();
        public TypeCreateDTO TypeEl { get; set; }


    }
}
