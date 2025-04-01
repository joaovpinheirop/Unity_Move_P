# Movimentação em Primeira Pessoa
Este projeto demonstra uma mecânica básica de movimentação em primeira pessoa em um ambiente 3D. O objetivo é criar um sistema simples e funcional para navegação do jogador utilizando teclado e mouse.

## Funcionalidades
- Movimentação com as teclas **W, A, S, D**  
- Controle da câmera pelo mouse (Usando Cinemachine)
- Possibilidade  pular  
- Física básica para colisão com o ambiente  

## Sobre o Projeto
Este é um projeto independente criado para estudo e aprimoramento no desenvolvimento de 
mecânicas básicas de movimentação em jogos. Futuras melhorias podem incluir ajustes na física, 
interação com objetos e um cenário mais detalhado.


## Tecnologias Utilizadas
- **Engine:** Unity  
- **Linguagem:** C#  

## Estrutura do Projeto
📂 **Assets**  
 ┣ 📂 Material *(Texturas e materiais do jogo)*  
 ┣ 📂 Prefab *(Modelos reutilizáveis do projeto)*  
 ┣ 📂 Scenes *(Cenas do jogo)*  
 ┗ 📂 Scripts *(Código-fonte do projeto)*  
 &emsp; ┣ 📂 **Player** *(Scripts relacionados ao jogador e seus estados)*  
 &emsp; ┃ ┣ 📜 `ControllerPlayer.cs` - Gerencia o controle do jogador e interações com a State Machine.  
 &emsp; ┃ ┣ 📜 `IdleState.cs` - Define o comportamento do jogador quando parado.  
 &emsp; ┃ ┣ 📜 `JumpState.cs` - Gerencia a ação de pulo.  
 &emsp; ┃ ┗ 📜 `WalkingState.cs` - Controla a movimentação do jogador.  
 &emsp; ┗ 📂 **StateMachine** *(Sistema de gerenciamento de estados)*  
 &emsp; &emsp; ┣ 📜 `State.cs` - Classe base para todos os estados.  
 &emsp; &emsp; ┗ 📜 `StateMachine.cs` - Gerencia as transições entre os estados.  


---
## Sistema de State Machine
A movimentação do jogador é gerenciada por uma **Máquina de Estados (State Machine)**, permitindo transições organizadas entre diferentes estados, como:

- **Idle** (Parado) – Quando o jogador não está se movendo.  
- **Walking** (Andando) – Quando há entrada de movimento.  
- **Jumping** (Pulando) – Quando o jogador executa um salto.

Com essa abordagem, adicionar novas ações, como correr, agachar ou interagir com o ambiente, torna-se simples e intuitivo, garantindo um código mais escalável e de fácil manutenção.

## Melhorias Futuras
- Implementar estado de corrida e agachamento.
- Adicionar animações para transições mais suaves.
- Incluir interação com objetos no ambiente.

### Versão 0.0.1
---

*Projeto desenvolvido para fins de aprendizado e portfólio.*  
