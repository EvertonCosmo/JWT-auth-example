using System;
using Caelum.Stella.CSharp.Validation;

namespace VivoApi.Helpers
{
  public class DocumentsValidation
  {
    public void ValidCpf(string cpf)
    {
      try
      {
        new CPFValidator().AssertValid(cpf);
      }
      catch (Exception)
      {
        throw new AppException("Cpf invalid");
      }
    }
    public void validCnpj(string cnpj)
    {
      try
      {
        new CNPJValidator().AssertValid(cnpj);
      }
      catch (Exception)
      {
        throw new AppException("Cpf invalid");
      }
    }

  }
}