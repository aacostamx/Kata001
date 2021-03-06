﻿using Kata001.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata001.Interface
{
    public interface IFileService
    {
        string Headers { get; }
        string FileName { get; }
        void CreateCVSFile(List<ApiResponse> table);
    }
}
