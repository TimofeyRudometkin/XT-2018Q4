using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Epam.Task6._1.BackupSystem
{
    class Program
    {
        private static StringBuilder PathOfWatchingDir = new StringBuilder(@"C:\Watching repository");
        private static StringBuilder PathOfSystemDir = new StringBuilder(@"C:\System repository");
        private static string NameOfFileVsChanges = "BackUp.txt";
        private static Thread ThreadOfWatchingOrChanging;
        private static Thread ThreadOfMenu;
        public static DateTime dateTime;
        private const string Separator = "EnD Of BaCkUp BlOcK";
        private const string NeWFiLeWaSCrEaTeDOn = "NeW FiLe WaS CrEaTeD On";
        private const string NeWDiReCtOrYWaSCrEaTeDOn = "NeW DiReCtOrY WaS CrEaTeD On";
        private const string WiTthThEFoLlOwInGCoNtEnT = "WiTth ThE FoLlOwInG CoNtEnT";
        private const string FiLeWaSChAnGeDOn = "FiLe WaS ChAnGeD On";
        private const string DiReCtOrYWaSChAnGeDOn = "DiReCtOrY WaS ChAnGeD On";
        private const string FiLeWaSReNaMeDOn = "FiLe WaS ReNaMeD On";
        private const string DiReCtOrYWaSReNaMeDOn = "DiReCtOrY WaS ReNaMeD On";
        private const string FiLeWaSDeLeAtEdOn = "FiLe WaS DeLeAtEd On";
        private const string DiReCtOrYWaSDeLeAtEdOn = "DiReCtOrY WaS DeLeAtEd On";

        static void Main(string[] args)
        {
            Console.WriteLine($"Specify the operating mode of the application:{Environment.NewLine}1. " +
                $"Monitoring changes(Input '1');{Environment.NewLine}2. Roll back changes(Input '2');{Environment.NewLine}" +
                $"3. Quit from application(Input something else).");
            string choise = Console.ReadLine();
            switch(choise)
            {
                case "1":
                    ThreadOfMenu = new Thread(MenuOfWatchingFunction);
                    ThreadOfMenu.SetApartmentState(ApartmentState.STA);
                    ThreadOfMenu.Priority = ThreadPriority.AboveNormal;
                    ThreadOfMenu.Start();
                    ThreadOfWatchingOrChanging = new Thread(Watching);
                    ThreadOfWatchingOrChanging.SetApartmentState(ApartmentState.MTA);
                    ThreadOfWatchingOrChanging.Start();
                    ThreadOfWatchingOrChanging.Suspend();
                    break; 
                case "2":
                    ThreadOfMenu = new Thread(MenuOfRollBackChanges);
                    ThreadOfMenu.SetApartmentState(ApartmentState.STA);
                    ThreadOfMenu.Priority = ThreadPriority.AboveNormal;
                    ThreadOfMenu.Start();
                    ThreadOfWatchingOrChanging = new Thread(Changing);
                    ThreadOfWatchingOrChanging.SetApartmentState(ApartmentState.MTA);
                    ThreadOfWatchingOrChanging.Start();
                    ThreadOfWatchingOrChanging.Suspend();
                    break;
                default:
                    break;
            }
        }

        private static void MenuOfWatchingFunction()
        {
            try
            {
                Console.WriteLine($"The application will create a directory to save the folder image on  next path'{PathOfSystemDir.ToString()}'.{Environment.NewLine}" +
            $"Type an empty string in the console to accept the path, or type something to change the path.");
                string choise = Console.ReadLine();
                if (choise != "")
                {
                    using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        folderBrowserDialog.ShowDialog();
                        PathOfSystemDir = new StringBuilder(folderBrowserDialog.SelectedPath);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + e.StackTrace);
            }
            ThreadOfWatchingOrChanging.Resume();
        }
        private static void Watching()
        {
            try
            {
                DirectoryInfo DIPathOfOriginalDirectory = new DirectoryInfo(PathOfWatchingDir.ToString());
                DirectoryInfo DIPathOfDirectoryForCopy = new DirectoryInfo(Path.Combine(PathOfSystemDir.ToString(), "Backup"));

                if (DIPathOfDirectoryForCopy.Exists)
                {
                    DIPathOfDirectoryForCopy.Delete(true);
                }
                DIPathOfDirectoryForCopy.Create();
                CopyTheFolder(DIPathOfOriginalDirectory, DIPathOfDirectoryForCopy, DateTime.Now);
                File.WriteAllText(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), "");

                Console.WriteLine("Path of watching directory : " + PathOfWatchingDir);
                Console.WriteLine("Path of system directory for saving backup files : " + PathOfWatchingDir);

                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = PathOfWatchingDir.ToString();
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes;
                watcher.Filter = "*";
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Deleted += new FileSystemEventHandler(OnDelete);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Input 'q' for end watching.");
                while (Console.ReadLine() != "q") ;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message + Environment.NewLine + e + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void Watching"
                     + e.StackTrace);
            }
        }
        private static void OnCreated(object source,FileSystemEventArgs eventHandler)
        {
            string ContentOfFile = "";
            try
            {
                if (eventHandler.FullPath.EndsWith(".txt"))
                {
                    using (StreamReader streamReaderOriginal = new StreamReader(eventHandler.FullPath))
                    {
                        using (StreamWriter streamWriterBackUp = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                        {
                            streamWriterBackUp.Write(NeWFiLeWaSCrEaTeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine + eventHandler.FullPath +
                                Environment.NewLine);
                            ContentOfFile = streamReaderOriginal.ReadLine();
                            if (ContentOfFile != null)
                            {
                                streamWriterBackUp.WriteLine(WiTthThEFoLlOwInGCoNtEnT);
                            }
                            while (ContentOfFile != null)
                            {
                                streamWriterBackUp.Write(ContentOfFile);
                                ContentOfFile = streamReaderOriginal.ReadLine();
                            }
                            streamWriterBackUp.WriteLine(Environment.NewLine + Separator);
                        }
                    }
                }
                else if (!eventHandler.FullPath.EndsWith(".*"))
                {
                    Directory.CreateDirectory(eventHandler.FullPath);
                    using (StreamWriter streamWriterBackUp = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriterBackUp.WriteLine(NeWDiReCtOrYWaSCrEaTeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine +
                            eventHandler.FullPath + Environment.NewLine + Separator);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message + Environment.NewLine + e + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void OnCreated " +
                    $"{e.StackTrace + Environment.NewLine}");
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs eventHandler)
        {
            string ContentOfFile = "";
            try
            {
                if (eventHandler.FullPath.EndsWith(".txt"))
                {
                    using (StreamReader streamReaderOriginal = new StreamReader(eventHandler.FullPath))
                    {
                        using (StreamWriter streamWriterBackUp = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                        {
                            streamWriterBackUp.Write(FiLeWaSChAnGeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine + eventHandler.FullPath +
                                Environment.NewLine);
                            ContentOfFile = streamReaderOriginal.ReadLine();
                            if(ContentOfFile!=null)
                            {
                                streamWriterBackUp.WriteLine(WiTthThEFoLlOwInGCoNtEnT);
                            }
                            while (ContentOfFile != null)
                            {
                                streamWriterBackUp.Write(ContentOfFile);
                                ContentOfFile = streamReaderOriginal.ReadLine();
                            }
                            streamWriterBackUp.WriteLine(Environment.NewLine + Separator);
                        }
                    }
                }
                else if (!eventHandler.FullPath.EndsWith(".*"))
                {
                    using (StreamWriter streamWriterBackUp = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriterBackUp.WriteLine(DiReCtOrYWaSChAnGeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine + eventHandler.FullPath +
                            Environment.NewLine + Separator);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void OnChanged" 
                    + e.StackTrace);
            }
        }
        private static void OnRenamed(object source, RenamedEventArgs eventHandler)
        {
            try
            {
                if (eventHandler.FullPath.EndsWith(".txt"))
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine($"{FiLeWaSReNaMeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine}" +
                            $"FrOm{Environment.NewLine + eventHandler.OldFullPath + Environment.NewLine}" +
                            $"To{Environment.NewLine + eventHandler.FullPath + Environment.NewLine + Separator}");
                    }
                }
                else if (!eventHandler.FullPath.EndsWith(".*"))
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine($"{DiReCtOrYWaSReNaMeDOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine}" +
                            $"FrOm{Environment.NewLine + eventHandler.OldFullPath + Environment.NewLine}" +
                            $"To{Environment.NewLine + eventHandler.FullPath + Environment.NewLine + Separator}");
                    }
                }
            }
            catch
            {

            }
        }
        private static void OnDelete(object source, FileSystemEventArgs eventHandler)
        {
            try
            {
                if (eventHandler.FullPath.EndsWith(".txt"))
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine(FiLeWaSDeLeAtEdOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine + Environment.NewLine +
                            eventHandler.FullPath + Environment.NewLine + Separator);
                    }
                }
                else if (!eventHandler.FullPath.EndsWith(".*"))
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine(DiReCtOrYWaSDeLeAtEdOn + Environment.NewLine + DateTime.UtcNow + Environment.NewLine + Environment.NewLine +
                            eventHandler.FullPath + Environment.NewLine + Separator);
                    }
                }
            }            catch
            {

            }
        }
        private static string ConvertPathFromWatchingDirToSystemDir(string PathInWatchingDir)
        {
            return PathInWatchingDir.Replace(PathInWatchingDir, PathOfSystemDir.ToString());
        }
        private static string ConvertPathFromSystemDirToWatchingDir(string PathInSystemDir)
        {
            return PathInSystemDir.Replace(PathInSystemDir.ToString(), PathOfWatchingDir.ToString());
        }
        private static void CopyTheFolder(DirectoryInfo DIPathOfOriginalDirectory, DirectoryInfo DIPathOfDirectoryForCopy,DateTime DateOfCreation)
        {
            foreach (FileInfo file in DIPathOfOriginalDirectory.GetFiles())
            {
                if (DateOfCreation >= file.CreationTimeUtc)
                {
                    file.CopyTo(Path.Combine(DIPathOfDirectoryForCopy.FullName, file.Name));
                    File.SetCreationTimeUtc(Path.Combine(DIPathOfDirectoryForCopy.FullName, file.Name), file.CreationTimeUtc);
                    File.SetLastAccessTimeUtc(Path.Combine(DIPathOfDirectoryForCopy.FullName, file.Name), file.CreationTimeUtc);
                    File.SetLastWriteTimeUtc(Path.Combine(DIPathOfDirectoryForCopy.FullName, file.Name), file.CreationTimeUtc);
                }
            }
            foreach (DirectoryInfo dir in DIPathOfOriginalDirectory.GetDirectories())
            {
                if (DateOfCreation >= dir.CreationTimeUtc)
                {
                    DIPathOfDirectoryForCopy.CreateSubdirectory(dir.Name);
                    DIPathOfDirectoryForCopy = new DirectoryInfo(Path.Combine(DIPathOfDirectoryForCopy.FullName, dir.Name));
                    DIPathOfDirectoryForCopy.CreationTimeUtc = dir.CreationTimeUtc;
                    CopyTheFolder(dir, DIPathOfDirectoryForCopy, DateOfCreation);
                    DIPathOfDirectoryForCopy = DIPathOfDirectoryForCopy.Parent;
                }
            }
        }


        private static void MenuOfRollBackChanges()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"The application will open a directory with save the folder image and backup file on next path'{PathOfSystemDir.ToString()}'" +
                        $".{Environment.NewLine}Type an empty string in the console to accept the path, or type something to change the path.");
                string choise = Console.ReadLine();
                if (choise != "")
                {
                    using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        folderBrowserDialog.ShowDialog();
                        PathOfSystemDir = new StringBuilder(folderBrowserDialog.SelectedPath);
                    }
                }
                    Application.Run(new Calendar());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                }
            }
            ThreadOfWatchingOrChanging.Resume();
        }
        private static void Changing()
        {
            string ContentOfFile;
            DateTime DateOfCreation;
            string Path;

            try
            {
                DirectoryInfo DIPathOfDirectoryForCopy = new DirectoryInfo(PathOfWatchingDir.ToString());
                DirectoryInfo DIPathOfOriginalDirectory = new DirectoryInfo(System.IO.Path.Combine(PathOfSystemDir.ToString(), "Backup"));

                if (DIPathOfDirectoryForCopy.Exists)
                {
                    DIPathOfDirectoryForCopy.Delete(true);
                }
                DIPathOfDirectoryForCopy.Create();
                CopyTheFolder(DIPathOfOriginalDirectory, DIPathOfDirectoryForCopy, dateTime);

                using (StreamReader streamReader = new StreamReader(System.IO.Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString())))
                {
                    ContentOfFile = streamReader.ReadLine();
                    while (ContentOfFile != null)
                    {
                        try
                        {
                            switch (ContentOfFile)
                            {
                                case NeWFiLeWaSCrEaTeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (!File.Exists(Path))
                                        {
                                            using (StreamWriter streamWriter = new StreamWriter(Path, true))
                                            {
                                                ContentOfFile = streamReader.ReadLine();
                                                if (ContentOfFile == WiTthThEFoLlOwInGCoNtEnT)
                                                {
                                                    ContentOfFile = streamReader.ReadLine();
                                                    while (ContentOfFile != Separator)
                                                    {
                                                        streamWriter.WriteLine(ContentOfFile);
                                                        ContentOfFile = streamReader.ReadLine();
                                                    }
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            File.SetCreationTimeUtc(Path, DateOfCreation);
                                            File.SetLastWriteTimeUtc(Path, DateOfCreation);
                                            File.SetLastAccessTimeUtc(Path, DateOfCreation);
                                        }
                                        else throw new Exception("Program 'Changing',case 'NeWFiLeWaSCrEaTeDOn',if (!File.Exists(Path)) - file is already exists");
                                    }
                                    break;
                                case NeWDiReCtOrYWaSCrEaTeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (!Directory.Exists(Path))
                                        {
                                            Directory.CreateDirectory(Path);
                                            Directory.SetCreationTimeUtc(Path, DateOfCreation);
                                            Directory.SetLastWriteTimeUtc(Path, DateOfCreation);
                                            Directory.SetLastAccessTimeUtc(Path, DateOfCreation);
                                        }
                                        else throw new Exception("Program 'Changing',case 'NeWDiReCtOrYWaSCrEaTeDOn',if (!Directory.Exists(Path)) - " +
                                            "directory is already exists");
                                    }
                                    break;
                                case FiLeWaSChAnGeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (!File.Exists(Path))
                                        {
                                            File.CreateText(Path);
                                        }
                                        else
                                        {
                                            File.WriteAllText(Path, "");
                                        }
                                        using (StreamWriter streamWriter = new StreamWriter(Path, true))
                                        {
                                            ContentOfFile = streamReader.ReadLine();
                                            if (ContentOfFile == WiTthThEFoLlOwInGCoNtEnT)
                                            {
                                                ContentOfFile = streamReader.ReadLine();
                                                while (ContentOfFile != Separator)
                                                {
                                                    streamWriter.WriteLine(ContentOfFile);
                                                    ContentOfFile = streamReader.ReadLine();
                                                }
                                            }
                                        }
                                        File.SetLastWriteTimeUtc(Path, DateOfCreation);
                                        File.SetLastAccessTimeUtc(Path, DateOfCreation);
                                    }
                                    break;
                                case DiReCtOrYWaSChAnGeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (Directory.Exists(Path))
                                        {
                                            Directory.SetLastWriteTimeUtc(Path, DateOfCreation);
                                            Directory.SetLastAccessTimeUtc(Path, DateOfCreation);
                                        }
                                        else throw new Exception("Program 'Changing',case 'DiReCtOrYWaSChAnGeDOn',if (DateOfCreation <= Program.dateTime)");
                                    }
                                    break;
                                case FiLeWaSReNaMeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        ContentOfFile = streamReader.ReadLine();
                                        if (File.Exists(Path))
                                        {
                                            File.Copy(Path, ContentOfFile);
                                            File.SetLastWriteTimeUtc(ContentOfFile, DateOfCreation);
                                            File.SetLastAccessTimeUtc(ContentOfFile, DateOfCreation);
                                            File.SetCreationTimeUtc(ContentOfFile, File.GetCreationTimeUtc(Path));
                                            File.Delete(Path);
                                        }
                                    }
                                    break;
                                case DiReCtOrYWaSReNaMeDOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        ContentOfFile = streamReader.ReadLine();
                                        if (Directory.Exists(Path))
                                        {
                                            Directory.CreateDirectory(ContentOfFile);
                                            Directory.SetLastWriteTimeUtc(ContentOfFile, DateOfCreation);
                                            Directory.SetLastAccessTimeUtc(ContentOfFile, DateOfCreation);
                                            Directory.SetCreationTimeUtc(ContentOfFile, Directory.GetCreationTimeUtc(Path));
                                            Directory.Delete(Path);
                                        }
                                    }
                                    break;
                                case FiLeWaSDeLeAtEdOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (File.Exists(Path))
                                        {
                                            File.Delete(Path);
                                        }
                                    }
                                    break;
                                case DiReCtOrYWaSDeLeAtEdOn:
                                    ContentOfFile = streamReader.ReadLine();
                                    DateOfCreation = DateTime.Parse(ContentOfFile);
                                    if (DateOfCreation <= Program.dateTime)
                                    {
                                        ContentOfFile = streamReader.ReadLine();
                                        Path = ContentOfFile;
                                        if (Directory.Exists(Path))
                                        {
                                            Directory.Delete(Path);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            while (ContentOfFile != Separator)
                            {
                                ContentOfFile = streamReader.ReadLine();
                            }
                            ContentOfFile = streamReader.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
            }
            Console.WriteLine("Reclamation of the changes made.");
        }
    }
}
