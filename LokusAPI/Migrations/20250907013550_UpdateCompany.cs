using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LokusAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Clients_CostumerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companys_CompanyId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stablishment_StablishmentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Users_UserId",
                table: "Companys");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySubscription_Companys_CompaniesId",
                table: "CompanySubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Companys_CompanyId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Stablishment_StablishmentId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companys_CompanyId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Stablishment_Address_AddressId",
                table: "Stablishment");

            migrationBuilder.DropForeignKey(
                name: "FK_Stablishment_Companys_CompanyId",
                table: "Stablishment");

            migrationBuilder.DropForeignKey(
                name: "FK_StablishmentGalleries_Stablishment_StablishmentId",
                table: "StablishmentGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stablishment",
                table: "Stablishment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Stablishment",
                newName: "Stablishments");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Stablishment_CompanyId",
                table: "Stablishments",
                newName: "IX_Stablishments_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Stablishment_AddressId",
                table: "Stablishments",
                newName: "IX_Stablishments_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Companys_UserId",
                table: "Companies",
                newName: "IX_Companies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CostumerId",
                table: "Addresses",
                newName: "IX_Addresses_CostumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CompanyId",
                table: "Addresses",
                newName: "IX_Addresses_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stablishments",
                table: "Stablishments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Clients_CostumerId",
                table: "Addresses",
                column: "CostumerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Companies_CompanyId",
                table: "Addresses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stablishments_StablishmentId",
                table: "Categories",
                column: "StablishmentId",
                principalTable: "Stablishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySubscription_Companies_CompaniesId",
                table: "CompanySubscription",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Companies_CompanyId",
                table: "Feedbacks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Stablishments_StablishmentId",
                table: "Feedbacks",
                column: "StablishmentId",
                principalTable: "Stablishments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StablishmentGalleries_Stablishments_StablishmentId",
                table: "StablishmentGalleries",
                column: "StablishmentId",
                principalTable: "Stablishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stablishments_Addresses_AddressId",
                table: "Stablishments",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stablishments_Companies_CompanyId",
                table: "Stablishments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Clients_CostumerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Companies_CompanyId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stablishments_StablishmentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySubscription_Companies_CompaniesId",
                table: "CompanySubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Companies_CompanyId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Stablishments_StablishmentId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_StablishmentGalleries_Stablishments_StablishmentId",
                table: "StablishmentGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Stablishments_Addresses_AddressId",
                table: "Stablishments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stablishments_Companies_CompanyId",
                table: "Stablishments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stablishments",
                table: "Stablishments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Stablishments",
                newName: "Stablishment");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companys");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Stablishments_CompanyId",
                table: "Stablishment",
                newName: "IX_Stablishment_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Stablishments_AddressId",
                table: "Stablishment",
                newName: "IX_Stablishment_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UserId",
                table: "Companys",
                newName: "IX_Companys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CostumerId",
                table: "Address",
                newName: "IX_Address_CostumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CompanyId",
                table: "Address",
                newName: "IX_Address_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stablishment",
                table: "Stablishment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Clients_CostumerId",
                table: "Address",
                column: "CostumerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companys_CompanyId",
                table: "Address",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stablishment_StablishmentId",
                table: "Categories",
                column: "StablishmentId",
                principalTable: "Stablishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Users_UserId",
                table: "Companys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySubscription_Companys_CompaniesId",
                table: "CompanySubscription",
                column: "CompaniesId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Companys_CompanyId",
                table: "Feedbacks",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Stablishment_StablishmentId",
                table: "Feedbacks",
                column: "StablishmentId",
                principalTable: "Stablishment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Companys_CompanyId",
                table: "Images",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stablishment_Address_AddressId",
                table: "Stablishment",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stablishment_Companys_CompanyId",
                table: "Stablishment",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StablishmentGalleries_Stablishment_StablishmentId",
                table: "StablishmentGalleries",
                column: "StablishmentId",
                principalTable: "Stablishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
