using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.API.Type
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
