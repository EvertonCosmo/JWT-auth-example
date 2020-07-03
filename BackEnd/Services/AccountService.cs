using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Extensions.Options;

using VivoApi.Helpers;

using VivoApi.Entities;
using VivoApi.Data;


namespace VivoApi.Services
{
  // TO DO  
  /*
    register -  create generate a PasswordHash and a Salt to Hash Password to store in database 
    Authenticate - Changes to use a PasswordHash and Password Salt
    New Migration to this modified Entity(User)
  */
  public interface IAccountService
  {
    Users Authenticate(string cpf, string password);
    Users Create(Users user, string password);
    IEnumerable<Users> GetAll();
  }

  // Account Service is responsible for all database interaction and core business logic related to user authentication and management
  public class AccountService : IAccountService
  {
    private readonly ApplicationDbContext applicationDb;

    private readonly DocumentsValidation documentsValidation;
    public AccountService(ApplicationDbContext _applicationDb, DocumentsValidation _documentsValidation)
    {
      applicationDb = _applicationDb;

      documentsValidation = _documentsValidation;
    }
    public Users Authenticate(string cpf, string password)
    {

      if (String.IsNullOrEmpty(cpf) || String.IsNullOrEmpty(password))
        return null;
      try
      {
        documentsValidation.ValidCpf(cpf);

      }
      catch (AppException)
      {
        return null;
      }
      var _user = applicationDb.Users.FirstOrDefault(users => users.Cpf == cpf);

      if (_user == null)
        return null;


      if (!VerifyPasswordHash(password, _user.PasswordHash, _user.PasswordSalt))
        return null;

      return _user;
    }
    public Users Create(Users user, string password)
    {
      try
      {
        documentsValidation.ValidCpf(user.Cpf);
      }
      catch (AppException)
      {
        throw new AppException("invalid cpf ");
      }
      if (String.IsNullOrWhiteSpace(password))
        throw new AppException("Password is required");
      if (applicationDb.Users.Any(x => x.Cpf == user.Cpf))
        throw new AppException("cpf " + user.Cpf + "is already");

      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);
      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;
      applicationDb.Users.Add(user);
      applicationDb.SaveChanges();

      return user;
    }

    public IEnumerable<Users> GetAll()
    {
      return applicationDb.Users.ToList();
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

      using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }


  }
}