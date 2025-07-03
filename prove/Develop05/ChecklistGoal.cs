namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (_completed)
                return 0;

            _currentCount++;
            int earned = Points;

            if (_currentCount >= _targetCount)
            {
                _completed = true;
                earned += _bonusPoints;
            }
            return earned;
        }

        public override string GetStatusString()
        {
            return _completed ? "[X]" : $"[ ] Completed {_currentCount}/{_targetCount}";
        }

        public void SetCurrentCountForLoad(int current)
        {
            _currentCount = current;
            if (_currentCount >= _targetCount)
                _completed = true;
        }

        public override string ToDataString()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
        }
    }
}
