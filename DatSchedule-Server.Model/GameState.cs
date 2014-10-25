using System;

namespace DatSchedule_Server.Model
{
    public class GameState
    {
        public int StressLevel { get; set; }

        public Guid ApplicationId
        {
            get { return Guid.NewGuid(); }
        }
        public string[] Tasks { get; set; }
    }
}
