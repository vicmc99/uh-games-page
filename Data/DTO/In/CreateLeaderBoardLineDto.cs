namespace Data.DTO.In;

public class CreateLeaderBoardLineDto
{
    public int Year { get; set; }
    public int FacultyId { get; set; }
    public int Ranking { get; set; }
    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }
}