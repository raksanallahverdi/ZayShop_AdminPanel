namespace ZayShop.Utilities.File
{
    public interface IFileService
    {
        string Upload(IFormFile file,string folder);
        void Delete(string folder, string fileName);
        bool isImage(string contentType);
        bool isAvailableSize(long length, long maxSize = 100);
    }
}
