import * as THREE from 'three';

export function rotateLayer(scene, cubies, axis = 'y', value = 1, angle = Math.PI / 2) {
  const group = new THREE.Group();

  // Tolerância para evitar problemas com ponto flutuante
  const epsilon = 0.01;

  // Agrupa os cubies da camada
  cubies.forEach(cubie => {
    if (Math.abs(cubie.position[axis] - value) < epsilon) {
      group.add(cubie);
    }
  });

  // Adiciona o grupo na cena e posiciona no centro dos cubies
  scene.add(group);

  // Ajusta o pivot do grupo (centro da camada)
  group.position.set(0, 0, 0);

  // Move os cubies do mundo para o grupo local
  group.updateMatrixWorld();
  group.children.forEach(child => {
    child.position.setFromMatrixPosition(child.matrixWorld);
    scene.attach(child); // tira do grupo sem perder a posição global
    group.add(child);    // reanexa no local certo
  });

  // Aplica a rotação no grupo
  if (axis === 'x') group.rotateX(angle);
  if (axis === 'y') group.rotateY(angle);
  if (axis === 'z') group.rotateZ(angle);

  // Após a rotação, movemos de volta para a cena
  group.children.forEach(child => {
    child.updateMatrixWorld();
    child.position.setFromMatrixPosition(child.matrixWorld);
    child.rotation.setFromRotationMatrix(child.matrixWorld);
    scene.attach(child);
  });

  // Remove o grupo da cena
  scene.remove(group);
}
