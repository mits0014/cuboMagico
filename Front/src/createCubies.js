import * as THREE from 'three';
import { showArrows } from './cubeControls/showArrows';
import { onClickArrow } from './cubeControls/arrowAction';

const faceOrder = ["Right", "Left", "Up", "Down", "Front", "Back"];

const colorMap = {
  white: 0xffffff,
  yellow: 0xffff00,
  red: 0xff0000,
  orange: 0xffa500,
  blue: 0x0000ff,
  green: 0x00ff00,
  black: 0x000000
};

function hexColor(colorName) {
  return colorMap[colorName?.toLowerCase()] ?? 0x000000;
}

// Lista dos cubies atuais
let currentCubies = [];

/**
 * Atualiza os cubos na cena com base no estado vindo do servidor.
 * @param {Object} newState - Estado do cubo vindo do backend.
 * @param {THREE.Scene} scene - Cena do Three.js onde os cubos estão sendo renderizados.
 */
export function updateCubeInScene(newState, scene, camera) {
  if (!scene) {
    console.error("Cena não fornecida para updateCubeInScene.");
    return;
  }

  // Remove os cubies antigos da cena
  for (const cubie of currentCubies) {
    scene.remove(cubie);
    if (cubie.edges) scene.remove(cubie.edges);
  }
  currentCubies = [];
  console.log("novo estado", newState);
  // Adiciona os cubies atualizados
  for (const cubieData of newState.cubies) {
    const geometry = new THREE.BoxGeometry(1, 1, 1);

    const materials = faceOrder.map(face => {
      const colorName = cubieData.faceColors?.[face] ?? "black";
      return new THREE.MeshBasicMaterial({ color: hexColor(colorName) });
    });

    const mesh = new THREE.Mesh(geometry, materials);
    mesh.position.set(cubieData.x, cubieData.y, cubieData.z);
    scene.add(mesh);

    // Adiciona bordas
    const edgeGeometry = new THREE.EdgesGeometry(geometry);
    const edgeMaterial = new THREE.LineBasicMaterial({ color: 0x000000 });
    const edges = new THREE.LineSegments(edgeGeometry, edgeMaterial);
    edges.position.copy(mesh.position);
    scene.add(edges);

    // Armazena referência para remoção futura
    mesh.edges = edges;
    currentCubies.push(mesh);

  
  }
  const arrowsGroup = new THREE.Group();
  scene.add(arrowsGroup);

  showArrows(currentCubies, scene, camera);
}
