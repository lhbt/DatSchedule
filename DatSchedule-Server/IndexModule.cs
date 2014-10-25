namespace DatSchedule_Server
{
    using Nancy;

    public class IndexModule : NancyModule
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