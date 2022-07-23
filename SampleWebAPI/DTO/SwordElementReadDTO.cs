using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SwordElementReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; } 
        public List<ElementReadDTO> Elements { get; set; } = new List<ElementReadDTO>();
    }

}
