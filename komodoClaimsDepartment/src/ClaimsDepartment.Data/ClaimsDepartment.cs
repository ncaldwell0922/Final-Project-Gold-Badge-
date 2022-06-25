
public class ClaimsDepartment
{
    public ClaimsDepartment(){}

    public ClaimsDepartment
    (
        int id,
        ClaimType typeOfClaim,
        string description,
        double claimAmount,
        DateTime dateOfIncident,
        DateTime dateOfClaim,
        bool isValid
    )
    {
        ID = id;
        TypeOfClaim = typeOfClaim;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
        IsValid = isValid;
    }

    public int ID { get; set; }
    public ClaimType TypeOfClaim { get; set; }
    public string Description { get; set; }
    public double ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid { get; set; }
}
