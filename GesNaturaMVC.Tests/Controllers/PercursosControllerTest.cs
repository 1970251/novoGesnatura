using System;
using System.Web.Mvc;
using GesNaturaMVC.Controllers;
using GesNaturaMVC.DAL;
using GesNaturaMVC.Models;
using GesNaturaMVC.ViewModels;
using GesPhloraClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;

namespace GesNaturaMVC.Tests.Controllers
{
    [TestClass]
    public class PercursosControllerTest
    {
        
        [TestMethod]
        public void DetailsView()
        {
            var context = new TestGesNaturaAppContext();
            var percurso = new Percurso();
            percurso.ID = 1;
            percurso.Nome = "Um Caminho";
            percurso.Tipologia = "Linear";
            percurso.Dificuldade = "Baixa";
            percurso.DuracaoAproximada = 2;
            percurso.Distancia = 5;
            context.Percursos.Add(percurso);
            //context.Percursos.Add(new Percurso { ID = 1, Nome="Um Caminho" });

            var percCriado = new PercursosCriados();
            percCriado.IDCliente = "12345";
            percCriado.NomeCliente = "Luis";
                        
            var percursoVM = new PercursoVM();
            percursoVM.ID = percurso.ID;
            percursoVM.Nome = percurso.Nome;
            percursoVM.ClientID = percCriado.IDCliente;
            percursoVM.Nome = percCriado.NomeCliente;
                    
            //Act
            var controller = new PercursosController(context);
            var result = controller.Details(1) as ViewResult;
            var perc = (Percurso)result.ViewData.Model;
            
            //Assert
            Assert.AreEqual("Um Caminho", perc.Nome);

        }
        [TestMethod]
        public void Index()
        {
            //Arrange
            var context = new TestGesNaturaAppContext();
            var percurso = new Percurso();
            percurso.ID = 1;
            percurso.Nome = "Um Caminho";
            percurso.Tipologia = "Linear";
            percurso.Dificuldade = "Baixa";
            percurso.DuracaoAproximada = 2;
            percurso.Distancia = 5;
            context.Percursos.Add(percurso);
            //context.Percursos.Add(new Percurso { ID = 1, Nome="Um Caminho" });
            var percursoVM = new PercursoVM();
            percursoVM.ID = percurso.ID;
            percursoVM.Nome = percurso.Nome;

            //Act
            var controller = new PercursosController(context);
            var result = controller.Index(percursoVM);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            

        }
    }
}
