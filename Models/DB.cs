using Microsoft.AspNetCore.Components.HtmlRendering.Infrastructure;

namespace Edilizia.Models
{
    public static class DB
    {
        private static int _maxId = 2;

        private static List<Dipendente> _dipendenti { get; set; } = [
            new Dipendente() { DipendenteId = 0, Nome = "Marco", Cognome = "Silveri", Indirizzo = "Via Fasulla 123", CodiceFiscale = "MarcoScemo", Coniugato = true, Figli = 33, Mansione = "Nulla facente" },
            new Dipendente() { DipendenteId = 1, Nome = "Francesco", Cognome = "Missorini", Indirizzo = "Via Fasulla 321", CodiceFiscale = "FrancescoScemo", Coniugato = false, Figli = 1, Mansione = "Salvini" },
            new Dipendente() { DipendenteId = 2, Nome = "Abel", Cognome = "Sassu", Indirizzo = "Via Fasulla ancora", CodiceFiscale = "AbelScemo", Coniugato = true, Figli = 0, Mansione = "Mematore" },
        ];

        public static List<Dipendente> getAll()
        {
            return _dipendenti;
        }
        public static Dipendente? getById(int? id)
        {
            if (id == null) return null;
            for (int i = 0; i < _dipendenti.Count; i++)
            {
                Dipendente dipendente = _dipendenti[i];
                if (_dipendenti[i].DipendenteId == id)
                {
                    return dipendente;
                }
            }
            return null;
        }
        
        public static Dipendente AggiungiDipendente(string nome, string cognome, string indirizzo, string codicefiscale, bool coniugato, int figli, string mansione)
        {
            _maxId++;
            var dipendente = new Dipendente() { DipendenteId = _maxId, Nome = nome, Cognome = cognome, Indirizzo = indirizzo, CodiceFiscale = codicefiscale, Coniugato=coniugato, Figli=figli,  Mansione=mansione };
            _dipendenti.Add(dipendente);
            return dipendente;
        }
    }
}
