using System;
using System.Collections.Generic;

namespace Task_4._2P
{
    public enum Importance
    {
        LOW,
        MEDIUM,
        HIGH
    }
    class DuplicateCode
    {
        public static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            Console.Write(">> ");
            return Console.ReadLine();
        }

        public class Task
        {
            public string Description { get; set; }
            public Importance Importance { get; set; }

            public Task(string description, Importance importance = Importance.MEDIUM)
            {
                Description = description;
                Importance = importance;
            }
        }

        public class TaskList
        {
            private List<Task> _tasks;

            public TaskList()
            {
                _tasks = new List<Task>();
            }

            public void AddTask(Task task)
            {
                _tasks.Add(task);
            }

            public void ChangePriority(int currentIndex, int newIndex)
            {
                Task t = _tasks[currentIndex];
                _tasks.Remove(t);
                _tasks.Insert(newIndex, t);
            }

            public void DeleteTask(int index)
            {
                _tasks.RemoveAt(index);
            }
        }

        public class TaskListRepository
        {
            private Dictionary<string, TaskList> _tasklistRepo;

            public TaskListRepository()
            {
                _tasklistRepo = new Dictionary<string, TaskList>();
            }

            public void AddCategory(string category)
            {
                switch(category)
                {
                    case null:
                        throw new ArgumentNullException("Category cannot be null");
                    case "":
                        throw new ArgumentOutOfRangeException("Category cannot be empty");
                    default:
                        TaskList taskList= new TaskList():
                        _tasklistRepo[category] = taskList;
                        break;
                }
            }

            public void DeleteCategory(string category)
            {
                switch(category)
                {
                    case null:
                        throw new ArgumentNullException("Category cannot be null");
                    case "":
                        throw new ArgumentOutOfRangeException("Category cannot be empty");
                    default:
                        TaskList taskList= new TaskList():
                        _tasklistRepo[category] = taskList;
                        break;
                }
            }

            public void AddTaskToCategory(string category, Task task)
            {
                
            }
        }



        static void Main(string[] args)
        {
            List<string> taskPersonal = new List<string>();
            List<string> tasksWork = new List<string>();
            List<string> tasksFamily = new List<string>();

            int max;

            while (true)
            {
                Console.Clear();

                max = taskPersonal.Count > tasksWork.Count ?
                    taskPersonal.Count : tasksWork.Count;
                max = max > tasksFamily.Count ? max : tasksFamily.Count;

                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));

                for (int i = 0; i < max; i++)
                {
                    Console.Write("{0,10}|", i);
                    PrintListItem(taskPersonal, i);
                    PrintListItem(tasksWork, i);
                    PrintListItem(tasksFamily, i);
                    Console.WriteLine();
                }

                Console.ResetColor();

                string listName = ReadString(
                    "\nWhich category do you want to place a new task? "
                    + "Type \'Personal\', \'Work\', or \'Family\'").ToLower();
                string task = ReadString(
                    "Describe your task below (max. 30 symbols)");

                if (task.Length > 30)
                    task = task.Substring(0, 30);

                switch (listName)
                {
                    case "personal":
                        taskPersonal.Add(task);
                        break;
                    case "work":
                        tasksWork.Add(task);
                        break;
                    case "family":
                        tasksFamily.Add(task);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
