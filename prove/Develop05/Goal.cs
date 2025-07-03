using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;
        protected bool _completed;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _completed = false;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        public virtual bool IsComplete() => _completed;

        // Records an event, returns points earned
        public abstract int RecordEvent();

        // Returns goal status string for display
        public virtual string GetStatusString()
        {
            return _completed ? "[X]" : "[ ]";
        }

        // For saving to file (override in derived classes)
        public abstract string ToDataString();

        // Factory method to create Goal from saved string
        public static Goal FromDataString(string data)
        {
            var parts = data.Split('|');
            var type = parts[0];
            var name = parts[1];
            var desc = parts[2];
            var points = int.Parse(parts[3]);

            switch (type)
            {
                case "SimpleGoal":
                    bool completed = bool.Parse(parts[4]);
                    var sg = new SimpleGoal(name, desc, points);
                    if (completed) sg.MarkCompleteForLoad();
                    return sg;

                case "EternalGoal":
                    return new EternalGoal(name, desc, points);

                case "ChecklistGoal":
                    int current = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var cg = new ChecklistGoal(name, desc, points, target, bonus);
                    cg.SetCurrentCountForLoad(current);
                    return cg;

                default:
                    throw new Exception("Unknown goal type");
            }
        }
    }
}
