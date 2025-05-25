public enum Face
{
    Up, Down, Left, Right, Front, Back
}

public class Cubie
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    // Armazena quais faces do cubie estão visíveis e suas cores
    public Dictionary<Face, string> FaceColors { get; private set; } = new();

    public Cubie(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public void SetColor(Face face, string color)
    {
        FaceColors[face] = color;
    }

    public string GetColor(Face face)
    {
        return FaceColors.ContainsKey(face) ? FaceColors[face] : "None";
    }
    public void RemoveColor(Face face)
{
    if (FaceColors.ContainsKey(face))
        FaceColors.Remove(face);
}

    // Gira as cores do cubie com base na rotação de uma face (a lógica será implementada dentro da classe Cube)
}
