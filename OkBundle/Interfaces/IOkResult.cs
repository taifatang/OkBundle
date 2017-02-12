using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkBundle.Interfaces
{
    public interface IOkResult<T>
    {
        T Result { get; }
    }
}
