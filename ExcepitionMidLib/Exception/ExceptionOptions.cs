using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepitionMidLib.Exception
{
    public class ExceptionOptions
    {
        public int DefaultDatabaseErrorCode { get; set; } = 502;
        public int DefaultInternalServerErrorCode = 501;
    }
}
