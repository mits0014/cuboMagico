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
}
