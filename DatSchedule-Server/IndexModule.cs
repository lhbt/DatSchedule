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
        }
    }
}