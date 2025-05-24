import * as THREE from 'three';
import { sendRotation } from '../conection/service.js';
export function onClickArrow(event, camera, arrowsGroup) {
    const mouse = new THREE.Vector2();
    const raycaster = new THREE.Raycaster();

    mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
    mouse.y = -(event.clientY / window.innerHeight) * 2 + 1;

    raycaster.setFromCamera(mouse, camera);

    const intersections = raycaster.intersectObjects(arrowsGroup.children, true);

    if (intersections.length > 0) {
        const intersectedArrow = intersections[0].object.parent; // ArrowHelper (ou o grupo customizado)
        console.log("Seta clicada:", intersectedArrow);

        // Aqui você pode definir uma lógica para identificar qual direção foi clicada.
        // Exemplo: comparar a direção com os vetores usados originalmente
        const clickedDir = intersectedArrow.userData.direction;
        const face = intersectedArrow.userData.face;

        // Exemplo de decisão baseada na direção
        const rotationDirection = getRotationDirection(clickedDir, face);

        // Prepara o comando para o backend
        const command = {
            face: face,
            direction: rotationDirection
        };

        // Envie para o backend (via WebSocket ou HTTP POST)
        sendRotation(command.face, command.direction);
        arrowsGroup.clear(); // Remove a seta após o clique
    }
}

function getRotationDirection(dir, face) {
    // Simplificação: você pode melhorar com precisão angular, usando dot product
    if (dir.equals(new THREE.Vector3(0, 1, 0))) return "Clockwise";
    if (dir.equals(new THREE.Vector3(0, -1, 0))) return "CounterClockwise";
    if (dir.equals(new THREE.Vector3(1, 0, 0))) return "Right";
    if (dir.equals(new THREE.Vector3(-1, 0, 0))) return "Left";
    if (dir.equals(new THREE.Vector3(0, 0, 1))) return "Forward";
    if (dir.equals(new THREE.Vector3(0, 0, -1))) return "Backward";
    return "Unknown";
}



