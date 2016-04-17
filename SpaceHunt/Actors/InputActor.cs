using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Util;
using SpaceHunt.Messages;
using SpaceHunt.Utils;

namespace SpaceHunt.Actors
{
    class InputActor : ReceiveActor
    {
        private IActorRef drawingActor;
        private Cursor cursor;

        public InputActor(IActorRef drawingActor)
        {
            this.drawingActor = drawingActor;
            cursor = new Cursor();

            Receive<StartGame>(msg =>
            {
                StartConsoleListener();
            });

            Receive<ListenForNextInput>(msg =>
            {
                ListenForInput();
            });
        }

        private void StartConsoleListener()
        {
            Self.Tell(new ListenForNextInput());
        }

        private void ListenForInput()
        {
            var key = Console.ReadKey(true);
            ProcessKeyStroke(key);


            Self.Tell(new ListenForNextInput());
        }

        private void ProcessKeyStroke(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    cursor.MoveCursor(Direction.Up);
                    drawingActor.Tell(new DrawCursor(cursor.Position));
                    break;
                case ConsoleKey.DownArrow:
                    cursor.MoveCursor(Direction.Down);
                    drawingActor.Tell(new DrawCursor(cursor.Position));
                    break;
                case ConsoleKey.LeftArrow:
                    cursor.MoveCursor(Direction.Left);
                    drawingActor.Tell(new DrawCursor(cursor.Position));
                    break;
                case ConsoleKey.RightArrow:
                    cursor.MoveCursor(Direction.Right);
                    drawingActor.Tell(new DrawCursor(cursor.Position));
                    break;
            }
        }
    }

    class ListenForNextInput { }

}
