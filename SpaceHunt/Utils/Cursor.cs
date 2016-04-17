using System;
using System.Drawing;
using System.Net.Configuration;

namespace SpaceHunt.Utils
{
    public class Cursor
    {
        private Point position;
        private Point lastPosition;
       
        public Cursor()
        {
            position = new Point(0, GameSettings.GridSize.Y + GameSettings.CommandLines - 1);
            lastPosition = new Point(0, GameSettings.GridSize.Y + GameSettings.CommandLines - 1);    
        }

        public Point LastPosition { get { return lastPosition; } }

        public bool IsInCommand { get { return InCommandArea(); } }

        public Point Position { get { return position; } set { position = value; } }

        public void Set(int x, int y)
        {
            SetCursor(x, y);
            
        }

        public bool MoveCursor(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return TryUp();
                case Direction.Down:
                    return TryDown();
                case Direction.Left:
                    return TryLeft();
                case Direction.Right:
                    return TryRight();
                default:
                    return false;
            }
        }

        public bool LastInGrid()
        {
            return lastPosition.X < GameSettings.GridSize.X && lastPosition.Y < GameSettings.GridSize.Y;
        }
        
        private void SetCursor(int x, int y)
        {
            lastPosition = position;
            position.X = x;
            position.Y = y;
        }

        private bool TryUp()
        {
            if (InCommandArea())
            {
                lastPosition = position;
                position.Y -= 2;
                return true;
            }
            if (!AtTop())
            {
                lastPosition = position;
                position.Y--;
                return true;
            }
            return false;
        }

        private bool TryDown()
        {
            if (!AtBottomOfGrid() && !InCommandArea())
            {
                lastPosition = position;
                position.Y++;
                return true;
            }
            if (AtBottomOfGrid())
            {
                lastPosition = position;
                position.Y += 2;
                position.X = 0;
                return true;
            }
            return false;
        }

        private bool TryLeft()
        {
            if (InMenu())
            {
                lastPosition = position;
                position.X -= 2;
                return true;
            }
            if (!AtLeftEdge())
            {
                lastPosition = position;
                position.X--;
                return true;
            }
            return false;
        }

        private bool TryRight()
        {
            if (AtMenuEdge())
            {
                lastPosition = position;
                position.X += 2;
                if (position.Y < 2)
                {
                    position.Y = 2;
                }
                return true;
            }
            if (!AtMenuEdge() && !InMenu())
            {
                lastPosition = position;
                position.X++;
                return true;
            }
            return false;
        }

        private bool InMenu()
        {
            return position.X == GameSettings.GridSize.X + 1;
        }

        private bool InCommandArea()
        {
            return position.Y > GameSettings.GridSize.Y;
        }

        private bool AtTop()
        {
            if (InMenu())
            {
                return position.Y < 3;
            }

            return position.Y == 0;
        }
        
        private bool AtBottomOfGrid()
        {
            return position.Y == GameSettings.GridSize.Y - 1;
        }

        private bool AtLeftEdge()
        {
            return position.X == 0;
        }

        private bool AtMenuEdge()
        {
            return position.X == GameSettings.GridSize.X - 1;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}