using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEvaluacionEmanuel.Data.Migrations
{
    public partial class StoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.CreateClientProcedure
                @nocliente nvarchar(max),
                @nombre nvarchar(max),
                @apellidopaterno nvarchar(max),
                @apellidomaterno nvarchar(max),
                @domicilio nvarchar(max),
                @createdat datetime2(7),
                @estatus bit

                AS
                BEGIN 

                SET NOCOUNT ON;
                
                INSERT INTO Clientes(Id, NoCliente, Nombre, ApellidoPaterno, ApellidoMaterno, Domicilio, CreatedAt, Estatus)
                VALUES (NEWID(), @nocliente, @nombre, @apellidopaterno, @apellidomaterno, @domicilio, @createdat, @estatus)

                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GgetClientByIdProcedure
                @id uniqueidentifier

                AS
                BEGIN 
                
                SELECT * FROM Clientes WHERE Id = @id

                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
