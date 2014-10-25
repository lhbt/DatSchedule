namespace DatScheduleServer.Model
{
    public class GameState
    {
        public GameState(int stressLevel, int fatigueLevel, int hungerLevel)
        {
            StressLevel = stressLevel;
            FatigueLevel = fatigueLevel;
            HungerLevel = hungerLevel;
            DayIsOver = false;
        }

        public bool DayIsOver { get; set; }

        public int StressLevel { get;  set; }
        public int FatigueLevel { get;  set; }
        public int HungerLevel { get;  set; }
    }
}