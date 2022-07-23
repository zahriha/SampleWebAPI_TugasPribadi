using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SwordTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public TypeEl TypeEl { get; set; }

    }
}
