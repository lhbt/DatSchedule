using System.Collections.Generic;

namespace DatScheduleServer.Model
{
    public class GameTasks
    {
        public static List<Task> ListOfTasks = new List<Task>
        {
            new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"),
            new Task("Interview", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"),
            new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"),
            new Task("Conf. call", 1, TaskType.Meeting, "#33CCFF"),
            new Task("PDU", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Code Kata", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Git Brown Bag", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Budget catchup", 2, TaskType.Meeting, "#33CCFF"),
            new Task("Recruitment catchup", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Infrastructure follow-up", 2, TaskType.Meeting, "#33CCFF"),
            new Task("Post Mortem", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Yelling on the intern", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Yelling on the developer", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Yelling on the QA", 1, TaskType.Meeting, "#33CCFF"),
            new Task("Yelling on the BA", 1, TaskType.Meeting, "#33CCFF"),            
            new Task("Meal", 1, TaskType.Meal, "#FF6633"),
            new Task("Lunch with wife", 2, TaskType.Meal, "#FF6633"),
            new Task("Lunch with CEO", 1, TaskType.Meal, "#FF6633"),
            new Task("Team Lunch", 1, TaskType.Meal, "#FF6633"),
            new Task("Bacon butty with Dan F.", 1, TaskType.Meal, "#FF6633"),
            new Task("Salad with Gary H.", 1, TaskType.Meal, "#FF6633"),
            new Task("Omelette du fromage", 1, TaskType.Meal, "#FF6633"),
            new Task("Foosball", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Swimming", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Hitting the gym", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Hitting the intern", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Video games", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Having a beer", 1, TaskType.Leisure, "#FFFF33"),
            new Task("Watching Fawlty Towers", 1, TaskType.Leisure, "#FFFF33")
        };


    }
}