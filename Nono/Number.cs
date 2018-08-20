namespace Nono
{
    public class Number
    {
        public int Value { get; set; }
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }

        public int PossibleSquareCount => ToIndex - FromIndex + 1;
        public bool Placed => PossibleSquareCount == Value;

        public Number(int value, int lineLength)
        {
            Value = value;
            FromIndex = 0;
            ToIndex = lineLength - 1;
        }

        public bool CanOwnSquareRange(int fromIndex, int toIndex)
        {
            return FromIndex <= fromIndex && ToIndex >= toIndex;
        }

        public void UpdateFromIndexFromPreviousNumber(Number previousNumber)
        {
            var lowestStartingIndexAllowedByPreviousNumber = previousNumber.FromIndex + previousNumber.Value + 1;
            if (lowestStartingIndexAllowedByPreviousNumber > FromIndex)
            {
                FromIndex = lowestStartingIndexAllowedByPreviousNumber;
            }
        }

        public void UpdateToIndexFromNextNumber(Number nextNumber)
        {
            var highestEndingIndexAllowedByNextNumber = nextNumber.ToIndex - nextNumber.Value - 1;
            if (highestEndingIndexAllowedByNextNumber < ToIndex)
            {
                ToIndex = highestEndingIndexAllowedByNextNumber;
            }
        }
    }
}