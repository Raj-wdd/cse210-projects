namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return Points;
            }
            return 0;
        }

        public void MarkCompleteForLoad()
        {
            _completed = true;
        }

        public override string ToDataString()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{_completed}";
        }
    }
}
