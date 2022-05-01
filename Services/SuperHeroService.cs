using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService
    {

        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> Get()
        {
            return await _context.SuperHeroes.ToListAsync();
        }


        public async Task<SuperHero> Get(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return hero;
        }

        public async Task<SuperHero> UpdateHero(SuperHero request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return dbHero;
        }

        public async Task<SuperHero> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return dbHero;
        }
    }
}
