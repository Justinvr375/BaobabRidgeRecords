using System;
using System.Collections.Generic;
using System.Globalization;

namespace BaobabRidgeRecords
{
    public static class AnimalValidator
    {
        // Constant field names for failedField
        public const string AnimalIdField = "AnimalID";
        public const string AnimalNameField = "Name";
        public const string AnimalSpeciesField = "Species";
        public const string AnimalAgeField = "Age";
        public const string AnimalScoreField = "RecoveryScore";

        // This method will clean the input text, validate the business rules and build&run the classification method
        public static bool ValidateAndPrepare(string idInput, string nameInput, string speciesInput, string ageInput, string scoreInput,
            List<Animal> currentRoster, bool isUpdate, out Animal? result, out string errorMessage, out string failedField)
        {
            result = null;         //result is the cleaned, classified animal and can only use it when method returns true
            errorMessage = "";     
            failedField = "";      //constant to keep track of the textField to focus on



            string cleanID = idInput.Trim().ToUpperInvariant();
            string cleanName = nameInput.Trim();
            string cleanSpecies = speciesInput.Trim();
            string cleanAge = ageInput.Trim();
            string cleanScore = scoreInput.Trim();


            // Validate Animal ID
            if (AnimalLedger.IsValidTag(cleanID) == false)
            {
                errorMessage = "Animal ID must start with 'WR-' followed by 4 numbers (ex. WR-0007)";
                failedField = AnimalIdField;
                return false;
            }

            // Rules for adding a new animal and updating an existing animal
            if (isUpdate == false)
            {
                foreach (var animalExist in currentRoster)
                {
                    if (animalExist.AnimalID == cleanID)
                    {
                        errorMessage = "This Animal ID already exists. The ID must be unique.";
                        failedField = AnimalIdField;
                        return false;
                    }
                }
            }
            else
            {
                bool found = false;
                foreach (var animalExist in currentRoster)
                {
                    if (animalExist.AnimalID == cleanID)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    errorMessage = "Animal not found.";
                    failedField = AnimalIdField;
                    return false;
                }
            }

            // Validate Animal Name and Species
            if (cleanName.Length < 1 || cleanName.Length > 30)
            {
                errorMessage = "You must enter a name and it cannot be longer than 30 characters.";
                failedField = AnimalNameField;
                return false;
            }

            if (cleanName.Contains('|'))
            {
                errorMessage = "Name cannot contain the pipe character '|'.";
                failedField = AnimalNameField;
                return false;
            }

            if (cleanSpecies.Length < 1 || cleanSpecies.Length > 30)
            {
                errorMessage = "You must enter a species and it cannot be longer than 30 characters.";
                failedField = AnimalSpeciesField;
                return false;
            }

            if (cleanSpecies.Contains('|'))
            {
                errorMessage = "Species cannot contain the pipe character '|'.";
                failedField = AnimalSpeciesField;
                return false;
            }

            // Validate Age and Recovery score
            if (!int.TryParse(cleanAge, NumberStyles.None, CultureInfo.InvariantCulture, out int ageParsed) || ageParsed < 0 || ageParsed > 100)
            {
                errorMessage = "Age must be a whole number between 0 and 100";
                failedField = AnimalAgeField;
                return false;
            }

            if (!int.TryParse(cleanScore, NumberStyles.None, CultureInfo.InvariantCulture, out int scoreParsed) || scoreParsed < 0 || scoreParsed > 100)
            {
                errorMessage = "Recovery Score must be a whole number between 0 and 100";
                failedField = AnimalScoreField;
                return false;
            }

            
            //Builds and Runs classification
            var validAnimal = new Animal { AnimalID = cleanID, Name = cleanName, Species = cleanSpecies, Age = ageParsed, RecScore = scoreParsed };

            validAnimal.Classify();
            result = validAnimal;
            return true;
        }

    }
}