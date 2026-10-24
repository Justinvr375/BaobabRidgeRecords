namespace BaobabRidgeRecords;


public class Animal
{
    //Each row holds the lowest score in the
    // band, the status name and the housing unit. Rows go from lowest to highest.
    private static readonly (int MinScore, string Status, string Unit)[] Bands =
    {
        (0,  "Critical",      "Intensive Care Unit"),
        (20, "Serious",       "High-Dependency Ward"),
        (40, "Stable",        "Recovery Ward"),
        (60, "Recovering",    "Outdoor Enclosure"),
        (80, "Release-Ready", "Pre-Release Camp"),
    };

    public string AnimalID { get; set; } = "";
    public string Name { get; set; } = "";
    public string Species { get; set; } = "";
    public int Age { get; set; }
    public int RecScore { get; set; }
    public string Status { get; set; } = "";
    public string HousingUnit { get; set; } = "";

    // Sets Status and HousingUnit from RecScore. It starts at the first band and
    // moves up while the score is high enough. Add/Update both can do it, so we need classification rules to ensure this.

    public void Classify()
    {
        var chosen = Bands[0];

        foreach (var band in Bands)
        {
            if (RecScore < band.MinScore)
            {
                break;
            }
            chosen = band;
        }

        Status = chosen.Status;
        HousingUnit = chosen.Unit;
    }

    // Builds the line of text that is saved to animals.txt for this animal.
    public string ToFileLine()
    {
        return AnimalID + "|" + Name + "|" + Species + "|" + Age + "|" + RecScore + "|" + Status + "|" + HousingUnit;
    }
}