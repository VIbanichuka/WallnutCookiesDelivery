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
        CheckImageFileIsNull(image);

        var fileName = CreateImage(image);
        return fileName;
    }

    public string UpdateImage(IFormFile image, string imageUrl)
    {
        CheckImageFileIsNull(image);

        CheckImageUrlIsNullOrEmpty(imageUrl);

        DeleteImageIfExists(imageUrl);

        var fileName = CreateImage(image);
        return fileName;
    }

    public void DeleteImage(string imageUrl)
    {
        CheckImageUrlIsNullOrEmpty(imageUrl);

        DeleteImageIfExists(imageUrl);
    }

    private void CheckImageFileIsNull(IFormFile image)
    {
        if (image.FileName == null)
        {
            throw new ArgumentException(nameof(image), "You haven't included a file");
        }
    }

    private void CheckImageUrlIsNullOrEmpty(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new ArgumentException(nameof(imageUrl), "This file doesn't exist");
        }
    }

    private string GetUniqueFileName(string fileName)
    {
        return Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString() 
            + Path.GetExtension(fileName);
    }

    private string GetImagePath(string fileName)
    {
        return Path.Combine(_webHostEnvironment.WebRootPath + "/images/Oreshki/", fileName);
    }

    private void DeleteImageIfExists(string imageUrl)
    {
        var imagePath = GetImagePath(imageUrl);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }
    }

    private string CreateImage(IFormFile image)
    {
        var fileName = GetUniqueFileName(image.FileName);

        var path = GetImagePath(fileName);

        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            image.CopyTo(fileStream);
        }

        return fileName;
    }
}