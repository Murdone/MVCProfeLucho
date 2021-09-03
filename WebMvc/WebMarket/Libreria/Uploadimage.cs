using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebMarket.Libreria
{
    public class Uploadimage
    {
        public async Task<byte[]> ByteAvatarImageAsync(IFormFile AvatarImage, IWebHostEnvironment environment, string image)
        {
            if (AvatarImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await AvatarImage.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            else
            {
                var archivoOrigen = $"{environment.ContentRootPath}/wwwroot/{image}";
                return File.ReadAllBytes(archivoOrigen);
            }
        }
    }
}
