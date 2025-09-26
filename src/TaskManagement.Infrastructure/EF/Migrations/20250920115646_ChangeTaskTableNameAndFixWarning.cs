using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTaskTableNameAndFixWarning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItems_tasks_TaskId",
                schema: "task",
                table: "CheckListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Users_UserId",
                schema: "dbo",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                schema: "dbo",
                table: "tasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                schema: "dbo",
                newName: "Tasks",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_UserId",
                schema: "dbo",
                table: "Tasks",
                newName: "IX_Tasks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                schema: "dbo",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItems_Tasks_TaskId",
                schema: "task",
                table: "CheckListItems",
                column: "TaskId",
                principalSchema: "dbo",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                schema: "dbo",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItems_Tasks_TaskId",
                schema: "task",
                table: "CheckListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                schema: "dbo",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                schema: "dbo",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                schema: "dbo",
                newName: "tasks",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserId",
                schema: "dbo",
                table: "tasks",
                newName: "IX_tasks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                schema: "dbo",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItems_tasks_TaskId",
                schema: "task",
                table: "CheckListItems",
                column: "TaskId",
                principalSchema: "dbo",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Users_UserId",
                schema: "dbo",
                table: "tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
