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
    public class Create_Should
    {
        [Test]
        public void ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var context = CreatorsDbContext.Create();

            // Assert
            Assert.IsInstanceOf<ICreatorsDbContext>(context);
        }
    }
}
