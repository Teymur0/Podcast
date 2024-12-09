using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.Utilities
{
    public static class FileService
    {

        public static bool CheckSize(this IFormFile file, int mb)
        {
            return file.Length < mb * 1024 * 1024;
        }

        public static bool CheckType(this IFormFile file, string type = "image")
        {
            return file.ContentType.Contains(type);
        }

        public async static Task<string> CreateFileAsync(this IFormFile file, string path)
        {


            string filename = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf('.'));

            path = Path.Combine(path, filename);

            using (FileStream stream = new(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }

            return filename;
        }

        public static void DeleteFile(this string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
