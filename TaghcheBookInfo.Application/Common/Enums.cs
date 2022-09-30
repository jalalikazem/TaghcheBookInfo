using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaghcheBookInfo.Application.Common
{
    public class Enums
    {
        public enum GeneralErrors
        {
            NoError = 0,
            EntryNoFound = 1,
            InternalServerError = 2,
            DataBaseError = 3,
            DuplicateEntry = 4,
            UsedBefore = 5,
            Underflow = 6,
            Overflow = 7,
            InvalidData = 8,
            InvalidOperation = 9,
            InCompeleteData = 10,
            ValueNotSet = 11,
            Unauthorized = 12
        }
    }
}
