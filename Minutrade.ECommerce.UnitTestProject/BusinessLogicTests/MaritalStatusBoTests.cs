using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.UnitTestProject.BusinessLogicTests
{
    [TestClass]
    public class MaritalStatusBoTests
    {
        public MaritalStatusBoTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void FailToCreateNewMaritalStatus()
        {
            try
            {
                var dto = new MaritalStatuDto
                {
                    MaritalStatus = null
                };

                new MaritalStatusBo().PostMaritalStatus(dto);
            
                Assert.IsTrue(false);
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void CreateNewMaritalStatus()
        {
            try
            {
                var dto = new MaritalStatuDto
                {
                    MaritalStatus = "União Estável"
                };

                new MaritalStatusBo().PostMaritalStatus(dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
