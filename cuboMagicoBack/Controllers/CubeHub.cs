using CuboMagicoBack.Models;
using CuboMagicoBack.Controllers;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
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

            if (direction == "clockwise")
            {
                Console.WriteLine($"Rotating face {parsedFace} clockwise.");
                CubeLogic.RotateFaceClockwise(_cubeState.Cubies, (CubeFace)parsedFace);
            }
            else
            {
                Console.WriteLine($"Rotating face {parsedFace} counterclockwise.");
                CubeLogic.RotateFaceCounterClockwise(_cubeState.Cubies, (CubeFace)parsedFace);
            }



            Console.WriteLine($"Sending updated cube state to all clients.");
            string stateString = _cubeState.ToString();
            var parsedState = Cube.ParseCubeStateFromString(stateString);
            await Clients.All.SendAsync("CubeUpdated", new { cubies = parsedState });

        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: serializando o cubo");
            string stateString = _cubeState.ToString();
            var parsedState = Cube.ParseCubeStateFromString(stateString);
            await Clients.All.SendAsync("CubeUpdated", new { cubies = parsedState });

        }

        public async Task ResetCube()
        {
            Console.WriteLine("Resetting cube to initial state.");
            _cubeState = new Cube(); // Reseta o cubo para o estado inicial
            string stateString = _cubeState.ToString();
            var parsedState = Cube.ParseCubeStateFromString(stateString);
            await Clients.All.SendAsync("CubeUpdated", new { cubies = parsedState });
        }
        
        public async Task shuffleCube()
        {
            Console.WriteLine("Shuffling cube.");
            CubeLogic.shuffleCubie(_cubeState.Cubies); // Chama o método de embaralhamento do cubo
            string stateString = _cubeState.ToString();
            var parsedState = Cube.ParseCubeStateFromString(stateString);
            await Clients.All.SendAsync("CubeUpdated", new { cubies = parsedState });
        }
    }
}
