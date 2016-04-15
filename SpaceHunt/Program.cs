using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using SpaceHunt.Actors;
using SpaceHunt.Messages;

namespace SpaceHunt
{
    class Program
    {

        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            Console.SetWindowSize(79,34);
            Console.SetBufferSize(79,34);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorSize = 100;

            MyActorSystem = ActorSystem.Create("MyActorSystem");

            var gameManager = MyActorSystem.ActorOf(Props.Create(() => new GameManagerActor()), "manager");

            gameManager.Tell(new StartGame());

            MyActorSystem.WhenTerminated.Wait();
        }
    }
}
