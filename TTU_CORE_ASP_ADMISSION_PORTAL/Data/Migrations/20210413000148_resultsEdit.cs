using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class resultsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             
 

            migrationBuilder.AlterColumn<string>(
                name: "ExamType",
                table: "ResultUploadModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantModelID",
                table: "ResultUploadModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "ResultUploadModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "ResultUploadModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicantModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_GradeId",
                table: "ResultUploadModel",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_SubjectId",
                table: "ResultUploadModel",
                column: "SubjectId");
             
            

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_ApplicantModel_ApplicantModelID",
                table: "ResultUploadModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_GradeModel_GradeId",
                table: "ResultUploadModel",
                column: "GradeId",
                principalTable: "GradeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_SubjectModel_SubjectId",
                table: "ResultUploadModel",
                column: "SubjectId",
                principalTable: "SubjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_HallModel_HallId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_ApplicantModel_ApplicantModelID",
                table: "ResultUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_GradeModel_GradeId",
                table: "ResultUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_SubjectModel_SubjectId",
                table: "ResultUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModel_GradeId",
                table: "ResultUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModel_SubjectId",
                table: "ResultUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_ApplicationUserId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_HallId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "ResultUploadModel");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "ResultUploadModel");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "ApplicantModel");

            migrationBuilder.AlterColumn<int>(
                name: "ExamType",
                table: "ResultUploadModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantModelID",
                table: "ResultUploadModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "ResultUploadModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subject",
                table: "ResultUploadModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_ApplicantModel_ApplicantModelID",
                table: "ResultUploadModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
