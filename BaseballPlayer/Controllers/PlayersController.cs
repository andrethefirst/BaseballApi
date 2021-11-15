using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseballPlayer.Models;
using System.Linq;

namespace BaseballPlayer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayersController : ControllerBase
  {
    private readonly BaseballPlayerContext _db;

    public PlayersController(BaseballPlayerContext db)
    {
      _db = db;
    }

    // GET api/players
    [HttpGet]
    public async Task <ActionResult<PaginationModel>> Get(string position, string team, string name, int page, int perPage)
    {
      var query = _db.Players.AsQueryable();
      if (position != null)
      {
        query = query.Where(entry => entry.Position == position);
      }
      if (team != null)
      {
        query= query.Where(entry => entry.Team == team);
      }
      if (name !=null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      List<Player> players = await query.ToListAsync();

      if (perPage == 0) perPage = 3;

      int total = players.Count;
      List<Player> playerPage = new List<Player>();
      
      if(page < (total / perPage))
      {
        playerPage = players.GetRange(page * perPage, perPage);
      }

      if (page == (total/perPage))
      {
        playerPage = players.GetRange(page * perPage, total - (page * perPage));
      }

      return new PaginationModel()
      {
        Data = playerPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = page == 0 ? "No previous page" : $"/api/players?page={page - 1}&perPage={perPage}",
        NextPage = page == total/perPage ? "No next page" : $"/api/players?page={page + 1}&perPage={perPage}"
      };
    }

    // POST api/players
    [HttpPost]
    public async Task<ActionResult<Player>> Post(Player player)
    {
      _db.Players.Add(player);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
    }

    // GET: api/Players/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayer(int id)
    {
      var player = await _db.Players.FindAsync(id);

      if(player == null)
      {
        return NotFound();
      }

      return player;
    }

    // PUT: api/Players/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Player player)
    {
      if (id != player.PlayerId)
      {
        return BadRequest();
      }

      _db.Entry(player).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PlayerExists(id))
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
     // DELETE: api/Players/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
      var player = await _db.Players.FindAsync(id);
      if (player == null)
      {
        return NotFound();
      }

      _db.Players.Remove(player);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool PlayerExists(int id)
    {
      return _db.Players.Any(e => e.PlayerId == id);
    }

    // [HttpGet]
    // public IActionResult GetPlayers([FromQuery] UrlQuery urlQuery)
    // {
    //   IEnumerable<Player> players = null;

      
 
        
    //     string sql = @"SELECT PlayerId, JerseyNumber, Name, Team FROM Player";

    //     if(urlQuery.PageNumber.HasValue)
    //     {
    //       sql += @" ORDER BY Player.PlayerPK
    //         OFFSET @PageSize * (@PageNumber -1) ROWS
    //         FETCH NEXT @PageSize ROWS ONLY";
    //     }
    //     players = _db.Players.Query<Player>(sql, urlQuery);
      

    //   return Ok(players);
    // }
    //       [HttpGet]
    // public ActionResult<IEnumerable<Player>> Get(UrlQuery urlQuery) // [FromQuery]
    // {
    //   var query = _db.UrlQuerys.AsQueryable();
    //   if (pageNumber !=null)
    //   {
    //     query = query.Where(entry => entry.PageNumber == PageNumber);
    //   }
    //   return query.ToList();
    // } 
  }
}