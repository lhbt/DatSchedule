using System;
using DatSchedule_Server.Model;
using StructureMap;

namespace DatSchedule_Server
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        public Bootstrapper()
        {
            IOC();
        }

        private void IOC()
        {
            ObjectFactory.Initialize(x=>x.For<IGameState>().Use<GameState>());
        }
    }
}