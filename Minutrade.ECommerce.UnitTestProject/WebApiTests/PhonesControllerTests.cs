using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dto;
using Minutrade.ECommerce.BusinessObjects;
using System;

namespace Minutrade.ECommerce.UnitTestProject.WebApiTests
{
    [TestClass]
    public class PhonesControllerTests
    {
        public PhonesControllerTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void GetPhonesTest()
        {
            var phoneBo = new PhoneBo();
            var result = phoneBo.GetPhones();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetPhoneTest()
        {
            var phone = new PhoneBo();
            var result = phone.GetPhone(2);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void CreateNewPhone()
        {
            try
            {
                var dto = new PhoneDto
                {
                    ClientId = 2,
                    CodArea = 33,
                    Number = "3333-4444"
                };

                new PhoneBo().PostPhone(dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UpdatePhone()
        {
            try
            {
                var dto = new PhoneDto
                {
                    Id = 2,
                    ClientId = 3,
                    CodArea = 31,
                    Number = "1111-2222"
                };

                new PhoneBo().PutPhone(2,dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void DeletePhone()
        {
            try
            {
                new PhoneBo().DeletePhone(3);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
