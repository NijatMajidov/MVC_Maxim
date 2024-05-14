using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Exceptions
{
    public class FileSizeException : Exception
    {
        public FileSizeException(string name,string? message) : base(message)
        {
            PropertyName = name;
        }

        public string PropertyName { get; set; }

    }
}
