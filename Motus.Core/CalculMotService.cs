namespace Motus.Core
{
    public class CalculMotService : ICalculMotService
    {
        public EssaiMot CalculMot(string tentative, string motADeviner)
        {
            var essaiMot = new EssaiMot();


            var lettresTentative = tentative.ToCharArray();
            var lettresMotADeviner = motADeviner.ToCharArray();


            var lettres = new List<Lettre>();
            for (var i = 0; i < lettresTentative.Length; i++)
            {
                var lettre = new Lettre
                {
                    Caractere = lettresTentative[i],
                    Etat = EtatLettre.MauvaiseLettre
                };
                lettres.Add(lettre);
            }

            for (var i = 0; i < lettresTentative.Length; i++)
            {
                var lettreTentative = lettresTentative[i];


                if (lettreTentative == lettresMotADeviner[i])
                {
                    lettres[i].Etat = EtatLettre.OK;
                }

                else if (lettresMotADeviner.Contains(lettreTentative))
                {
                    lettres[i].Etat = EtatLettre.BonneLettreMalPlacee;
                }
            }


            essaiMot.Lettres = lettres;

            return essaiMot;
        }
    }
}
