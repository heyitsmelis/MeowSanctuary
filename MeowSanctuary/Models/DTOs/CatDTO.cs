namespace MeowSanctuary.Models.DTOs
{
    public class CatDTO
    {
        public CatDTO(object a)
        {
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
    }
}
