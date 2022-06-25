using BusinessLayer;
using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.TestGenre
{
    [TestClass]
    public class TestGenre
    {
        private int id;

        [TestMethod]
        [DataRow ("gense test")]
        public void TestAdd(string nom)
        {
            Manager.GetInstance().CreateGenre(new Genre { Nom = nom});
            Assert.IsNotNull(Manager.GetInstance().GetGenreByName(nom));
            
        }

        [TestMethod]
        [DataRow("gense test", "nouveau nom")]
        public void TestUpdate(string nom, string nouveauNom)
        {
            Manager.GetInstance().UpdateGenre(Manager.GetInstance().GetGenreByName(nom).Id, nouveauNom);
            Assert.IsNotNull(Manager.GetInstance().GetGenre(id));
            Assert.AreEqual(Manager.GetInstance().GetGenre(id).Nom, nouveauNom);
        }

        [TestMethod]
        [DataRow(40)]
        public void TestDelete(int id)
        {
            Manager.GetInstance().DeleteGenre(id);
            Assert.IsNull(Manager.GetInstance().GetGenre(id));            
        }

    }
}
