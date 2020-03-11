using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Domain.DomainBaseClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public class FileService : Service<DocumentBase>, IFileService
    {
        private readonly DocumentSettings _documentSettings;

        public FileService(ITrackableRepository<DocumentBase> repository
            , IOptions<DocumentSettings> documentSettings


            ) : base(repository)
        {
            _documentSettings = documentSettings.Value;
        }

        public async Task<string> SaveToDisk(IFormFile file)
        {
            if (!Directory.Exists(_documentSettings.FilePath))
            {
                Directory.CreateDirectory(_documentSettings.FilePath);
            }
            var returnFilePath = _documentSettings.FilePath + Guid.NewGuid().ToString() + "_" + file.FileName;
            using (var fileStream = new FileStream(returnFilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return returnFilePath;
        }

        public async Task<string> GetFileInBase64(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    byte[] bytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        bytes = memoryStream.ToArray();
                    }

                    string base64 = Convert.ToBase64String(bytes);
                    return base64;
                    //return new MemoryStream(Encoding.UTF8.GetBytes(base64));
                }
            }
            return "";
        }

        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
