using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceHunt.GameObjects;
using SpaceHunt.GameObjects.Enums;

namespace SpaceHunt.StateTracker
{
    public class Sector
    {
        public string Name { get; set; }

        public Point Position { get; set; }

        public Owner Owner { get; set; }

        public Resource Resource { get; set; }

        public List<IGameObject> Objects { get; set; }
     
        public bool IsDirty { get; set; }

        public Sector(string name, Point position)
        {
            Name = name;
            Position = position;
            Objects = new List<IGameObject>();
            Owner = Owner.Neutral;
            IsDirty = false;
        }

        public bool HasObject(IGameObject gameObject)
        {
            return Objects.Contains(gameObject);
        }


        public void AddGameObject(IGameObject gameObject)
        {           
            Objects.Add(gameObject);
            SetOwner();
            IsDirty = true;
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            Objects.Remove(gameObject);
            SetOwner();
            IsDirty = true;
        }

        private void SetOwner()
        {
            var ai = Objects.AsEnumerable().Count(x => x.Owner() == Owner.AI);
            var player = Objects.AsEnumerable().Count(x => x.Owner() == Owner.Player);

            if (ai > 0 && player > 0)
            {
                Owner = Owner.Contested;
            }
            else
            {
                Owner = ai > 0 ? Owner.AI : Owner.Neutral;
                Owner = player > 0 ? Owner.Player : Owner.Neutral;
            }
        }

    }
}
