using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaghcheBookInfo.Application.Common.Enums;

namespace TaghcheBookInfo.Application.Common
{
    public class GeneralResponse
    {
        public GeneralResponse(bool succeeded, GeneralErrors error = GeneralErrors.NoError)
        {
            Succeeded = succeeded;
            Error = error;
        }

        public bool Succeeded { get; }
        public GeneralErrors Error { get; }
        public string Message { get; set; }
        public object Data { get; set; }
        public GeneralResponse(bool succeeded, object data, string message, GeneralErrors error = GeneralErrors.NoError)
        {
            Succeeded = succeeded;
            Data = data;
            Message = message;
        }
        public static GeneralResponse Success()
        {
            return new(true);
        }

        public static GeneralResponse Failed(GeneralErrors error = GeneralErrors.InternalServerError)
        {
            return new(false, error);
        }

        public static GeneralResponse Success(object data, string message)
        { 
            return new(true, data, message);
        }
        public static GeneralResponse Failed(string message, GeneralErrors error = GeneralErrors.InternalServerError)
        {
            return new(false, null, message, error);
        }

        public static implicit operator bool(GeneralResponse managerResult)
        {
            return managerResult.Succeeded;
        }
    }

    
}
