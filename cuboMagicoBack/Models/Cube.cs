using System.Text.RegularExpressions;

namespace CuboMagicoBack.Models;

public class Cube
{
    private const int Size = 3;
    public Cubie[,,] Cubies { get; set; } = new Cubie[Size, Size, Size];

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
                    sb.Append($"({x},{y},{z}) => ");
                    foreach (Face face in Enum.GetValues(typeof(Face)))
                    {
                        var color = cubie.GetColor(face);
                        if (color != null)
                            sb.Append($"{face}:{color}, ");
                    }
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
    }
    

    public static List<object> ParseCubeStateFromString(string stateString)
{
    var result = new List<object>();
    var lines = stateString.Split('\n', StringSplitOptions.RemoveEmptyEntries);

    foreach (var line in lines)
    {
        var match = Regex.Match(line.Trim(), @"\((\d+),\s*(\d+),\s*(\d+)\)\s*=>\s*(.+)");

        if (!match.Success) continue;

        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        int z = int.Parse(match.Groups[3].Value);
        string facesPart = match.Groups[4].Value;

        var faceColors = new Dictionary<string, string>();

        // Divide os pares face:cor
        var faceColorPairs = facesPart.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach (var pair in faceColorPairs)
        {
            var parts = pair.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string face = parts[0].Trim();
                string color = parts[1].Trim();
                faceColors[face] = color;
            }
        }

        result.Add(new
        {
            x,
            y,
            z,
            faceColors
        });
    }

    return result;
}


    // Aqui virão os métodos RotateFace(Face face, bool clockwise), etc.
}
