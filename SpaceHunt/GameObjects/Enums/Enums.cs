using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceHunt.GameObjects.Enums
{
    public enum State
    {
        Alive,
        Dead,
        Unknown
    }

    public enum Owner
    {
        Player,
        AI,
        Neutral,
        Contested
    }

    public enum Resource
    {
        Production,
        Food,
        Science,
        None
    }

    public enum Icons
    {
        Probe,
        Fighter,
        Cruiser,
        Station
    }


}
