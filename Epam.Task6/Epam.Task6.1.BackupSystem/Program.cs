using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Epam.Task6._1.BackupSystem
{
    class Program
    {
        private static StringBuilder PathOfWatchingDir = new StringBuilder(@"C:\Watching repository");
        private static StringBuilder PathOfSystemDir = new StringBuilder(@"C:\System repository");
        private static string NameOfFileVsChanges = "BackUp.txt";
        public static Thread ThreadOfWatchingOrChanging;
        public static Thread ThreadOfMenu;
        public static DateTime dateTime;

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
                    MenuOfRollBackChanges();
                    //ThreadOfWatchingOrChanging = new Thread(Watching);
                    //ThreadOfWatchingOrChanging.SetApartmentState(ApartmentState.MTA);
                    //ThreadOfWatchingOrChanging.Start();
                    //ThreadOfWatchingOrChanging.Suspend();
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
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite);
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
                CopyTheFolder(DIPathOfOriginalDirectory, DIPathOfDirectoryForCopy);

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
                Console.WriteLine($"{e.Message + Environment.NewLine + e + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void Watching");
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
                            streamWriterBackUp.Write($"New file {eventHandler.FullPath} was created on {DateTime.UtcNow} with the following content{Environment.NewLine}");
                            ContentOfFile = streamReaderOriginal.ReadLine();
                            while (ContentOfFile != null)
                            {
                                streamWriterBackUp.Write(ContentOfFile);
                                ContentOfFile = streamReaderOriginal.ReadLine();
                            }
                            streamWriterBackUp.WriteLine($"END OF CONTENT{ Environment.NewLine}");
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(eventHandler.FullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message + Environment.NewLine + e + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void OnCreated");
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
                            streamWriterBackUp.Write($"File {eventHandler.FullPath} was changed on {DateTime.UtcNow} with the following content{Environment.NewLine}");
                            ContentOfFile = streamReaderOriginal.ReadLine();
                            while (ContentOfFile != null)
                            {
                                streamWriterBackUp.Write(ContentOfFile);
                                ContentOfFile = streamReaderOriginal.ReadLine();
                            }
                            streamWriterBackUp.WriteLine($"END OF CONTENT{ Environment.NewLine}");
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(eventHandler.FullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine} void OnChanged");
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
                        streamWriter.WriteLine($"File was renamed from {eventHandler.OldFullPath} to {eventHandler.FullPath} on  {DateTime.UtcNow}.{Environment.NewLine}");
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine($"Directory was renamed from {eventHandler.OldFullPath} to {eventHandler.FullPath} on {DateTime.UtcNow}.{Environment.NewLine}");
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
                        streamWriter.WriteLine($"File {eventHandler.FullPath} was deleated on  {DateTime.UtcNow}.{Environment.NewLine}");
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path.Combine(PathOfSystemDir.ToString(), NameOfFileVsChanges.ToString()), true))
                    {
                        streamWriter.WriteLine($"Directory {eventHandler.FullPath} was deleated on {DateTime.UtcNow}.{Environment.NewLine}");
                    }
                }
            }
            catch
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
        private static void CopyTheFolder(DirectoryInfo DIPathOfOriginalDirectory, DirectoryInfo DIPathOfDirectoryForCopy)
        {
            foreach (FileInfo file in DIPathOfOriginalDirectory.GetFiles())
            {
                file.CopyTo(Path.Combine(DIPathOfDirectoryForCopy.FullName, file.Name));
                //add creation time change
            }
            foreach (DirectoryInfo dir in DIPathOfOriginalDirectory.GetDirectories())
            {
                DIPathOfDirectoryForCopy.CreateSubdirectory(dir.Name);
                DIPathOfDirectoryForCopy = new DirectoryInfo(Path.Combine(DIPathOfDirectoryForCopy.FullName, dir.Name));
                DIPathOfDirectoryForCopy.CreationTimeUtc = dir.CreationTimeUtc;
                CopyTheFolder(dir, DIPathOfDirectoryForCopy);
                DIPathOfDirectoryForCopy = DIPathOfDirectoryForCopy.Parent;
            }
        }


        private static void MenuOfRollBackChanges()
        {
            string stringDateTime = "";
            string stringDateTime2 = "";
            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Input day");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Day));
                        {
                            if (Day >= 1 && Day <= 31)
                            {
                                stringDateTime += $"{stringDateTime2}.";
                                break;
                            }
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Input month");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Month));
                        {
                            if (Month >= 1 && Month <= 12)
                            {
                                stringDateTime += $"{stringDateTime2}.";
                                break;
                            }
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Input year");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Year));
                        {
                            if (Year >= 0 && Year <= 2050)
                            {
                                stringDateTime += $"{stringDateTime2} ";
                                break;
                            }
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Input hours");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Hours));
                        {
                            if (Hours >= 0 && Hours <= 23)
                            {
                                stringDateTime += $"{stringDateTime2}:";
                                break;
                            }
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Input minutes");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Minutes));
                        {
                            if (Minutes >= 0 && Minutes <= 59)
                            {
                                stringDateTime += $"{stringDateTime2}:";
                                break;
                            }
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Input secondes");
                        stringDateTime2 = Console.ReadLine();
                        if (int.TryParse(stringDateTime2, out int Seconds));
                        {
                            if (Seconds >= 0 && Seconds <= 59)
                            {
                                stringDateTime += $"{stringDateTime2}";
                                break;
                            }
                        }
                    }
                    dateTime = DateTime.Parse(stringDateTime);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite);
                }
            }
        }
    }
}
