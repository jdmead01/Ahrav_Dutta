using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedding_planner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Users_UserId",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Weddings_WeddingId",
                table: "Invite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invite",
                table: "Invite");

            migrationBuilder.RenameTable(
                name: "Invite",
                newName: "Invites");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_WeddingId",
                table: "Invites",
                newName: "IX_Invites_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_UserId",
                table: "Invites",
                newName: "IX_Invites_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invites",
                table: "Invites",
                column: "InviteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Weddings_WeddingId",
                table: "Invites",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Weddings_WeddingId",
                table: "Invites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invites",
                table: "Invites");

            migrationBuilder.RenameTable(
                name: "Invites",
                newName: "Invite");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_WeddingId",
                table: "Invite",
                newName: "IX_Invite_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_UserId",
                table: "Invite",
                newName: "IX_Invite_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invite",
                table: "Invite",
                column: "InviteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Users_UserId",
                table: "Invite",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Weddings_WeddingId",
                table: "Invite",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
