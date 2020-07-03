using System.ComponentModel.DataAnnotations;



namespace VivoApi.Models.Users
{

  public class RegisterModel
  {
    [Required]
    public string cpf { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Password { get; set; }


  }
}