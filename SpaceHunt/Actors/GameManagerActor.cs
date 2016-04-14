using System.Collections.Generic;
using System.ComponentModel.Design;
using Akka.Actor;
using SpaceHunt.Messages;

namespace SpaceHunt.Actors
{
    public class GameManagerActor : ReceiveActor
    {

        private Dictionary<IActorRef, bool> TurnCompleteTracker = new Dictionary<IActorRef, bool>();
        private IActorRef turnEndActor;

        public GameManagerActor()
        {
            Receive<StartGame>(s =>
            {
                StartGame();
            });

            Receive<TurnComplete>(msg =>
            {
                TurnCompleteTracker[msg.ActorRef] = true;
                CheckForTurnComplete(); 
            });

            Receive<EndOfTurnComplete>(msg =>
            {
                StartGameTurn();
            });
        }



        protected override void PreStart()
        {
            turnEndActor = Context.ActorOf(Props.Create(() => new TurnEndActor()), "TurnEndActor");
        }

        private void StartGame()
        {
            StartGameTurn();   
        }

        private void StartGameTurn()
        {
            foreach (var actor in TurnCompleteTracker.Keys)
            {
                actor.Tell(new StartTurn());
                TurnCompleteTracker[actor] = false;
            }
        }

        private void CheckForTurnComplete()
        {
            if (!TurnCompleteTracker.ContainsValue(false))
            {
                turnEndActor.Tell(new RunEndOfTurn());   
            }
        }


    }
}