namespace DatScheduleServer.Model
{
    public static class IntExtensions
    {
        public static int IncreaseValue(this int value, int inc)
        {
            value += inc;
            if (value > 100) value = 100;
            return value;
        }

        public static int DecreaseValue(this int value, int dec)
        {
            value -= dec;
            if (value < 0) value = 0;
            return value;
        }
    }
}