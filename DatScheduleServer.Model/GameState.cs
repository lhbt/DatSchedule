namespace DatScheduleServer.Model
{
    public class GameState
    {
        public GameState(int stressLevel, int tirednessLevel, int hungerLevel)
        {
            StressLevel = stressLevel;
            TirednessLevel = tirednessLevel;
            HungerLevel = hungerLevel;
        }

        public int StressLevel { get;  set; }
        public int TirednessLevel { get;  set; }
        public int HungerLevel { get;  set; }
    }
}