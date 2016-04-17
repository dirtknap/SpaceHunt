using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using SpaceHunt.Actors;
using SpaceHunt.Messages;
using SpaceHunt.Utils;

namespace SpaceHunt
{
    class Program
    {

        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            Console.SetWindowSize(GameSettings.GridSize.X + GameSettings.RightColumnSize, GameSettings.GridSize.Y + GameSettings.CommandLines);
            Console.SetBufferSize(GameSettings.GridSize.X + GameSettings.RightColumnSize, GameSettings.GridSize.Y + GameSettings.CommandLines);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorSize = 100;
            //Console.

            MyActorSystem = ActorSystem.Create("MyActorSystem");

            var gameManager = MyActorSystem.ActorOf(Props.Create(() => new GameManagerActor()), "manager");

            gameManager.Tell(new StartGame());

            MyActorSystem.WhenTerminated.Wait();
        }
    }
}
