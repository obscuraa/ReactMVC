namespace ReactMVC.Models
{
    public static class GeneralFunctions
    {
        public static double RandCoordinate(int Coefficient)
        {
            Random rand = new Random();
            return rand.NextDouble() * Coefficient - 1;
        }
    }
}
