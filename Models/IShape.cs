namespace ReactMVC.Models
{
    public interface IShape
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        double Radius { get; set; }

        double Area();
    }
}
