using System;
using OkBundle.Results;

namespace OkBundle
{
    public static class Ok
    {
        //If
        public static OkResult<If> If(bool predicate)
        {
            var ifResult = new If
            {
                Predicate = predicate
            };

            return ResultFactory.Create(ifResult);
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
        //While
        public static OkResult<While> While(bool predicate)
        {
            return ResultFactory.Create(new While(predicate));
        }
        //public static void Do(this OkResult<While> whileResult, Action action)
        //{
        //    if (whileResult.Result.Predicate)
        //    {
        //        action();
        //    }
        //}
    }
}
