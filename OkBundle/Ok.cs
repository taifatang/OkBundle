using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using OkBundle.Interfaces;
using OkBundle.Models;
using OkBundle.Results;

namespace OkBundle
{
    public static partial class Ok
    {

        //If
        public static OkResult<If> If(bool predicate)
        {
            return ResultFactory.Create(new If { Predicate = predicate });
        }

        public static OkResult<If> Do(this OkResult<If> okResult, Action action)
        {
            if (okResult.Result.Predicate == true)
            {
                action();
            }
            return okResult;
        }

        public static OkResult<If> ElseIf(this OkResult<If> okResult, bool nextPredicate)
        {
            okResult.Result.Predicate = nextPredicate;
            return okResult;
        }

        public static void Else(this OkResult<If> okResult, Action action)
        {
            if (okResult.Result.Predicate == false)
            {
                action();
            }
        }

    }
    public static partial class Ok
    {
        //Switch
        public static OkResult<Switch<T>> Switch<T>(T item)
        {
            var switchResult = new Switch<T>
            {
                Switcheroo = item
            };
            return ResultFactory.Create(switchResult);
        }

        public static OkResult<Switch<T>> Case<T>(this OkResult<Switch<T>> switchResult, T toBeCompared)
        {
            if (switchResult.Result.Switcheroo.Equals(toBeCompared))
            {
                switchResult.Result.Execute = true;
            }
            return switchResult;
        }

        public static OkResult<Switch<T>> Do<T>(this OkResult<Switch<T>> switchResult, Action action)
        {
            if (switchResult.Result.Execute)
            {
                action();
                switchResult.Result.InhibitNextExecution();
            }
            return switchResult;
        }
        public static void Default<T>(this OkResult<Switch<T>> switchResult, Action action)
        {
            if (switchResult.Result.ExecuteDefault)
            {
                action();
            }
        }
    }

    public static partial class Ok
    {
        public static void While(ref bool predicate, Action action)
        {
            while (predicate)
            {
                action();
            }
        }
        //While
        public static OkResult<While> While(bool predicate)
        {
            return ResultFactory.Create(new While(predicate));
        }
        public static void Do(this OkResult<While> whileResult, Action action)
        {
            var which = whileResult;
            RunCycle(ref which, action);
        }

        private static void RunCycle(ref OkResult<While> whileResult, Action action)
        {
            if (whileResult.Result.Predicate)
            {
                action();
            }
        }
    }

    public static partial class Ok
    {
        public static void ForEach<T>(IEnumerable<T> source, Action<T> action)
        {
            foreach (T i in source)
            {
                action(i);
            }
        }
    }

    public static partial class Ok
    {

        public static void For(int initialize, bool conditions, Func<int, int> evaluation) //conditions needs to be object
        {
            var forModel = new ForModel(initialize, conditions, evaluation);
        }

        public static void Do<T>(this T a, Action<T> action)
        {
            //TODO: broken
            action(a);
        }
    }

    public static partial class Ok
    {

    }
}
