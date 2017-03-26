using BulgarianCreators.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Data.CreatorsDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new CreatorsDbContext();

            // Assert
            Assert.IsInstanceOf<CreatorsDbContext>(context);
        }

        [Test]
        public void ReturnAnInstanceOf_ICreatorsDbContext()
        {
            // Arrange & Act
            var context = new CreatorsDbContext();

            // Assert
            Assert.IsInstanceOf<ICreatorsDbContext>(context);
        }

        [Test]
        public void test()
        {
            var context = new CreatorsDbContext();

            
        }
    }
}
