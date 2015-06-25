using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using System.Linq;

namespace Minutrade.ECommerce.UnitTestProject.WebApiTests
{
    [TestClass]
    public class StatesControllerTests
    {
        public StatesControllerTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void GetStatesTest()
        {
            var stateBo = new StatesBo();
            var result = stateBo.GetStates();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetStateTest()
        {
            var state = new StatesBo();
            var result = state.GetState(2);

            Assert.IsTrue(result != null);
        }
    }
}
