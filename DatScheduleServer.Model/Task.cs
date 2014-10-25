namespace DatScheduleServer.Model
{
    public class Task
    {
        public Task(string name, double duration, TaskType type, string colorCode)
        {
            Name = name;
            Duration = duration;
            Type = type;
            ColorCode = colorCode;
        }

        public double Duration { get; private set; }
        public string Name { get; private set; }
        public string ColorCode { get; private set; }
        public TaskType Type { get; private set; }
    }
}