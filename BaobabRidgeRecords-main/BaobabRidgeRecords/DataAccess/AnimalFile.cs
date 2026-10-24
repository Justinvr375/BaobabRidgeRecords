using System.Xml.Linq;

namespace BaobabRidgeRecords;

public class AnimalLedger
{
        public static readonly string LedgerPath = Path.Combine(AppContext.BaseDirectory, "animals.txt");

    // Reads animals.txt and returns only the valid animal. Lines that are invalid or
    // repeat an earlier ID are skipped, and it also  tells the us how many.
    public static List<Animal> LoadRoster(out int badRows)
    {
        var roster = new List<Animal>();
        int bad = 0;

        TryOp(() =>
        {
            if (!File.Exists(LedgerPath))
            {
                File.WriteAllText(LedgerPath, "");
                return;
            }

            // Keeps track of all the IDs already inputted so duplicates can be skipped
            var seenTags = new HashSet<string>();

            foreach (string row in File.ReadAllLines(LedgerPath))
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }

                Animal? animal = ParseRow(row);

                // Skip lines that use an ID we have already loaded
                if (animal == null || !seenTags.Add(animal.AnimalID))
                {
                    bad++;
                    continue;
                }

                // Work out the status and housing unit again from the score, in order to match up wit da classification rules.
                
                animal.Classify();
                roster.Add(animal);
            }
        }, "The animal file could not be read.");

        
        badRows = bad;
        return roster;
    }

    //Checks validity of an Id
    public static bool IsValidTag(string tag)
    {
       
        if (tag.Length != 7) //Checks length of provided ID
        {
            return false;
        }

        
        if (!tag.StartsWith("WR-")) //Checking whether it starts with WR-
        {
            return false;
        }


        for (int i = 3; i < 7; i++)// loops through remaining characters and checks whether it is digits or not
        {
            if (!char.IsDigit(tag[i]))
            {
                return false;
            }
        }

        return true;
    }




    // Converts one line from .txt into an Animal then returns a null if the
    // line is not in the correct form.
    
    private static Animal? ParseRow(string row)
    {
        string[] f = row.Split('|');

        
        if (f.Length != 7)
        {
            return null;
        }

        
        string tag = f[0].Trim().ToUpperInvariant();
        if (!IsValidTag(tag))
        {
            return null;
        }

        // Age 
        int age;
        if (!int.TryParse(f[3].Trim(), out age))
        {
            return null;
        }
        if (age < 0)
        {
            return null;
        }
        if (age > 100)
        {
            return null;
        }

        // Recovery score
        int score;
        if (!int.TryParse(f[4].Trim(), out score))
        {
            return null;
        }
        if (score < 0)
        {
            return null;
        }
        if (score > 100)
        {
            return null;
        }

        // Name (required)
        if (f[1].Trim().Length == 0)
        {
            return null;
        }

        // Species thype
        if (f[2].Trim().Length == 0)
        {
            return null;
        }

        // The stored status and housing unit are irrelevent here. Classify() sets them from the score
        return new Animal
        {
            AnimalID = tag,
            Name = f[1].Trim(),
            Species = f[2].Trim(),
            Age = age,
            RecScore = score,
        };
    }

    public static bool AddAnimal(Animal animal)
    {
        return TryOp(() =>
        {
           
            if (File.Exists(LedgerPath)) //checks whether file exists
            {
                string existing = File.ReadAllText(LedgerPath);
                if (existing.Length > 0 && !existing.EndsWith('\n')) 
                {
                    File.AppendAllText(LedgerPath, Environment.NewLine);
                }
            }

            File.AppendAllText(LedgerPath, animal.ToFileLine() + Environment.NewLine); //adds the animal to the list 
        }, "The animal could not be added.");
    }

    
    // It writes to a temporary file first and then replaces animals.txt, so if
    // the write fails halfway the original file is not damaged. (in theory)
    public static bool RewriteAll(List<Animal> roster)
    {
        return TryOp(() =>
        {
            string temp = LedgerPath + ".tmp";
            File.WriteAllLines(temp, roster.Select(a => a.ToFileLine()));
            File.Move(temp, LedgerPath, overwrite: true);
        }, "The changes could not be saved.");
    }

   
    private static bool TryOp(Action op, string problem)
    {
        try
        {
            op();
            return true;
        }
        catch (IOException)
        {
            ShowError(problem + " The file may be open in another program.");
        }
        catch (UnauthorizedAccessException)
        {
            ShowError(problem + " The program access is denied at this time, you may be unauthorized to change the file.");
        }

        return false;
    }

    // warning message 
    private static void ShowError(string message)
    {
        MessageBox.Show(message, "File Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static List<Animal>? Search(string aID) 
    {
        if (string.IsNullOrWhiteSpace(aID)) //checks data entered by user and returns null if nothing was entered
        {
            return null;
        }

        List<Animal> animals = AnimalLedger.LoadRoster(out _); //Loading animals in a list
        List<Animal> animalList = new List<Animal>(); //creating empty list to display results 
        
       
        foreach (Animal animal in animals)
        {
            if (animal.AnimalID.Equals(aID.Trim(),StringComparison.OrdinalIgnoreCase))
            {
                animalList.Add(animal); //adding the found animal to the results list
            }
            
            
        }
        return animalList;
        
    }
    //Updating an animal
    public static bool Update(string aID, string aName, string aSpecies, int aAge, int aRecScore)
    {
        bool saved = false;
        bool found = false;
        
        TryOp(() =>
        {
            List<Animal> animals = AnimalLedger.LoadRoster(out _); //loading roster into a list of objects

            foreach (Animal animal in animals) //loops through list of animals. If that animal is found it updates the object with the new values from the texfields
            {
                if (animal.AnimalID.Equals(aID, StringComparison.OrdinalIgnoreCase))
                {
                    animal.Name = aName;
                    animal.Species = aSpecies;
                    animal.Age = aAge;
                    animal.RecScore = aRecScore;
                    animal.Classify();
                    found = true;

                    break;
                }
                
            }
           
            if (!found)
            {
                MessageBox.Show("Animal you are trying to update no longer exists");
                return; //returns if the animal was not found within the list 
            }
            
            saved = RewriteAll(animals);

        }, "Could not update.");

        return saved;
        
    }


    //Loops through list containing textfile contents and deletes the animal with the corresponding animalID
    public static bool DeleteAnimal(string animalID)
    {
        try
        {
            if (!File.Exists(LedgerPath))
            {
                return false; //Return if file was not found
            }

            List<string> lines = File.ReadAllLines(LedgerPath).ToList();// loading txtfile to a list
            bool deleted = false; 

            for (int i = 0; i < lines.Count; i++) //loops through list and deletes animal if the animals ID was found
            {
                string[] fields = lines[i].Split('|');

                if (fields.Length == 7 &&fields[0].Trim().Equals(animalID.Trim(),StringComparison.OrdinalIgnoreCase))
                {
                    lines.RemoveAt(i);
                    deleted = true;
                    break;
                }
            }

            if (!deleted)
            {
                return false; //Checks delete status and returns if nothing was deleted
            }

            string temp = LedgerPath + ".tmp";
            File.WriteAllLines(temp, lines);
            File.Move(temp, LedgerPath, overwrite: true);

            return true;
        }
        catch (IOException)
        {
            MessageBox.Show("The animal could not be deleted. Check whether the file is open.","File Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("You do not have permission to modify the animal file.","Access Denied",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        return false;
    }


}
