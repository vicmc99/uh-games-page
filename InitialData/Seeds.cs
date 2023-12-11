using Data.Model;

namespace InitialData;

public class InitialDomainData
{
    public static List<Faculty> GetFaculties()
    {
        return new List<Faculty>
        {
            new() { Id = 1, Name = "Facultad de Artes y Letras", Acronym = "FAyL", Mascot = "Elefantes" },
            new() { Id = 2, Name = "Facultad de Biología", Acronym = "Bio", Mascot = "Gavilanes" },
            new() { Id = 3, Name = "Facultad de Comunicación", Acronym = "FCOM", Mascot = "Vikingos" },
            new() { Id = 4, Name = "Facultad Contabilidad y Finanzas", Acronym = "CONFIN", Mascot = "Lobos" },
            new() { Id = 5, Name = "Facultad de Derecho", Acronym = "Lex", Mascot = "Zorros" },
            new() { Id = 6, Name = "Facultad de Economía", Acronym = "EKO", Mascot = "Leones" },
            new() { Id = 7, Name = "Español para no Hispanohablantes", Mascot = "Aplanadoras" },
            new() { Id = 8, Name = "Facultad de Filosofía, Historia y Sociología", Acronym = "FHS", Mascot = "Buhos" },
            new() { Id = 9, Name = "Facultad de Física", Acronym = "Fis", Mascot = "Tigres" },
            new() { Id = 10, Name = "Facultad de Geografía", Acronym = "GEO", Mascot = "Tiburones" },
            new() { Id = 11, Name = "Instituto de Farmacia y Alimentos", Acronym = "IFAL", Mascot = "Serpientes" },
            new()
            {
                Id = 12, Name = "Instituto de Ciencias y Tecnologías Aplicadas", Acronym = "INSTEC", Mascot = "Gatos"
            },
            new() { Id = 13, Name = "Instituto Superior de Diseño", Acronym = "ISDi", Mascot = "Mapaches" },
            new() { Id = 14, Name = "Facultad de Lenguas Extranjeras", Acronym = "FLEX", Mascot = "Panteras" },
            new() { Id = 15, Name = "Facultad de Matemática y Computación", Acronym = "MATCOM", Mascot = "Cuervos" },
            new() { Id = 16, Name = "Facultad de Psicología", Acronym = "Psico", Mascot = "Fenix" },
            new() { Id = 17, Name = "Facultad de Química", Acronym = "Qui", Mascot = "Pumas" },
            new() { Id = 18, Name = "Facultad de Turismo", Acronym = "FTur", Mascot = "Aviones" }
        };
    }

    public static List<LeaderboardLine> GetLeaderboardLines()
    {
        return new List<LeaderboardLine>
        {
            new() { FacultyId = 15, GoldMedals = 12, SilverMedals = 5, BronzeMedals = 3, Ranking = 1, Year = 2023 }
        };
    }

    public static List<Leaderboard> GetLeaderBoard()
    {
        return new List<Leaderboard>
        {
            new() { Id = 1, Year = 2023, LeaderboardLines = GetLeaderboardLines() }
        };
    }


    public static List<Major> GetMajor()
    {
        return new List<Major>
        {
            new() { Name = "Computación", Faculty = GetFaculties()[0] }
        };
    }

    public static List<Athlete> GetAthlete()
    {
        return new List<Athlete>
        {
            new()
            {
                Name = "Leonardo", DateOfBirth = new DateOnly(2001, 1, 1), Nick = "el leo"
            }
        };
    }

    public static List<Representative> GetRepresentative()
    {
        return new List<Representative>
        {
            new() { Athlete = GetAthlete()[0], Faculty = GetFaculties()[0], Year = 2023 }
        };
    }
}