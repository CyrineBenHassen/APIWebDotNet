
using Microsoft.EntityFrameworkCore;
using System;
using TP6.Data;
using TP6.Models;


namespace TP6.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDbContext _context;

        public CategorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorie>> GetAll() => await _context.Categories.ToListAsync();

        public async Task<Categorie?> GetById(int id) => await _context.Categories.FindAsync(id);

        public async Task<Categorie> Add(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
            return categorie;
        }

        public async Task<Categorie?> Update(int id, Categorie categorie)
        {
            var existing = await _context.Categories.FindAsync(id);
            if (existing == null) return null;

            existing.Name = categorie.Name;
            existing.Description = categorie.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null) return false;

            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
