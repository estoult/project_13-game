
    public struct SpellLetter
    {
        public char Character;
        public LetterState State;

        public SpellLetter(char c)
        {
            Character = c;
            State = LetterState.None;
        }
    }

    public enum LetterState
    {
        None,
        Correct,
        Incorrect
    }
