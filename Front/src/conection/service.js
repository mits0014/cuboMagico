import { connection } from "../main";

export function sendRotation(face, direction, cubie) {
  connection.invoke("Rotate", face, direction, cubie.x, cubie.y, cubie.z);
  console.log("Comando enviado:", face, direction);
}

function arraysEqual(a, b) {
  return Array.isArray(a) && Array.isArray(b) && a.length === b.length &&
    a.every((val, index) => val === b[index]);
}

const rotationMap = {
  //canto inferior esquerdo frente
  '0,0,2|Front|down': { face: 'left', direction: 'CounterClockwise' },
  '0,0,2|Front|Left': { face: 'down', direction: 'CounterClockwise' },
  '0,0,2|Down|front': { face: 'left', direction: 'clockwise' },
  '0,0,2|Down|Left': { face: 'front', direction: 'CounterClockwise' },
  '0,0,2|Left|down': { face: 'front', direction: 'clockwise' },
  '0,0,2|Left|front': { face: 'down', direction: 'clockwise' },

  //canto superior esquerdo frente
  '0,2,2|Front|up': { face: 'left', direction: 'clockwise' },
  '0,2,2|Front|Left': { face: 'Up', direction: 'CounterClockwise' },
  '0,2,2|Left|up': { face: 'front', direction: 'CounterClockwise' },
  '0,2,2|Left|front': { face: 'up', direction: 'clockwise' },
  '0,2,2|Up|Front': { face: 'front', direction: 'CounterClockwise' },
  '0,2,2|Up|left': { face: 'down', direction: 'counter' },

  //canto superior direito frente
  '2,2,2|Front|up': { face: 'right', direction: 'clockwise' },
  '2,2,2|Front|right': { face: 'up', direction: 'clockwise' },
  '2,2,2|Up|front': { face: 'right', direction: 'CounterClockwise' },
  '2,2,2|Up|right': { face: 'front', direction: 'CounterClockwise' },
  '2,2,2|Right|up': { face: 'front', direction: 'clockwise' },
  '2,2,2|Right|front': { face: 'up', direction: 'CounterClockwise' },

  //canto inferior direito frente
  '2,0,2|Front|down': { face: 'right', direction: 'CounterClockwise' },
  '2,0,2|Front|right': { face: 'down', direction: 'clockwise' },
  '2,0,2|Down|front': { face: 'right', direction: 'clockwise' },
  '2,0,2|Down|right': { face: 'front', direction: 'clockwise' },
  '2,0,2|Right|front': { face: 'down', direction: 'CounterClockwise' },
  '2,0,2|Right|down': { face: 'front', direction: 'CounterClockwise' },

  //canto inferior esquerdo atraz
  '0,0,0|Left|down': { face: 'back', direction: 'clockwise' },
  '0,0,0|Left|back': { face: 'down', direction: 'CounterClockwise' },
  '0,0,0|Down|Left': { face: 'back', direction: 'CounterClockwise' },
  '0,0,0|Down|back': { face: 'left', direction: 'CounterClockwise' },
  '0,0,0|Back|Left': { face: 'down', direction: 'clockwise' },
  '0,0,0|Back|down': { face: 'left', direction: 'clockwise' },

  // canto superior esquerdo atraz
  
  '0,2,0|Left|back': { face: 'up', direction: 'CounterClockwise' },
  '0,2,0|Left|up': { face: 'back', direction: 'CounterClockwise' },
  '0,2,0|Back|Left': { face: 'up', direction: 'clockwise' },
  '0,2,0|Back|up': { face: 'left', direction: 'CounterClockwise' },
  '0,2,0|Up|Left': { face: 'back', direction: 'clockwise' },
  '0,2,0|Up|back': { face: 'left', direction: 'clockwise' },
  
  // canto inferior esquerdo atraz
  
  '2,0,0|Back|down': { face: 'right', direction: 'clockwise' },
  '2,0,0|Back|right': { face: 'down', direction: 'CounterClockwise' },
  '2,0,0|Down|back': { face: 'right', direction: 'CounterClockwise' },
  '2,0,0|Down|right': { face: 'back', direction: 'clockwise' },
  '2,0,0|Right|back': { face: 'down', direction: 'clockwise' },
  '2,0,0|Right|down': { face: 'back', direction: 'CounterClockwise' },
  
  // canto superior direito atraz
  '2,2,0|Up|right': { face: 'back', direction: 'CounterClockwise' },
  '2,2,0|Up|back': { face: 'right', direction: 'clockwise' },
  '2,2,0|Back|up': { face: 'right', direction: 'CounterClockwise' },
  '2,2,0|Back|right': { face: 'up', direction: 'CounterClockwise' },
  '2,2,0|Right|up': { face: 'back', direction: 'clockwise' },
  '2,2,0|Right|back': { face: 'up', direction: 'clockwise' },
};



export function rightiComand(direction, cubie, face) {
  const key = cubie.join(',') + '|' + face + '|' + direction;
  const result = rotationMap[key];

  if (result) {
    return { ...result, cubie };
  } else {
    return { face: null, direction: null, cubie };
  }
}
