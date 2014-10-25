namespace DatScheduleServer.Model
{
    public class Task
    {
        public Task(string name, int duration, TaskType type, string colorCode)
        {
            Name = name;
            Duration = duration;
            Type = type;
            ColorCode = colorCode;
        }

        public int Duration { get; private set; }
        public string Name { get; private set; }
        public string ColorCode { get; private set; }
        public TaskType Type { get; private set; }
    }
}