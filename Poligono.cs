
namespace Tarea_Extraclase
{
    class Poligono
    {
        public static void Main()
        {
            List<double> Punto = new List<double> { 2, -1};
            List<double> Vertices = new List<double> { -1, 2, 2, 3, 4, 1, 3, -2, 0, -3};
            Console.WriteLine(Posicion(Punto, Vertices));
        }
        public static string Posicion(List<double> Punto, List<double> Vertices)
        {
            List<double> Vectores_Poligono = Hallar_Vectores(Vertices);
            List<double> Vectores_Punto = Hallar_Vectores(Anadir_Lista(Punto, Vertices));
            double error = Math.Abs(Area_Punto(Vectores_Punto) - Area_Poligono(Vectores_Poligono));
            if (error < 0.00006) return "La persona esta en la isla";
            else return "La pesona no esta en la isla";
        }
        public static List<double> Hallar_Vectores(List<double> Vertices)
        {
            List<double> Vectores = new List<double>();
            if (Vertices.Count < 6) throw new Exception("Ingrese al menos tres puntos");
            else if (Vertices.Count % 2 != 0) throw new Exception("Ingrese todas las coordenadas");
            else
            {
                for (int i = 2, j = 3; i < Vertices.Count - 1 && j < Vertices.Count; i += 2, j += 2)
                {
                    Vectores.Add(Vertices[i] - Vertices[0]);
                    Vectores.Add(Vertices[j] - Vertices[1]);
                }
                return Vectores;
            }
        }
        static double Distancia(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        static double Producto_Escalar(double x_1, double y_1, double x_2, double y_2)
        {
            return (x_1 * x_2) + (y_1 * y_2);
        }
        static double Area_Poligono(List<double> Vectores)
        {
            double Sumatoria_Areas = 0;
            int lista = Vectores.Count;
            double error = 0.00000000000001;
            for (int i = 0, j = 1, k = 2, r = 3; i < lista - 3 && j < lista - 2 && k < lista - 1 && r < lista; i += 2, j += 2, k += 2, r += 2)
            {
                double a = Producto_Escalar(Vectores[i], Vectores[j], Vectores[k], Vectores[r]);
                double b = Distancia(Vectores[i], Vectores[j]) * Distancia(Vectores[k], Vectores[r]);
                double angulo = Math.Acos(a / (b + error));
                double seno = Math.Sin(angulo);
                Sumatoria_Areas += (b * seno) / 2;
            }
            Console.WriteLine(Sumatoria_Areas);
            return Sumatoria_Areas;
        }
        static double Area_Punto(List<double> Vectores)
        {
            double Sumatoria_Areas = 0;
            int i = 0;
            int j = 1;
            int k = 2;
            int r = 3;
            return Area_Punto(Vectores, Sumatoria_Areas, i, j, k, r);
        }
        static double Area_Punto(List<double> Vectores, double Sumatoria_Areas, int i, int j, int k, int r)
        {
            int lista = Vectores.Count;
            if (i >= Vectores.Count - 3)
            {
                double error = 0.00000000000001;
                double a = Producto_Escalar(Vectores[0], Vectores[1], Vectores[lista - 2], Vectores[lista - 1]);
                double b = Distancia(Vectores[0], Vectores[1]) * Distancia(Vectores[lista - 2], Vectores[lista - 1]);
                double angulo = Math.Acos(a / (b + error));
                double seno = Math.Sin(angulo);
                double temporal = Sumatoria_Areas + (b * seno) / 2;
                Console.WriteLine(temporal);
                return Sumatoria_Areas += (b * seno) / 2;
            }
            else
            {
                double error = 0.00000000000001;
                double a = Producto_Escalar(Vectores[i], Vectores[j], Vectores[k], Vectores[r]);
                double b = Distancia(Vectores[i], Vectores[j]) * Distancia(Vectores[k], Vectores[r]);
                double angulo = Math.Acos(a / (b + error));
                double seno = Math.Sin(angulo);
                Sumatoria_Areas += (b * seno) / 2;
                return Area_Punto(Vectores, Sumatoria_Areas, i + 2, j + 2, k + 2, r + 2);
            }
        }
        static List<double> Anadir_Lista(List<double> Punto, List<double> Vertices)
        {
            if (Punto.Count != 2) throw new Exception("Ingrese correctamente las coordenadas del punto");
            else
            {
                for (int i = 0; i < Vertices.Count; i++) Punto.Add(Vertices[i]);
                return Punto;
            }
        }
    }
}