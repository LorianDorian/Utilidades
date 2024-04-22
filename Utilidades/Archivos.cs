using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Utilidades
{
    public class Archivos
    {
        public static void CreateTextFile(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                throw new InvalidOperationException("An archive with the same name already exists.");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        public static void CompressFilesToZip(string zipFilePath, params string[] files)
        {
            using (FileStream zipToCreate = new FileStream(zipFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    foreach (string file in files)
                    {
                        if (!File.Exists(file))
                        {
                            throw new FileNotFoundException($"File '{file}' not found.");
                        }

                        // Get the name of the file without the path
                        string entryName = Path.GetFileName(file);

                        // Create a new entry in the ZIP archive
                        ZipArchiveEntry zipEntry = archive.CreateEntry(entryName);

                        // Open the file to be added to the entry stream
                        using (FileStream originalFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (Stream zipEntryStream = zipEntry.Open())
                            {
                                // Copy the file to the ZIP entry stream
                                originalFileStream.CopyTo(zipEntryStream);
                            }
                        }
                    }
                }
            }
        }

        public static void CopyArchive(string sourceDirectory, string destinationDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException($"Source directory '{sourceDirectory}' not found.");
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Get all files in the source directory
            string[] files = Directory.GetFiles(sourceDirectory);

            foreach (string file in files)
            {
                // Get the file name
                string fileName = Path.GetFileName(file);

                // Combine the file name with the destination directory to get the full destination path
                string destinationFilePath = Path.Combine(destinationDirectory, fileName);

                // Copy the file to the destination directory
                File.Copy(file, destinationFilePath);
            }

            // Get all subdirectories in the source directory
            string[] directories = Directory.GetDirectories(sourceDirectory);

            foreach (string directory in directories)
            {
                // Get the directory name
                string directoryName = Path.GetFileName(directory);

                // Combine the directory name with the destination directory to get the full destination path
                string destinationSubDirectory = Path.Combine(destinationDirectory, directoryName);

                // Recursively copy the subdirectory
                CopyArchive(directory, destinationSubDirectory);
            }
        }

        public static void DeleteArchive(string archivePath)
        {
            if (File.Exists(archivePath))
            {
                File.Delete(archivePath);
                Console.WriteLine($"Archive '{archivePath}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Archive '{archivePath}' not found.");
            }
        }

        public static void MoveArchive(string sourceArchivePath, string destinationDirectory)
        {
            if (!File.Exists(sourceArchivePath))
            {
                Console.WriteLine($"Source archive '{sourceArchivePath}' not found.");
                return;
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceArchivePath));

            // Read the contents of the source file
            byte[] fileContents;
            using (FileStream fileStream = new FileStream(sourceArchivePath, FileMode.Open))
            {
                fileContents = new byte[fileStream.Length];
                fileStream.Read(fileContents, 0, fileContents.Length);
            }

            // Write the contents to the destination file
            using (FileStream destinationFileStream = new FileStream(destinationFilePath, FileMode.Create))
            {
                destinationFileStream.Write(fileContents, 0, fileContents.Length);
            }

            // Delete the source file
            File.Delete(sourceArchivePath);

            Console.WriteLine($"Archive '{sourceArchivePath}' moved to '{destinationFilePath}' successfully.");
        }

        public static string FindFile(string searchDirectory, string fileName)
        {
            string filePath = SearchDirectory(searchDirectory, fileName);
            if (filePath != null)
            {
                Console.WriteLine($"File '{fileName}' found at '{filePath}'.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found in '{searchDirectory}' or its subdirectories.");
            }
            return filePath;
        }

        private static string SearchDirectory(string directory, string fileName)
        {
            string[] files = Directory.GetFiles(directory, fileName);
            if (files.Length > 0)
            {
                return files[0];
            }

            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                string filePath = SearchDirectory(subDirectory, fileName);
                if (filePath != null)
                {
                    return filePath;
                }
            }

            return null;
        }


    }
}
