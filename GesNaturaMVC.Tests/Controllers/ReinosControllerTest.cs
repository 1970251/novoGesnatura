using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using GesNaturaMVC.Controllers;
using GesNaturaMVC.DAL;
using GesPhloraClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GesNaturaMVC.Tests.Controllers
{
    [TestClass]
    public class ReinosControllerTest
    {
        private IGesNaturaDbContext db = new IGesNaturaDbContext();

        [TestMethod]
        public async Task TestIndex()
        {
            // Arrange
            ReinosController controller = new ReinosController();
            var reino = await db.Classes.FindAsync();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDetailsData()
        {
            var controller = new ReinosController();
            var result = controller.Details(1).Result as ViewResult;
            var reino = (Reino)result.ViewData.Model;
            Assert.AreEqual("Animal", reino.Nome);
        }
        [TestMethod]
        public void TestReinosAllData()
        {
            var context = new TestGesNaturaAppContext();

            context.Reinoes.Add(new Reino { ID = 1, Nome = "AnimalTeste" });
            context.Reinoes.Add(new Reino { ID = 2, Nome = "VegetalTeste" });

            var controller = new ReinosController();
            var resultado = controller.Index() as ViewResult;

            Assert.IsNotNull(resultado);
        }
    }
}
