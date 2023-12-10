using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_BookEntries_BookEntryId",
                        column: x => x.BookEntryId,
                        principalTable: "BookEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookEntries",
                columns: new[] { "Id", "AddressName", "CellPhone", "CompanyName", "DateOfBirth", "Email", "FirstName", "Gender", "HomePhone", "LastName", "MiddleName", "WorkPhone" },
                values: new object[,]
                {
                    { 26, "Markets Meadow", "838-307-2303", "O'Keefe, Dibbert and Hartmann", new DateTime(1957, 8, 3, 16, 43, 25, 655, DateTimeKind.Local).AddTicks(129), "Prince_Ebert29@yahoo.com", "Prince", "Female", "591-947-8944", "Ebert", "Brody", null },
                    { 27, "Dynamic Personal Loan Account", null, "Trantow, Kautzer and Hagenes", new DateTime(1955, 2, 12, 8, 2, 7, 801, DateTimeKind.Local).AddTicks(7449), "Brenden.Kuhn72@gmail.com", "Brenden", "Male", null, "Kuhn", "Otto", null },
                    { 28, "Borders withdrawal", null, "Schroeder - Mayer", new DateTime(1983, 2, 2, 9, 43, 23, 191, DateTimeKind.Local).AddTicks(7300), "Newton_Schneider@yahoo.com", "Newton", "Female", "701-554-6047", "Schneider", "Trent", null },
                    { 29, "extend parse", "252-293-0720", "Schamberger, Schamberger and Huel", new DateTime(1983, 7, 20, 1, 39, 15, 648, DateTimeKind.Local).AddTicks(9974), "Dexter74@hotmail.com", "Dexter", "Male", null, "Thompson", "Peyton", null },
                    { 30, "optical rich", null, "Fay, Wilkinson and Carroll", new DateTime(1991, 2, 4, 19, 33, 19, 912, DateTimeKind.Local).AddTicks(3397), "Pearlie_Maggio@yahoo.com", "Pearlie", "Male", "654-214-3383", "Maggio", "Jessica", "623-425-0471" },
                    { 31, "Practical Granite Gloves aggregate", "739-788-1723", "Schuppe Inc", new DateTime(1995, 9, 24, 13, 10, 1, 121, DateTimeKind.Local).AddTicks(6634), "Verdie.Denesik4@hotmail.com", "Verdie", "Female", "481-801-3228", "Denesik", "Kylee", null },
                    { 32, "Cambridgeshire wireless", "691-946-0334", "Kohler and Sons", new DateTime(2002, 7, 16, 12, 40, 28, 3, DateTimeKind.Local).AddTicks(3434), "Alvah94@hotmail.com", "Alvah", "Male", null, "Gerlach", "Nola", null },
                    { 33, "Gorgeous Fantastic Wooden Pants", "385-660-2121", "Rempel and Sons", new DateTime(1992, 2, 11, 10, 26, 17, 186, DateTimeKind.Local).AddTicks(3175), "Sadie_Weber@hotmail.com", "Sadie", "Male", null, "Weber", "Guido", "772-975-8087" },
                    { 34, "redundant Steel", null, "Runolfsson LLC", new DateTime(1961, 7, 16, 13, 50, 38, 359, DateTimeKind.Local).AddTicks(8389), "Jacky_Larson32@hotmail.com", "Jacky", "Female", "941-955-6230", "Larson", "Graciela", null },
                    { 35, "Cotton Gorgeous", null, "Rice LLC", new DateTime(1961, 9, 19, 19, 48, 14, 164, DateTimeKind.Local).AddTicks(7188), "Marilyne.Bogan@yahoo.com", "Marilyne", "Male", null, "Bogan", "Sandrine", null },
                    { 36, "Practical sensor", null, "Marquardt - Stoltenberg", new DateTime(1991, 7, 16, 19, 26, 55, 283, DateTimeKind.Local).AddTicks(658), "Marge56@yahoo.com", "Marge", "Male", null, "Ondricka", "Elouise", "841-455-9375" },
                    { 37, "Director Intranet", "679-979-9762", "Krajcik, Stamm and Bernier", new DateTime(1982, 5, 29, 8, 13, 24, 217, DateTimeKind.Local).AddTicks(2790), "Alberto78@gmail.com", "Alberto", "Female", "319-210-0501", "Leffler", "Chyna", null },
                    { 38, "deposit Centers", null, "Padberg and Sons", new DateTime(1970, 7, 27, 9, 19, 34, 396, DateTimeKind.Local).AddTicks(4994), "Hosea22@gmail.com", "Hosea", "Female", "931-234-6151", "Orn", "Jayce", null },
                    { 39, "Manor Unbranded Metal Pizza", null, "Von Group", new DateTime(1989, 6, 13, 2, 29, 14, 731, DateTimeKind.Local).AddTicks(2576), "Claude.Berge64@gmail.com", "Claude", "Female", null, "Berge", "Dylan", null },
                    { 40, "grey Yuan Renminbi", "680-766-9237", "Herzog - Rau", new DateTime(2001, 7, 31, 9, 51, 25, 970, DateTimeKind.Local).AddTicks(6646), "Marcelino21@hotmail.com", "Marcelino", "Male", "348-635-6769", "Johns", "Nia", null },
                    { 41, "bypassing convergence", "674-294-3222", "Leffler Group", new DateTime(1991, 1, 11, 8, 17, 35, 164, DateTimeKind.Local).AddTicks(3599), "Axel87@gmail.com", "Axel", "Male", null, "O'Keefe", "Obie", null },
                    { 42, "multi-byte Handcrafted Granite Computer", "306-916-1366", "Boyle - Kessler", new DateTime(1956, 9, 13, 8, 33, 3, 816, DateTimeKind.Local).AddTicks(8295), "Cheyenne.Skiles@yahoo.com", "Cheyenne", "Female", null, "Skiles", "Friedrich", "861-641-3098" },
                    { 43, "Money Market Account Security", null, "Kling - Braun", new DateTime(1996, 8, 20, 10, 44, 5, 187, DateTimeKind.Local).AddTicks(3198), "Santos97@hotmail.com", "Santos", "Female", null, "Shanahan", "Camylle", null },
                    { 44, "1080p Central", "427-423-7509", "O'Keefe - Rosenbaum", new DateTime(1991, 3, 14, 6, 6, 12, 934, DateTimeKind.Local).AddTicks(2813), "Brook21@hotmail.com", "Brook", "Female", null, "Jacobs", "Cassandre", "394-538-1039" },
                    { 45, "Auto Loan Account Kroon", "441-795-1740", "Nader - Kohler", new DateTime(1975, 3, 7, 21, 6, 40, 410, DateTimeKind.Local).AddTicks(2512), "Jailyn_Johnston7@yahoo.com", "Jailyn", "Female", "218-575-3315", "Johnston", "Zita", "893-831-4066" },
                    { 46, "Forward Hollow", "462-638-5414", "Roberts, Schroeder and Boyer", new DateTime(1983, 12, 4, 1, 0, 10, 288, DateTimeKind.Local).AddTicks(8964), "Otis_McLaughlin@gmail.com", "Otis", "Male", "925-511-9247", "McLaughlin", "Alessandra", null },
                    { 47, "Granite withdrawal", "508-788-1762", "Harris - Grant", new DateTime(1954, 1, 18, 16, 36, 35, 596, DateTimeKind.Local).AddTicks(6093), "Jazmyn.Kutch@yahoo.com", "Jazmyn", "Male", "231-572-5768", "Kutch", "Ursula", null },
                    { 48, "Practical HDD", "292-352-1643", "Zemlak - Zemlak", new DateTime(1969, 9, 1, 23, 5, 50, 857, DateTimeKind.Local).AddTicks(268), "Winfield.Hartmann@hotmail.com", "Winfield", "Female", "263-861-2284", "Hartmann", "Pasquale", null },
                    { 49, "Frozen Home Loan Account", null, "Reichel LLC", new DateTime(1964, 10, 7, 6, 26, 59, 451, DateTimeKind.Local).AddTicks(5972), "Owen12@yahoo.com", "Owen", "Female", "388-926-0644", "Kozey", "Tabitha", null },
                    { 50, "Re-engineered SAS", "295-344-3220", "Schmeler, Jast and Crona", new DateTime(1973, 5, 25, 7, 56, 43, 240, DateTimeKind.Local).AddTicks(6158), "Albin1@yahoo.com", "Albin", "Male", "794-884-4374", "Purdy", "Uriel", "668-878-1340" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "BookEntryId", "CityTown", "Country", "Line1", "Line2", "Line3", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 51, 26, "Donnellyhaven", "Timor-Leste", "91620 Agustin Neck", "Apt. 847", "Apt. 840", "75107", "Massachusetts" },
                    { 52, 26, "Travisfort", "Bangladesh", "49921 Leopold Estate", "Suite 715", "Apt. 237", "26584-0541", "Minnesota" },
                    { 53, 27, "West Rowland", "Belgium", "94899 Norma Square", "Apt. 796", "Apt. 724", "84181-4394", "Oregon" },
                    { 54, 27, "West Geovanny", "Saint Lucia", "10844 Willms Meadow", null, "Apt. 208", "52085-1746", "Texas" },
                    { 55, 28, "Nilsmouth", "Afghanistan", "15333 Taylor Ferry", "Apt. 506", "Apt. 316", "80092-7223", "Wyoming" },
                    { 56, 28, "Dachbury", "Belize", "790 Luigi Port", null, "Suite 386", "93144", "Michigan" },
                    { 57, 29, "New Geoton", "Ecuador", "722 Lizeth Prairie", "Apt. 906", "Apt. 105", "26651", "Massachusetts" },
                    { 58, 29, "Larkinborough", "Latvia", "07671 Wisoky Summit", "Apt. 618", "Suite 612", "54740-1602", "South Dakota" },
                    { 59, 30, "Wymanchester", "Iraq", "29994 Keebler Common", "Suite 957", "Suite 432", "59260", "Illinois" },
                    { 60, 30, "New Garettfort", "Belarus", "971 Torrance Loaf", null, "Suite 699", "73405-3628", "South Dakota" },
                    { 61, 31, "Genevievetown", "Netherlands", "071 Rowena Forges", null, "Apt. 769", "81046", "South Carolina" },
                    { 62, 31, "Heidenreichland", "France", "86714 Jonas Flats", null, "Apt. 291", "03737-1515", "North Carolina" },
                    { 63, 32, "Lake Vidal", "Panama", "098 Clemmie Lane", "Apt. 448", "Suite 791", "01594-4257", "Colorado" },
                    { 64, 32, "Harriston", "Sao Tome and Principe", "73950 Brandon Run", "Apt. 027", "Suite 702", "09144", "Illinois" },
                    { 65, 33, "O'Reillyburgh", "Barbados", "584 Martina Ramp", null, "Suite 998", "95080-7824", "Iowa" },
                    { 66, 33, "Langworthfurt", "New Zealand", "29967 Antonia Bypass", "Suite 980", "Apt. 011", "16676", "South Carolina" },
                    { 67, 34, "Norbertton", "Nicaragua", "6976 Monroe Isle", "Suite 765", "Suite 792", "75589", "South Carolina" },
                    { 68, 34, "Jaquanmouth", "Montenegro", "54324 Christiansen Freeway", null, "Suite 182", "65098-0080", "West Virginia" },
                    { 69, 35, "Vladimirfort", "Israel", "269 Maribel Lane", null, "Apt. 947", "26944-4305", "Maryland" },
                    { 70, 35, "North Orlo", "Cayman Islands", "8105 Ocie Divide", "Apt. 340", "Suite 043", "10482-4159", "Delaware" },
                    { 71, 36, "Clovisborough", "South Georgia and the South Sandwich Islands", "839 Nader Oval", "Apt. 168", "Apt. 630", "46133", "Maryland" },
                    { 72, 36, "Kozeyville", "Dominican Republic", "69278 Leuschke Track", null, "Apt. 340", "84439-4490", "Washington" },
                    { 73, 37, "North Kentonside", "El Salvador", "612 Myriam Roads", "Apt. 022", "Apt. 336", "02598-3190", "Vermont" },
                    { 74, 37, "Ardellashire", "Gibraltar", "56299 Mason Hills", "Apt. 651", "Suite 717", "41247-8216", "Minnesota" },
                    { 75, 38, "Franeckistad", "Romania", "33993 Triston Ridges", null, "Suite 929", "34820-2497", "Alabama" },
                    { 76, 38, "West Tylerfurt", "Belize", "319 Amy Rue", null, "Apt. 189", "39478", "Wyoming" },
                    { 77, 39, "East Deltaborough", "South Georgia and the South Sandwich Islands", "971 Glover River", "Apt. 272", "Suite 961", "77717", "Utah" },
                    { 78, 39, "Melynaside", "Ireland", "1095 Aimee Flat", "Apt. 189", "Suite 611", "86824-9154", "New Mexico" },
                    { 79, 40, "North Westleymouth", "Virgin Islands, U.S.", "8629 Jeffrey Parkways", null, null, "52846", "Maine" },
                    { 80, 40, "New Joanne", "Mauritania", "5662 Jordi Flat", "Suite 496", "Apt. 284", "36730", "Iowa" },
                    { 81, 41, "Gutkowskiview", "Cayman Islands", "095 Verla Haven", "Suite 509", "Apt. 601", "43101", "Maine" },
                    { 82, 41, "New Elliotport", "Guadeloupe", "276 Laron Ridge", null, "Suite 827", "70369-6197", "Georgia" },
                    { 83, 42, "Lebsackhaven", "Mauritania", "994 Heidenreich Corner", null, "Apt. 216", "78680-6123", "Colorado" },
                    { 84, 42, "Anselberg", "Bhutan", "627 Juliana Island", "Suite 100", "Suite 947", "29440-8728", "Missouri" },
                    { 85, 43, "West Jared", "Gambia", "28670 Chauncey Ports", "Suite 571", "Suite 691", "68118-0819", "Georgia" },
                    { 86, 43, "Boylechester", "Turkmenistan", "9444 Arjun Rue", "Suite 613", "Apt. 281", "03649", "Indiana" },
                    { 87, 44, "Domingofurt", "Guatemala", "4483 Shields Ville", null, "Apt. 453", "20190", "Rhode Island" },
                    { 88, 44, "New Rethaborough", "Uruguay", "245 Marquardt Radial", "Suite 679", "Suite 927", "64656", "Michigan" },
                    { 89, 45, "Gleasonburgh", "Costa Rica", "9347 Ankunding Grove", null, "Suite 389", "59529", "Tennessee" },
                    { 90, 45, "West Kraig", "Lao People's Democratic Republic", "317 Trantow Landing", null, "Apt. 678", "66963", "North Carolina" },
                    { 91, 46, "Romagueraton", "French Polynesia", "3115 Jennings Mills", null, "Apt. 091", "56952-2467", "Minnesota" },
                    { 92, 46, "Monserrateburgh", "Holy See (Vatican City State)", "8562 Simonis Rapid", null, "Apt. 578", "88358", "Wyoming" },
                    { 93, 47, "Lake Jamie", "Qatar", "621 Petra Isle", "Apt. 831", "Apt. 141", "25857-9849", "New Mexico" },
                    { 94, 47, "East Terrencehaven", "Netherlands Antilles", "7536 Reinger Rapids", null, "Suite 047", "25041", "Idaho" },
                    { 95, 48, "North Stacy", "Senegal", "1740 Trevion Road", "Suite 482", "Apt. 939", "97654-2484", "North Dakota" },
                    { 96, 48, "Mariellemouth", "Honduras", "872 Katarina View", "Suite 470", "Suite 022", "89951-9835", "Nevada" },
                    { 97, 49, "North Olaf", "Marshall Islands", "997 Peyton Springs", "Suite 327", "Apt. 052", "93502", "Idaho" },
                    { 98, 49, "Kuvalisfurt", "Nigeria", "266 Catalina Rest", "Apt. 417", "Suite 140", "04618-4429", "Rhode Island" },
                    { 99, 50, "Lake Sydneeport", "Nigeria", "1838 Fadel Plaza", "Suite 513", "Apt. 942", "60082-9211", "Tennessee" },
                    { 100, 50, "Hartmannshire", "Serbia", "9180 Horacio Unions", "Apt. 817", "Suite 927", "91745", "Utah" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BookEntryId",
                table: "Address",
                column: "BookEntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BookEntries");
        }
    }
}
