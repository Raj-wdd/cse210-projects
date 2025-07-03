namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            // Eternal goals never complete, always earn points
            return Points;
        }

        public override bool IsComplete() => false;

        public override string GetStatusString() => "[∞]";

        public override string ToDataString()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }
    }
}
