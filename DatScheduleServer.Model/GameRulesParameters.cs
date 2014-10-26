namespace DatScheduleServer.Model
{
    public class GameRulesParameters
    {
        public static int ImpactOfSleepOnFatigue { get { return 20; }}
        public static int ImpactOfMealOnHunger { get { return 15; }}
        public static int ImpactOfLeisureOnStress { get { return 20; }}

        public static int ImpactOfMeetingOnStress { get { return 8; }}
        public static int ImpactOfMeetingOnHunger { get { return 5; }}
        public static int ImpactOfMeetingOnFatigue { get { return 8; }}
    }
}
