using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {

            EKALog ekaLog = new EKALog();
            ekaLog.MethodLog();

            EKADiskInfo ekaDiskInfo = new EKADiskInfo();
            ekaDiskInfo.MetghodFreePlace();

            EKAFileInfo ekaFileInfo = new EKAFileInfo();
            ekaFileInfo.MethodFileInfo();

            EKADirInfo ekaDirInfo = new EKADirInfo();
            ekaDirInfo.EKADirInfoMethod();

            EKAFileManager ekaFileManager = new EKAFileManager();
            ekaFileManager.FileAndDirectoryWorkMethod();

            ViewEKALogFile viewEKALogFile = new ViewEKALogFile();
            viewEKALogFile.ViewEKALogFileMethod();



        }
    }


    internal class EKALog
    {
        public void MethodLog()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(@"F:\\EKAfileInfo.txt");
                fileInfo.Refresh();

                var nameOfFile = fileInfo.Name;
                var fullNameOfFile = fileInfo.FullName;
                var timeOfCreate = fileInfo.CreationTime;
                var timeOfAccess = fileInfo.LastAccessTime;
                var existOfFile = fileInfo.Exists;

                using (StreamWriter streamWriter = new StreamWriter(@"F:\\EKAlogfile.txt", false, Encoding.Default))
                {
                    streamWriter.WriteLine($"File name: {nameOfFile}");
                    streamWriter.WriteLine($"Full file path: {fullNameOfFile}");
                    streamWriter.WriteLine($"Date and time of file creation by user: {timeOfCreate}");
                    streamWriter.WriteLine($"Date and time the file was last modified by the user.: {timeOfAccess}");
                    streamWriter.WriteLine($"File existence: {existOfFile}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }



    internal class EKADiskInfo
    {
        public void MetghodFreePlace()
        {
            DriveInfo[] drifeInfo = DriveInfo.GetDrives();

            foreach (DriveInfo drife in drifeInfo)
            {
                Console.WriteLine($"Available disk space:\n{drife.Name} {drife.AvailableFreeSpace}");
                Console.WriteLine($"Total available disk space: {drife.TotalFreeSpace}");
                Console.WriteLine($"Volume label: {drife.VolumeLabel}");
                Console.WriteLine($"Total disk size in bytes: {drife.TotalSize}");
                Console.WriteLine($"File system: {drife.DriveFormat}");
            }
        }
    }

    internal class EKAFileInfo
    {
        public void MethodFileInfo()
        {
            FileInfo fileInfo = new FileInfo(@"F:\\EKAlogfile.txt");
            Console.WriteLine($"\n\nFile name: {fileInfo.Name}");
            Console.WriteLine($"Full file path: {fileInfo.DirectoryName}");
            Console.WriteLine($"File size: {fileInfo.Length}");
            Console.WriteLine($"File extension: {fileInfo.Extension}");
            Console.WriteLine($"File creation time: {fileInfo.CreationTime}");
        }
    }

    internal class EKADirInfo
    {

        public void EKADirInfoMethod()
        {
            Console.WriteLine("Directory subdirectories F:");
            string[] dirs = Directory.GetDirectories("F:\\");
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"\nNumber of directory subdirectories  F = {dirs.Length}");

            Console.WriteLine("\nFiles:");
            string[] files = Directory.GetFiles("F:\\");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"\nNumber of directory subdirectories F = {files.Length}");

            var time = Directory.GetCreationTime("F:\\");
            Console.WriteLine($"Catalog creation date F: {time}");

            var parent = Directory.GetParent("F:\\");
            Console.WriteLine($"Parent directory directory F: {parent}");
        }

    }

    internal class EKAFileManager
    {
        public void FileAndDirectoryWorkMethod()
        {
            Console.WriteLine("\n");
            string[] listFiles = Directory.GetFiles("C:\\");
            string[] listDirectories = Directory.GetDirectories("C:\\");

            Console.WriteLine("\nDirectory file list C");
            foreach (string i in listFiles)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nDirectory folder list C:");
            foreach (string j in listDirectories)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("\nDirectory created.");
            Directory.CreateDirectory("F:\\EKAInspect");

            Console.WriteLine("Creating a file and writing to it.");

            using (StreamWriter streamWriter = new StreamWriter("F:\\EKAInspect\\ekadirinfo.txt", true, Encoding.Default))
            {
                streamWriter.Write("HELLO FROM EGOR!");
                streamWriter.Close();
            }

            Console.WriteLine("\nFile copy created.");
            File.Copy("F:\\EKAInspect\\ekadirinfo.txt", "F:\\EKAInspect\\Copyekadirinfo.txt", false);

            Console.WriteLine("First file deleted.");
            File.Delete("F:\\EKAInspect\\ekadirinfo.txt");

            Directory.CreateDirectory("F:\\EKAFiles");

            File.Copy("F:\\EKAInspect\\Copyekadirinfo.txt", "F:\\EKAFiles\\NewCopyekadirinfo.txt", false);

        }
    }



    internal class ViewEKALogFile
    {
        public void ViewEKALogFileMethod()
        {
            using (StreamReader streamReader = new StreamReader(@"F:\ekalogfile.txt", Encoding.Default))
            {
                Console.WriteLine();
                string stroka = streamReader.ReadToEnd();
                Console.WriteLine(stroka);
            }
        }
    }
}
