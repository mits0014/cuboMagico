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


            var original = new Cubie[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {

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

    public static bool IsCubeSolved(Cubie[,,] cubies)
    {
        // Para cada face do cubo
        foreach (Face face in Enum.GetValues(typeof(Face)))
        {
            // Determina a camada fixa para cada face
            int fixedIndex = face switch
            {
                Face.Up => 2,
                Face.Down => 0,
                Face.Left => 0,
                Face.Right => 2,
                Face.Front => 2,
                Face.Back => 0,
                _ => throw new ArgumentException("Face inválida")
            };

            // Obtém a cor da primeira peça da face para comparar
            object referenceColor = face switch
            {
                Face.Up => cubies[0, 2, 0].FaceColors[Face.Up],
                Face.Down => cubies[0, 0, 0].FaceColors[Face.Down],
                Face.Left => cubies[0, 0, 0].FaceColors[Face.Left],
                Face.Right => cubies[2, 0, 0].FaceColors[Face.Right],
                Face.Front => cubies[0, 0, 2].FaceColors[Face.Front],
                Face.Back => cubies[0, 0, 0].FaceColors[Face.Back],
                _ => null
            };

            // Percorre todos os cubies da face e compara as cores
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    object color = face switch
                    {
                        Face.Up => cubies[i, 2, j].FaceColors[Face.Up],
                        Face.Down => cubies[i, 0, j].FaceColors[Face.Down],
                        Face.Left => cubies[0, i, j].FaceColors[Face.Left],
                        Face.Right => cubies[2, i, j].FaceColors[Face.Right],
                        Face.Front => cubies[i, j, 2].FaceColors[Face.Front],
                        Face.Back => cubies[i, j, 0].FaceColors[Face.Back],
                        _ => null
                    };
                    if (!referenceColor.Equals(color))
                        return false;
                }
            }
        }
        return true;
    }


    // Outras funções auxiliares como rotacionar uma camada, validar estado, etc.
}