import * as THREE from 'three';
// Cores das faces
const faceOrder = ["Right", "Left", "Up", "Down", "Front", "Back"];
const faceMap = {
  Right: 0,
  Left: 1,
  Up: 2,
  Down: 3,
  Front: 4,
  Back: 5
};

function hexColor(colorName) {
  const colors = {
    white: 0xffffff,
    yellow: 0xffff00,
    red: 0xff0000,
    orange: 0xffa500,
    blue: 0x0000ff,
    green: 0x00ff00,
    black: 0x000000
  };
  return colors[colorName.toLowerCase()] ?? 0x000000;
}

let currentCubies = [];

export function updateCubeInScene(newState) {
  // Remover cubies anteriores da cena
  for (const cubie of currentCubies) {
    scene.remove(cubie);
    if (cubie.edges) scene.remove(cubie.edges);
  }
  currentCubies = [];

  for (const cubieData of newState.cubies) {
    const geometry = new THREE.BoxGeometry(1, 1, 1);

    // Cria os materiais nas posições corretas
    const materials = new Array(6).fill(null).map((_, index) => {
      const faceName = faceOrder[index];
      const colorName = cubieData.faceColors[faceName] ?? "black";
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

    // Guardar para remoção futura
    mesh.edges = edges;
    currentCubies.push(mesh);
  }
}
