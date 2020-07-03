using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AutoMapper;
using VivoApi.Data;
using VivoApi.Models.Users;
using VivoApi.Services;
using VivoApi.Helpers;
using VivoApi.Entities;
namespace VivoApi.Controllers
{


  [Authorize]
  [ApiController]
  [Route("account")]
  public class AccountController : ControllerBase
  {
    private readonly ApplicationDbContext applicationDb;
    private readonly IAccountService accountService;
    private readonly AppSettings appSettings;
    private readonly IMapper mapper;
    public AccountController(ApplicationDbContext _applicationDb, IMapper _mapper, IOptions<AppSettings> _appSettings, IAccountService _accountService)
    {
      applicationDb = _applicationDb;
      accountService = _accountService;
      appSettings = _appSettings.Value;
      mapper = _mapper;
    }


    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] AuthenticateModel model)
    {
      var user = accountService.Authenticate(model.Cpf, model.Password);

      if (user == null)
        return BadRequest(new { message = "cpf or password wrong" });

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
        Expires = DateTime.UtcNow.AddMinutes(30),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var Createdtoken = tokenHandler.CreateToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(Createdtoken);
      return Ok(new { user, token });
    }


    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
      Users user = mapper.Map<Users>(model);
      try
      {
        accountService.Create(user, model.Password);
        return Ok();
      }
      catch (AppException e)
      {
        return BadRequest(new { message = e.Message });
      }
    }
    [AllowAnonymous]
    [HttpGet("all")]
    public IActionResult GetAll()
    {
      var users = accountService.GetAll();
      return Ok(users);
    }

  }

}