namespace Imoty.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Models;

    public class ConstructionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Constructions.Any())
            {
                return;
            }

            await dbContext.Constructions.AddAsync(new Construction { Name = "Brick" });
            await dbContext.Constructions.AddAsync(new Construction { Name = "Panel" });
            await dbContext.Constructions.AddAsync(new Construction { Name = "Stone" });

            await dbContext.SaveChangesAsync();
        }
    }
}
