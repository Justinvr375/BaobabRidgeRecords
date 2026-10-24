using System.CodeDom.Compiler;
using System.Drawing.Text;

namespace BaobabRidgeRecords;

public partial class Form1 : Form
{
    private Animal? editAnimal = null; //source for which mode the form is in
    public Form1() //calling methods when application runs for the first time
    {
        InitializeComponent();


        SetupGrid();
        RefreshGrid(true);
        AddMode();
    }


    private void AddColumn(string header, string propertyName) //Method to add collumns. Mainly used in the setupgrid() method
    {
        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
        column.HeaderText = header;
        column.DataPropertyName = propertyName;
        dgvAnimal.Columns.Add(column);
    }


    private void SetupGrid() //Method to set up the grid
    {
        dgvAnimal.AutoGenerateColumns = false;
        dgvAnimal.ReadOnly = true;
        dgvAnimal.AllowUserToAddRows = false;
        dgvAnimal.AllowUserToDeleteRows = false;
        dgvAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAnimal.MultiSelect = false;
        dgvAnimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        AddColumn("Animal ID", "AnimalID");
        AddColumn("Name", "Name");
        AddColumn("Species", "Species");
        AddColumn("Age", "Age");
        AddColumn("Recovery Score", "RecScore");
        AddColumn("Status", "Status");
        AddColumn("Housing Unit", "HousingUnit");
    }

    public void RefreshGrid(bool reportSkipped) // refreshing the grid
    {
        int skipped; //keeps track of the lines in the textFile that were skipped (if any)
        List<Animal> animals = AnimalLedger.LoadRoster(out skipped); //fetching textFile contents


        dgvAnimal.DataSource = null;
        dgvAnimal.DataSource = animals;


        dgvAnimal.ClearSelection();
        dgvAnimal.CurrentCell = null;

        if (reportSkipped && skipped > 0) //If any lines where skipped it displays a message specifying the amount of lines
        {
            MessageBox.Show(skipped + " line(s) in animals.txt are invalid hence skipped.",
                "Some lines skipped", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // The Add button will validate the animal info user input in the textboxes before adding the animal to animals.txt
    private void btnAdd_Click(object sender, EventArgs e)
    {
        List<Animal> roster = AnimalLedger.LoadRoster(out _);

        bool isValid = AnimalValidator.ValidateAndPrepare(txtAnimalID.Text, txtName.Text, txtSpecies.Text, txtAge.Text,
            txtRecoveryScore.Text, roster, isUpdate: false, out Animal? validatedAnimal,
            out string errorMessage, out string failedField);

        if (isValid == false)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            switch (failedField) //Focusing the textField that caused a validation error
            {
                case AnimalValidator.AnimalIdField:
                    txtAnimalID.Focus();
                    txtAnimalID.SelectAll();
                    break;

                case AnimalValidator.AnimalNameField:
                    txtName.Focus();
                    txtName.SelectAll();
                    break;

                case AnimalValidator.AnimalSpeciesField:
                    txtSpecies.Focus();
                    txtSpecies.SelectAll();
                    break;

                case AnimalValidator.AnimalAgeField:
                    txtAge.Focus();
                    txtAge.SelectAll();
                    break;

                case AnimalValidator.AnimalScoreField:
                    txtRecoveryScore.Focus();
                    txtRecoveryScore.SelectAll();
                    break;
            }
            return;
        }

        if (validatedAnimal != null) // If all the validation succeeded, displays a message and clears all text fields
        {
            bool succeeded = AnimalLedger.AddAnimal(validatedAnimal);

            if (succeeded)
            {
                string successMessage = $"Successfully saved {validatedAnimal.Name} ({validatedAnimal.AnimalID})\n\n" +
                    $"Status: {validatedAnimal.Status}\n" + $"Housing Unit: {validatedAnimal.HousingUnit}";

                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAnimalID.Clear();
                txtName.Clear();
                txtSpecies.Clear();
                txtAge.Clear();
                txtRecoveryScore.Clear();
                txtAnimalID.Focus();

                RefreshGrid(false);
            }
        }
    }

    private void btnGenerateSummary_Click(object sender, EventArgs e)
    {

        // Load the current animal records.
        List<Animal> animals = AnimalLedger.LoadRoster(out _);

        int totalAnimals = animals.Count;

        double averageAge = 0;
        double averageScore = 0;

        if (totalAnimals > 0)
        {
            averageAge = animals.Average(a => a.Age);
            averageScore = animals.Average(a => a.RecScore);
        }

        // Count the animals in each status.

        int critical = animals.Count(a =>
            a.Status == "Critical");

        int serious = animals.Count(a =>
            a.Status == "Serious");

        int stable = animals.Count(a =>
            a.Status == "Stable");

        int recovering = animals.Count(a =>
            a.Status == "Recovering");

        int releaseReady = animals.Count(a =>
            a.Status == "Release-Ready");

        // Display the results on the form.
        lblTotalAnimals.Text = totalAnimals.ToString();


        lblAverageAge.Text = totalAnimals > 0
            ? averageAge.ToString("F2")
            : "N/A";

        lblAverageScore.Text = totalAnimals > 0
            ? averageScore.ToString("F2")
            : "N/A";


        lblCritical.Text = critical.ToString();
        lblSerious.Text = serious.ToString();
        lblStable.Text = stable.ToString();
        lblRecovering.Text = recovering.ToString();
        lblReleaseReady.Text = releaseReady.ToString();

        // Prepare the summary report.
        string report =
            "BAOBAB RIDGE ANIMAL SUMMARY REPORT" + Environment.NewLine +
            "==================================" + Environment.NewLine +
            Environment.NewLine +
            "Total Animals: " + totalAnimals + Environment.NewLine +
            "Average Age: " +
                (totalAnimals > 0 ? averageAge.ToString("F2") : "N/A") +
                Environment.NewLine +
            "Average Recovery Score: " +
                (totalAnimals > 0 ? averageScore.ToString("F2") : "N/A") +
                Environment.NewLine +
            Environment.NewLine +
            "ANIMALS BY STATUS" + Environment.NewLine +
            "-----------------" + Environment.NewLine +
            "Critical: " + critical + Environment.NewLine +
            "Serious: " + serious + Environment.NewLine +
            "Stable: " + stable + Environment.NewLine +
            "Recovering: " + recovering + Environment.NewLine +
            "Release-Ready: " + releaseReady + Environment.NewLine;

        // Save the report to summary.txt.

        string reportPath = Path.Combine(AppContext.BaseDirectory,"summary.txt");


        try
        {
            File.WriteAllText(reportPath, report);
            MessageBox.Show("Summary report generated successfully.\n\n" +"Saved to:\n" + reportPath,"Summary Report",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        catch (IOException)
        {
            MessageBox.Show("The summary report could not be saved. " +"Please check whether the file is open.","File Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("The program does not have permission to save summary.txt.","Access Denied", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }



    }
    public void FillTextboxes(Animal animal) //Method for filling in text boxes with currently selected animal
    {

        txtAnimalID.Text = animal.AnimalID.ToString();
        txtName.Text = animal.Name;
        txtSpecies.Text = animal.Species;
        txtAge.Text = animal.Age.ToString();
        txtRecoveryScore.Text = animal.RecScore.ToString();

    }
    private void dgvAnimal_CellClick(object sender, DataGridViewCellEventArgs e) //filling text fields with currently selected dgv row
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        if (dgvAnimal.Rows[e.RowIndex].DataBoundItem is Animal animal)
        {
            FillTextboxes(animal); //Calling method to fill textboxes with the animal in the selected row
            EditMode(animal);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        var result = AnimalLedger.Search(txtSearchAnimalID.Text); //used for validating

        if (result != null && result.Count > 0)
        {
            dgvAnimal.DataSource = result;
            dgvAnimal.CurrentCell = dgvAnimal.Rows[0].Cells[0];
            dgvAnimal.Rows[0].Selected = true;
            //setting the resulting search as the selected item
            EditMode(result[0]);
        }
        else
        {
            MessageBox.Show("The Animal was not found, please search again.");
            txtSearchAnimalID.Clear();
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            RefreshGrid(true);

        }
    }

    private void EditMode(Animal animal) //Setting conditions for editting 
    {
        editAnimal = animal;
        FillTextboxes(animal);

        txtAnimalID.ReadOnly = true;
        btnAdd.Enabled = false;
        btnSaveChanges.Enabled = true;
    }

    private void AddMode() //Setting conditions for addding 
    {
        txtAnimalID.Clear();
        txtName.Clear();
        txtSpecies.Clear();
        txtAge.Clear();
        txtRecoveryScore.Clear();
        txtSearchAnimalID.Clear();
        txtAnimalID.ReadOnly = false;
        btnAdd.Enabled = true;
        btnSaveChanges.Enabled = false;
    }

    private void btnClear_Click(object sender, EventArgs e) //Clearing 
    {
        AddMode();
        RefreshGrid(true);
    }

    private void btnSaveChanges_Click(object sender, EventArgs e) //saving changes 
    {
        List<Animal> roster = AnimalLedger.LoadRoster(out _);
        bool isValid = AnimalValidator.ValidateAndPrepare(txtAnimalID.Text, txtName.Text, txtSpecies.Text, txtAge.Text,
            txtRecoveryScore.Text, roster, true, out Animal? validatedRoster, out string errorMessage,
            out string failedField); //Calling validation method

        if (!isValid) // if validation is not successfull display a message and return
        {
            MessageBox.Show(errorMessage);
            return;
        }

        if (AnimalLedger.Update(txtAnimalID.Text, txtName.Text, txtSpecies.Text, int.Parse(txtAge.Text),
            int.Parse(txtRecoveryScore.Text))) //if validation is successful, disaply that the animal was updated
        {
            MessageBox.Show("Animal was updated");
            AddMode();
            RefreshGrid(true);
        }
    }


    private void btnDelete_Click(object sender, EventArgs e)
    {

        // Make sure an animal has been selected.
        if (dgvAnimal.SelectedRows.Count == 0 || dgvAnimal.SelectedRows[0].DataBoundItem is not Animal animal)
        {
            MessageBox.Show("Please select an animal from the grid first.","No Animal Selected",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            return;
        }

        // Confirm the deletion.
        DialogResult result = MessageBox.Show( $"Are you sure you want to delete {animal.Name} " + $"({animal.AnimalID})?","Confirm Deletion", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
        {
            return;
        }

        // Delete the selected animal.
        if (AnimalLedger.DeleteAnimal(animal.AnimalID))
        {
            MessageBox.Show("Animal deleted successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            // Clear the form if the deleted animal was being edited.
            if (editAnimal != null &&editAnimal.AnimalID.Equals(animal.AnimalID,StringComparison.OrdinalIgnoreCase))
            {
                AddMode();
            }

            RefreshGrid(false);
        }
        else
        {
            MessageBox.Show("The animal was not deleted. It may no longer exist.","Deletion Failed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            RefreshGrid(false);
        }

    }

}