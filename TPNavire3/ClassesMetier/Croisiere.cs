using Station.Interfaces;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetier
{
    internal class Croisiere: Navire, ICroisierable
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<string, Passager> passagers;

        public char TypeNavireCroisiere { get => this.typeNavireCroisiere; }
        public int NbPassagersMaxi { get => this.nbPassagersMaxi; }
        internal Dictionary<string, Passager> Passagers { get => this.passagers; }

        
        
        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi, Dictionary<string, Passager> passagers)
            : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.passagers = passagers;
        }
        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi)
            : this(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel, typeNavireCroisiere, nbPassagersMaxi, new Dictionary<string, Passager>())
        {
        }
        public override string ToString()
        {
            return base.ToString() + " : Croisière";
        }
        public void Embarquer(List<Passager> unPassager)
        {
            if (unPassager.Count <= this.nbPassagersMaxi - this.passagers.Count)
            {
                foreach (Passager passager in unPassager)
                {
                    this.passagers.Add(passager.NumPasseport, passager);

                }
            }               
            else
            {
                throw new Exception("Il n'y a plus de places dans le navire");
            }
        }

        public void Embarquer(Passager unPassager)
        {
            if ( passagers.Count < nbPassagersMaxi)
            {
                this.passagers.Add(unPassager.NumPasseport, unPassager);
            }
        }
        public List<Passager> Debarquer(List<Passager> lesPassagers)
        {
            List<Passager> listPassager = new List<Passager>();
            foreach (Passager unPassager in lesPassagers)
            {
                if (Debarquer(unPassager))
                {         
                    listPassager.Add(unPassager);
                }
            }
            return listPassager;
        }

        public bool Debarquer (Passager passager)
        {
            return this.passagers.Remove(passager.NumPasseport);
        }
        public int NbPassager()
        {
            return this.passagers.Count;
        }
    }
}
