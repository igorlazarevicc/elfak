### Lab 3 — Personal Information Management System

For this lab, I developed a **Windows Forms application in C# for managing personal information**, focusing on UI design, event handling, input validation, and object-oriented programming.

The application allows users to add, edit, delete, and sort people by first name, last name, or date of birth. I implemented input validation for names and phone numbers, required-field checks, and automatic form population when selecting or double-clicking an entry in the list.

I also worked with **data binding using `ListBox.DataSource`** and implemented a shared list of people that can be accessed throughout the project without creating multiple instances. The application supports editing existing entries without removing and re-adding them, as well as clearing individual entries or the entire list.

Another part of the lab involved **delegates and extension methods**. I implemented sorting based on a selected criterion using a delegate, along with a `DateTime` extension method that returns the current system date and time in a custom format (`dd.MM.yyyy. HH:mm`).

Additional features include resetting input fields, automatically setting the date of birth to the current date, managing keyboard focus, displaying system time through a form event, and adding confirmation dialogs and `MessageBox` notifications for user actions.

The project also separates the data classes and application logic into dedicated projects, keeping the code organized and the UI independent from the underlying data.

**Main concepts covered:**
- Windows Forms and UI controls
- Event handling and input validation
- ListBox data binding using `DataSource`
- CRUD operations and editing existing records
- Delegates and custom sorting
- Extension methods in C#
- Static/shared data and singleton-style instance management
- Date and time formatting
- MessageBox dialogs and form events
- Object-oriented programming and project separation



<p align="center">
  <img src="https://github.com/user-attachments/assets/30f2daf2-9fed-4f57-afe9-10511fd6dc26" width="24%" />
  <img src="https://github.com/user-attachments/assets/eddfdfb3-0b3b-41d5-b04b-652cb545f63e" width="24%" />
  <img src="https://github.com/user-attachments/assets/7fdca285-ee18-463a-a593-f4c4a1aa2eae" width="24%" />
  <img src="https://github.com/user-attachments/assets/be3ad420-5b37-4762-9002-ff33e87f2427" width="24%" />
</p>



