namespace TravelaFinalApp.Application.Helpers
{
    public static class FileHelper
    {
        public static void DeleteFileFromRoute(string path)
        {
            if(System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
