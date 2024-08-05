using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sahibinden_project.Migrations
{
    /// <inheritdoc />
    public partial class newtabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Favorites",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyType",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarListing_Brand",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Listings",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EngineSize",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearType",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeatingType",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Km",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "M2",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Listings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Listings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Listings",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorites",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CarListing_Brand",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "EngineSize",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HeatingType",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Km",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "M2",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Listings");
        }
    }
}
