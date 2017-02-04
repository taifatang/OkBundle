using System;
using NUnit.Framework;
using OkBundle.UnitTests.Enums;
using Should;

namespace OkBundle.UnitTests.Tests
{
    [TestFixture]
    public class SwitchTests
    {

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
        [TestCase(OkSwitchEnum.CaseZero, OkSwitchEnum.CaseOne, OkSwitchEnum.CaseTwo, 0)]
        [TestCase(OkSwitchEnum.CaseOne, OkSwitchEnum.CaseOne, OkSwitchEnum.CaseTwo, 1)]
        [TestCase(OkSwitchEnum.CaseTwo, OkSwitchEnum.CaseZero, OkSwitchEnum.CaseTwo, 2)]
        [TestCase(OkSwitchEnum.CaseFour, OkSwitchEnum.CaseZero, OkSwitchEnum.CaseTwo, 0)]
        public void Should_Skip_Do_Block_When_Case_Failed_To_Matched(Object object1, Object object2, Object object3, int expected)
        {
            var executedBlock = 0;

            Ok.Switch(object1)
                .Case(object2).Do(() => { executedBlock = 1; })
                .Case(object3).Do(() => { executedBlock = 2; });

            executedBlock.ShouldEqual(expected);
        }
        [Test]
        public void Should_Execute_Default_Block_When_Case_Failed_To_Matched()
        {
            var executedBlock = 0;

            Ok.Switch(1)
                .Case(2).Do(() => { executedBlock = 1; })
                .Case(3).Do(() => { executedBlock = 2; })
                .Default(() => { executedBlock = 3; });

            executedBlock.ShouldEqual(3);
        }
        [Test]
        public void Should_Not_Execute_Default_Block_When_Case_Matched()
        {
            var executedBlock = 0;

            Ok.Switch(1)
                .Case(1).Do(() => { executedBlock = 1; })
                .Default(() => { executedBlock = 2; });

            executedBlock.ShouldEqual(1);
            executedBlock.ShouldNotEqual(2);
        }
    }
}
