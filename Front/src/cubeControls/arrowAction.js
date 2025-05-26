import * as THREE from 'three';
import { sendRotation } from '../conection/service.js';
import { rightiComand } from '../conection/service.js';
export function onClickArrow(event, camera, arrowsGroup, cubie) {
    const mouse = new THREE.Vector2();
    const raycaster = new THREE.Raycaster();

    mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
    mouse.y = -(event.clientY / window.innerHeight) * 2 + 1;

    raycaster.setFromCamera(mouse, camera);

    const intersections = raycaster.intersectObjects(arrowsGroup.children, true);

    if (intersections.length > 0) {
        const intersectedArrow = intersections[0].object.parent; // ArrowHelper (ou o grupo customizado)

        const clickedDir = intersectedArrow.userData.direction;
        const face = intersectedArrow.userData.face;

        var direction = getRotationDirection(clickedDir, face);

        console.log("Direção clicada:", direction);
        console.log("Face clicada:", face);

        // Prepara o comando para o backend
        const cubieArray = [cubie.x, cubie.y, cubie.z];
        const command = rightiComand(direction, cubieArray, face);


        console.log("Face calculada:", command.face);
        console.log("Direção calculada:", command.direction);

        // Envie para o backend
        sendRotation(command.face, command.direction, cubie);

        window.removeEventListener('click', onClickArrow);
        arrowsGroup.clear();
    }
}

function getRotationDirection(dir, face) {
    // Simplificação: você pode melhorar com precisão angular, usando dot product
    if (dir.equals(new THREE.Vector3(0, 1, 0))) return "up";
    if (dir.equals(new THREE.Vector3(0, -1, 0))) return "down";
    if (dir.equals(new THREE.Vector3(1, 0, 0))) return "right";
    if (dir.equals(new THREE.Vector3(-1, 0, 0))) return "Left";
    if (dir.equals(new THREE.Vector3(0, 0, 1))) return "front";
    if (dir.equals(new THREE.Vector3(0, 0, -1))) return "back";
    return "Unknown";
}



