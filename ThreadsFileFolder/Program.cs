namespace ThreadsFileFolder
{
    internal class Program
    {
        #region Function
        public static void copyFile(string source, string destination)
        {
            if (File.Exists(source))
            {
                if (!Path.Exists(destination) && !Path.HasExtension(destination))
                    Directory.CreateDirectory(destination);
                try
                {
                    using (var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
                    {
                        if (!Path.HasExtension(destination))
                            destination = $@"{destination}\{Path.GetFileNameWithoutExtension(source)}Copy{Path.GetExtension(source)}";

                        if (Path.GetExtension(source) == Path.GetExtension(destination))
                        {
                            using (var destinationStream = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                var len = 2000;
                                var bytes = new byte[len];
                                var totalBytes = 0;
                                do
                                {
                                    len = sourceStream.Read(bytes, 0, len);
                                    destinationStream.Write(bytes, 0, len);
                                    totalBytes += len;
                                    Console.WriteLine(totalBytes);
                                    Thread.Sleep(10);

                                } while (0 < len);
                            }
                            Console.WriteLine("File copied");
                        }
                        else
                        {
                            Console.WriteLine("Choose correct file");
                            // ex.Message log
                            Console.WriteLine("Press any key for continue");
                            Console.ReadKey();
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong");
                    // ex.Message log
                    Console.WriteLine("Press any key for continue");
                    Console.ReadKey();

                }

            }
            else
            {
                Console.WriteLine("File not found");
                Console.WriteLine("Press any key for continue");
                Console.ReadKey();
            }
        }
        #endregion
        static void Main(string[] args)
        {
            #region Firs Task
            //Console.Write("Source Path: ");
            //var source = Console.ReadLine()!; 
            //Console.Write("Destination Path: ");
            //var destination = Console.ReadLine()!; 
            //var thread = new Thread(() => { copyFile(source, destination); });
            //thread.Start();
            #endregion

            #region Second Task
            bool inMenu = true;
            while (inMenu)
            {
                DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Elchin\Desktop");
                DirectoryInfo[] folders = directory.GetDirectories();
                Console.WriteLine("Folders: ");
                foreach (DirectoryInfo file in folders)
                {
                    Console.WriteLine(file.FullName);
                }
                Console.WriteLine();
                Console.WriteLine("Files: ");
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.FullName);
                }
                Console.WriteLine();
                Console.WriteLine("1)Folder sec ");
                Console.WriteLine("2)Kopyalamaq ucun file sec ");
                Console.WriteLine("3)Exit ");
                Console.Write("Secim edin: ");
                var secim = Console.ReadLine();
                switch (secim)
                {
                    #region Folder
                    case "1":
                        try
                        {
                            Console.Write("Enter path of Folder: ");
                            var pathOfFolder = Console.ReadLine()!;
                            DirectoryInfo folderDirectory = new DirectoryInfo(pathOfFolder);
                            DirectoryInfo[] foldersInFolder = folderDirectory.GetDirectories();
                            FileInfo[] fileInFolder = folderDirectory.GetFiles();
                            Console.WriteLine();
                            foreach (DirectoryInfo file in foldersInFolder)
                            {
                                Console.WriteLine(file.FullName);
                            }
                            Console.WriteLine();
                            foreach (FileInfo file in fileInFolder)
                            {
                                Console.WriteLine(file.FullName);
                            }
                            Console.WriteLine();
                            Console.WriteLine("File kopyalamaq isteyirsiniz?");
                            Console.WriteLine("1)Beli");
                            Console.WriteLine("2)Xeyr(evvelki menu)");
                            Console.Write("Secim edin: ");
                            var folderSecim = Console.ReadLine();
                            if (folderSecim == "1")
                            {
                                Console.Write("Enter path of file: ");
                                var filePath = Console.ReadLine()!;
                                Console.Write("Enter path of folder: ");
                                var folderPath = Console.ReadLine()!;
                                copyFile(filePath, folderPath);
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else if (folderSecim == "2")
                            {
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                        break;
                    #endregion
                    #region File
                    case "2":
                        Console.Write("Enter path of file: ");
                        var fileP = Console.ReadLine()!;
                        Console.Write("Enter path of folder: ");
                        var folderP = Console.ReadLine()!;
                        copyFile(fileP, folderP);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    #endregion
                    #region Exit
                    case "3":
                        inMenu = false;
                        break;
                    #endregion
                    default:
                        Console.WriteLine("Wrong input!!!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
            #endregion
        }
    }
}
