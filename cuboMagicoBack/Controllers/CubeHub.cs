using CuboMagicoBack.Models;
using Microsoft.AspNetCore.SignalR;
// Add the following using if Cube is in a different namespace, e.g. cuboMagicoBack.CubeLogic
// using cuboMagicoBack.CubeLogic;

namespace cuboMagicoBack.Controllers
{
    public class CubeHub : Hub
    {
        // Estado central do cubo mágico
        private static Cube _cubeState = new Cube();

        public async Task Rotate(string face, string direction, int x, int y, int z)
        {
            Console.WriteLine($"Rotação: face={face}, direção={direction}, posição=({x},{y},{z})");

            if (!Enum.TryParse<Face>(face, true, out var parsedFace))
            {
                Console.WriteLine($"Invalid face value received: {face}");
                return;
            }



            // Rotaciona a face apropriada
            CubeLogic.RotateFaceClockwise(_cubeState.Cubies, (CubeFace)parsedFace);

            // Envia o novo estado do cubo a todos os clientes
            Console.WriteLine($"Sending updated cube state to all clients.");
            var dto = CubeMapper.ToDto(_cubeState.Cubies);
            await Clients.All.SendAsync("CubeUpdated", dto);
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId} serializando o cubo");
            var dto = CubeMapper.ToDto(_cubeState.Cubies);
            await Clients.Caller.SendAsync("CubeUpdated", dto);
        }
    }
}
