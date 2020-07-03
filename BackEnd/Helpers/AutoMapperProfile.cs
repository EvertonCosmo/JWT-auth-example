using AutoMapper;
using VivoApi.Entities;
using VivoApi.Models.Users;

namespace VivoApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Users, AuthenticateModel>();
      CreateMap<RegisterModel, Users>();
    }
  }
}