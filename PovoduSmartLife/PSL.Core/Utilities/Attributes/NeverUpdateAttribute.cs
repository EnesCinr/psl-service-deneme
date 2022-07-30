using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NeverUpdateAttribute : Attribute
    {
    }
}
