using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetContacts
                                AS
                                SELECT * FROM Contacts
                                GO");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
