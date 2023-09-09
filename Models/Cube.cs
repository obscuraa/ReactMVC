namespace ReactMVC.Models
{
    public class Cube : IShape
    {
        public double X { get ; set ; }
        public double Y { get ; set ; }
        public double Z { get ; set ; }
        public double Radius { get ; set ; }
        public double SideLength { get ; set ; }

        public double Area()
        {
            return 6 * Math.Pow(SideLength, 2); ;
        }
    }
}
