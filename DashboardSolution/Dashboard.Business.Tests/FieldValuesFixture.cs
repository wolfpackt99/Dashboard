using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard.Business.Tests
{
    [TestClass]
    public class FieldValuesFixture
    {
        [TestMethod]
        public void GetDocument()
        {
            var myDoc = FieldValues.GetActivityItems();
            myDoc.Should().NotBeNull("Document shouldn't be null");
        }
    }
}
