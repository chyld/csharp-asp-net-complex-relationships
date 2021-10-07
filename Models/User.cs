using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web
{
  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    [InverseProperty("FromUser")]
    public List<Message> SentMessages { get; set; }
    [InverseProperty("ToUser")]
    public List<Message> ReceivedMessages { get; set; }
  }
}
