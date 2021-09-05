using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Helpers
{
    public static class FileUpload
    {
        public static string upload(string Folder , IFormFile _file)
        {
            var FolderName = "/wwwroot/" + Folder;
            // Get Directory
            string FolderPath = Directory.GetCurrentDirectory() + FolderName;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(_file.FileName);

            // Merge Path with File Name
            string FinalPath = Path.Combine(FolderPath, FileName);

            // Save File As Streams "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                _file.CopyTo(Stream);
            }
            return FileName;
        }



        public static void DeleteFiles(string FolderName , string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName);
            }

        }
    }



}
