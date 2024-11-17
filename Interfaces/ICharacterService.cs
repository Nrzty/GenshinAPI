using GenshinAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenshinAPI.Interfaces
{

    public interface ICharacterService
    {

        Task<IEnumerable<Character>> GetAllCharacters();
        Task<Character> GetByIdAsync(int id);
        Task AddAsync(Character character);

    }

}