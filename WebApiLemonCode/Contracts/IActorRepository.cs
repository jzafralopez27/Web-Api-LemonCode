using WebApiLemonCode.Models;

namespace WebApiLemonCode.Contract
{
    public interface IActorRepository
    {
        List<Actor> GetActors();
        Actor GetActorbyId(int id);
        void AddActor(Actor actor);
        void UpdateActor(Actor actor);
        Actor DeleteActor(int Id);
      
    }
}
