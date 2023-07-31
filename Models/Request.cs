using System.IO.Compression;

namespace ReactMVC.Models
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    public class Request : Prototype
    {
        public Request(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Request(double x, double y, double z, double radius)
        {
            X = x;
            Y = y;
            Z = z;
            Radius = radius;
        }

        public Request(double x, double y, double z, double radius, double rI, int number, double nC, double maxRI, double minRI, double distributionRI, double rglobal, string? boundingArea, string? generate_Centre_Coords, double shape, double scale, int number_Of_Files, int try_count, double excess) : this(x, y, z)
        {
            Radius = radius;
            RI = rI;
            Number = number;
            NC = nC;
            MaxRI = maxRI;
            MinRI = minRI;
            DistributionRI = distributionRI;
            Rglobal = rglobal;
            BoundingArea = boundingArea;
            GenerateCentreCoords = generate_Centre_Coords;
            Shape = shape;
            Scale = scale;
            NumberOfFiles = number_Of_Files;
            TryCount = try_count;
            this.Excess = excess;
        }

        public Request()
        {
        }
        public int id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Radius { get; set; }
        public double RI { get; set; }
        //spheres number(int) - число шаров планируемое
        public int Number { get; set; }
        //nc(double) - концентрация шаров которую мы хотим получить определяется как sum(r_i^3)  / r^3,
        public double NC { get; set; }
        //размер самого большого(r_i) (double)
        public double MaxRI { get; set; }
        //размер самого малого(r_i) (double)
        public double MinRI { get; set; }
        //вид распределения радиусов r_i(комбобокс):-гаусово-нормальное-любое на твоё усмотрение
        public double DistributionRI { get; set; }
        //размер ограничивающей области rglobal(double)
        public double Rglobal { get; set; }
        //тип ограничивающей области(комбобокс:сфера, куб )
        public string? BoundingArea { get; set; }
        //тип распределения для генерации x,y,z центров(комбобокс:гамма, гаусово, рядом будут расположены дополнительные поля для ввода shape(double), scale(double) по которым будет происходить генерация)
        public string? GenerateCentreCoords { get; set; }
        public double Shape { get; set; }
        public double Scale { get; set; }
        //число файлов(int) (т.е. сколько раз мы хотим осуществить генерацию)
        public int NumberOfFiles { get; set; }
        //try_count число попыток запихнуть шар в систему(если не лезет) - (int)
        public int TryCount { get; set; }
        //excess доп параметр , по умолчанию excess = 1.005 (double)
        public double Excess = 1.005;

        //C-шный код 
        public static bool Intersect(double x, double y, double z, double[] r, double x0, double y0, double z0, double r0, double r_global, int n)
        {
            int i;
            if (n > 0)
            {
                i = 0;
                while (i < n)
                {
                    if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)) < r[i] + r0)
                    {
                        return false;
                    }
                    i += 1;
                }
            }
            return true;
        }

        public static int In_sphere(double x0, double y0, double z0, double r0, double r_global)
        {
            //  int i;
            //  i = 0;

            if (Math.Sqrt(Math.Pow(x0, 2) + Math.Pow(y0, 2) + Math.Pow(z0, 2)) > r_global)
            {
                return 0;
            }
            return 1;
        }
        public static double Uniform(double a, double b)
        {
            var rand = new Random();
            return rand.NextDouble() / (rand.NextDouble() + 1.0) * (b - a) + a;
        }

        public static double Concentration(double r_global, double[] vr)
        {
            double result = 0;
            foreach (double value in vr)
            {
                result += Math.Pow(value, 3);
            }
            return result / Math.Pow(r_global, 3);
        }
        // конец C-шного кода

        public static void PrintEllipsoidFields(List<Request> ellipsoids)
        {
            if (ellipsoids.Count == 1)
            {
                PrintFieldsToFile(ellipsoids[0], "ellipsoid.txt");
            }
            else
            {
                Parallel.For(0, ellipsoids.Count, i =>
                //for (int i = 0; i < ellipsoids.Count; i++)
                {
                    string fileName = $"ellipsoid{i + 1}.txt";
                    PrintFieldsToFile(ellipsoids[i], fileName);
                });
                ArchiveFiles();
            }
        }

        private static void PrintFieldsToFile(Request ellipsoid, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"X: {ellipsoid.X}");
                writer.WriteLine($"Y: {ellipsoid.Y}");
                writer.WriteLine($"Z: {ellipsoid.Z}");
                writer.WriteLine($"Radius: {ellipsoid.Radius}");
            }
        }
        private static void ArchiveFiles()
        {
            string zipFileName = "ellipsoid_archive.zip";
            string[] fileNames = Directory.GetFiles(Directory.GetCurrentDirectory(), "ellipsoid*.txt");

            using (ZipArchive archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                foreach (string fileName in fileNames)
                {
                    archive.CreateEntryFromFile(fileName, Path.GetFileName(fileName));
                }
            }
        }

        public override Prototype Clone()
        {
            return new Request
            {
                X = this.X,
                Y = this.Y,
                Z = this.Z,
                Radius = this.Radius
            };
        }
    }
}