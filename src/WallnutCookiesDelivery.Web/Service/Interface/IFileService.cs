namespace WallnutCookiesDelivery.Web.Service.Interface;

public interface IFileService
{
    string UploadImage(IFormFile image);
    string UpdateImage(IFormFile image, string imageUrl);
    void DeleteImage(string imageUrl);
}
