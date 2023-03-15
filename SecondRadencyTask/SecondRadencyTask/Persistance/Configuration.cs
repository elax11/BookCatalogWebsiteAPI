namespace SecondRadencyTask.Persistance
{
    public class LibraryConfiguration : ILibraryConfiguration
    {
        public string SecretKey => System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
    }
}
