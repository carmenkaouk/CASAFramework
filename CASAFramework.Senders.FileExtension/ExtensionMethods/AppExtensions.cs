using CasaFramework.InterfaceLibrary;


namespace CASAFramework.Senders.FileExtension.ExtensionMethods;

public  static class AppExtensions
{
    public static void AddFileListener(this App app, string path)
    {
        app.SetListener(new FileListener(path)); 
    }
}
