namespace DatScheduleServer.Model
{
    public class GameRulesParameters
    {
        public static int ImpactOfSleepOnFatigue { get { return 40; }}
        public static int ImpactOfMealOnHunger { get { return 20; }}
        public static int ImpactOfLeisureOnStress { get { return 20; }}
        public static int ImpactOfMeetingOnStress { get { return 10; }}
        public static int ImpactOfMeetingOnHunger { get { return 5; }}
        public static int ImpactOfMeetingOnFatigue { get { return 10; }}
    }
}
