using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace VivoApi.Entities
{
  public class Users
  {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Cpf { get; set; }

    [JsonIgnore]
    // public string Password { get; set; }
    public byte[] PasswordHash { get; set; }

    [JsonIgnore]
    public byte[] PasswordSalt { get; set; }

    // public byte[] PasswordSalt { get; set; }
    // public virtual string Token { get; set; }
  }

}