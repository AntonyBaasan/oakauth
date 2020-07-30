using NUnit.Framework;
using OakAuth.Interfaces.Applications;
using OakAuth.Models.Applications;
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
        public void CreateAppliation_SetClientName()
        {
            var app =  applicationModelBuilder.CreateApplication("App1", ApplicationType.MachineToMachine);

            Assert.AreEqual("App1", app.ClientName);
        }

        [Test]
        public void CreateAppliation_SetApplicationType()
        {
            var app =  applicationModelBuilder.CreateApplication("App1", ApplicationType.MachineToMachine);

            Assert.AreEqual(ApplicationType.MachineToMachine, app.ApplicationType);
        }

        [Test]
        public void CreateAppliation_WhenMachineToMachineType_AllowedScopesEmpty()
        {
            var app =  applicationModelBuilder.CreateApplication("App1", ApplicationType.MachineToMachine);

            Assert.AreEqual(0, app.AllowedScopes.Count);
        }
    }
}
