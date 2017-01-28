using System;
using OkBundle.OkObject;
using OkBundle.Results;

namespace OkBundle
{
    public static class Ok
    {
        //If
        public static OkObject<If> If(bool predicate)
        {
            var ifObject = new If(predicate);
            return OkObjectFactory.Create(ifObject);
        }
        public static OkResult<If> Do(this OkObject<If> ifObject, Action action)
        {
            if (ifObject.Get().Predicate)
            {
                action();
            }
            return ResultFactory.Create(ifObject.Get());
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
        // TODO: Replace OkResult with OkPredicate or OkObject to allow fluentAPI more Robust
        public static OkObject<Switch<T>> Switch<T>(T item)
        {
            //var switchObject = OkSwitch<T>.SetObject(item);
            var switchObject = new Switch<T>(item);
         
            return OkObjectFactory.Create(switchObject);
        }

        public static OkResult<Switch<T>> Case<T>(this OkObject<Switch<T>> switchObject, T toBeCompared)
        {
            if (switchObject.Get().Equals(toBeCompared))
            {
                switchObject.Get().Execute = true;
            }
            return ResultFactory.Create(switchObject.Get());
        }

        public static OkObject<Switch<T>> Do<T>(this OkResult<Switch<T>> switchResult, Action action)
        {
            if (switchResult.Result.Execute)
            {
                action();
                switchResult.Result.InhibitNextExecution();
            }
            return OkObjectFactory.Create(switchResult.Result);
        }

        public static void Default<T>(this OkObject<Switch<T>> switchObject, Action action)
        {
            if (switchObject.Get().ExecuteDefault)
            {
                action();
            }
        }
        //While
    }
}
