using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dto;
using Minutrade.ECommerce.BusinessObjects;
using System;

namespace Minutrade.ECommerce.UnitTestProject.WebApiTests
{
    [TestClass]
    public class MaritalStatusControllerTests
    {
        public MaritalStatusControllerTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void GetMaritalStatusTest()
        {
            var maritalBo = new MaritalStatusBo();
            var result = maritalBo.GetMaritalStatus();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetMaritalStatuTest()
        {
            var marital = new MaritalStatusBo();
            var result = marital.GetMaritalStatu(3);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void CreateNewMaritalStatus()
        {
            try
            {
                var dto = new MaritalStatuDto
                {
                    MaritalStatus = "Companheiro"
                };

                new MaritalStatusBo().PostMaritalStatus(dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UpdateMaritalStatus()
        {
            try
            {
                var dto = new MaritalStatuDto
                {
                    Id = 2,
                    MaritalStatus = "Casado(a)"
                };

                new MaritalStatusBo().PutMarital(2,dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void DeleteClient()
        {
            try
            {
                new MaritalStatusBo().DeleteMarital(1);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
