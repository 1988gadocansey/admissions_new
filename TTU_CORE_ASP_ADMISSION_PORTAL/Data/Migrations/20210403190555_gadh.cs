using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class gadh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

             

            migrationBuilder.AlterColumn<bool>(
               name: "ReportedInSchool",
               table: "ApplicantModel",
               type: "boolean",
               nullable: true,
               oldClrType: typeof(bool),
               oldType: "boolean");


            
            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_HallId",
                table: "ApplicantModel",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_HallModel_HallId",
                table: "ApplicantModel",
                column: "HallId",
                principalTable: "HallModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_HallModel_HallId",
                table: "ApplicantModel");

           

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_HallId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "ApplicantModel");
 

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ApplicationUserId1",
                table: "ApplicantModel",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId1",
                table: "ApplicantModel",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
