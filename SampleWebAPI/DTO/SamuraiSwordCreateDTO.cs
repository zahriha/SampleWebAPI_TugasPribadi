using SampleWebAPI.Domain;

namespace SampleWebAPI.DTO
{
    public class SamuraiSwordCreateDTO
    {
        public string Name { get; set; }
        public List<SwordCreateNoSamuraiInputDTO> Swords { get; set; }= new List<SwordCreateNoSamuraiInputDTO>();

    }
}
