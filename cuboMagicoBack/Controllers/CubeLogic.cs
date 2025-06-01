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

        if (face == CubeFace.Up || face == CubeFace.Down)
        {
            int y = 0; // A face Up é a camada y = 2
            if (face == CubeFace.Up) y = 2;



            Console.WriteLine($"Rotacionando a face Up (y = {y}) no sentido horário...");
            var original = new Cubie[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.WriteLine($"Cubie[{x}, {y}, {z}] = {cubies[x, y, z].ToString()}");
                    original[x, z] = cubies[x, y, z];
                }
            }

            // Roda a matriz clockwise
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubies[x, y, z] = original[2 - z, x];

                    // Se quiser, atualize também a orientação das faces do cubie:
                    RotateCubieFacesClockwise(cubies[x, y, z], Face.Up);
                }
            }
        }
        else if (face == CubeFace.Right || face == CubeFace.Left)
        {
            int x = 0; // 
            if (face == CubeFace.Right) x = 2;


            Console.WriteLine("Rotacionando a face Left (x = 0) no sentido horário...");
            var original = new Cubie[3, 3];
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    original[y, z] = cubies[x, y, z];
                }
            }

            // Rotacionar a matriz clockwise
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubies[x, y, z] = original[2 - z, y];
                    RotateCubieFacesClockwise(cubies[x, y, z], Face.Left);
                }
            }
        }
        else if (face == CubeFace.Front || face == CubeFace.Back)
        {
            int z = 0; // A face Front é a camada z = 2
            if (face == CubeFace.Front) z = 2;

            Console.WriteLine($"Rotacionando a face Front (z = {z}) no sentido horário...");
            var original = new Cubie[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    original[x, y] = cubies[x, y, z];
                }
            }
            // Rotacionar a matriz clockwise
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    cubies[x, y, z] = original[y, 2 - x];
                    RotateCubieFacesClockwise(cubies[x, y, z], Face.Front);
                }
            }
        }
    }

    public static void RotateFaceCounterClockwise(Cubie[,,] cubies, CubeFace face)
    {
        // Para rotacionar no sentido anti-horário, basta rotacionar 3 vezes no sentido horário
        RotateFaceClockwise(cubies, face);
        RotateFaceClockwise(cubies, face);
        RotateFaceClockwise(cubies, face);
    }

    private static void RotateCubieFacesClockwise(Cubie cubie, Face rotatingFace)
    {
        if (rotatingFace == Face.Up || rotatingFace == Face.Down)
        {
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

            return;
        }
        if (rotatingFace == Face.Right || rotatingFace == Face.Left)
        {
            // Salva as cores atuais das faces laterais
            var up = cubie.FaceColors.ContainsKey(Face.Up) ? cubie.FaceColors[Face.Up] : null;
            var front = cubie.FaceColors.ContainsKey(Face.Front) ? cubie.FaceColors[Face.Front] : null;
            var down = cubie.FaceColors.ContainsKey(Face.Down) ? cubie.FaceColors[Face.Down] : null;
            var back = cubie.FaceColors.ContainsKey(Face.Back) ? cubie.FaceColors[Face.Back] : null;

            cubie.RemoveColor(Face.Up);
            cubie.RemoveColor(Face.Front);
            cubie.RemoveColor(Face.Down);
            cubie.RemoveColor(Face.Back);

            if (front != null) cubie.SetColor(Face.Up, front);
            if (down != null) cubie.SetColor(Face.Front, down);
            if (back != null) cubie.SetColor(Face.Down, back);
            if (up != null) cubie.SetColor(Face.Back, up);

            return;
        }
        if (rotatingFace == Face.Front || rotatingFace == Face.Back)
        {
            // Salva as cores atuais das faces laterais
            var up = cubie.FaceColors.ContainsKey(Face.Up) ? cubie.FaceColors[Face.Up] : null;
            var right = cubie.FaceColors.ContainsKey(Face.Right) ? cubie.FaceColors[Face.Right] : null;
            var down = cubie.FaceColors.ContainsKey(Face.Down) ? cubie.FaceColors[Face.Down] : null;
            var left = cubie.FaceColors.ContainsKey(Face.Left) ? cubie.FaceColors[Face.Left] : null;

            cubie.RemoveColor(Face.Up);
            cubie.RemoveColor(Face.Right);
            cubie.RemoveColor(Face.Down);
            cubie.RemoveColor(Face.Left);

            if (right != null) cubie.SetColor(Face.Up, right);
            if (up != null) cubie.SetColor(Face.Left, up);
            if (left != null) cubie.SetColor(Face.Down, left);
            if (down != null) cubie.SetColor(Face.Right, down);

            return;
        }
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

    public static void shuffleCubie(Cubie[,,] cubies)
    {
        Random random = new Random();
        int muves = random.Next(10, 20);
        for (int i = 0; i < muves; i++)
        {
            // Escolhe uma face aleatória para rotacionar
            CubeFace face = (CubeFace)random.Next(0, 6);

            int y = random.Next(0, 2); // Apenas para dar uma pausa entre as rotações
            if (y == 0)
            {
                RotateFaceCounterClockwise(cubies, face);
            }
            else
            {
                // Aqui você poderia implementar a rotação anti-horária, se necessário
                // Por enquanto, apenas rotaciona no sentido horário
                RotateFaceClockwise(cubies, face);
            }
        }
    }


    // Outras funções auxiliares como rotacionar uma camada, validar estado, etc.
}