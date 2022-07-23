using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SamuraiSwordReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordReadDTO> Swords { get; set; } = new List<SwordReadDTO>();

    }
}
