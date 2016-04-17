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
        private IActorRef drawingActor;
        private IActorRef inputActor;

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
            drawingActor = Context.ActorOf(Props.Create(() => new DrawingActor()), "drawingActor");
            turnEndActor = Context.ActorOf(Props.Create(() => new TurnEndActor()), "turnEndActor");
            inputActor = Context.ActorOf(Props.Create(() => new InputActor(drawingActor)), "inputActor");
        }

        private void StartGame()
        {
            drawingActor.Tell(new InitialzeScreen());
            inputActor.Tell(new StartGame());
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