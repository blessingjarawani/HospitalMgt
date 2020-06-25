using BLL.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Services
{
    public class FileService : IFileService
    {
        private static FileService _fileService { get; set; }

        public static FileService CreateFileService()
        {
            return _fileService ?? new FileService();
        }
    }
}