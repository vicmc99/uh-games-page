using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment_of_the_cardinality_of_the_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Representatives_Athletes_AthleteId",
                table: "Representatives");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Athletes_AthleteId1",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_AthleteId1",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "AthleteId1",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "FirstSurname",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Athletes");

            migrationBuilder.RenameColumn(
                name: "SecondSurname",
                table: "Athletes",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ComposedTeamsEventId",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NormalTeamId",
                table: "TeamMembers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamCompositionId",
                table: "TeamMembers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AthleteId",
                table: "Representatives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Majors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Athletes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberScore = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.ScoreId);
                });

            migrationBuilder.CreateTable(
                name: "TeamCompositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComposedTeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCompositions_Teams_ComposedTeamId",
                        column: x => x.ComposedTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Userds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Rules = table.Column<string>(type: "TEXT", nullable: true),
                    Pictogram = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: false),
                    Round = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    GoogleMapsURL = table.Column<string>(type: "TEXT", nullable: true),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BanUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoAccessDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanUsers_Userds_Id",
                        column: x => x.Id,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BanUsers_Userds_UserId",
                        column: x => x.UserId,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "journalits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journalits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_journalits_Userds_Id",
                        column: x => x.Id,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_journalits_Userds_UserId",
                        column: x => x.UserId,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moderators_Userds_Id",
                        column: x => x.Id,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moderators_Userds_UserId",
                        column: x => x.UserId,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperUser_Userds_Id",
                        column: x => x.Id,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperUser_Userds_UserId",
                        column: x => x.UserId,
                        principalTable: "Userds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    AthleteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    Statistics = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Round = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLines_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLines_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLines_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplineId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modalities_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modalities_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamEventId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamEventId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_TeamEventId",
                        column: x => x.TeamEventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_TeamEventId1",
                        column: x => x.TeamEventId1,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventParticipants_TeamMembers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEvents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostTitle = table.Column<string>(type: "TEXT", nullable: false),
                    PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RelatedEventId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPost_Events_RelatedEventId",
                        column: x => x.RelatedEventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsPost_journalits_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "journalits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamCompositionScores",
                columns: table => new
                {
                    CompositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompositionId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    ComposedTeamsEventId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCompositionScores", x => x.CompositionId);
                    table.ForeignKey(
                        name: "FK_TeamCompositionScores_Events_ComposedTeamsEventId",
                        column: x => x.ComposedTeamsEventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamCompositionScores_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "ScoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCompositionScores_TeamCompositions_CompositionId1",
                        column: x => x.CompositionId1,
                        principalTable: "TeamCompositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamScores",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamEventId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamScores", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TeamScores_Events_TeamEventId",
                        column: x => x.TeamEventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamScores_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "ScoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamScores_Teams_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Round = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentEvents_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModalityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Modalities_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamParticipantScores",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamParticipantScores", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TeamParticipantScores_EventParticipants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "EventParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamParticipantScores_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "ScoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fragment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fragment = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    NewsPostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fragment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fragment_NewsPost_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "NewsPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Contents = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    NewsPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReviewById = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComment_Moderators_ReviewById",
                        column: x => x.ReviewById,
                        principalTable: "Moderators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComment_NewsPost_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "NewsPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ComposedTeamsEventId",
                table: "Teams",
                column: "ComposedTeamsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_AthleteId",
                table: "TeamMembers",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_NormalTeamId",
                table: "TeamMembers",
                column: "NormalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamCompositionId",
                table: "TeamMembers",
                column: "TeamCompositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_Name",
                table: "Majors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name",
                table: "Faculties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_Name",
                table: "Athletes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanUsers_UserId",
                table: "BanUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_ModalityId",
                table: "Competitions",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Name",
                table: "Disciplines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_SportId",
                table: "Disciplines",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_ParticipantId",
                table: "EventParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_TeamEventId",
                table: "EventParticipants",
                column: "TeamEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_TeamEventId1",
                table: "EventParticipants",
                column: "TeamEventId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_TeamId",
                table: "EventParticipants",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fragment_NewsPostId",
                table: "Fragment",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_EventId",
                table: "GroupEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_GroupId",
                table: "GroupEvents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLines_AthleteId",
                table: "GroupLines",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLines_GroupId",
                table: "GroupLines",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLines_TeamId",
                table: "GroupLines",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LeagueId",
                table: "Groups",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_journalits_UserId",
                table: "journalits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LeagueId",
                table: "Locations",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TournamentId",
                table: "Locations",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Modalities_CategoryId",
                table: "Modalities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Modalities_DisciplineId",
                table: "Modalities",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Modalities_SportId",
                table: "Modalities",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_UserId",
                table: "Moderators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPost_CreatorId",
                table: "NewsPost",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPost_RelatedEventId",
                table: "NewsPost",
                column: "RelatedEventId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_NewsPostId",
                table: "PostComment",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_ReviewById",
                table: "PostComment",
                column: "ReviewById");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_CategoryId",
                table: "Sports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Name",
                table: "Sports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperUser_UserId",
                table: "SuperUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompositions_ComposedTeamId",
                table: "TeamCompositions",
                column: "ComposedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompositionScores_ComposedTeamsEventId",
                table: "TeamCompositionScores",
                column: "ComposedTeamsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompositionScores_CompositionId1",
                table: "TeamCompositionScores",
                column: "CompositionId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompositionScores_ScoreId",
                table: "TeamCompositionScores",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamParticipantScores_ParticipantId",
                table: "TeamParticipantScores",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamParticipantScores_ScoreId",
                table: "TeamParticipantScores",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamScores_ScoreId",
                table: "TeamScores",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamScores_TeamEventId",
                table: "TeamScores",
                column: "TeamEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamScores_TeamId1",
                table: "TeamScores",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentEvents_EventId",
                table: "TournamentEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentEvents_TournamentId",
                table: "TournamentEvents",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Representatives_Athletes_AthleteId",
                table: "Representatives",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Athletes_AthleteId",
                table: "TeamMembers",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_TeamCompositions_TeamCompositionId",
                table: "TeamMembers",
                column: "TeamCompositionId",
                principalTable: "TeamCompositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_NormalTeamId",
                table: "TeamMembers",
                column: "NormalTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_ComposedTeamsEventId",
                table: "Teams",
                column: "ComposedTeamsEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Representatives_Athletes_AthleteId",
                table: "Representatives");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Athletes_AthleteId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_TeamCompositions_TeamCompositionId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_NormalTeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_ComposedTeamsEventId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "BanUsers");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Fragment");

            migrationBuilder.DropTable(
                name: "GroupEvents");

            migrationBuilder.DropTable(
                name: "GroupLines");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "SuperUser");

            migrationBuilder.DropTable(
                name: "TeamCompositionScores");

            migrationBuilder.DropTable(
                name: "TeamParticipantScores");

            migrationBuilder.DropTable(
                name: "TeamScores");

            migrationBuilder.DropTable(
                name: "TournamentEvents");

            migrationBuilder.DropTable(
                name: "Modalities");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropTable(
                name: "NewsPost");

            migrationBuilder.DropTable(
                name: "TeamCompositions");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "journalits");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Userds");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ComposedTeamsEventId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_AthleteId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_NormalTeamId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TeamCompositionId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_Majors_Name",
                table: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_Name",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Athletes_Name",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "ComposedTeamsEventId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "NormalTeamId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "TeamCompositionId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Athletes",
                newName: "SecondSurname");

            migrationBuilder.AddColumn<string>(
                name: "AthleteId1",
                table: "TeamMembers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AthleteId",
                table: "Representatives",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Majors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Athletes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Athletes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstSurname",
                table: "Athletes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Athletes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_AthleteId1",
                table: "TeamMembers",
                column: "AthleteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Representatives_Athletes_AthleteId",
                table: "Representatives",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Athletes_AthleteId1",
                table: "TeamMembers",
                column: "AthleteId1",
                principalTable: "Athletes",
                principalColumn: "Id");
        }
    }
}
