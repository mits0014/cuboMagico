import * as THREE from 'three';
import { updateCubeInScene } from './createCubies';
import { createSence } from './createScene';
import { createControls } from './createControls';
import { rotateLayer } from './cubeControls/rotateLayer';
import { showArrows } from './cubeControls/showArrows';

// Cena, câmera e renderizador
const scene = createSence();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

// Controles orbitais
const controls = createControls(camera, renderer);

// Criando os cubies (26 cubinhos visíveis)
const cubies = updateCubeInScene(scene);
const raycaster = new THREE.Raycaster();
const mouse = new THREE.Vector2();

const arrowsGroup = new THREE.Group();
scene.add(arrowsGroup);

showArrows(cubies, scene, camera);


// Animação
function animate() {
  requestAnimationFrame(animate);
  controls.update();
  renderer.render(scene, camera);
}

animate();



