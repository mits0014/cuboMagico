import * as signalR from "@microsoft/signalr";

 // Importe a função que atualiza o cubo na cena

const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5286/cubehub") // ou a porta do seu ASP.NET
  .withAutomaticReconnect()
  .build();

connection.on("CubeUpdated", (newState) => {
  console.log("Estado do cubo atualizado recebido:", newState);
  //updateCubeInScene(newState); // Atualize os cubies no Three.js
});

connection.start().then(() => {
  console.log("Conectado ao SignalR");
});

export function sendRotation(face, direction) {
  connection.invoke("Rotate", face, direction);
  console.log("Comando enviado:", face, direction);
}
