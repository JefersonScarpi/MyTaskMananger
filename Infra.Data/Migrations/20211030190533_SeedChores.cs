using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class SeedChores : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Chores(Title, Description, Complete, ListIndexId)" +
                "VALUES('Read Books', 'To Improve the reading skill', 'false', '1')");
            mb.Sql("INSERT INTO Chores(Title, Description, Complete, ListIndexId)" +
               "VALUES('Read Books', 'To Improve the reading skill', 'false', '2')");
            mb.Sql("INSERT INTO Chores(Title, Description, Complete, ListIndexId)" +
               "VALUES('Read Books', 'To Improve the reading skill', 'false', '3')");
            

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Chores");
        }
    }
}
