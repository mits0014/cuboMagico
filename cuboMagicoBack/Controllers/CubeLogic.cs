public enum CubeFace
{
    Up,
    Down,
    Left,
    Right,
    Front,
    Back
}

public enum Direction
{
    Forward,
    Backward,
    Left,
    Right
}


public static class CubeLogic
{

    public static void RotateFaceClockwise(Cubie[,,] cubies, CubeFace face)
    {
        if (face != CubeFace.Up)
            throw new NotImplementedException("Apenas a face Up está implementada por enquanto.");

        // Clona a camada superior para manipular
        Cubie[,] original = new Cubie[3, 3];
        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                original[x, z] = cubies[x, 2, z];
            }
        }

        // Roda a matriz clockwise
        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                cubies[x, 2, z] = original[2 - z, x];

                // Se quiser, atualize também a orientação das faces do cubie:
                RotateCubieFacesClockwise(cubies[x, 2, z], Face.Up);
            }
        }
    }

    private static void RotateCubieFacesClockwise(Cubie cubie, Face rotatingFace)
{
    if (rotatingFace != Face.Up)
        throw new NotImplementedException("Somente a rotação da face Up foi implementada.");

    // Roda as cores das faces lateralmente (como vista de cima)
    var original = new Dictionary<Face, string>(cubie.FaceColors);

    if (original.ContainsKey(Face.Front)) cubie.SetColor(Face.Right, original[Face.Front]);
    if (original.ContainsKey(Face.Right)) cubie.SetColor(Face.Back, original[Face.Right]);
    if (original.ContainsKey(Face.Back)) cubie.SetColor(Face.Left, original[Face.Back]);
    if (original.ContainsKey(Face.Left)) cubie.SetColor(Face.Front, original[Face.Left]);
}

    public static void PrintTopFace(Cubie[,,] cubies)
    {
        Console.WriteLine("Face Up (y = 2):");
        for (int z = 2; z >= 0; z--) // z de 2 a 0 para que a visualização fique "de cima para baixo"
        {
            for (int x = 0; x < 3; x++)
            {
                var cubie = cubies[x, 2, z];
                string color = cubie.FaceColors[Face.Up].ToString().PadRight(7);
                Console.Write(color + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }




    public static void ApplyMove(Cubie[,,] cubies, string move)
    {
        // Exemplo: "U", "U'", "R", "L", etc.
        // Pode usar uma tabela de tradução ou switch para chamar o método certo
    }

    // Outras funções auxiliares como rotacionar uma camada, validar estado, etc.
}