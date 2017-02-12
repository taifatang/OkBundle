using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Should;

namespace OkBundle.UnitTests.Tests
{
    [TestFixture]
    public class ForEachTests
    {
        [Test]
        public void Should_Called_Delegate_Once_Per_Item()
        {
            var tracker = 0;
            var name = new[]
            {
                "David",
                "John",
                "Nik"
            };

            Ok.ForEach(name, (n) => { tracker++; });

            name.Length.ShouldEqual(tracker);
        }
    }
}
