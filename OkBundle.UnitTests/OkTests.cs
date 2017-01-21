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
        [TestCase(1 == 1, true)]
        [TestCase(1 == 2, false)]
        [TestCase(true && true && false, false)]
        [TestCase(true || true || false, true)]
        public void Should_Return_expected_When_Input_Is_Given(bool input, bool expected)
        {
            var okResult = Ok.If(input);
            okResult.Predicate.ShouldEqual(expected);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Perform_If_Block_Base_On_Predicate(bool predicate)
        {
            var isExcuted = false;

            Ok.If(predicate)
                .Do(() => { isExcuted = true; });

            isExcuted.ShouldEqual(predicate);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Perform_Else_Block_Base_On_Predicate(bool predicate)
        {
            var isExcuted = false;

            Ok
                .If(predicate).Do(() => { isExcuted = true; })
                .Else(() => { isExcuted = false; });

            isExcuted.ShouldEqual(predicate);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Perform_Else_If_Block_Base_On_Predicate(bool predicate)
        {
            var isExcuted = false;

            Ok
                .If(false).Do(() => { isExcuted = false; })
                .ElseIf(predicate).Do(() => { isExcuted = true;  });

            isExcuted.ShouldEqual(predicate);
        }
        public void Should_Return_Switch_Result_When_Given_Switch_Object(bool predicate)
        {
            var customValue = 0;
            var result = Ok.Switch(customValue);

            isExcuted.ShouldEqual(predicate);
        }
    }
}
