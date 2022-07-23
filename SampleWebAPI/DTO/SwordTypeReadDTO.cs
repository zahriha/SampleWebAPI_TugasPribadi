using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SwordTypeReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public TypeEl TypeEl { get; set; }
    }
}
