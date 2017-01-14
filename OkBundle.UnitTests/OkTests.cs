using NUnit.Framework;
using Should;

namespace OkBundle.UnitTests
{
    [TestFixture]
    public class OkTests
    {
        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(!true, false)]
        [TestCase(!false, true)]
        public void If_Method_Return_Expected_Value(bool actual, bool expected)
        {
            bool result = Ok.If(actual);
            result.ShouldEqual(expected);
        }

        [TestCase(1 == 1, true)]
        [TestCase(1 == 2, false)]
        [TestCase(true && true && false, false)]
        [TestCase(true || true || false, true)]
        public void If_Should_Take_Predicate(bool predicate, bool expected)
        {
            bool result = Ok.If(predicate);
            result.ShouldEqual(expected);
        }
        [TestCase(true, 0)]
        [TestCase(false, 1)]
        public void If_Perform_Do_Block_According_To_Predicate(bool predicate, int expected)
        {
            var result = 1;

            Ok.If(predicate)
                .Do(() => { --result; });

            result.ShouldEqual(expected);
        }
        [TestCase(true, 0)]
        [TestCase(false, 2)]
        public void If_Perform_Else_Block_According_To_Predicate(bool predicate, int expected)
        {
            var result = 1;

            Ok.If(predicate)
                .Do(() => { --result; })
                .Else(() => { ++result; });

            result.ShouldEqual(expected);
        }
        [TestCase(true, 2)]
        [TestCase(false, 1)]
        public void If_Perform_Else_If_Block_According_To_Predicate(bool predicate, int expected)
        {
            var result = 1;

            Ok.If(false)
                .Do(() => { result = 0; })
                .ElseIf(predicate)
                .Do(() => { result = 2;  });

            result.ShouldEqual(expected);
        }
    }
}
