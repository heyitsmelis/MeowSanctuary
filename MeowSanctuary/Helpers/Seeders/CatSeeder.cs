using MeowSanctuary.Data;
using MeowSanctuary.Models;

namespace MeowSanctuary.Helpers.Seeders
{
    public class CatSeeder
    {
        public readonly SanctuaryContext _context;

        public CatSeeder(SanctuaryContext context)
        {
            _context = context;
        }

        public void SeedInitialCats()
        {
            if (!_context.Cats.Any())
            {
                var cat1 = new Cat
                {
                    Name = "Kitty",
                    Age = 3,
                    Breed = "Persian",
                    Color = "Brown"
                };

                var cat2 = new Cat
                {
                    Name = "Gatito",
                    Age = 4,
                    Breed = "Siamese",
                    Color = "White"
                };

                _context.Add(cat1);
                _context.Add(cat2);

                _context.SaveChanges();
            }
        }
    }
}
