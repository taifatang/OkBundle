using System;
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
            okResult.Result.Predicate.ShouldEqual(expected);
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
            var isExcuted = !predicate;

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

            Ok.If(false).Do(() => { isExcuted = false; })
                .ElseIf(predicate).Do(() => { isExcuted = true; });

            isExcuted.ShouldEqual(predicate);
        }
        [TestCase(0)]
        [TestCase(true)]
        [TestCase("abc")]
        public void Should_Return_Switch_Result_When_Given_An_Switch_Object(Object anyObject)
        {
            var okResult = Ok.Switch(anyObject);

            okResult.Result.Switcheroo.ShouldEqual(anyObject);
        }
        [TestCase("matchedMe", "matchedMe", true)]
        [TestCase("matchedMe", "shouldNotExecuteDoBlock", false)]
        [TestCase(123, 123, true)]
        [TestCase(456, 789, false)]
        public void Should_Return_Correct_Execute_Property_When_Compared_Objects(Object object1, Object object2, bool expected)
        {
            var switchResult = Ok.Switch(object1).Case(object2);

            switchResult.Result.Execute.ShouldEqual(expected);
        }
        [TestCase("matchedMe", "matchedMe", true)]
        [TestCase("matchedMe", "shouldNotExecuteDoBlock", false)]
        public void Should_Perform_Do_Block_When_Case_Matched(Object object1, Object object2, bool expected)
        {
            var isExecuted = false;

            Ok.Switch(object1)
                .Case(object2).Do(() => { isExecuted = true; });

            isExecuted.ShouldEqual(expected);
        }
        [TestCase("matchedMe", "shouldNotExecuteDoBlock", "shouldNotExecuteDoBlock", 0)]
        [TestCase("matchedMe", "matchedMe", "shouldNotExecuteDoBlock", 1)]
        [TestCase("matchedMe", "case1NotMatched", "matchedMe", 2)]
        [TestCase(TestEnum.CaseZero, TestEnum.CaseOne, TestEnum.CaseTwo, 0)]
        [TestCase(TestEnum.CaseOne, TestEnum.CaseOne, TestEnum.CaseTwo, 1)]
        [TestCase(TestEnum.CaseTwo, TestEnum.CaseZero, TestEnum.CaseTwo, 2)]
        [TestCase(TestEnum.CaseFour, TestEnum.CaseZero, TestEnum.CaseTwo, 0)]
        public void Should_Skip_Do_Block_When_Case_Failed_To_Matched(Object object1, Object object2, Object object3, int expected)
        {
            var executedBlock = 0;

            Ok.Switch(object1)
                .Case(object2).Do(() => { executedBlock = 1; })
                .Case(object3).Do(() => { executedBlock = 2; });

            executedBlock.ShouldEqual(expected);
        }
    }
}
