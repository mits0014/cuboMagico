import * as THREE from 'three';
import { onClickArrow } from './arrowAction';

export function showArrows(cubies, scene, camera) {
    const raycaster = new THREE.Raycaster();
    const mouse = new THREE.Vector2();

    const arrowsGroup = new THREE.Group();
    scene.add(arrowsGroup);


    window.addEventListener('click', (event) => {
        mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
        mouse.y = -(event.clientY / window.innerHeight) * 2 + 1;

        raycaster.setFromCamera(mouse, camera);

        const intersects = raycaster.intersectObjects(cubies);

        const cubieClicado = intersects[0].object;
        console.log('Cubie clicado:', cubieClicado.position);
        if (intersects.length > 0) {
            const intersect = intersects[0];
            const clickedCubie = intersect.object;
            const faceIndex = intersect.faceIndex;

            // Descobrir qual face foi clicada
            const faceDirection = getClickedFaceDirection(faceIndex);
            renderArrows(clickedCubie, faceDirection, arrowsGroup, camera);
        }
    });
}

function createCustomArrow(direction, origin, length = 1.5, color = 0xA732FA) {
    const arrowGroup = new THREE.Group();

    // Corpo da seta (cilindro)
    const shaftGeometry = new THREE.CylinderGeometry(0.03, 0.03, length * 0.8, 8);
    const shaftMaterial = new THREE.MeshBasicMaterial({ color });
    const shaft = new THREE.Mesh(shaftGeometry, shaftMaterial);
    shaft.position.y = length * 0.4;
    arrowGroup.add(shaft);

    // Cabeça da seta (cone)
    const headGeometry = new THREE.ConeGeometry(0.08, length * 0.2, 8);
    const headMaterial = new THREE.MeshBasicMaterial({ color });
    const head = new THREE.Mesh(headGeometry, headMaterial);
    head.position.y = length * 0.9;
    arrowGroup.add(head);

    // Orientação
    arrowGroup.position.copy(origin);
    arrowGroup.quaternion.setFromUnitVectors(new THREE.Vector3(0, 1, 0), direction.clone().normalize());

    // Metadados úteis
    arrowGroup.userData = {
        direction: direction.clone().normalize()
    };

    return arrowGroup;
}




export function renderArrows(cubie, faceDirection, arrowsGroup, camera) {
    const arrows = [];

    const directions = {
        Front: [new THREE.Vector3(1, 0, 0), new THREE.Vector3(0, 1, 0), new THREE.Vector3(-1, 0, -0), new THREE.Vector3(0, -1, 0)],
        Back: [new THREE.Vector3(-1, 0, 0), new THREE.Vector3(1, 0, 0), new THREE.Vector3(0, -1, 0), new THREE.Vector3(0, 1, 0)],
        Left: [new THREE.Vector3(0, -1, 0), new THREE.Vector3(0, 0, 1), new THREE.Vector3(0, 0, -1), new THREE.Vector3(0, 1, 0)],
        Right: [new THREE.Vector3(0, 1, 0), new THREE.Vector3(0, 0, -1), new THREE.Vector3(0, -1, 0), new THREE.Vector3(0, 0, 1)],
        Up: [new THREE.Vector3(1, 0, 0), new THREE.Vector3(0, 0, 1), new THREE.Vector3(-1, 0, 0), new THREE.Vector3(0, 0, -1)],
        Down: [new THREE.Vector3(1, 0, 0), new THREE.Vector3(0, 0, -1), new THREE.Vector3(-1, 0, 0), new THREE.Vector3(0, 0, 1)],
    };

    if (!directions[faceDirection]) {
        console.warn('FaceDirection inválido:', faceDirection);
        return;
    }

    arrowsGroup.clear();
    const origin = cubie.position.clone();

    directions[faceDirection].forEach(dir => {
        const arrow = new createCustomArrow(dir.clone().normalize(), origin, 1.5, 0xA732FA);
        arrow.userData = {
            direction: dir.clone().normalize(),
            face: faceDirection
        };
        arrowsGroup.add(arrow);
        arrows.push(arrow);
    });
    window.addEventListener('click', (event) => onClickArrow(event, camera, arrowsGroup, origin), false);
}

function getClickedFaceDirection(faceIndex) {
    const faceId = Math.floor(faceIndex / 2);
    return ['Right', 'Left', 'Up', 'Down', 'Front', 'Back'][faceId];
}
