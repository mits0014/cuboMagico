import { connection } from "../main";

export function sendRotation(face, direction, cubie) {
  connection.invoke("Rotate", face, direction, cubie.x, cubie.y, cubie.z);
  console.log("Comando enviado:", face, direction);
}