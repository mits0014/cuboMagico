# 🧊 Cubo Magico
![Exemplo de GIF](https://github.com/mits0014/videosEImagens/blob/main/cuboMagico.gif)

Projeto dividido em duas aplicações — **backend** e **frontend** — para simular e interagir com um cubo mágico 3D em tempo real.

---

## 📝 Descrição

O **Cubo Magico** utiliza tecnologias modernas para representar um cubo mágico 3D com suporte a múltiplos usuários conectados em tempo real.

- O **backend** foi desenvolvido com ASP.NET Core (.NET C#), utilizando **SignalR** como biblioteca de WebSocket para comunicação em tempo real.
- O **frontend** é uma aplicação leve com **Vite** servindo HTML e JavaScript puro, utilizando **Three.js** para renderização 3D e integração com SignalR.

---
## Implementação
### Representação do Cubo
- Na pasta cuboMagicoBack/Models, encontra-se a classe Cube, que é responsável por armazenar o estado atual do cubo mágico. A classe Cube é implementada como um array multidimensional contendo 27 cubies (pequenos cubos). Desses, apenas 26 possuem faces visíveis — o cubie central interno não tem faces externas.

- Cada cubie é uma tupla que armazena, para cada uma das seis faces, uma cor correspondente. Essas faces são responsáveis por gerenciar a exibição visual e controlar a animação da rotação do cubo.

### Manipulação do Cubo

A classe `CubeLogic` é responsável por implementar as operações de manipulação do cubo mágico. Ela gerencia tanto a rotação completa de uma face (conjunto de 9 cubies) quanto a rotação individual de cada cubie que a compõe, garantindo a consistência visual e estrutural do cubo após cada movimento.

#### Etapas da Rotação

1. **Criação de uma cópia da face selecionada:**  
   Ao iniciar a rotação, o sistema cria uma cópia dos 9 cubies da face que será rotacionada.

2. **Reorganização dos cubies no sentido horário:**  
   Com base na cópia, os cubies são reposicionados conforme uma matriz 3x3 girada no sentido horário. Esse processo altera apenas as posições relativas dos cubies na face.  
   A imagem abaixo ilustra essa reorganização:

   ![Rotação da face](https://github.com/mits0014/videosEImagens/blob/main/imagem_rotacao_face.png)

3. **Observação da rotação na prática:**  
   Ao visualizar o cubo de cima, é possível notar que ele está posicionado corretamente. Na transição do estado 2 para o estado 3 da imagem, desconsideramos temporariamente as cores — focando apenas no reposicionamento estrutural dos cubies.

4. **Preservação da orientação das cores:**  
   Após reposicionar os cubies, é necessário também rotacionar individualmente cada um deles, para que as cores das faces permaneçam orientadas corretamente. Por exemplo, cubies com a face verde voltada para frente devem continuar com essa orientação após a rotação.  
   A imagem abaixo demonstra esse ajuste:

   ![Rotação dos Cubos](https://github.com/mits0014/videosEImagens/blob/main/imagem_rotacao_cubos.png)

Sem essa rotação individual, certos cubies (como o do canto direito na imagem) podem acabar com uma face sem cor visível ou com a orientação errada, comprometendo a representação visual correta do cubo.


---
## 🚀 Como rodar o projeto

### 1. Clone o repositório
- Abra o cmd na pasta de sua preferencia e execute os seguintes comandos.

```bash
git clone https://github.com/mits0014/cuboMagico.git
cd cuboMagico
```

### 2. Backend (.NET)
1. Navegue até a pasta do backend
2. Execute o projeto:
```bash
cd ./cuboMagicoBack
dotnet run
```

Isso iniciará o servidor SignalR em uma porta definida no `launchSettings.json`.

### 3. Frontend (Vite + JS)
1. Em outro terminal navegue até a pasta `frontend`
2. Instale as dependências (caso existam):
```bash
npm install
```
3. Inicie o Vite dev server:
```bash
npm run dev
```

O frontend se conectará automaticamente ao servidor SignalR e exibirá o cubo 3D no seu estagio inicial.

---

## 🛠️ Tecnologias Utilizadas

- **Backend**:
  - .NET Core (ASP.NET)
  - SignalR

- **Frontend**:
  - Vite
  - JavaScript Puro
  - Three.js
  - SignalR Client

---

## 📁 Estrutura do Projeto

```
cuboMagico/
├── CuboMagicoBack/       # Backend ASP.NET com SignalR
├── frontend/                # Frontend com Vite + Three.js
├── README.md
```
---

## 👨‍💻 Autor

- **Matheus Lima da Silveira** – [GitHub/mits0014](https://github.com/mits0014)

---

## 🔗 Repositório

Você pode acessar e explorar o projeto completo aqui:  
👉 [https://github.com/mits0014/cuboMagico](https://github.com/mits0014/cuboMagico)
