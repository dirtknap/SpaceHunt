using System.Drawing;
using Akka.Actor;
using SpaceHunt.GameObjects.Enums;

namespace SpaceHunt.GameObjects
{
    public interface IGameObject
    {
        IActorRef ActorRef();
        Owner Owner();
        string Name();
        char Icon(); 
        State State();
        Point CurrentPos();
        Point OldPos();
    }
}