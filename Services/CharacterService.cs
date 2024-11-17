using GenshinAPI.Data;
using GenshinAPI.Interfaces;
using GenshinAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GenshinAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task AddAsync(Character personagem)
        {
            _context.Characters.Add(personagem);
            await _context.SaveChangesAsync();
        }
    }
}
