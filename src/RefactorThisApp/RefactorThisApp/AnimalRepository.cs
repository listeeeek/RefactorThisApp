// ReSharper disable LoopCanBeConvertedToQuery

using LanguageExt;

namespace RefactorThisApp;

public class AnimalRepository // : IAnimalRepository
{
    private IEnumerable<Animal> _animals = new List<Animal>()
    {
        new Animal()
        {
            Wiek = 3,
            CzyAktywne = "true",
            Nazwa = "Pluszek",
            Typ = "Kot",
            ListaSzczepien = new Dictionary<string, DateTime>()
            {
                { "SDX", DateTime.Now },
                { "RFX", DateTime.Now },
            }
        },
        new Animal()
        {
            Wiek = 10,
            CzyAktywne = "false",
            Nazwa = "Pluto",
            Typ = "Pies",
            ListaSzczepien = new Dictionary<string, DateTime>()
            {
                { "SDX", DateTime.Now },
                { "XC", DateTime.Now },
            }
        },

        new Animal()
        {
            Wiek = 11,
            CzyAktywne = "true",
            Nazwa = "Szarik",
            Typ = "Pies",
            ListaSzczepien = new Dictionary<string, DateTime>()
            {
                { "TYX", DateTime.Now },
                { "PQX", DateTime.Now },
            }
        },

        new Animal()
        {
            Wiek = 7,
            CzyAktywne = "false",
            Nazwa = "Oliwer",
            Typ = "Kananek"
        },

        new Animal()
        {
            Wiek = 20,
            CzyAktywne = "true",
            Nazwa = "Grzywka",
            Typ = "Alpaka"
        },
        new Animal()
        {
            Wiek = 9,
            CzyAktywne = "truee",
            Nazwa = "Reksio",
            Typ = "Pies",
            ListaSzczepien = new Dictionary<string, DateTime>()
            {
                { "SDX", DateTime.Now },
                { "RFX", DateTime.Now },
            }
        },
    };


    // Metoda pobiera liste zwierzat wg kryteriow czy jest nadal aktywne
    public List<Animal> GetAnimals(bool czyAktywne)
    {
        var lista = new List<Animal>();

        //TODO: refactor me pls
        foreach (var animal in _animals)
        {
            if (czyAktywne)
            {
                if (animal.CzyAktywne.ToLower() == "true")
                {
                    lista.Add(animal);
                }
            }
            else
            {
                if (animal.CzyAktywne.ToLower() == "false")
                {
                    lista.Add(animal);
                }
            }
        }

        return lista;
    }

    // Pobieranie aktywnego zwierzeta po nazwie.
    // WAZNE!!! Metoda nie powinna nic logowac.
    // To osoba wywolujaca ja powinna zdecydowac co sie stanie jak nie bedzie odpowiednich 
    // kryteriow spelnionych
    public Option<Animal> GetAnimal(string nazwa)
    {
        var v = _animals.FirstOrDefault(s => s.Nazwa.Equals(nazwa, StringComparison.CurrentCultureIgnoreCase));

        var blad = "Nie znaleziono zwierzaka";

        if (v.CzyAktywne.Equals("true", StringComparison.CurrentCultureIgnoreCase))
        {
            return v;
        }

        blad = "Zwierze istnieje w bazie danych, ale nie jest aktywny";

        return Option<Animal>.None;
    }
}