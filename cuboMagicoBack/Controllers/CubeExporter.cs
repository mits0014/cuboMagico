using System.Collections.Generic;
using System.Linq;
using CuboMagicoBack.Models;

namespace CuboMagicoBack.Controllers;
public static class CubeExporter
{
    public static List<object> FlattenCubeForExport(Cubie[,,] cubies)
    {
        var list = new List<object>();

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

                    // Converte o dicionário Face -> string para string -> string
                    var faceColors = cubie.FaceColors.ToDictionary(
                        kvp => kvp.Key.ToString(),  // Face enum -> string
                        kvp => kvp.Value
                    );

                    var entry = new
                    {
                        X = cubie.X,
                        Y = cubie.Y,
                        Z = cubie.Z,
                        FaceColors = faceColors
                    };

                    list.Add(entry);
                }
            }
        }

        return list;
    }
}
