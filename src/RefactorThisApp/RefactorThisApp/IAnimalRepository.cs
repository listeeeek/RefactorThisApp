using LanguageExt;

namespace RefactorThisApp;

public interface IAnimalRepository
{
    //TODO: tu pewnie powinno sie cos pojawic


    Option<Animal> GetAnimal(string nazwa);
}