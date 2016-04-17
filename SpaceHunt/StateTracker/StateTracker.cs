using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpaceHunt.GameObjects;
using SpaceHunt.Utils;

namespace SpaceHunt.StateTracker
{
    class StateTracker
    {
        private static StateTracker instance;

        private readonly Sector[,] mapState;

        private static object lockObject = new object();
        
        public static StateTracker Instance
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
            mapState = new Sector[64,32];

            InitializeMapState();
        }


        public Sector[,] GetState()
        {
            return mapState;
        }

        public Sector GetSector(int x, int y)
        {
            return mapState[x, y];
        }

        public void UpdateObject(IGameObject gameObject)
        {
            lock (lockObject)
            {
                if (mapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].HasObject(gameObject))
                {
                    mapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].AddGameObject(gameObject);
                    mapState[gameObject.OldPos().X, gameObject.OldPos().Y].RemoveGameObject(gameObject);
                }
            }
        }

        public void AddObject(IGameObject gameObject)
        {
            if (!StateContainsObject(gameObject))
            {
                mapState[gameObject.CurrentPos().X, gameObject.CurrentPos().Y].AddGameObject(gameObject);
            }
        }

        public void RemoveObject(IGameObject gameObject)
        {
            lock (lockObject)
            {
                for (var x = 0; x < mapState.GetLength(0); x++)
                {
                    for (var y = 0; y < mapState.GetLength(1); y++)
                    {
                        if (mapState[x, y].HasObject(gameObject))
                        {
                            mapState[x, y].RemoveGameObject(gameObject);
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
                for (var x = 0; x < mapState.GetLength(0); x++)
                {
                    for (var y = 0; y < mapState.GetLength(1); y++)
                    {
                        if (mapState[x, y].HasObject(gameObject))
                        {
                            result.Add(new Point(x, y));
                        }

                    }
                }
            }

            return result.Any();
        }

        private List<Point> StateFindObject(IGameObject gameObject)
        {
            var result = new List<Point>();

            lock (lockObject)
            {
                for (var x = 0; x < mapState.GetLength(0); x++)
                {
                    for (var y = 0; y < mapState.GetLength(1); y++)
                    {
                        if (mapState[x, y].HasObject(gameObject))
                        {
                            result.Add(new Point(x, y));
                        }
                    }
                }
            }

            return result;
        }

        private void InitializeMapState()
        {
            lock (lockObject)
            {
                for (var x = 0; x < mapState.GetLength(0); x++)
                {
                    for (var y = 0; y < mapState.GetLength(1); y++)
                    {
                        mapState[x, y] = Randomizer.Instance.GenerateRandomSector(x,y); 
                    }
                }
            }
        }

    }
}
