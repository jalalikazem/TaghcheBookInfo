using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaghcheBookInfo.Application.Common
{
    public class GeneralResponse
    {
        public GeneralResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; }
        public string Message { get; set; }
        public object Data { get; set; }
        public GeneralResponse(bool succeeded, object data, string message)
        {
            Succeeded = succeeded;
            Data = data;
            Message = message;
        }
        public static GeneralResponse Success()
        {
            return new(true);
        }

        public static GeneralResponse Failed()
        {
            return new(false);
        }

        public static GeneralResponse Success(object data, string message)
        { 
            return new(true, data, message);
        }
        public static GeneralResponse Failed(string message)
        {
            return new(false, null, message);
        }

        public static implicit operator bool(GeneralResponse managerResult)
        {
            return managerResult.Succeeded;
        }
    }

    
}
