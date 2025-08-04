namespace RefactorThisApp;

public class Animal
{
    public string Typ { get; set; }
    public string Nazwa { get; set; }
    public long Wiek { get; set; }
    public string CzyAktywne { get; set; }

    public Dictionary<string, DateTime> ListaSzczepien { get; set; }
}