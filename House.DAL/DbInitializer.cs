namespace House.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(HouseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Houses.Any())
            {
                return;   // DB has been seeded
            }

            var houses = new House.Domain.Models.House[]
            {
                new Domain.Models.House{ Area = 57, City = "Łódź", County = "łódzkie", Price = 800000 },
                new Domain.Models.House{ Area = 65, City = "Kielce", County = "świętokrzyskie", Price = 1000000 },
                new Domain.Models.House{ Area = 104, City = "Łódź", County = "łódzkie", Price = 100000 },
                new Domain.Models.House{ Area = 45, City = "Kielce", County = "świętokrzyskie", Price = 900000 },
                new Domain.Models.House{ Area = 290, City = "Kielce", County = "świętokrzyskie", Price = 2000000 },
            };
            
            foreach(var house in houses)
            {
                context.Houses.Add(house);
            }

            context.SaveChanges();
        }
    }
}
