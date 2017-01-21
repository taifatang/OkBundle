using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkBundle
{
    public static class Ok
    {
        public static OkResult If(bool predicate)
        {
            return OkResult.Create(predicate);
        }
        public static OkResult Do(this OkResult result, Action action)
        {
            if (result.Predicate == true)
            {
                action();
            }
            return result;
        }
        public static OkResult ElseIf(this OkResult result, bool nextPredicate)
        {
            return OkResult.Create(nextPredicate);
        }
        public static void Else(this OkResult result, Action action)
        {
            if (result.Predicate == false)
            {
                action();
            }
        }

        public static OkSwitchResult Switch(any)
        {
            
        }
    }
}
