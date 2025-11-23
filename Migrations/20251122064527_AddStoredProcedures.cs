using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_futbolistica_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE sp_GetAllTeams
                AS
                BEGIN
                    SELECT * FROM Teams;
                END
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE sp_GetAllPlayers
                AS
                BEGIN
                    SELECT * FROM Players;
                END
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE sp_GetAllMatches
                AS
                BEGIN
                    SELECT * FROM Matches;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetAllTeams");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetAllPlayers");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetAllMatches");
        }
    }
}
