using System;
using Elmah.Assertions;

namespace DatSchedule_Server
{
    public class IndexModule : BaseHandlerModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/initiate"] = parameters =>
            {
                return "Application initiated";
            };

            Post["/init"] = parameters =>
            {
                Log();
                return "Application initiated";
            };
        }

        private void Log()
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Test Exception"));
        }
    }
}