using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minutrade.ECommerce.CommonObjects.Validations;

namespace Minutrade.ECommerce.UnitTestProject.CommonObjectsTests
{
    [TestClass]
    public class CpfValidationsTests
    {
        [TestMethod]
        public void ValidateCorrectCpfTest()
        {
            const string cpfNumber = "849.678.822-93";
            var result             = Cpf.Validade(cpfNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateWrongCpfTest()
        {
            const string cpfNumber = "111.222.333-44";
            var result             = Cpf.Validade(cpfNumber);

            Assert.IsFalse(result);
        }
    }
}