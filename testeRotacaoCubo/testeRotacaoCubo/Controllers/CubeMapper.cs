using CuboMagicoBack.Models;

namespace CuboMagicoBack.Controllers
{
    public static class CubeMapper
    {
            public static CubeDto ToDto(Cubie[,,] cubies)
            {
                var list = new List<CubieDto>();

                int sizeX = cubies.GetLength(0);
                int sizeY = cubies.GetLength(1);
                int sizeZ = cubies.GetLength(2);

                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        for (int z = 0; z < sizeZ; z++)
                        {
                            var cubie = cubies[x, y, z];

                            // Copia as cores de forma defensiva
                            var faceColors = cubie.FaceColors
                                .Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value))
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                            list.Add(new CubieDto
                            {
                                X = cubie.X,
                                Y = cubie.Y,
                                Z = cubie.Z,
                                FaceColors = faceColors
                            });
                        }
                    }
                }

                return new CubeDto { Cubies = list };
            }
        }
}