### Lab 4 — Driver Management System

For this lab, I developed a **Windows Forms application for managing drivers and their driving licence information** in C#.

The application allows users to add, edit, delete, and sort drivers, with all registered drivers displayed in a `DataGridView`. I implemented input validation for driver names, required-field checks, confirmation dialogs, and `MessageBox` notifications for user actions.

I also worked with **multiple forms and UI controls**, including `ComboBox`, `PictureBox`, `DataGridView`, `OpenFileDialog`, and buttons with custom icons. Each driver is required to have a profile picture, which can be selected from the file system and displayed when viewing or editing the driver's information.

One of the main parts of the lab was implementing **sorting using delegates**. The user can choose a sorting criterion from a dropdown menu, such as licence number, first name, or last name, while the sorting method itself does not receive any arguments.

The application also includes a **real-time clock** that updates every second using a timer, fixed-size forms, configured `TabOrder`, and confirmation when closing a form. Driving licence categories are handled dynamically, including the option to select which category can be restricted for a particular driver.

As in the previous lab, the project structure separates the **data and application logic into separate projects**, keeping it independent from the Windows Forms interface.

**Main concepts covered:**

* Windows Forms and multiple forms
* Event handling and input validation
* DataGridView and dynamic data management
* Delegates and custom sorting
* Timers and real-time updates
* OpenFileDialog and image handling
* PictureBox and loading images from the file system
* ComboBox and dynamic selections
* MessageBox and user confirmations
* TabOrder and UI organization
* Separation of application logic and UI
* Object-oriented programming in C#


p.s. There are a few minor bugs here :)

<img width="696" height="432" alt="image" src="https://github.com/user-attachments/assets/70145487-e345-4862-ac79-7a330a612d75" />
<img width="502" height="819" alt="image" src="https://github.com/user-attachments/assets/39ec949f-4cf4-4045-a9e6-22671486174b" />
