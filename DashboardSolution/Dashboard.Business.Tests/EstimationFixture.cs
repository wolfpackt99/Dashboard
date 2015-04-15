using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard.Business.Tests
{
    [TestClass]
    public class EstimationFixture
    {
        [TestMethod]
        public async Task GetRemainingWorkTest()
        {
            var x = new Estimation();

            var result = await x.GetAllWorkRemaining("");

            result.Should().ContainKey("Development");
            System.Diagnostics.Debug.WriteLine(string.Format("Original: {0}", result));
        }
    }
}
