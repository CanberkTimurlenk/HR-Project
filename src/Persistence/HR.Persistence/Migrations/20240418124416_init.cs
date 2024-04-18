using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HR.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MersisNumber = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    TaxNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LogoFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    EstablishmentYear = table.Column<int>(type: "int", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    PhotoFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResetPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    TurkishIdentificationNumber = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    DateOfEmployment = table.Column<DateTime>(type: "Date", nullable: true),
                    DateOfDismissal = table.Column<DateTime>(type: "Date", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressTypes = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    ServiceUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_ApplicationUser_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatorEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReviewerManagerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advances_AdvanceTypes_AdvanceTypeId",
                        column: x => x.AdvanceTypeId,
                        principalTable: "AdvanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advances_ApplicationUser_CreatorEmployeeId",
                        column: x => x.CreatorEmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advances_ApplicationUser_ReviewerManagerId",
                        column: x => x.ReviewerManagerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReviewerManagerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ApplicationUser_CreatorEmployeeId",
                        column: x => x.CreatorEmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ApplicationUser_ReviewerManagerId",
                        column: x => x.ReviewerManagerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReviewerManagerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_ApplicationUser_CreatorEmployeeId",
                        column: x => x.CreatorEmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leaves_ApplicationUser_ReviewerManagerId",
                        column: x => x.ReviewerManagerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaves_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AdvanceTypes",
                columns: new[] { "Id", "Description", "IsActive", "TypeName" },
                values: new object[,]
                {
                    { 1, "Salary", true, "Salary" },
                    { 2, "Business", true, "Business" },
                    { 3, "Other", true, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "Firstname", "IsActive", "LastLogin", "Lastname", "Middlename", "ModifiedDate", "Password", "PhotoFile", "ResetPassword", "UserType" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yonetici@bilgeadam.com", "Site", true, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(1289), new TimeSpan(0, 3, 0, 0, 0)), "Yoneticisi", "-", null, "ba394499b56b89fe5bda1338fcca6a04", "https://images.unsplash.com/photo-1530785602389-07594beb8b73?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", null, "Admin" });

            migrationBuilder.InsertData(
                table: "CompanyTypes",
                columns: new[] { "Id", "Description", "IsActive", "TypeName" },
                values: new object[,]
                {
                    { 1, "", true, "Limited Company" },
                    { 2, "", true, "Public Company" },
                    { 3, "", true, "Private Company" },
                    { 4, "", true, "Holding Company" },
                    { 5, "", true, "Joint Venture" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "Description", "IsActive", "TypeName" },
                values: new object[,]
                {
                    { 1, "annual", true, "Annual Leave" },
                    { 2, "", true, "Maternity Leave" },
                    { 3, "", true, "Paternity Leave" },
                    { 4, "", true, "Marriage Leave" },
                    { 5, "", true, "Bereavement Leave" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressId", "CompanyTypeId", "ContractEndDate", "ContractStartDate", "Email", "EmployeeCount", "EstablishmentYear", "LogoFile", "MersisNumber", "Name", "PhoneNumber", "TaxNumber", "TaxOffice" },
                values: new object[] { 1, 3, 1, new DateTime(2024, 10, 18, 15, 44, 16, 233, DateTimeKind.Local).AddTicks(7794), new DateTime(2024, 3, 19, 15, 44, 16, 233, DateTimeKind.Local).AddTicks(7767), "sample@example.com", 100, 2000, "company_logo.png", "1234567890", "Sample Company", "123-456-7890", "0987654321", "Sample Tax Office" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressTypes", "City", "CompanyId", "Country", "PostalCode", "State", "Street" },
                values: new object[] { 3, 2, "Third City", 1, "Third Country", "67890", "Third State", "789 Pine Lane" });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DateOfBirth", "DeletedDate", "Department", "Email", "Firstname", "IsActive", "LastLogin", "Lastname", "Middlename", "ModifiedDate", "Password", "PhoneNumber", "PhotoFile", "ResetPassword", "TurkishIdentificationNumber", "UserType" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IT", "manager@mail.com", "John", true, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(6662), new TimeSpan(0, 3, 0, 0, 0)), "Doe", "-", null, "ba394499b56b89fe5bda1338fcca6a04", "1234567890", "", null, "12345678901", "Manager" });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DateOfBirth", "DateOfDismissal", "DateOfEmployment", "DeletedDate", "Department", "Email", "Firstname", "IsActive", "LastLogin", "Lastname", "Middlename", "ModifiedDate", "Password", "PhoneNumber", "PhotoFile", "ResetPassword", "Salary", "TurkishIdentificationNumber", "UserType" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(4333), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IT", "employee@mail.com", "Jane", true, new DateTimeOffset(new DateTime(2024, 4, 18, 15, 44, 16, 236, DateTimeKind.Unspecified).AddTicks(4323), new TimeSpan(0, 3, 0, 0, 0)), "Doe", "-", null, "ba394499b56b89fe5bda1338fcca6a04", "1234567890", "https://images.unsplash.com/photo-1530785602389-07594beb8b73?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", null, 10000m, "12345678902", "Employee" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressTypes", "City", "Country", "PostalCode", "ServiceUserId", "State", "Street" },
                values: new object[,]
                {
                    { 1, 1, "Sample City", "Sample Country", "12345", 1, "Sample State", "123 Main Street" },
                    { 2, 1, "Another City", "Another Country", "54321", 2, "Another State", "456 Oak Avenue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ServiceUserId",
                table: "Addresses",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_AdvanceTypeId",
                table: "Advances",
                column: "AdvanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_CreatorEmployeeId",
                table: "Advances",
                column: "CreatorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_ReviewerManagerId",
                table: "Advances",
                column: "ReviewerManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CompanyId",
                table: "ApplicationUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatorEmployeeId",
                table: "Expenses",
                column: "CreatorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ReviewerManagerId",
                table: "Expenses",
                column: "ReviewerManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_CreatorEmployeeId",
                table: "Leaves",
                column: "CreatorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_LeaveTypeId",
                table: "Leaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ReviewerManagerId",
                table: "Leaves",
                column: "ReviewerManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Advances");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "AdvanceTypes");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyTypes");
        }
    }
}
