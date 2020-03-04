using Microsoft.AspNetCore.Http;
using System.IO;

namespace SocializR.Code.ExtensionMethods
{
    public static class CommonExtensionMethods
    {
        public static byte[] GetFileBytes(this IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
