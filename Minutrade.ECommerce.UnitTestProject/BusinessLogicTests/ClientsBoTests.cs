using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.UnitTestProject.BusinessLogicTests
{
    [TestClass]
    public class ClientsBoTests
    {
        public ClientsBoTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void FailToCreateNewClientWithInvalidCpfTest()
        {
            try
            {
                var dto = new ClientDto
                {
                    MaritalStatusId      = 1,
                    StateId              = 1,
                    Cpf                  = "111.222.333-44",
                    Name                 = "José Teste Filho",
                    Email                = "filho@teste.com",
                    Street               = "Avenida Qualquer",
                    Neighborhood         = "Qualquer",
                    Number               = 200,
                    CEP                  = "4058500",
                    Complement           = "",
                    ReferenceInformation = ""
                };

                new ClientsBo().PostClient(dto);

                Assert.IsTrue(false);
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void CreateNewClientWithValideCpfTest()
        {
            try
            {
                var dto = new ClientDto
                {
                    MaritalStatusId      = 2,
                    StateId              = 2,
                    Cpf                  = "508.803.883-66",
                    Name                 = "José Teste Filho",
                    Email                = "filho@teste.com",
                    Street               = "Avenida Qualquer",
                    Neighborhood         = "Qualquer",
                    Number               = 200,
                    CEP                  = "4058500",
                    Complement           = "casa",
                    ReferenceInformation = "Proximo a escola estadual"
                };

                new ClientsBo().PostClient(dto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}