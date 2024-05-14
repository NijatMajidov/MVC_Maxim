using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public string PropertyName { get; set; }
        public FileNotFoundException(string name, string? message) : base(message)
        {
            PropertyName = name;
        }
    }
}
