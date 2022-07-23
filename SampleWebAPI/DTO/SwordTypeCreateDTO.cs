using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SwordTypeCreateDTO
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public TypeCreateNoIdDTO TypeEl { get; set; }
    }
}
