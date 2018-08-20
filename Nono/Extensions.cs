namespace Nono
{
    public static class Extensions
    {
        public static string ToPrintableString(this Square square)
        {
            switch (square)
            {
                case Square.Empty:
                    return "  ";
                case Square.Filled:
                    return "██";
                default:
                    return "><";
            }
        }

        public static bool IsKnown(this Square square)
        {
            return square != Square.Unknown;
        }
    }
}