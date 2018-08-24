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
        [TestMethod]
        public void TestReinosCreate()
        {
            var context = new TestGesNaturaAppContext();

            context.Reinoes.Add(new Reino { ID = 1, Nome = "AnimalTeste" });
            context.Reinoes.Add(new Reino { ID = 2, Nome = "VegetalTeste" });

            var controller = new ReinosController(context);

            var resultado = controller.Create() as ViewResult;
            
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task TestReinosIndex()
        {
            var context = new TestGesNaturaAppContext();

            context.Reinoes.Add(new Reino { ID = 1, Nome = "AnimalTeste" });
            context.Reinoes.Add(new Reino { ID = 2, Nome = "VegetalTeste" });

            var controller = new ReinosController(context);

            var resultado = await controller.Index() as ViewResult;
            
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public async Task TestDetails()
        {
            var context = new TestGesNaturaAppContext();

            context.Reinoes.Add(new Reino { ID = 1, Nome = "AnimalTeste" });
            context.Reinoes.Add(new Reino { ID = 2, Nome = "VegetalTeste" });

            var controller = new ReinosController(context);

           
            var result = await controller.Details(1) as ViewResult;
            var reino = (Reino)result.ViewData.Model;
            Assert.AreEqual("AnimalTeste", reino.Nome);
        }
        Reino GetDemoReino()
        {
            return new Reino() { ID = 3, Nome = "Nome Demo" };
        }
    }
}
