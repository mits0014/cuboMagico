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
- A classe CubeLogic é responsável por implementar as operações de manipulação do cubo. Ela gerencia tanto a rotação completa de uma face inteira quanto a rotação individual de cada cubie que compõe essa face.

- Ao selecionar uma face para rotação, o sistema reorganiza os cubies daquela face no sentido horário. Em seguida, cada cubie da face é rotacionado individualmente para refletir a rotação aplicada, garantindo que o estado do cubo seja atualizado corretamente após cada movimento.

- exemplo de como esta rotação funciona, Primeiramente o codigo cria uma copia da facie selecionada, apos isso rearanja os cubinhos trocando os de posição no sentido horario como representa a imagem a baixo
![Exemplo de GIF](https://github.com/mits0014/videosEImagens/blob/main/1.png)

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
