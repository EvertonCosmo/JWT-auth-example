namespace VivoApi.Helpers
{
  //contains properties defined in the appsettings.json file and is used for accessing application settings via objects that are injected into classes 
  public class AppSettings
  {
    public string Secret { get; set; }
  }
}