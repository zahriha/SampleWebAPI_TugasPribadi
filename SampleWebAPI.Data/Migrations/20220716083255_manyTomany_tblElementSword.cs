using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class manyTomany_tblElementSword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Elements_ElementsId",
                table: "ElementSword");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Swords_SwordsId",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "SwordsId",
                table: "ElementSword",
                newName: "SwordId");

            migrationBuilder.RenameColumn(
                name: "ElementsId",
                table: "ElementSword",
                newName: "ElementId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_SwordsId",
                table: "ElementSword",
                newName: "IX_ElementSword_SwordId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateMade",
                table: "ElementSword",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Elements_ElementId",
                table: "ElementSword",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Swords_SwordId",
                table: "ElementSword",
                column: "SwordId",
                principalTable: "Swords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Elements_ElementId",
                table: "ElementSword");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Swords_SwordId",
                table: "ElementSword");

            migrationBuilder.DropColumn(
                name: "DateMade",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "SwordId",
                table: "ElementSword",
                newName: "SwordsId");

            migrationBuilder.RenameColumn(
                name: "ElementId",
                table: "ElementSword",
                newName: "ElementsId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_SwordId",
                table: "ElementSword",
                newName: "IX_ElementSword_SwordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Elements_ElementsId",
                table: "ElementSword",
                column: "ElementsId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Swords_SwordsId",
                table: "ElementSword",
                column: "SwordsId",
                principalTable: "Swords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
