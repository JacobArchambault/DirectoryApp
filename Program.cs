using System.IO;
using static System.Console;
using static System.IO.Directory;

namespace DirectoryApp
{
    class Program
    {
        static void Main()
        {
            WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            ModifyAppDirectory();
            FunWithDirectoryType();
            ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            WriteLine("***** Directory Info *****");
            WriteLine($"Full name: {dir.FullName}");
            WriteLine($"Name: {dir.Name}");
            WriteLine($"Parent: {dir.Parent}");
            WriteLine($"Creation: {dir.CreationTime}");
            WriteLine($"Attributes: {dir.Attributes}");
            WriteLine($"Root: {dir.Root}");
            WriteLine("**************************\n");
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Get all files with a *.jpg extension.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            // How many were found?
            WriteLine($"Found {imageFiles.Length} *.jpg files\n");

            // Now print out info for each file.
            foreach (FileInfo f in imageFiles)
            {
                WriteLine("***************************");
                WriteLine($"File name: {f.Name}");
                WriteLine($"File size: {f.Length}");
                WriteLine($"Creation: {f.CreationTime}");
                WriteLine($"Attributes: {f.Attributes}");
                WriteLine("***************************\n");
            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            // Create \MyFolder off initial directory.
            dir.CreateSubdirectory("MyFolder");

            // Capture returned DirectoryInfo object.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            // Prints path to ..\MyFolder2\Data.
            WriteLine($"New Folder is: {myDataFolder}");
        }

        static void FunWithDirectoryType()
        {
            // List all drives on current computer.
            string[] drives = GetLogicalDrives();
            WriteLine("Here are your drives:");
            foreach (string s in drives)
                WriteLine($"--> {s} ");

            // Delete what was created.
            WriteLine("Press Enter to delete directories");
            ReadLine();
            try
            {
                Delete(@"C:\MyFolder");

                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Delete(@"C:\MyFolder2", true);
            }
            catch (IOException e)
            {
                WriteLine(e.Message);
            }
        }
    }
}