namespace SampleWebAPI.DTO
{
    public class SamuraiWithAll
    {
   
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<SwordWithAllDTO> Swords { get; set; } = new List<SwordWithAllDTO>();

    }
}
