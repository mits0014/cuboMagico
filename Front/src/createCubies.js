import * as THREE from 'three';
// Cores das faces
const faceColors = {
    Up: 0xffffff,    // Branco
    Down: 0xffff00,  // Amarelo
    Left: 0xff0000,  // Vermelho
    Right: 0xffa500, // Laranja
    Front: 0x0750ED, // Azul
    Back: 0x00ff00   // Verde
};

  // Criando os cubies (26 cubinhos visíveis)
  export function createCubies(scene) {
    const cubies = [];
  
    for (let x = -1; x <= 1; x++) {
      for (let y = -1; y <= 1; y++) {
        for (let z = -1; z <= 1; z++) {
          if (x === 0 && y === 0 && z === 0) continue;
  
          const geometry = new THREE.BoxGeometry(1, 1, 1);
          const materials = [
            new THREE.MeshBasicMaterial({ color: x === 1 ? faceColors.Right : 0x000000 }), // Right
            new THREE.MeshBasicMaterial({ color: x === -1 ? faceColors.Left : 0x000000 }),  // Left
            new THREE.MeshBasicMaterial({ color: y === 1 ? faceColors.Up : 0x000000 }),     // Top
            new THREE.MeshBasicMaterial({ color: y === -1 ? faceColors.Down : 0x000000 }),  // Bottom
            new THREE.MeshBasicMaterial({ color: z === 1 ? faceColors.Front : 0x000000 }),  // Front
            new THREE.MeshBasicMaterial({ color: z === -1 ? faceColors.Back : 0x000000 })   // Back
          ];
  
          const cubie = new THREE.Mesh(geometry, materials);
          cubie.position.set(x, y, z);
          scene.add(cubie);
          cubies.push(cubie);
  
          // Adiciona bordas
          const edgeGeometry = new THREE.EdgesGeometry(geometry);
          const edgeMaterial = new THREE.LineBasicMaterial({ color: 0x000000 });
          const edges = new THREE.LineSegments(edgeGeometry, edgeMaterial);
          edges.position.copy(cubie.position);
          scene.add(edges);
        }
      }
    }
  
    return cubies; // Retorna os cubies, se precisar manipulá-los depois
  }