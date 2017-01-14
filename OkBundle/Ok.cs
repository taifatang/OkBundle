using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkBundle
{
    public static class Ok
    {
        public static bool If(bool predicate)
        {
            return predicate;
        }
        public static bool Do(this bool predicate, Action action)
        {
            if (predicate)
            {
                action();
            }
            return predicate;
        }
        public static bool ElseIf(this bool predicate, bool nextPredicate)
        {
            return nextPredicate;
        }
        public static void Else(this bool predicate, Action action)
        {
            if (predicate == false)
            {
                action();
            }
        }
     
    }
}
