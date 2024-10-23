using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Helpers
{
    public static class FileHelper
    {
        public static void DeleteFileFromRoute(string path)
        {
            if(System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
        public static async Task SaveFileToLocalAsync(this IFormFile file, string path)
        {
            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}   
