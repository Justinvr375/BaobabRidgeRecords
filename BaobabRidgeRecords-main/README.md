# Baobab Ridge Wildlife Rehabilitation Records System
*The Baobab Ridge Wildlife Rehabilitation Records System is a C# Windows Forms application made to record animals in care. Its purpose is to track all the animals in care and work out the status and housing using a standardized Recovery Score calculation.*

## Members
- Justin Van Rooyen (604494) - Feature 3
- Muhammed Daanyaal Moosa (604173) - Foundation & Feature 2
- Shannon Pretorius (605056) - Feature 1 & Validations
- Lorilia-Jane Da Encarnacao (603383) - Feature 4 & Feature 5

## Prerequisites & Installation
**Requirements**
- Visual Studio 2022 with .NET desktop development workload installed
- .NET 8.0 or newer

**How to build and run the application**
1. Clone the repository to your local machine
2. Open the solution file (BaobabRidgeRecords.sln) in Visual Studio 2022
3. Build the application (Ctrl + Shift + B)
4. Press F5 to run the application
- The animals.txt is copied beside the .exe automatically, so no need for setup
- The summary.txt is created in the same folder when you click Generate Summary on the Windows Form app

## Features
**1. Add a new animal:**
- The Add button adds a new animal to the animals.txt and DataGridView. The five inputs include Animal ID, Name, Species, Age, and Recovery Score. Status and Housing Unit fields are calculated automatically upon saving.
- The fields that need to be filled in are validated to ensure the correct information is recorded. The validations rules include an ID that starts with WR- followed by 4 digits which is converted to upper case and checked for uniqueness. Name and species must be between 1 and 30 characters and cannot contain |. Age and score must be whole numbers from 0 to 100.
- When an error occurs, a message will be displayed which names the field and the cursor returns to that box without saving anything.
- On success the Status and Housing Unit are calculated from the Recovery Score by a single classification method (also used by Update) and is shown in a confirmation message. One new line is appended to animal.txt, the grid refreshes and the boxes are cleared.

**2. View all animals:**
- The system loads all recorded animals from the animals.txt file and displays them clearly in the DataGridView when the application opens.
  
**3. Update an animal:**
- Search button selects searched record and auto selects it to fill the text boxes.
- This enables edit mode and disables the Add button.
- Update function added through Save Changes button.
- Selecting rows in DataGridView fills text boxes and puts the form in edit mode. Clear button clears text fields and puts the form in add mode.

**4. Delete an animal:**
- Allows the user to select an animal from the DataGridView and delete it from the system.
- Displays a confirmation message showing the animal's ID and name before deletion and only follows through with the deletion once the user confirms the action.
- Cancelling the confirmation leaves the animal record unchanged and as it was.
- Refreshes the DataGridView after a successful deletion.
- Clears the form if the deleted animal was currently loaded for editing.
- Displays a warning if no animal is selected or if the deletion fails.
  
**5. Generate a summary report:**
- Calculates and displays the total number of valid animal records.
- Calculates the average age of all animals as well as their average recovery score.
- Counts the animals in each recovery status.
- Displays all the previously mentioned calculated results in the summary section of the form.
- Saves the generated report to a text file,summary.txt, in the application's output directory.
- Displays zero for the total and status counts when no valid animal records exist.
- Displays N/A for the average age and recovery score when no valid records exist.
- Displays a success message when the report is generated or a warning message if the report can't be saved.  

## Storage & Data Formats
**File formats**
- animals.txt: it stores one animal per row, 7 fields in the order ID, Name, Species, Age, Score, Status, Housing Unit, separated by |. It has no header, uses UTF-8 and it is stored beside the .exe. All malformed lines are skipped when loading.
- summary.txt: it is overwritten each time it is generated. It includes the timestamp, the total, the averages to two decimals, and a count for each of the five statuses.

**System Architecture**
- There are three layers including the Presentation, BusinessLogic, and DataAccess Layers used to create loose coupling.
- The Presentation Layer contains the Form that the user views
- The BusinessLogic Layer contains the Animal class with the animal fields and constructor as well as the AnimalValidation class used to validate the field inputs.
- The DataAccess Layer contains the AnimalFile with the AnimalLedger where the file storage is accessed through various methods.

**Known limitations**
- The validation rules did not compromise for number inputs in the name and species fields, so the user can enter for example 4 as a name or species.
