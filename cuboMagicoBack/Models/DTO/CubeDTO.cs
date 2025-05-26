using CuboMagicoBack.Models;

public class CubieDto
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Dictionary<Face, string> FaceColors { get; set; }
}

public class CubeDto
{
    public List<CubieDto> Cubies { get; set; }


    public override string ToString()
    {
        if (Cubies == null || Cubies.Count == 0)
            return "CubeDto: 0 cubies";

        var cubiesInfo = string.Join(", ", Cubies.Select(c =>
            $"({c.X},{c.Y},{c.Z}): [{string.Join(", ", c.FaceColors.Select(fc => $"{fc.Key}={fc.Value}"))}]"
        ));

        return $"CubeDto: {Cubies.Count} cubies - {cubiesInfo}";
    }
}