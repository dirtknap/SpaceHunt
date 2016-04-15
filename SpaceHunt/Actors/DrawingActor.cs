using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using SpaceHunt.GameObjects.Enums;
using SpaceHunt.Messages;
using SpaceHunt.StateTracker;

namespace SpaceHunt.Actors
{
    class DrawingActor : ReceiveActor
    {
        private Dictionary<Owner, ConsoleColor> colors = new Dictionary<Owner, ConsoleColor>()
        {
            {Owner.AI, ConsoleColor.Red },
            {Owner.Player, ConsoleColor.Blue },
            {Owner.Contested, ConsoleColor.Magenta },
            {Owner.Neutral, ConsoleColor.Black }
        };

        private Dictionary<Resource, ConsoleColor> resourceColors = new Dictionary<Resource, ConsoleColor>()
        {
            {Resource.Science, ConsoleColor.Cyan },
            {Resource.Food,  ConsoleColor.Green },
            {Resource.Production, ConsoleColor.Yellow },
            {Resource.None, ConsoleColor.Gray }
        };

        private Dictionary<Resource, char> resourceIcons = new Dictionary<Resource, char>()
        {
            {Resource.Science, '\u03A3' },
            {Resource.Food,  'F' },
            {Resource.Production, '\u03A9' },
            {Resource.None, ' ' }
        };

        private List<char[]> rightColumn = new List<char[]>();


        public DrawingActor()
        {
            Receive<InitialzeScreen>(msg =>
            {
                InitialzeScreen();
            });

            Receive<DrawSector>(msg =>
            {
                UpdateSector(msg.Sector);
            });
        }

        private void InitialzeScreen()
        {
            Console.Clear();

            InitializeRightColumn();
            Console.SetCursorPosition(0,0);

            var map = StateTracker.StateTracker.Instance.GetState();

            for (var y = 0; y < map.GetLength(1); y++)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    UpdateSector(map[x,y]);
                }

                if (y < rightColumn.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(rightColumn[y]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.SetCursorPosition(0,32);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Command:");
        }

        private void UpdateSector(Sector sector)
        {
            Console.SetCursorPosition(sector.Position.X, sector.Position.Y);
            Console.BackgroundColor = colors[sector.Owner];
            Console.ForegroundColor = sector.Owner == Owner.Neutral ? ConsoleColor.Gray : ConsoleColor.Yellow;

            if (sector.Owner == Owner.Contested)
            {
                Console.Write('X');
            }
            else if (sector.Resource != Resource.None)
            {
                Console.ForegroundColor = sector.Owner == Owner.Neutral
                    ? resourceColors[sector.Resource]
                    : ConsoleColor.Yellow;
                Console.Write(resourceIcons[sector.Resource]);
            }
            else
            {
                Console.Write((sector.Objects.Count > 1 ? sector.Objects.First().Icon() : ' '));
            }
        }

        private void InitializeRightColumn()
        {
            rightColumn.Add("|\u03A9 SPACEHUNT \u03A9|".ToCharArray());
            rightColumn.Add("|-------------|".ToCharArray());

            var x = 0;

            while (x < 29)
            {
                rightColumn.Add("|             |".ToCharArray());

                x++;
            }

            rightColumn.Add("|-------------|".ToCharArray());
        }
    }
}
