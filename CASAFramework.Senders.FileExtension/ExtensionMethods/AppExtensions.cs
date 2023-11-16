using CasaFramework.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Senders.FileExtension.ExtensionMethods;

public  static class AppExtensions
{
    public static void AddFileListener(this App app, string path)
    {
        app.SetListener(new FileListener(path)); 
    }
}
