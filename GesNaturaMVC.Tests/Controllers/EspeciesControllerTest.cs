using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GesNaturaMVC.Controllers;
using System.Web.Mvc;
using GesNaturaMVC.ViewModels;
using GesPhloraClassLibrary.Models;
using System.Threading.Tasks;
using System.Linq;

namespace GesNaturaMVC.Tests.Controllers
{
    /// <summary>
    /// Summary description for EspeciesControllerTest
    /// </summary>
    [TestClass]
    public class EspeciesControllerTest
    {
        public EspeciesControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Details()
        {
            var context = new TestGesNaturaAppContext();

            var genero = new Genero();
            var reino = new Reino();
            var classe = new Classe();
            var ordem = new Ordem();
            var familia = new Familia();
            var esp = new Especie();

            context.Reinoes.Add(new Reino { ID = 1, Nome = "Animal" });
            context.Classes.Add(new Classe { ID = 1, Nome = "Aves", ReinoID = 1 });
            context.Ordems.Add(new Ordem { ID = 1, Nome = "Passeriformes", ClasseID = 1 });
            context.Familias.Add(new Familia { ID = 1, Nome = "Motacillidae", OrdemID = 1 });
            context.Generoes.Add(new Genero { ID = 1, Nome = "Motacilla", FamiliaID = 1 });

            //especieVM.Reino = especie.Genero.Familia.Ordem.Classe.Reino.Nome;
            

            context.Especies.Add(new Especie { ID = 1, Nome = "Alvéola-branca", GeneroID = 1 });
            context.Especies.Add(new Especie { ID = 2, Nome = "Pardal-comum", GeneroID = 1 });
                      
            //var especieVM = new EspecieViewModel();
            //especieVM.Familia = "Motacillidae";
            //especieVM.Genero.Nome = "Motacilla";

            //viewModel.ID = 1;
            //viewModel.Nome = "Alvéola-branca";
            
            //var result = await controller.Details(1) as ViewResult;
            //var classe = (Classe)result.ViewData.Model;


            var controller = new EspeciesController(context);
            //var viewModel = controller.ViewData.Model as IEnumerable<Especie>;
            
            var result = controller.Details(1) as ViewResult;
            var especie = (Especie)result.ViewData.Model;
            
            Assert.IsNotNull(result);
            Assert.AreEqual("Alvéola-branca", especie.Nome);
            //Assert.IsTrue(viewModel.Count() == 2);
           
        }
    }
}
