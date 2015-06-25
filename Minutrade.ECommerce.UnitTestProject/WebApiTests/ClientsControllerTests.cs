using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.UnitTestProject.WebApiTests
{
    [TestClass]
    public class ClientsControllerTests
    {
        public ClientsControllerTests()
        {
            MapperConfig.InitMaps();
        }

        [TestMethod]
        public void GetClientsTest()
        {
            var clientBo = new ClientsBo();
            var result = clientBo.GetClients();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetClientTest()
        {
            var client = new ClientsBo();
            var result = client.GetClient(3);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void CreateNewClientWithValideCpfTest()
        {
            try
            {
                var dto = new ClientDto
                {
                    MaritalStatusId = 2,
                    StateId = 2,
                    Cpf = "508.803.883-66",
                    Name = "José Teste Filho",
                    Email = "filho@teste.com",
                    Street = "Avenida Qualquer",
                    Neighborhood = "Qualquer",
                    Number = 200,
                    CEP = "4058500",
                    Complement = "casa",
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

        [TestMethod]
        public void UpdateClientWithValideCpfTest()
        {
            try
            {
                var dto = new ClientDto
                {
                    Id = 6,
                    MaritalStatusId = 2,
                    StateId = 2,
                    Cpf = "508.803.883-66",
                    Name = "José Teste Filhooooo",
                    Email = "filho@teste.com",
                    Street = "Avenida Qualquer",
                    Neighborhood = "Qualquer",
                    Number = 200,
                    CEP = "4058500",
                    Complement = "casa",
                    ReferenceInformation = "Proximo a escola estadual"
                };

                new ClientsBo().PutClient(6,dto);

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
                new ClientsBo().DeleteClient(5);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}