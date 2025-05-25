namespace CuboMagicoBack.Models;

public class Cube
{
    private const int Size = 3;
    public Cubie[,,] Cubies { get; private set; } = new Cubie[Size, Size, Size];

    public Cube()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                for (int z = 0; z < Size; z++)
                {
                    var cubie = new Cubie(x, y, z);

                    // Definindo cores iniciais baseado na posição
                    if (y == 2) cubie.SetColor(Face.Up, "White");
                    if (y == 0) cubie.SetColor(Face.Down, "Yellow");

                    if (x == 0) cubie.SetColor(Face.Left, "Orange");
                    if (x == 2) cubie.SetColor(Face.Right, "Red");

                    if (z == 2) cubie.SetColor(Face.Front, "Green");
                    if (z == 0) cubie.SetColor(Face.Back, "Blue");

                    Cubies[x, y, z] = cubie;
                }
            }
        }
    }
    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                for (int z = 0; z < Size; z++)
                {
                    var cubie = Cubies[x, y, z];
                    sb.Append($"Posição ({x},{y},{z}): ");
                    foreach (Face face in Enum.GetValues(typeof(Face)))
                    {
                        var color = cubie.GetColor(face);
                        if (color != null)
                            sb.Append($"{face}={color} ");
                    }
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
    }
    public void ImprimirFaceFront()
    {
        // A face Front está no plano z = 2
        for (int y = 2; y >= 0; y--)
        {
            for (int x = 0; x < 3; x++)
            {
                var cubie = Cubies[x, y, 2];
                var cor = cubie.GetColor(Face.Front) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
    }
    public void ImprimirFaceDireita()
    {
        // A face Right está no plano x = 2
        for (int y = 2; y >= 0; y--)
        {
            for (int z = 0; z < 3; z++)
            {
                var cubie = Cubies[2, y, z];
                var cor = cubie.GetColor(Face.Right) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
        
    }
    public void ImprimirFaceEsquerda()
    {
        // A face Left está no plano x = 0
        for (int y = 2; y >= 0; y--)
        {
            for (int z = 0; z < 3; z++)
            {
                var cubie = Cubies[0, y, z];
                var cor = cubie.GetColor(Face.Left) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
    }

    internal void ImprimirFaceCima()
    {
        // A face Up está no plano y = 2
        for (int z = 0; z < 3; z++)
        {
            for (int x = 0; x < 3; x++)
            {
                var cubie = Cubies[x, 2, z];
                var cor = cubie.GetColor(Face.Up) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
    }

    internal void ImprimirFaceBaixo()
    {
        // A face Down está no plano y = 0
        for (int z = 0; z < 3; z++)
        {
            for (int x = 0; x < 3; x++)
            {
                var cubie = Cubies[x, 0, z];
                var cor = cubie.GetColor(Face.Down) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
    }

    internal void ImprimirFaceTraseira()
    {
        // A face Back está no plano z = 0
        for (int y = 2; y >= 0; y--)
        {
            for (int x = 0; x < 3; x++)
            {
                var cubie = Cubies[x, y, 0];
                var cor = cubie.GetColor(Face.Back) ?? "-";
                Console.Write($"{cor}\t");
            }
            Console.WriteLine();
        }
    }

    // Aqui virão os métodos RotateFace(Face face, bool clockwise), etc.
}
