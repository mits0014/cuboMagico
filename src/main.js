import * as THREE from 'three';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls'
import { createCubies } from './createCubies';
import { createSence } from './createScene';

// Cena, câmera e renderizador
const scene = createSence();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

// Controles orbitais
const controls = new OrbitControls(camera, renderer.domElement);
controls.enableDamping = true;
camera.position.set(5, 5, 5);
controls.update();


// Criando os cubies (26 cubinhos visíveis)
const cubies = createCubies(scene);

// Animação
function animate() {
  requestAnimationFrame(animate);
  controls.update();
  renderer.render(scene, camera);
}

animate();