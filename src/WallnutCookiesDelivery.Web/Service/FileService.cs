using WallnutCookiesDelivery.Web.Service.Interface;

namespace WallnutCookiesDelivery.Web.Service;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public string UploadImage(IFormFile image)
    {
        if (image.FileName != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(image.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var path = Path.Combine(_webHostEnvironment.WebRootPath + "/images/Oreshki/", fileName);
            image.CopyTo(new FileStream(path, FileMode.Create));
            return fileName;
        }
        return FileNotFoundException("You haven't included a file");
    }

    public string UpdateImage(IFormFile image, string imageUrl)
    {
        
        if (image.FileName != null)
        {
            var localFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Oreshki", imageUrl);
            if (File.Exists(localFolderPath))
            {
                File.Delete(localFolderPath);
            }
            
            var fileName = Path.GetFileNameWithoutExtension(image.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var path = Path.Combine(_webHostEnvironment.WebRootPath + "/images/Oreshki/", fileName);
            image.CopyTo(new FileStream(path, FileMode.Create));
        }
        return imageUrl;
    }

    public string DeleteImage(string imageUrl)
    {
        var localFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Oreshki", imageUrl);
        if (File.Exists(localFolderPath))
        {
            File.Delete(localFolderPath);
        }
        return imageUrl;
    }

    private string FileNotFoundException(string message)
    {
        return message;
    }
}