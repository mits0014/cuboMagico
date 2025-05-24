import * as THREE from 'three';
import { createSence } from './createScene';
import { createControls } from './createControls';
import { cubies } from './conection/service';
import * as signalR from "@microsoft/signalr";

// Cena, câmera e renderizador
const scene = createSence();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);
const controls = createControls(camera, renderer);


// Conexão com o SignalR websocket
export const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5286/cubehub")
  .withAutomaticReconnect()
  .build();

const cubies = [];

// inicia conexão e escuta atualizações do cubo
connection.start().then(() => {
  console.log("Conectado ao SignalR");
});

// receber atualizações do cubo e atualizar a cena
connection.on("CubeUpdated", (newState) => {
  console.log("Estado do cubo atualizado recebido:", newState);
  updateCubeInScene(newState, scene); // Atualize os cubies no Three.js
});


// Animação
function animate() {
  requestAnimationFrame(animate);
  controls.update();
  renderer.render(scene, camera);
}

animate();



