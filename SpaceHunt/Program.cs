using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace SpaceHunt
{
    class Program
    {

        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            Console.SetWindowSize(32,32);

            MyActorSystem = ActorSystem.Create("MyActorSystem");

            MyActorSystem.WhenTerminated.Wait();
        }
    }
}
