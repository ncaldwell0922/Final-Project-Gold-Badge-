using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class ClaimsData
{
    [Fact]
    public void CreateAClaim()
        {
            ClaimsDepartment claims = new ClaimsDepartment();
            claims.ID = 234;
            claims.TypeOfClaim = ClaimType.Car;
            claims.Description = "Hit a large pothole";
            claims.ClaimAmount = 4000;
            claims.DateOfIncident = new DateTime(2021, 10, 13);
            claims.DateOfClaim = new DateTime(2022, 1, 6);

            int expectedClaimAmount = 4000;
            int actualClaimAmount = claims.ClaimAmount;

            Assert.Equal(expectedClaimAmount, actualClaimAmount);
        }
}