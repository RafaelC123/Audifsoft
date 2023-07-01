using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Application.CustomAttributes.Models
{
    public class Scheme : Attribute
    {
        public Scheme(string Scheme)
        {
            this.scheme = Scheme;
        }

        public string scheme { get; }
    }
}
