using System.Collections.Generic;

namespace DatScheduleServer.Model
{
    public class GameTasks
    {
        public static List<Task> ListOfTasks
        {
            get
            {
                return new List<Task>
                {
                    new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF", false),
                    new Task("Interview", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF", false),
                    new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF", false),
                    new Task("Conf. call", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("PDU", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Code Kata", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Git Brown Bag", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Budget catchup", 2, TaskType.Meeting, "#33CCFF", false),
                    new Task("Recruitment catchup", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Refactoring session", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Futurespective", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Kanban update", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("1 to 1", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Dev leads guild", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Principals guild", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Impromptu meeting", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Infrastructure follow-up", 2, TaskType.Meeting, "#33CCFF", false),
                    new Task("Post Mortem", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Yelling on the intern", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Yelling on the developer", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Yelling on the QA", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Yelling on the BA", 1, TaskType.Meeting, "#33CCFF", false),
                    new Task("Meal", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Lunch with wife", 2, TaskType.Meal, "#FF6633", false),
                    new Task("Lunch with CEO", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Team Lunch", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Bacon butty with Dan F.", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Salad with Gary H.", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Omelette du fromage", 1, TaskType.Meal, "#FF6633", false),
                    new Task("Foosball", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Swimming", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Hitting the gym", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Hitting the intern", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Video games", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Having a beer", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Watching Fawlty Towers", 1, TaskType.Leisure, "#FFFF33", false),
                    new Task("Quick nap", 1, TaskType.Sleep, "#FFFF33", false)
                };
            }
        }
    }
}