            using System.Text.Json;
// See https://aka.ms/new-console-template for more information
using CuboMagicoBack.Models;

using CuboMagicoBack.Controllers;

Console.WriteLine("Bem-vindo ao Risckcube!");

Cube _cubeState = new Cube();

bool sair = false;
while (!sair)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1 - Exibir estado do cubo");
    Console.WriteLine("2 - Exibir face frontal");
    Console.WriteLine("3 - Exibir face direita");
    Console.WriteLine("4 - Exibir face esquerda");
    Console.WriteLine("5 - Exibir face de cima");
    Console.WriteLine("6 - Exibir face de baixo");
    Console.WriteLine("7 - Exibir face traseira");
    Console.WriteLine("10 - Rotacionar face");
    Console.WriteLine("11 - Resetar cubo");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();
    Cubie[,,] cubies = new Cubie[1, 1, 1]; // Inicialização de cubies, você pode ajustar conforme necessário
    CubeFace face = CubeFace.Up; // Exemplo de face, você pode mudar conforme necessário

    switch (opcao)
    {
        case "1":
            // Exibir estado do cubo (implemente o método ToString no Cube para facilitar)
            Console.WriteLine(_cubeState.ToString());
            break;
        case "2":
             _cubeState.ImprimirFaceFront();
            break;
        case "3":
            // Implemente o método ImprimirFaceDireita na classe Cube
            _cubeState.ImprimirFaceDireita();
            break;
        case "4":
            // Implemente o método ImprimirFaceEsquerda na classe Cube
            _cubeState.ImprimirFaceEsquerda();
            break;
        case "5":
            // Implemente o método ImprimirFaceCima na classe Cube
            _cubeState.ImprimirFaceCima();
            break;
        case "6":
            // Implemente o método ImprimirFaceBaixo na classe Cube
            _cubeState.ImprimirFaceBaixo();
            break;
        case "7":
            // Implemente o método ImprimirFaceTraseira na classe Cube
            _cubeState.ImprimirFaceTraseira();
            break;
        case "10":
            Console.Write("Digite a face para rotacionar (ex: U, D, L, R, F, B): ");
            Console.Write("Digite a direção (horario/antihorario): ");
            // Implemente o método Rotate na classe Cube
            CubeLogic.RotateFaceClockwise(_cubeState.Cubies, face);

            

            var cube = _cubeState;




            // ...

            var export = CubeExporter.FlattenCubeForExport(_cubeState.Cubies);
            string json = JsonSerializer.Serialize(export, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);

            Console.WriteLine("Face rotacionada!");
            break;
        case "11":
            _cubeState = new Cube();
            Console.WriteLine("Cubo resetado!");
            break;
        case "0":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
Console.WriteLine("Programa encerrado.");

