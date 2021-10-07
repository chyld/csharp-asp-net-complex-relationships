using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace web
{

  [ApiController]
  [Route("api/messages")]
  public class MessageController : ControllerBase
  {
    private Database _db;

    public MessageController(Database db)
    {
      _db = db;
    }

    //  POST http://localhost:5001/api/messages/sara/bob/hey
    [HttpPost("{fromId}/{toId}/{message}")]
    public async Task<IActionResult> SendMessage(int fromId, int toId, string message)
    {
      var u1 = await _db.Users.Where(u => u.Id == fromId).SingleOrDefaultAsync();
      var u2 = await _db.Users.Where(u => u.Id == toId).SingleOrDefaultAsync();
      var m = new Message() { FromUser = u1, ToUser = u2, Text = message };
      await _db.AddAsync(m);
      await _db.SaveChangesAsync();
      return Ok(m);
    }

    //  GET http://localhost:5001/api/messages/to/sara
    [HttpPost("to/{toId}")]
    public async Task<IActionResult> GetReceivedMessages(int toId)
    {
      var u = await _db.Users.Where(u => u.Id == toId).Include(u => u.ReceivedMessages).SingleOrDefaultAsync();
      var messages = u.ReceivedMessages;
      return Ok(messages);
    }

    //  GET http://localhost:5001/api/messages/from/sara
    [HttpPost("from/{fromId}")]
    public async Task<IActionResult> GetSentMessages(int fromId)
    {
      var u = await _db.Users.Where(u => u.Id == fromId).Include(u => u.SentMessages).SingleOrDefaultAsync();
      var messages = u.SentMessages;
      return Ok(messages);
    }
  }
}
