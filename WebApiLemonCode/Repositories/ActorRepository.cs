using Newtonsoft.Json;
using System.Net.Http.Json;
using WebApiLemonCode.Contract;
using WebApiLemonCode.Models;

namespace WebApiLemonCode.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Users\jzafr\source\repos\WEBAPILEMONCODE\WebApiLemonCode\Resources\Actores.json";

        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public Actor DeleteActor(int Id)
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> actors = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);

                var actorBorrado = actors.FirstOrDefault(a => a.Id == a.Id);

                actors.Remove(actorBorrado);

                string updatedJsonContent = JsonConvert.SerializeObject(actors);
                File.WriteAllText("C:\\Users\\jzafr\\source\\repos\\WEBAPILEMONCODE\\WebApiLemonCode\\Resources\\Actores.json", updatedJsonContent);
                return actorBorrado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Actor GetActorbyId(int id)
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> listActores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                var actorById = listActores.FirstOrDefault(a => a.Id == id);
                return actorById;

            } catch (Exception ex)
            {
                throw;
            }
        }

        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> listActores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                return listActores;
            } catch (Exception e)
            {
                throw;
            }
        }

        public Actor UpdateActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        private string GetActorsFromFile()
        {
            return File.ReadAllText(JSON_PATH);
        }

        void IActorRepository.UpdateActor(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
