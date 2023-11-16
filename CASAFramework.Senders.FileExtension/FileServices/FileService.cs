using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Senders.FileExtension.FileServices;

public static class FileService
{
    public static string ReadFile(string? path)
    {
        if (File.Exists(path))
            return File.ReadAllText(path);
        else
            throw new FileNotFoundException();

    }

    public static byte[] ReadByteArray(string? path)
    {
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
            throw new FileNotFoundException();

    }
    public static void WriteFile(string? path, string text)
    {
        if (Directory.Exists(Path.GetDirectoryName(path)))
        {
            File.WriteAllText(path, text);
        }
        else
        {

            throw new DirectoryNotFoundException();
        }

    }
    public static void WriteByteArray(string? path, byte[] bytes)
    {
        if (Directory.Exists(Path.GetDirectoryName(path)))
        {
            File.WriteAllBytes(path, bytes);
        }
        else
        {

            throw new DirectoryNotFoundException();
        }
    }
    public static void CreateFile(string path)
    {

        if (!File.Exists(path))
        {
            File.Create(path);
        }

    }
    public static void ValidatePath(string? path)
    {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException();

    }
    public static void CreateDirectoryIfMissing(string? path)
    {
        Directory.CreateDirectory(path);
    }


}
