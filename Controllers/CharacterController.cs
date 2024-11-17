using GenshinAPI.Data;
using GenshinAPI.Interfaces;
using GenshinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService, ApplicationDbContext context)
        {
            _characterService = characterService;
            _context = context;
        }

        // MÉTODO CREATE
        [HttpPost]
        public async Task<ActionResult> AddCharacter(Character character)
        {
            await _characterService.AddAsync(character);

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character); // HTTP 201
        }

        // MÉTODO READ - Pega todos os personagens do banco de dados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetPersonagens()
        {
            // Retorna todos os personagens.
            return Ok(await _characterService.GetAllCharacters()); // HTTP 200 (OK)
        }

        // MÉTODO READ POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _characterService.GetByIdAsync(id);

            // Se o personagem não existir
            if (character == null)
            {
                return NotFound();  // HTTP 404.
            }

            return Ok(character);  // HTTP 200 (OK)
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCharacter(int id, Character character)
        {
            if (id != character.Id)
            {          // HTTP 400
                return BadRequest(new { message = "Id não encontrado!" });
            }

            var characterFromDB = _context.Characters.Find(id);

            if (characterFromDB == null)
            {          // HTTP 404
                return NotFound(new { message = "Personagem não encontrado pra atualizar!" });
            }

            characterFromDB.Name = character.Name;
            characterFromDB.Element = character.Element;
            characterFromDB.Weapon = character.Weapon;
            characterFromDB.Rarity = character.Rarity;
            characterFromDB.Desc = character.Desc;
            characterFromDB.Launch = character.Launch;
            characterFromDB.BaseHP = character.BaseHP;
            characterFromDB.BaseATK = character.BaseATK;
            characterFromDB.BaseDEF = character.BaseDEF;

            _context.SaveChanges();

            return Ok(characterFromDB); // HTTP 200

        }

        [HttpPatch("{id}")]
        public IActionResult PatchCharacter(int id, [FromBody] JsonPatchDocument<Character> patchDoc)
        {
            if (patchDoc == null)
            {          // HTTP 400
                return BadRequest(new { message = "Corpo do Patch inválido!" });
            }

            var characterFromDB = _context.Characters.Find(id);

            if (characterFromDB == null)
            {
                return NotFound(new { message = "Personagem não encontrado pra atualizar!" });
            }

            patchDoc.ApplyTo(characterFromDB);

            _context.SaveChanges();

            return Ok(characterFromDB); // HTTP 200

        }

        // MÉTODO DELETE {ID}- 
        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var character = _context.Characters.Find(id);

            if (character == null)
            {
                return NotFound(new { message = "Personagem Não Encontrado !" }); // HTTP 404
            }

            _context.Characters.Remove(character);
            _context.SaveChanges();

            return NoContent();  // HTTP 204
        }
    }
}
