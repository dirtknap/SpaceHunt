using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace SpaceHunt.Messages
{
    public class StartGame { }

    public class StartTurn { }

    public class TurnComplete
    {
        public IActorRef ActorRef { get; set; }
        public String Name { get; set; }

        public TurnComplete(IActorRef actorRef, string name)
        {
            ActorRef = actorRef;
            Name = name;
        }
    }

    public class RunEndOfTurn { }

    public class EndOfTurnComplete { }
}
