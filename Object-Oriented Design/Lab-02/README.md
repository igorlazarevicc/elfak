### Lab — UML Class Diagrams & C++

This lab focused on designing class structures using UML diagrams and then implementing them in C++.

**Day 1 — Faculty Management System**

The first task was to model a faculty, its departments, students, and courses. The main challenge was figuring out how the classes should relate to each other and how to enforce the rules defined by the task. This included making sure each student belongs to exactly one department, each department belongs to one faculty, and only one instance of the faculty can exist.

I also worked on modelling relationships between students and courses, allowing students to select and change their courses, and calculating the total number of ECTS credits they could earn from their selected courses. After designing the UML class diagram, I implemented the model in C++, including constructors, destructors, attributes, and methods needed to demonstrate how the system works.

**Day 2 — Automated Exam Sheet Generator**

The second task involved designing a system for automatically generating exam sheets based on predefined templates and a database of questions and exercises.

The interesting part was figuring out how to represent the relationships between questions, topics, exam templates, and exam periods. A single question could belong to multiple topics, while each topic could be associated with multiple questions. The system also had to keep track of how often each question had been used and store the history of generated exam sheets, including the exact combination of questions in each one.

I modelled these entities and their relationships in UML before implementing the solution in C++. This required thinking about how the classes would work together, how to select questions based on a template, and how to preserve previously generated exam sheets.

**Main concepts covered:**
- UML class diagrams and object-oriented design
- Classes, attributes, methods, constructors, and destructors
- Associations, multiplicities, and many-to-many relationships
- Encapsulation and responsibility separation
- Singleton pattern and restricting object instantiation
- Managing relationships between objects in C++
- Implementing business rules and basic application logic
