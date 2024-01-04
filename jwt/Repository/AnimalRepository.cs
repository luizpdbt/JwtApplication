using CrudJwt.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudJwt.Repository
{
    public class AnimalRepository
    {
        private static List<Animal> listaAnimal;

        public AnimalRepository()
        {
            if(listaAnimal == null)
            listaAnimal = new List<Animal>();
        }

        public bool InserirAnimal(Animal animal)
        {
            if (animal == null) throw new System.Exception("Animal nao pode ser nulo");
            listaAnimal.Add(animal);

            return true;
        }

        public List<Animal> ReturnAnimals()
        {
            return listaAnimal;
        }

        public bool UpdateAnimal(Animal animal) 
        {
            var animalToUpdate = listaAnimal.Where(x => x.Code == animal.Code).FirstOrDefault();
            if (animalToUpdate != null) 
            {
                animalToUpdate.Name = animal.Name;
                animal.Description = animal.Description;

                listaAnimal.Add(animalToUpdate);

                return true;
            }
            throw new Exception($"Nenhum animal encontrado na lista com o valor:{animal.Code}");
        }

        public bool ExcludeAnimal(Animal animal)
        {
            if(listaAnimal.Remove(animal))
             return true;

            throw new Exception($"Nenhum animal encontrado na lista com o valor:{animal.Code} para exclusao");
        }
    }
}
