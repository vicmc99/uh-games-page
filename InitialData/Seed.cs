using Data.Model;

namespace InitialData;

public static class Seed
{

    public static List<Faculty> GetFaculties()
    {
        return new List<Faculty>()
        {
            new Faculty { Id = 1, Name = "Facultad de Artes y Letras", Acronym = "FAyL", Mascot = "Elefantes" },
            new Faculty { Id = 2, Name = "Facultad de Biología", Acronym = "Bio", Mascot = "Gavilanes" },
            new Faculty { Id = 3, Name = "Facultad de Comunicación", Acronym = "FCOM", Mascot = "Vikingos" },
            new Faculty { Id = 4, Name = "Facultad Contabilidad y Finanzas", Acronym = "CONFIN", Mascot = "Lobos" },
            new Faculty { Id = 5, Name = "Facultad de Derecho", Acronym = "Lex", Mascot = "Zorros" },
            new Faculty { Id = 6, Name = "Facultad de Economía", Acronym = "EKO", Mascot = "Leones" },
            new Faculty { Id = 7, Name = "Español para no Hispanohablantes", Mascot = "Aplanadoras" },
            new Faculty
            {
                Id = 8, Name = "Facultad de Filosofía, Historia y Sociología", Acronym = "FHS", Mascot = "Buhos"
            },
            new Faculty { Id = 9, Name = "Facultad de Física", Acronym = "Fis", Mascot = "Tigres" },
            new Faculty { Id = 10, Name = "Facultad de Geografía", Acronym = "GEO", Mascot = "Tiburones" },
            new Faculty
            {
                Id = 11, Name = "Instituto de Farmacia y Alimentos", Acronym = "IFAL", Mascot = "Serpientes"
            },
            new Faculty
            {
                Id = 12, Name = "Instituto de Ciencias y Tecnologías Aplicadas", Acronym = "INSTEC", Mascot = "Gatos"
            },
            new Faculty { Id = 13, Name = "Instituto Superior de Diseño", Acronym = "ISDi", Mascot = "Mapaches" },
            new Faculty { Id = 14, Name = "Facultad de Lenguas Extranjeras", Acronym = "FLEX", Mascot = "Panteras" },
            new Faculty
            {
                Id = 15, Name = "Facultad de Matemática y Computación", Acronym = "MATCOM", Mascot = "Cuervos"
            },
            new Faculty { Id = 16, Name = "Facultad de Psicología", Acronym = "Psico", Mascot = "Fenix" },
            new Faculty { Id = 17, Name = "Facultad de Química", Acronym = "Qui", Mascot = "Pumas" },
            new Faculty { Id = 18, Name = "Facultad de Turismo", Acronym = "FTur", Mascot = "Aviones" }
        };
    }
   
}