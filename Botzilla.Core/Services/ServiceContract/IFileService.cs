using Botzilla.Core.Services.ServiceContract;
using Botzilla.Core.Services.ServiceImplementation;
using Botzilla.Domain.DomainBaseClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services
{
    public interface IFileService
    {
        Task<string> SaveToDisk(IFormFile file);
        Task<string> GetFileInBase64(string filePath);
    }
}
