namespace DatScheduleServer.Model
{
    public class Task
    {
        protected bool Equals(Task other)
        {
            return Duration == other.Duration && string.Equals(Name, other.Name) && string.Equals(ColorCode, other.ColorCode) && Type == other.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Duration;
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ColorCode != null ? ColorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public Task(string name, int duration, TaskType type, string colorCode, bool scheduled)
        {
            Name = name;
            Duration = duration;
            Type = type;
            ColorCode = colorCode;
            Scheduled = scheduled;
        }

        public void SetScheduled()
        {
            Scheduled = true;
        }

        public int Duration { get; private set; }
        public string Name { get; private set; }
        public string ColorCode { get; private set; }
        public TaskType Type { get; private set; }
        public bool Scheduled { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Task) obj);
        }
    }
}