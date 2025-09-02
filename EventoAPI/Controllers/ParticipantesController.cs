using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventoAPI.Models;
using System.Text.Json;
using StackExchange.Redis;
using NuGet.Protocol.Plugins;

namespace EventoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly EventosDbContext _context;
        private readonly IConnectionMultiplexer _redis;

        public ParticipantesController(EventosDbContext context, IConnectionMultiplexer redis)
        {
            _context = context;
            _redis = redis;
        }

        // GET: api/Participantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes()
        {
            var redisDB = _redis.GetDatabase();
            string cacheKey = "participanteList";
            var participantesCache = await redisDB.StringGetAsync(cacheKey);
            if (!participantesCache.IsNullOrEmpty)
            {
                return JsonSerializer.Deserialize<List<Participante>>(participantesCache);
            }
            var participantes = await _context.Participantes.ToListAsync();
            await redisDB.StringSetAsync(cacheKey, JsonSerializer.Serialize(participantes), TimeSpan.FromMinutes(10));
            return participantes;
        }

        // GET: api/Participantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
            var redisDB = _redis.GetDatabase();
            string cacheKey = "participante_" + id.ToString();
            var participantesCache = await redisDB.StringGetAsync(cacheKey);
            if (!participantesCache.IsNullOrEmpty)
            {
                return JsonSerializer.Deserialize<Participante>(participantesCache);
            }
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            await redisDB.StringSetAsync(cacheKey, JsonSerializer.Serialize(participante), TimeSpan.FromMinutes(10));
            return participante;
        }

        // PUT: api/Participantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, Participante participante)
        {
            if (id != participante.Id)
            {
                return BadRequest();
            }

            _context.Entry(participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var redisDB = _redis.GetDatabase();
                string cacheKeyList = "participanteList";
                string cacheKey = "participante_" + id.ToString();
                await redisDB.KeyDeleteAsync(cacheKeyList);
                await redisDB.KeyDeleteAsync(cacheKey);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Participantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participante>> PostParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
            var redisDB = _redis.GetDatabase();
            string cacheKeyList = "participanteList";
            await redisDB.KeyDeleteAsync(cacheKeyList);

            return CreatedAtAction("GetParticipante", new { id = participante.Id }, participante);

        }

        // DELETE: api/Participantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            var redisDB = _redis.GetDatabase();
            string cacheKeyList = "participanteList";
            string cacheKey = "participante_" + id.ToString();
            await redisDB.KeyDeleteAsync(cacheKeyList);
            await redisDB.KeyDeleteAsync(cacheKey);

            return NoContent();
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.Id == id);
        }
    }
}
