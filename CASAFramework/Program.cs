
// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using CASAFramework.Senders.FileExtension.ExtensionMethods;
using CasaFramework.MainLibrary;


//configuration
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//regester services 

ServiceProvider serviceProvider = new ServiceProvider();
// add and set needed stuff
App app = new App();
app.AddFileListener(""); 