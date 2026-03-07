# Rock Paper Scissors – Unity 2D Game

## Project Description

This project is a **2D Rock, Paper, Scissors game built in Unity**.  
The game includes a **multi-page menu system, interactive UI, game logic, sound settings, and WebGL deployment**.

Players compete against the computer by choosing **Rock, Paper, or Scissors**. After selecting an option and pressing **Shoot**, the computer randomly generates its choice and the game determines the winner using the classic rules.

The project demonstrates **UI design, scene management, C# scripting, enums, switch-case logic, and WebGL publishing**.

---

# Project Features

## Menu System (Main Menu Scene)

The game starts with a **Main Menu** that contains several navigation pages:

### Home Page
- Displays the **game title**
- Includes the following buttons:
  - **Start Game**
  - **Exit**
  - **Settings**
  - **How to Play**
  - **About**

### How to Play Page
Provides instructions on how the game works and explains the rules of **Rock, Paper, Scissors**.

### About Page
Displays information about the project 

### Settings Page
Allows the player to customize the game experience.

Options include:
- Toggle **Background Music (On/Off)**
- Toggle **Sound Effects (On/Off)**

---

# Game Scene (Gameplay)

The gameplay interface contains the following elements:

### Player Action Buttons
- Rock
- Paper
- Scissors
- Shoot

### Display Area
Shows:
- Player’s choice
- Computer’s choice
- Game result

When the player clicks **Shoot**, the game determines the winner and displays the result.

---

# Game Logic

The game logic is implemented using **C# scripts**.

Key mechanics include:

- Player choice stored using an **enum**
- Computer generates a **random selection**
- A **switch-case statement** compares the player and computer choices

Game Rules:
- Rock beats Scissors
- Scissors beats Paper
- Paper beats Rock

The UI updates to display:
- Player choice
- Computer choice
- Game result

### Replay Feature
A **Replay button** allows the player to reset the round.

The Replay button only becomes active **after the player presses Shoot**.

---

# Anti-Cheat Feature

To prevent cheating:

- Once the player selects an option and presses **Shoot**, the selection **cannot be changed**.
- The player must press **Replay** to start a new round.

---

# Controls

| Control | Action |
|-------|-------|
| Mouse Click | Select Rock, Paper, or Scissors |
| Mouse Click | Press Shoot to start the round |
| Mouse Click | Press Replay to restart the round |
| Mouse Click | Navigate menu buttons |

---

# How to Run the Game

## Running the Game from Unity

1. Open the project in **Unity Hub**
2. Open the **Main Menu Scene**
3. Press **Play** in the Unity Editor

---

## Playing the Web Version

The game can be played directly in the browser using WebGL.
