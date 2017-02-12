using NUnit.Framework;
using OkBundle.Results;
using Should;

namespace OkBundle.UnitTests.Tests
{
    [TestFixture]
    public class WhileTests
    {
        [Test]
        public void Should_Return_While_Result_Object_When_Invoked()
        {
            var whileResult = Ok.While(true);

            whileResult.ShouldBeType<OkResult<While>>();
        }
        [Test]
        public void Should_Execute_While_Block_When_Predicate_Evaluate_To_True()
        {
            var isExecuted = false;
            Ok
                .While(true).Do(() => { isExecuted = true; });

            isExecuted.ShouldBeTrue();
        }
        [Test]
        public void Should_Execute_Twice()
        {
            var runCycles = 0;
            var tracker = 2;
            //Ok
            //    .While(ref tracker > 0, () =>
            //    {
            //        runCycles++;
            //        tracker--;
            //    });

            runCycles.ShouldEqual(2);
        }
    }
}
