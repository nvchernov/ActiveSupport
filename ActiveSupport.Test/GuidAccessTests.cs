using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ActiveSupport;

namespace ActiveSupport.Test
{
    public class GuidAccessTests
    {
        private const string GUID_TEST_VALUE = "0cf24680-4b64-11e3-ab73-001517c9f119";

        [Fact]
        public void Test_nullable_null_guid()
        {
            Guid? guid = null;

            Assert.True(guid.IsBlank());
            Assert.False(guid.IsPresent());

        }

        [Fact]
        public void Test_nullable_empty_guid()
        {
            Guid? guid = Guid.Empty;

            Assert.True(guid.IsBlank());
            Assert.False(guid.IsPresent());

        }

        [Fact]
        public void Test_nullable_guid_with_value()
        {
            Guid? guid = Guid.Parse(GUID_TEST_VALUE);

            Assert.False(guid.IsBlank());
            Assert.True(guid.IsPresent());
        }



        public void Test_empty_guid()
        {
            Guid guid = Guid.Empty;

            Assert.True(guid.IsBlank());
            Assert.False(guid.IsPresent());
        }

        [Fact]
        public void Test_guid_with_value()
        {
            Guid guid = Guid.Parse(GUID_TEST_VALUE);

            Assert.False(guid.IsBlank());
            Assert.True(guid.IsPresent());
        }



    }
}
