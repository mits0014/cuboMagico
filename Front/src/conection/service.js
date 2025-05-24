import { connection } from "../main";

export function sendRotation(face, direction) {
  connection.invoke("Rotate", face, direction);
  console.log("Comando enviado:", face, direction);
}