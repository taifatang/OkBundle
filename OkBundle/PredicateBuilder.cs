using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OkBundle.Interfaces;

namespace OkBundle
{
    public class PredicateBuilder<T>
    {
        private readonly IPredicate predicate;

        public PredicateBuilder(IPredicate predicate)
        {
            this.predicate = predicate;
        }


    }
}
