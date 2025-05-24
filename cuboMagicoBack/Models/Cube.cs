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

                    if (x == 0) cubie.SetColor(Face.Left, "Red");
                    if (x == 2) cubie.SetColor(Face.Right, "Orange");

                    if (z == 2) cubie.SetColor(Face.Front, "Blue");
                    if (z == 0) cubie.SetColor(Face.Back, "Green");

                    Cubies[x, y, z] = cubie;
                }
            }
        }
    }
}
