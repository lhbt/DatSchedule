namespace DatScheduleServer.Model
{
    public class Task
    {
        public Task(string name, double duration, TaskType taskType)
        {
            Name = name;
            Duration = duration;
            Type = taskType;
        }

        public double Duration { get; private set; }
        public string Name { get; private set; }
        public TaskType Type { get; private set; }
    }
}