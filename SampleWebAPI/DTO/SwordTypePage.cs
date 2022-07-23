namespace SampleWebAPI.DTO
{
    public class SwordTypePage
    {
        public List<SwordTypeDTO> Swords { get; set; } = new List<SwordTypeDTO>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

    }
}
