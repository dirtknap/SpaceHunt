using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpaceHunt.GameObjects;

namespace SpaceHunt.StateTracker
{
    class StateTracker
    {
        private StateTracker instance;

        private readonly List<IGameObject>[,] MapState;

        private object lockObject;
        
        public StateTracker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new StateTracker();
                    }
                }

                return instance;
            }
        }

        private StateTracker()
        {
            MapState = new List<IGameObject>[32,32];
        }

        public void UpdateObject(IGameObject gameObject)
        {
            lock (lockObject)
            {
                if (!MapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].Contains(gameObject))
                {
                    MapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].Add(gameObject);
                    MapState[gameObject.OldPos().X, gameObject.OldPos().Y].Remove(gameObject);
                }
            }
        }

        public void AddObject(IGameObject gameObject)
        {
            if (!StateContainsObject(gameObject))
            {
                MapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].Add(gameObject);
            }

        }
        public void RemoveObject(IGameObject gameObject)
        {
            lock (lockObject)
            {
                for (var x = 0; x < MapState.GetLength(0); x++)
                {
                    for (var y = 0; y < MapState.GetLength(1); y++)
                    {
                        if (MapState[x, y].Contains(gameObject))
                        {
                            MapState[x, y].Remove(gameObject);
                        }
                    }
                }
            }
        }

        private bool StateContainsObject(IGameObject gameObject)
        {
            var result = new List<Point>();

            lock (lockObject)
            {
                for (var x = 0; x < MapState.GetLength(0); x++)
                {
                    for (var y = 0; y < MapState.GetLength(1); y++)
                    {
                        if (MapState[x, y].Contains(gameObject))
                        {
                            result.Add(new Point(x, y));
                        }

                    }
                }
            }

            return result.Count > 0;
        }

        private List<Point> StateFindObject(IGameObject gameObject)
        {
            var result = new List<Point>();

            lock (lockObject)
            {
                for (var x = 0; x < MapState.GetLength(0); x++)
                {
                    for (var y = 0; y < MapState.GetLength(1); y++)
                    {
                        if (MapState[x, y].Contains(gameObject))
                        {
                            result.Add(new Point(x, y));
                        }

                    }
                }
            }

            return result;
        }

    }
}
