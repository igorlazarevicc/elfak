### Lab 5 — Minesweeper

For this lab, I developed a **Windows Forms Minesweeper game in C#**, focusing on working with UI controls, events, timers, menus, and data serialization.

The game starts with a **9×9 board and 10 mines** by default, while also allowing the user to configure larger boards and change the number of mines. I implemented the game logic, handling user interactions with the board, revealing cells, marking mines, and detecting the end of the game.

I also added a **game timer** that starts when a new game begins and resets whenever the game is restarted. An option to end the current game was included as well, revealing all remaining cells.

In addition to the game itself, I implemented an **administrator section for configuring the board** and used **XML serialization and deserialization** to save and load both mine configurations and the current state of the game.

The project also follows a separated structure, with the classes responsible for the application's data and logic placed in separate projects from the Windows Forms interface.

**Main concepts covered:**

* Windows Forms and UI controls
* Event handling
* MenuStrip and application menus
* Timers
* XML serialization and deserialization
* Saving and loading application state
* Separation of application logic and UI
* Object-oriented programming in C#


<img width="316" height="410" alt="image" src="https://github.com/user-attachments/assets/eacfa6e0-c36c-44cf-b59e-d61ede4a3a3f" />
<img width="317" height="410" alt="image" src="https://github.com/user-attachments/assets/b242a19d-6b89-447b-9a9a-eedd981d4df3" />

