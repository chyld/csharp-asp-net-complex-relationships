using System.Text.Json.Serialization;

namespace web
{
  public class Message
  {
    public int Id { get; set; }
    [JsonIgnore]
    public User FromUser { get; set; }
    [JsonIgnore]
    public User ToUser { get; set; }
    public string Text { get; set; }
  }
}
