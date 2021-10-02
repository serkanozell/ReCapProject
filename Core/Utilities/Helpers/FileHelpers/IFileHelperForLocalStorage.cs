using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelperForLocalStorage
    {
        string Add(IFormFile file, string path);
        string Update(List<IFormFile> filesForUpdate, string pathForUpdate);
        string Delete(List<IFormFile> filesToDelete, string pathToDelete);

    }
}
