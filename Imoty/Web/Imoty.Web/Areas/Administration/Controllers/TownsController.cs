namespace Imoty.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class TownsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Town> townsRepository;

        public TownsController(IDeletableEntityRepository<Town> townsRepository)
        {
            this.townsRepository = townsRepository;
        }

        // GET: Administration/Towns
        public async Task<IActionResult> Index()
        {
            return this.View(await this.townsRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Administration/Towns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || this.townsRepository == null)
            {
                return this.NotFound();
            }

            var town = await this.townsRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (town == null)
            {
                return this.NotFound();
            }

            return this.View(town);
        }

        // GET: Administration/Towns/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Towns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Town town)
        {
            if (this.ModelState.IsValid)
            {
                await this.townsRepository.AddAsync(town);
                await this.townsRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(town);
        }

        // GET: Administration/Towns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.townsRepository == null)
            {
                return this.NotFound();
            }

            var town = await this.townsRepository.All().FirstOrDefaultAsync(m => m.Id == id);
            if (town == null)
            {
                return this.NotFound();
            }

            return this.View(town);
        }

        // POST: Administration/Towns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Town town)
        {
            if (id != town.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.townsRepository.Update(town);
                    await this.townsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TownExists(town.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(town);
        }

        // GET: Administration/Towns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.townsRepository == null)
            {
                return this.NotFound();
            }

            var town = await this.townsRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (town == null)
            {
                return this.NotFound();
            }

            return this.View(town);
        }

        // POST: Administration/Towns/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.townsRepository == null)
            {
                return this.Problem("Entity set 'ApplicationDbContext.Towns'  is null.");
            }

            var town = this.townsRepository.All().FirstOrDefault(m => m.Id == id);
            if (town != null)
            {
                this.townsRepository.Delete(town);
            }

            await this.townsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool TownExists(int id)
        {
          return this.townsRepository.All().Any(e => e.Id == id);
        }
    }
}
