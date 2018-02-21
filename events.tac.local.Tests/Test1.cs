using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace events.tac.local.Tests
{
    public class Test1
    {
        [Fact]
        public void FailedTest()
        {
            Assert.True(false);
        }
    }
}
