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
  '0,0,0|Left|down': { face: 'back', direction: 'clockwise' },
  '0,0,0|Left|back': { face: 'down', direction: 'CounterClockwise' },
  '0,0,0|Down|Left': { face: 'back', direction: 'CounterClockwise' },
  '0,0,0|Down|back': { face: 'left', direction: 'CounterClockwise' },
  '0,0,0|Back|Left': { face: 'down', direction: 'clockwise' },
  '0,0,0|Back|down': { face: 'left', direction: 'clockwise' },

  '0,2,2|Front|up': { face: 'left', direction: 'clockwise' },
  '0,2,2|Front|Left': { face: 'Up', direction: 'CounterClockwise' },
  '0,2,2|Left|up': { face: 'front', direction: 'CounterClockwise' },
  '0,2,2|Left|front': { face: 'up', direction: 'clockwise' },
  '0,2,2|Up|Front': { face: 'front', direction: 'CounterClockwise' },
  '0,2,2|Up|left': { face: 'down', direction: 'counter' },

  '0,2,0|Front|Up': { face: 'left', direction: 'CounterClockwise' },
  '0,2,0|Front|Left': { face: 'Up', direction: 'CounterClockwise' },

  '0,0,2|down': { face: 'front', direction: 'CounterClockwise' },
  '0,0,2|left': { face: 'down', direction: 'clockwise' },

  

  '2,0,0|Back|down': { face: 'right', direction: 'clockwise' },
  '2,0,0|Back|right': { face: 'down', direction: 'CounterClockwise' },
  '2,0,0|Down|back': { face: 'right', direction: 'CounterClockwise' },
  '2,0,0|Down|right': { face: 'back', direction: 'clockwise' },
  '2,0,0|Right|back': { face: 'down', direction: 'clockwise' },
  '2,0,0|Right|down': { face: 'back', direction: 'CounterClockwise' },

  '2,2,0|up': { face: 'right', direction: 'CounterClockwise' },
  '2,2,0|left': { face: 'down', direction: 'counter' },

  '2,0,2|down': { face: 'back', direction: 'CounterClockwise' },
  '2,0,2|left': { face: 'down', direction: 'clockwise' },

  '2,2,2|up': { face: 'back', direction: 'CounterClockwise' },
  '2,2,2|left': { face: 'down', direction: 'counter' }
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
