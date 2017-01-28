using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using OkBundle.Results;

namespace OkBundle.OkObject
{
    public class OkObject<T>
    {
        public T Object { get; set; }

        public OkObject(T item)
        {
            Object = item;
        }
        public void Set(T item)
        {
            Object = item;
        }

        public T Get()
        {
            return Object;
        }
    }

    public static class OkObjectFactory
    {
        public static OkObject<T> Create<T>(T result)
        {
            return new OkObject<T>(result);
        }
    }
}
