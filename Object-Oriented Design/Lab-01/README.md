### Battleship — C++ OOP Project

For this project, I worked on a C++ implementation of **Battleship**, with a focus on object-oriented design, modularity, and keeping different parts of the game independent from one another.

The game board and ship positions are loaded from files. Ships must follow specific placement rules: they cannot overlap islands, extend to the edge of the board, overlap with other ships, or touch each other. An important part of the implementation was keeping the ships independent from the sea itself, so their positions could be changed without redesigning the board representation.

Another major challenge was implementing the **three independent shooting strategies**. The first randomly selects a position on the board, the second searches for an adjacent ship cell after a hit, and the third uses two known adjacent hits to continue searching along the ship. Each strategy has its own goal and required information, and the player switches to the next strategy only after the current one achieves its goal.

I also worked on separating what the game knows from what the player can see. The player receives feedback on whether a shot hits a ship but cannot see ship positions or learn which ship was hit. After every turn, the game displays the player's view of the sea, while the complete board is revealed at the end.

The project was a good exercise in **designing cooperating classes without tightly coupling them**, especially when implementing interchangeable strategies and managing the state of the game.

**Main concepts covered:**
- Object-oriented programming in C++
- Class design and separation of responsibilities
- File handling and loading game data
- Two-dimensional arrays and grid-based logic
- Composition and relationships between game objects
- Strategy pattern and interchangeable algorithms
- Encapsulation and information hiding
- State management and turn-based gameplay
- Input validation and enforcing game rules
- Modularity and extensibility
