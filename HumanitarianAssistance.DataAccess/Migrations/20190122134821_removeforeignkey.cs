﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class removeforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDetail_ProjectDetails_ProjectId",
                table: "VoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_VoucherDetail_ProjectId",
                table: "VoucherDetail");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "VoucherDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "VoucherDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetail_ProjectId",
                table: "VoucherDetail",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDetail_ProjectDetails_ProjectId",
                table: "VoucherDetail",
                column: "ProjectId",
                principalTable: "ProjectDetails",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
