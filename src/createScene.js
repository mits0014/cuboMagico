import * as THREE from 'three';
export function createSence() {
    const scene = new THREE.Scene();
    const light = new THREE.AmbientLight(0xffffff, 1);
    scene.add(light);

    return scene;
}