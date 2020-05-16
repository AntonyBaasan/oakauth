using NUnit.Framework;
using OakAuth.Interfaces.Applications;
using OakAuth.Service.Utility;

namespace OakAuth.UnitTests.Services.Utility
{
    [TestFixture]
    public class ApplicationBuilderTests
    {
        private ApplicationModelBuilder applicationModelBuilder;
        [SetUp]
        public void Setup()
        {
            applicationModelBuilder = new ApplicationModelBuilder();
        }

        [Test]
        public void CreateAppliation_Should_Set_ClientName()
        {
            var app =  applicationModelBuilder.CreateApplication("App1", ApplicationType.MachineToMachine);

            Assert.AreEqual("app1", app.ClientName);
        }
    }
}
