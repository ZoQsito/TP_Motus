using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motus.Core;

namespace Motus.CoreTests.CalculMotServiceTests
{
    [TestClass]
    public class CalculMot_Should
    {
        [TestMethod]
        public void SplitLetter_WhenCalcul()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("ABC", "XXX");

            Assert.AreEqual('A', actual.Lettres[0].Caractere);
            Assert.AreEqual('B', actual.Lettres[1].Caractere);
            Assert.AreEqual('C', actual.Lettres[2].Caractere);
        }

        [TestMethod]
        public void CalculEtatLettre_WhenCalcul()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("ABC", "XBA");

            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, actual.Lettres[0].Etat);
            Assert.AreEqual(EtatLettre.OK, actual.Lettres[1].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, actual.Lettres[2].Etat);
        }


        [TestMethod]
        public void ReturnOk_WhenSameWord()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("test", "test");

            Assert.IsTrue(actual.IsOk());
        }

        [TestMethod]
        public void CalculEtatLettre_WhenABCCCAndCXCXX()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("ABCCC", "CXCXX");

            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, actual.Lettres[0].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, actual.Lettres[1].Etat);
            Assert.AreEqual(EtatLettre.OK, actual.Lettres[2].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, actual.Lettres[3].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, actual.Lettres[4].Etat);
        }

        [TestMethod]

        public void CalculMot_ReturnsExpectedResults()
        {
            CalculMotService service = new CalculMotService();

            EssaiMot essaiMot = service.CalculMot("CXXCC", "CCCBC");

            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, essaiMot.Lettres[0].Etat);
            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, essaiMot.Lettres[1].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, essaiMot.Lettres[2].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, essaiMot.Lettres[3].Etat);
            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, essaiMot.Lettres[4].Etat);
        }
    }
}
