using Data.Model;

namespace Data.DTO;

public class LeaderboardLineDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int FacultyId { get; set; }
    public int Ranking { get; set; }
    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }

    public static LeaderboardLineDto FromEntity(LeaderboardLine entity)
    {
        return new LeaderboardLineDto
        {
            Id = entity.Id,
            Year = entity.Year,
            FacultyId = entity.FacultyId,
            Ranking = entity.Ranking,
            GoldMedals = entity.GoldMedals,
            SilverMedals = entity.SilverMedals,
            BronzeMedals = entity.BronzeMedals
        };
    }
}