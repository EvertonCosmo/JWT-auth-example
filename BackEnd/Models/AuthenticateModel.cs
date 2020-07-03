using System.ComponentModel.DataAnnotations;
namespace VivoApi.Models.Users
{
  public class AuthenticateModel
  {
    [Required]
    public string Cpf { get; set; }

    [Required]
    public string Password { get; set; }



  }
}