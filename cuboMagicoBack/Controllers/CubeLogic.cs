using CuboMagicoBack.Models;

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

        // Salva as cores atuais das faces laterais
        var front = cubie.FaceColors.ContainsKey(Face.Front) ? cubie.FaceColors[Face.Front] : null;
        var right = cubie.FaceColors.ContainsKey(Face.Right) ? cubie.FaceColors[Face.Right] : null;
        var back = cubie.FaceColors.ContainsKey(Face.Back) ? cubie.FaceColors[Face.Back] : null;
        var left = cubie.FaceColors.ContainsKey(Face.Left) ? cubie.FaceColors[Face.Left] : null;

        // Limpa as faces laterais antes de rotacionar
        cubie.RemoveColor(Face.Front);
        cubie.RemoveColor(Face.Right);
        cubie.RemoveColor(Face.Back);
        cubie.RemoveColor(Face.Left);

        // Rotaciona apenas as cores que existiam
        if (left != null) cubie.SetColor(Face.Front, left);
        if (front != null) cubie.SetColor(Face.Right, front);
        if (right != null) cubie.SetColor(Face.Back, right);
        if (back != null) cubie.SetColor(Face.Left, back);
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

}