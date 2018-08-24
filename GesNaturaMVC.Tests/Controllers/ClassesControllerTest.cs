using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using GesNaturaMVC.Controllers;
using GesNaturaMVC.DAL;
using GesPhloraClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GesNaturaMVC.Tests.Controllers
{
    [TestClass]
    public class ClassesControllerTest
    {
        [TestMethod]
        public async Task Details()
        {
            //Arrange
            var context = new TestGesNaturaAppContext();
            context.Classes.Add(new Classe { ID = 1, Nome = "Mamiferos", ReinoID=1});
            context.Classes.Add(new Classe { ID = 2, Nome = "Repteis", ReinoID=1 });
            var controller = new ClassesController(context);

            //Act
            var result = await controller.Details(1) as ViewResult;
            var classe = (Classe)result.ViewData.Model;

            //Assert
            Assert.AreEqual("Mamiferos", classe.Nome);
        }
        //[TestMethod]
        //public async Task TestIndex()
        //{

        //    // Arrange
        //    //ClassesController controller = new ClassesController();
        //    //var contextoDb = new GesNaturaDbContext();
        //    var classes = db.Classes.Include(c => c.Reino);
        //    var controller = new ClassesController();
            
        //    // Act

        //    var actionResult = await controller.Index();
        //    var result = actionResult as ViewResult;
                       
        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.Equals("Index", result.ViewName);
        //}
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    ClassesController controller = new ClassesController();

        //    // Act
        //    ViewResult result = controller.Index().Result as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
        //[TestMethod]
        //public void TestCreate()
        //{

        //    // Arrange
        //    //ClassesController controller = new ClassesController();
        //    var contextoDb = new GesNaturaDbContext();
        //    var controller = new ClassesController();
        //    // Act
        //    //ViewResult result = controller.Index() as ViewResult;
        //    var resultado = controller.Create();
        //    // Assert
        //    Assert.IsNotNull("");

        //}
        //[TestMethod]
        //public async Task TestDetails()
        //{
        //    var controller = new ClassesController();
        //    var classe = await db.Classes.FindAsync(2);
            
        //    var result = controller.Details(classe.ID).Result as ViewResult;
        //    var classes = (Classe)result.ViewData.Model;
        //    Assert.AreEqual("Mamiferos", classes.Nome);
        //    //Assert.AreEqual("Details", result.);
        //}
        //[TestMethod]
        //public void TestDetailsRedirect()
        //{
        //    var controller = new ClassesController();
        //    var result = (RedirectToRouteResult) controller.Details(-1);
        //    Assert.AreEqual("Index", result.Values["action"]);

        //}
    }
}
