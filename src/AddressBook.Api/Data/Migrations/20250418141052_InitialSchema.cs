using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
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
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_BookEntries_BookEntryId",
                        column: x => x.BookEntryId,
                        principalTable: "BookEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookEntries",
                columns: new[] { "Id", "CellPhone", "CompanyName", "DateOfBirth", "Email", "FirstName", "Gender", "HomePhone", "LastName", "MiddleName", "UserName", "WorkPhone" },
                values: new object[,]
                {
                    { 101, "374-620-9128", "Kiehn Group", new DateTime(1989, 10, 24, 9, 39, 46, 143, DateTimeKind.Local).AddTicks(7485), "Manuel_Brown25@hotmail.com", "Manuel", null, null, "Brown", "Jade", null, "878-271-2113" },
                    { 102, "265-382-1384", "Botsford Inc", new DateTime(1959, 3, 14, 21, 28, 35, 561, DateTimeKind.Local).AddTicks(9212), "Flavie_Hirthe90@gmail.com", "Flavie", null, null, "Hirthe", "Theron", null, "832-270-6840" },
                    { 103, "980-330-8184", "Bernhard, Emmerich and Parker", new DateTime(1996, 7, 20, 6, 16, 42, 927, DateTimeKind.Local).AddTicks(9061), "Gregoria_McGlynn24@hotmail.com", "Gregoria", "Female", "612-875-0380", "McGlynn", "Terrence", null, null },
                    { 104, "580-991-7741", "Zulauf - Okuneva", new DateTime(1958, 4, 29, 15, 31, 5, 863, DateTimeKind.Local).AddTicks(9657), "Catherine.Maggio88@gmail.com", "Catherine", "Female", null, "Maggio", "Sidney", null, null },
                    { 105, "365-752-6683", "Kautzer, Bahringer and Rippin", new DateTime(1985, 1, 6, 14, 30, 38, 632, DateTimeKind.Local).AddTicks(4728), "Lucinda_Konopelski41@gmail.com", "Lucinda", null, "670-888-0907", "Konopelski", "Marlon", null, "871-892-0377" },
                    { 106, null, "Abshire - Labadie", new DateTime(2001, 9, 7, 3, 50, 43, 659, DateTimeKind.Local).AddTicks(7480), "Eduardo.Schmidt80@gmail.com", "Eduardo", null, "258-367-9136", "Schmidt", "Ona", null, "896-860-6731" },
                    { 107, null, "Gerlach, Grant and Batz", new DateTime(1969, 10, 29, 6, 52, 54, 504, DateTimeKind.Local).AddTicks(8727), "Forest.Adams@yahoo.com", "Forest", "Female", null, "Adams", "Americo", null, "529-902-2261" },
                    { 108, "341-971-4754", "Hudson, Mayer and Ondricka", new DateTime(1969, 4, 20, 13, 46, 46, 92, DateTimeKind.Local).AddTicks(6293), "Jerrell3@gmail.com", "Jerrell", "Male", "751-315-5991", "Mraz", "Erin", null, "304-933-0639" },
                    { 109, "880-256-1195", "Doyle - Hand", new DateTime(1956, 5, 12, 2, 50, 17, 330, DateTimeKind.Local).AddTicks(2769), "Samara_Schulist29@gmail.com", "Samara", "Female", null, "Schulist", "Gabriella", null, "619-853-0655" },
                    { 110, null, "Rolfson - Bauch", new DateTime(1991, 7, 20, 15, 1, 5, 599, DateTimeKind.Local).AddTicks(7236), "Verda_Altenwerth@yahoo.com", "Verda", "Male", "246-330-4255", "Altenwerth", "Moises", null, "954-411-2349" },
                    { 111, null, "Turcotte, MacGyver and Schiller", new DateTime(1988, 5, 19, 10, 29, 13, 559, DateTimeKind.Local).AddTicks(1673), "Peyton_Bogan87@yahoo.com", "Peyton", "Female", "971-383-6659", "Bogan", "Elyse", null, "665-661-3306" },
                    { 112, null, "Dach - Hauck", new DateTime(1971, 1, 28, 0, 19, 46, 748, DateTimeKind.Local).AddTicks(374), "Norbert.Gibson30@gmail.com", "Norbert", "Male", null, "Gibson", "Sedrick", null, null },
                    { 113, null, "Hodkiewicz Inc", new DateTime(1968, 2, 18, 9, 34, 20, 982, DateTimeKind.Local).AddTicks(166), "Hiram_Klein70@yahoo.com", "Hiram", null, null, "Klein", "Christina", null, null },
                    { 114, null, "Cronin, Kunde and Mertz", new DateTime(1976, 12, 17, 16, 24, 40, 239, DateTimeKind.Local).AddTicks(8096), "Lance_Mills@gmail.com", "Lance", "Male", "957-309-0035", "Mills", "Eliezer", null, "227-227-7332" },
                    { 115, "526-327-6615", "Roberts - Miller", new DateTime(1978, 9, 6, 7, 42, 14, 580, DateTimeKind.Local).AddTicks(6064), "Marcelino.Emard@hotmail.com", "Marcelino", null, null, "Emard", "Hal", null, null },
                    { 116, "966-203-1511", "Pouros - Paucek", new DateTime(1997, 7, 13, 5, 57, 1, 850, DateTimeKind.Local).AddTicks(8144), "Easton_Fritsch@hotmail.com", "Easton", null, "280-705-7454", "Fritsch", "Lester", null, null },
                    { 117, null, "Carter - Dooley", new DateTime(1994, 11, 10, 3, 52, 3, 946, DateTimeKind.Local).AddTicks(7652), "Alvina26@hotmail.com", "Alvina", null, null, "Goodwin", "Irwin", null, "910-629-8969" },
                    { 118, null, "Goldner, Langosh and Carter", new DateTime(1965, 3, 13, 14, 8, 20, 187, DateTimeKind.Local).AddTicks(1044), "Fredy_Gibson65@gmail.com", "Fredy", null, null, "Gibson", "Esperanza", null, "704-971-2388" },
                    { 119, "371-399-5125", "Thiel LLC", new DateTime(1964, 12, 6, 13, 27, 9, 807, DateTimeKind.Local).AddTicks(4260), "Lelah.Koch@hotmail.com", "Lelah", null, null, "Koch", "Dereck", null, "737-904-4391" },
                    { 120, "687-940-8733", "Koepp Inc", new DateTime(1974, 1, 13, 21, 46, 3, 968, DateTimeKind.Local).AddTicks(3097), "Flavie_Schaden@hotmail.com", "Flavie", null, "428-416-2023", "Schaden", "Samanta", null, "338-632-0078" },
                    { 121, "321-439-3606", "Okuneva and Sons", new DateTime(1984, 4, 24, 0, 57, 50, 821, DateTimeKind.Local).AddTicks(534), "Annabelle_Kulas96@gmail.com", "Annabelle", "Male", null, "Kulas", "Tamara", null, null },
                    { 122, null, "Ledner - Connelly", new DateTime(1973, 5, 21, 13, 24, 37, 490, DateTimeKind.Local).AddTicks(8144), "Queen94@hotmail.com", "Queen", null, null, "Shields", "Claude", null, null },
                    { 123, "433-634-2297", "Hoeger - Miller", new DateTime(1969, 5, 15, 12, 59, 55, 999, DateTimeKind.Local).AddTicks(6767), "Amely_Beer@hotmail.com", "Amely", "Male", "597-331-6926", "Beer", "Kitty", null, null },
                    { 124, null, "Gaylord - Brekke", new DateTime(1957, 12, 19, 21, 47, 56, 830, DateTimeKind.Local).AddTicks(9134), "Niko_Herman55@hotmail.com", "Niko", null, "458-276-0646", "Herman", "Weldon", null, null },
                    { 125, "830-429-5496", "O'Kon, Osinski and Blick", new DateTime(2000, 11, 12, 13, 2, 35, 229, DateTimeKind.Local).AddTicks(2768), "Polly.Emmerich26@hotmail.com", "Polly", "Female", null, "Emmerich", "Greta", null, "560-750-5090" },
                    { 126, null, "Fisher Inc", new DateTime(2004, 7, 6, 16, 25, 58, 472, DateTimeKind.Local).AddTicks(7279), "Felicita_Hickle26@hotmail.com", "Felicita", null, null, "Hickle", "Furman", null, null },
                    { 127, "349-606-6319", "Miller - Strosin", new DateTime(1993, 1, 16, 21, 20, 41, 667, DateTimeKind.Local).AddTicks(7114), "Maximus_Stroman41@hotmail.com", "Maximus", "Male", null, "Stroman", "Greta", null, "325-532-8351" },
                    { 128, null, "Hills LLC", new DateTime(1989, 2, 25, 19, 31, 5, 580, DateTimeKind.Local).AddTicks(3846), "Malachi90@hotmail.com", "Malachi", "Male", "847-270-9013", "Reilly", "Gregory", null, null },
                    { 129, "475-554-9933", "Pfannerstill, Sipes and McKenzie", new DateTime(1985, 2, 9, 10, 27, 36, 526, DateTimeKind.Local).AddTicks(9490), "Jacinto16@hotmail.com", "Jacinto", "Female", null, "Trantow", "Rashad", null, null },
                    { 130, null, "Carter LLC", new DateTime(1966, 9, 26, 11, 23, 37, 423, DateTimeKind.Local).AddTicks(4272), "Kaitlyn40@hotmail.com", "Kaitlyn", null, "968-848-0679", "Toy", "Jadyn", null, "484-354-0449" },
                    { 131, "365-383-1790", "Wisoky - Bechtelar", new DateTime(1960, 12, 2, 6, 36, 16, 253, DateTimeKind.Local).AddTicks(2079), "Wellington16@gmail.com", "Wellington", "Female", "494-925-4932", "Gislason", "Rodger", null, null },
                    { 132, null, "Dickens - Balistreri", new DateTime(1969, 7, 29, 4, 26, 24, 389, DateTimeKind.Local).AddTicks(539), "Nora60@gmail.com", "Nora", "Male", "358-999-3999", "Goldner", "Alden", null, "562-696-5553" },
                    { 133, "923-338-9849", "Kuphal, Roob and Osinski", new DateTime(1955, 9, 27, 21, 5, 36, 181, DateTimeKind.Local).AddTicks(4215), "Noel27@yahoo.com", "Noel", "Male", null, "Nitzsche", "Erich", null, "462-633-0628" },
                    { 134, null, "Glover and Sons", new DateTime(1957, 3, 12, 22, 47, 39, 298, DateTimeKind.Local).AddTicks(2034), "Trisha49@hotmail.com", "Trisha", null, "543-262-8346", "Schaefer", "Jarred", null, null },
                    { 135, "414-707-7624", "Renner LLC", new DateTime(1988, 1, 1, 18, 31, 21, 860, DateTimeKind.Local).AddTicks(3810), "Urban.Marquardt@yahoo.com", "Urban", null, "283-817-2057", "Marquardt", "Grady", null, null },
                    { 136, "918-390-8802", "Ruecker, Smith and Casper", new DateTime(1993, 10, 24, 18, 56, 46, 558, DateTimeKind.Local).AddTicks(2471), "Ericka64@gmail.com", "Ericka", null, null, "McClure", "Angela", null, null },
                    { 137, "627-540-8048", "Dach, Schoen and Schmitt", new DateTime(1983, 11, 12, 11, 42, 51, 234, DateTimeKind.Local).AddTicks(6769), "Niko_Balistreri@hotmail.com", "Niko", "Female", null, "Balistreri", "Clinton", null, "961-583-2174" },
                    { 138, "409-744-8931", "Rath Group", new DateTime(1972, 9, 3, 23, 8, 50, 721, DateTimeKind.Local).AddTicks(9267), "Hosea85@hotmail.com", "Hosea", null, "292-265-8789", "Klocko", "Alessia", null, null },
                    { 139, "213-859-7124", "Stiedemann and Sons", new DateTime(1999, 5, 19, 0, 44, 4, 495, DateTimeKind.Local).AddTicks(410), "Sylvester84@hotmail.com", "Sylvester", null, "553-816-3809", "Kautzer", "Meggie", null, null },
                    { 140, "617-846-9358", "Rath, D'Amore and Streich", new DateTime(1977, 12, 22, 21, 13, 12, 109, DateTimeKind.Local).AddTicks(6727), "Syble_Kilback@gmail.com", "Syble", null, null, "Kilback", "Carmelo", null, null },
                    { 141, "967-743-9867", "Streich, Hayes and Krajcik", new DateTime(2003, 4, 10, 2, 42, 2, 12, DateTimeKind.Local).AddTicks(830), "Raegan.Littel@hotmail.com", "Raegan", null, null, "Littel", "Kailee", null, null },
                    { 142, "906-767-2292", "Nitzsche, Rau and Braun", new DateTime(1982, 10, 22, 10, 8, 55, 884, DateTimeKind.Local).AddTicks(1600), "Mabel_Willms26@gmail.com", "Mabel", "Male", "635-668-5238", "Willms", "Viva", null, "335-326-1594" },
                    { 143, "582-891-3658", "Murphy and Sons", new DateTime(1999, 12, 22, 13, 8, 27, 148, DateTimeKind.Local).AddTicks(7306), "Viola_Davis35@gmail.com", "Viola", "Female", null, "Davis", "Ernest", null, null },
                    { 144, "207-825-0617", "Koelpin - Durgan", new DateTime(1957, 8, 15, 12, 3, 24, 891, DateTimeKind.Local).AddTicks(6790), "Mason_Huel85@yahoo.com", "Mason", "Male", "967-639-1219", "Huel", "Oran", null, "594-918-2345" },
                    { 145, "477-915-6632", "Muller, Dickinson and Mraz", new DateTime(1973, 8, 2, 15, 48, 41, 353, DateTimeKind.Local).AddTicks(9972), "Lolita_Deckow70@gmail.com", "Lolita", "Female", null, "Deckow", "Sage", null, "436-411-8833" },
                    { 146, "797-260-0670", "Torp - Upton", new DateTime(1968, 6, 3, 17, 13, 50, 497, DateTimeKind.Local).AddTicks(5976), "Camren_Nicolas40@hotmail.com", "Camren", "Male", null, "Nicolas", "Berniece", null, null },
                    { 147, "267-801-3129", "Welch Inc", new DateTime(1960, 8, 25, 7, 28, 3, 684, DateTimeKind.Local).AddTicks(4771), "Jabari_Becker94@yahoo.com", "Jabari", "Female", null, "Becker", "Tanya", null, null },
                    { 148, "925-288-4927", "Hessel, Prohaska and Kohler", new DateTime(1963, 9, 8, 6, 5, 44, 242, DateTimeKind.Local).AddTicks(7883), "Zoey73@yahoo.com", "Zoey", null, null, "Moen", "Ignacio", null, "999-223-5073" },
                    { 149, null, "Romaguera Inc", new DateTime(1960, 5, 5, 6, 26, 3, 189, DateTimeKind.Local).AddTicks(1027), "Stacey.Spinka41@gmail.com", "Stacey", null, "982-782-6818", "Spinka", "Janet", null, "437-587-0782" },
                    { 150, null, "Wunsch, Weber and Bauch", new DateTime(1960, 12, 6, 9, 43, 6, 533, DateTimeKind.Local).AddTicks(1893), "Kirstin3@hotmail.com", "Kirstin", "Female", null, "Abshire", "Cecil", null, null },
                    { 151, null, "Littel - Olson", new DateTime(1987, 5, 27, 17, 2, 56, 955, DateTimeKind.Local).AddTicks(2982), "Alexandro53@hotmail.com", "Alexandro", null, null, "Ratke", "Ike", null, "818-262-7819" },
                    { 152, "986-960-1920", "Buckridge, Flatley and Anderson", new DateTime(1968, 4, 20, 20, 1, 53, 387, DateTimeKind.Local).AddTicks(7178), "Lawrence.Stark@gmail.com", "Lawrence", "Male", "327-919-1087", "Stark", "Arnold", null, null },
                    { 153, null, "Nitzsche, Herman and Corwin", new DateTime(1977, 1, 21, 22, 2, 14, 993, DateTimeKind.Local).AddTicks(9258), "Eloise.Swift@yahoo.com", "Eloise", null, "711-770-7611", "Swift", "Marietta", null, null },
                    { 154, null, "Daniel Group", new DateTime(2003, 5, 24, 18, 50, 11, 802, DateTimeKind.Local).AddTicks(3229), "Bell.Koss@hotmail.com", "Bell", "Male", null, "Koss", "Rosemary", null, null },
                    { 155, null, "Kirlin - Corwin", new DateTime(1966, 1, 14, 15, 4, 31, 354, DateTimeKind.Local).AddTicks(9433), "Jimmie_Farrell30@hotmail.com", "Jimmie", "Female", "971-449-3814", "Farrell", "Grover", null, "501-837-8831" },
                    { 156, "340-731-4211", "Quitzon, Volkman and Erdman", new DateTime(1999, 7, 17, 4, 37, 16, 857, DateTimeKind.Local).AddTicks(6329), "Laverne.Adams19@gmail.com", "Laverne", null, "434-455-7026", "Adams", "Camilla", null, "996-204-5752" },
                    { 157, "879-348-6463", "Nienow - Jenkins", new DateTime(1986, 9, 28, 15, 32, 49, 683, DateTimeKind.Local).AddTicks(1794), "Wallace_Sporer@hotmail.com", "Wallace", null, "995-571-9955", "Sporer", "Monserrate", null, null },
                    { 158, "305-216-0753", "Schultz - Towne", new DateTime(1988, 3, 8, 13, 50, 52, 785, DateTimeKind.Local).AddTicks(9591), "Alycia.Zulauf85@hotmail.com", "Alycia", null, null, "Zulauf", "Trenton", null, null },
                    { 159, null, "Denesik, Gutmann and Halvorson", new DateTime(1971, 6, 19, 22, 48, 49, 965, DateTimeKind.Local).AddTicks(3615), "Geovanny99@yahoo.com", "Geovanny", "Female", "561-930-6107", "Cartwright", "Agustina", null, "676-851-1968" },
                    { 160, null, "Hagenes Group", new DateTime(2004, 10, 19, 7, 5, 11, 873, DateTimeKind.Local).AddTicks(4013), "Clare.Little79@hotmail.com", "Clare", null, "954-872-2835", "Little", "Curt", null, null },
                    { 161, "258-972-9143", "Gibson LLC", new DateTime(1976, 12, 1, 17, 24, 15, 100, DateTimeKind.Local).AddTicks(3958), "Nathanial.Wehner66@hotmail.com", "Nathanial", null, "303-761-9858", "Wehner", "Angela", null, "504-725-8634" },
                    { 162, null, "Gusikowski, O'Reilly and Bergnaum", new DateTime(1972, 11, 11, 8, 41, 6, 737, DateTimeKind.Local).AddTicks(7041), "Frieda_Block@yahoo.com", "Frieda", null, "471-930-8100", "Block", "Russell", null, null },
                    { 163, "523-979-8845", "Harris, Wintheiser and Dickinson", new DateTime(1971, 1, 16, 9, 11, 52, 783, DateTimeKind.Local).AddTicks(3345), "Horace_Cruickshank@yahoo.com", "Horace", null, null, "Cruickshank", "Gilda", null, "448-322-9786" },
                    { 164, "486-824-6424", "Bahringer Group", new DateTime(1975, 8, 27, 18, 39, 11, 464, DateTimeKind.Local).AddTicks(6647), "Brad_Lubowitz@yahoo.com", "Brad", null, null, "Lubowitz", "Ed", null, "363-966-3627" },
                    { 165, "219-505-4707", "Feeney - Cummings", new DateTime(2004, 4, 15, 3, 31, 4, 144, DateTimeKind.Local).AddTicks(6087), "Kathlyn7@yahoo.com", "Kathlyn", "Male", null, "Reinger", "Melody", null, null },
                    { 166, "720-759-1128", "Hilpert, Breitenberg and Wilderman", new DateTime(1993, 3, 9, 11, 35, 29, 595, DateTimeKind.Local).AddTicks(2248), "Crystal.Keebler@hotmail.com", "Crystal", null, null, "Keebler", "Jerad", null, "302-717-0841" },
                    { 167, "511-952-1602", "Rogahn, Stokes and Bogan", new DateTime(1967, 5, 9, 5, 2, 6, 366, DateTimeKind.Local).AddTicks(8148), "Keyshawn.Shields@yahoo.com", "Keyshawn", null, null, "Shields", "Ewell", null, "825-906-5359" },
                    { 168, "450-848-4225", "Rippin Group", new DateTime(1956, 8, 7, 4, 23, 3, 893, DateTimeKind.Local).AddTicks(4215), "Jayme.Jacobson39@yahoo.com", "Jayme", null, null, "Jacobson", "Elenor", null, "623-572-5200" },
                    { 169, "247-690-0537", "Rempel LLC", new DateTime(1972, 7, 24, 0, 7, 40, 17, DateTimeKind.Local).AddTicks(9289), "Estefania62@yahoo.com", "Estefania", null, "329-930-5283", "Little", "Amira", null, null },
                    { 170, "333-323-0313", "Monahan - Hyatt", new DateTime(1976, 4, 29, 6, 56, 8, 3, DateTimeKind.Local).AddTicks(5737), "Don80@gmail.com", "Don", null, null, "Jacobs", "Harrison", null, null },
                    { 171, null, "MacGyver Inc", new DateTime(1986, 3, 18, 20, 40, 2, 939, DateTimeKind.Local).AddTicks(2805), "Adalberto80@gmail.com", "Adalberto", "Male", "904-286-4207", "Luettgen", "Colt", null, "210-434-0202" },
                    { 172, null, "Koch - Dooley", new DateTime(1964, 7, 9, 15, 39, 28, 699, DateTimeKind.Local).AddTicks(7731), "Jean62@yahoo.com", "Jean", null, "837-808-4045", "Dibbert", "Jazmyn", null, null },
                    { 173, null, "Gerlach, Stracke and Rogahn", new DateTime(1964, 8, 15, 8, 34, 27, 259, DateTimeKind.Local).AddTicks(8479), "Rodrick.Wuckert@gmail.com", "Rodrick", "Female", null, "Wuckert", "Hermina", null, "547-881-4023" },
                    { 174, null, "Moen - Olson", new DateTime(1998, 12, 3, 2, 2, 58, 874, DateTimeKind.Local).AddTicks(5443), "Keyon.Langosh3@gmail.com", "Keyon", null, "659-437-2564", "Langosh", "Percy", null, "735-988-8509" },
                    { 175, "992-526-9930", "Kuvalis, Harris and Franecki", new DateTime(1968, 5, 30, 1, 15, 26, 282, DateTimeKind.Local).AddTicks(3277), "Carleton41@hotmail.com", "Carleton", "Male", "282-295-7289", "Miller", "Verner", null, "599-213-7453" },
                    { 176, "559-850-7650", "Lakin - Larson", new DateTime(1967, 2, 20, 23, 1, 23, 41, DateTimeKind.Local).AddTicks(9016), "Heloise20@gmail.com", "Heloise", null, null, "Little", "Titus", null, null },
                    { 177, "919-225-9573", "Toy, Stiedemann and Jones", new DateTime(1981, 12, 7, 6, 5, 2, 720, DateTimeKind.Local).AddTicks(7392), "Haylie_Schmeler@yahoo.com", "Haylie", null, null, "Schmeler", "Noe", null, "325-529-2016" },
                    { 178, "919-291-8206", "Feest, Lueilwitz and Sawayn", new DateTime(1984, 2, 28, 2, 54, 18, 34, DateTimeKind.Local).AddTicks(5968), "Dominique78@yahoo.com", "Dominique", "Male", null, "Emard", "Chester", null, "975-529-7517" },
                    { 179, null, "Champlin - Conn", new DateTime(2002, 4, 14, 20, 14, 28, 904, DateTimeKind.Local).AddTicks(5568), "Katelyn96@gmail.com", "Katelyn", "Female", null, "Schmidt", "Bertram", null, "326-612-6268" },
                    { 180, "881-937-3128", "Hudson LLC", new DateTime(1956, 1, 2, 13, 7, 54, 29, DateTimeKind.Local).AddTicks(8976), "Hertha_Roob26@gmail.com", "Hertha", "Female", null, "Roob", "Loma", null, "499-201-9207" },
                    { 181, null, "Krajcik - McCullough", new DateTime(1983, 12, 19, 9, 17, 31, 385, DateTimeKind.Local).AddTicks(5741), "Isaac.Dare41@hotmail.com", "Isaac", null, "862-424-7370", "Dare", "Fae", null, "664-889-1069" },
                    { 182, "894-559-1142", "Baumbach, Hintz and Moore", new DateTime(1963, 10, 20, 18, 43, 52, 707, DateTimeKind.Local).AddTicks(9820), "Rigoberto_Jacobs@gmail.com", "Rigoberto", null, "793-423-0146", "Jacobs", "Nathaniel", null, null },
                    { 183, null, "Reichel and Sons", new DateTime(1975, 10, 28, 15, 15, 2, 173, DateTimeKind.Local).AddTicks(4903), "Estefania.Jaskolski@yahoo.com", "Estefania", "Male", "538-994-0837", "Jaskolski", "Monroe", null, "282-313-2477" },
                    { 184, null, "Jaskolski - Dietrich", new DateTime(1960, 7, 31, 19, 47, 7, 826, DateTimeKind.Local).AddTicks(6878), "Kendrick36@yahoo.com", "Kendrick", null, "942-687-9137", "Pouros", "Sherman", null, null },
                    { 185, null, "Grant - Stroman", new DateTime(1999, 11, 17, 10, 5, 17, 945, DateTimeKind.Local).AddTicks(4570), "Christ.Donnelly98@gmail.com", "Christ", null, "916-547-8930", "Donnelly", "Heloise", null, "854-502-0223" },
                    { 186, null, "Wiza Inc", new DateTime(2004, 2, 7, 20, 35, 32, 862, DateTimeKind.Local).AddTicks(3095), "Amie_Windler54@gmail.com", "Amie", "Male", "295-688-0996", "Windler", "Ahmad", null, null },
                    { 187, "653-952-1197", "Volkman and Sons", new DateTime(1993, 8, 26, 19, 24, 13, 208, DateTimeKind.Local).AddTicks(1503), "Lynn_Jast@yahoo.com", "Lynn", null, "761-552-3799", "Jast", "Katelin", null, "655-618-9501" },
                    { 188, "666-969-1895", "Bahringer, Pacocha and Wiza", new DateTime(1987, 9, 15, 6, 14, 8, 436, DateTimeKind.Local).AddTicks(2831), "Douglas_Cormier@hotmail.com", "Douglas", null, null, "Cormier", "Kiara", null, "365-659-3597" },
                    { 189, null, "Schmidt - Kuhlman", new DateTime(1959, 11, 9, 5, 20, 9, 807, DateTimeKind.Local).AddTicks(8167), "Gardner98@hotmail.com", "Gardner", "Female", null, "Reichert", "Buddy", null, "738-990-8554" },
                    { 190, null, "Barton, Ziemann and Jerde", new DateTime(1990, 2, 1, 11, 38, 32, 277, DateTimeKind.Local).AddTicks(8076), "Stefan.Gutkowski@gmail.com", "Stefan", "Female", null, "Gutkowski", "Trace", null, null },
                    { 191, "591-720-4247", "Cummerata - Mosciski", new DateTime(1995, 6, 26, 6, 57, 5, 378, DateTimeKind.Local).AddTicks(6085), "Larry85@yahoo.com", "Larry", null, "693-490-9313", "Bahringer", "Efren", null, null },
                    { 192, null, "Muller Inc", new DateTime(1999, 4, 21, 9, 53, 31, 140, DateTimeKind.Local).AddTicks(5082), "Julius_Bins97@gmail.com", "Julius", "Male", "981-575-6895", "Bins", "Ardella", null, null },
                    { 193, "652-856-4299", "Breitenberg, Bogan and Veum", new DateTime(1997, 1, 14, 22, 33, 9, 244, DateTimeKind.Local).AddTicks(6705), "Julian85@gmail.com", "Julian", "Female", "497-753-6311", "Langosh", "Edward", null, null },
                    { 194, null, "King - Collier", new DateTime(2000, 7, 1, 3, 54, 19, 418, DateTimeKind.Local).AddTicks(8098), "Ezra_Greenholt@gmail.com", "Ezra", null, "754-276-3284", "Greenholt", "Burdette", null, null },
                    { 195, "213-915-1018", "Anderson - Paucek", new DateTime(1961, 6, 15, 1, 5, 59, 725, DateTimeKind.Local).AddTicks(55), "Juliet_Reilly59@hotmail.com", "Juliet", null, "553-920-9558", "Reilly", "Tanya", null, null },
                    { 196, null, "Mann - Stracke", new DateTime(1998, 5, 24, 8, 57, 32, 34, DateTimeKind.Local).AddTicks(3241), "Laury46@hotmail.com", "Laury", null, null, "Champlin", "Nikita", null, "872-273-4169" },
                    { 197, "607-606-7576", "Grady, Jacobs and Ortiz", new DateTime(1977, 12, 18, 19, 18, 5, 426, DateTimeKind.Local).AddTicks(1181), "Allison_Cummings@hotmail.com", "Allison", "Male", "525-771-2112", "Cummings", "Tatum", null, "577-554-3574" },
                    { 198, null, "Ferry, Frami and Purdy", new DateTime(1981, 3, 1, 4, 49, 4, 896, DateTimeKind.Local).AddTicks(9614), "Marilyne.Hegmann73@gmail.com", "Marilyne", null, null, "Hegmann", "Eda", null, "848-321-0083" },
                    { 199, null, "Daugherty Group", new DateTime(1977, 7, 16, 5, 57, 0, 939, DateTimeKind.Local).AddTicks(5948), "Xander_Donnelly@gmail.com", "Xander", "Female", null, "Donnelly", "Arianna", null, "428-263-3990" },
                    { 200, "216-754-4304", "Mertz and Sons", new DateTime(1969, 3, 27, 2, 35, 13, 703, DateTimeKind.Local).AddTicks(7088), "Tristian_Johnson98@hotmail.com", "Tristian", "Female", "560-540-6643", "Johnson", "Belle", null, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BookEntryId", "CityTown", "Country", "Line1", "Line2", "Line3", "Name", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 54, 103, "Lake Chasity", "United States", "2803 Ottis Common", null, "Suite 373", "quantifying Creative", "61352", "Delaware" },
                    { 55, 105, "Amirhaven", "United States", "45419 Emard Route", "Apt. 320", "Apt. 524", "Ergonomic hybrid", "09938", "Georgia" },
                    { 56, 106, "Brookefort", "United States", "998 Carter Bridge", null, "Apt. 446", "Triple-buffered bleeding-edge", "41646", "Alabama" },
                    { 57, 111, "East Luis", "United States", "528 Jane Flat", "Apt. 632", "Suite 481", "Incredible Metal Table Accounts", "40342-7243", "North Dakota" },
                    { 58, 112, "New Jacques", "United States", "95608 Bednar Valley", null, "Apt. 171", "SMTP payment", "90110", "Texas" },
                    { 59, 113, "Tobyburgh", "United States", "609 Franecki Green", null, "Suite 112", "methodologies solution", "79994-5040", "Tennessee" },
                    { 60, 114, "Lennieberg", "United States", "312 Jaleel Plaza", null, "Suite 824", "Innovative override", "37643", "Alabama" },
                    { 61, 115, "Shainahaven", "United States", "039 Harvey Ridges", "Suite 437", "Apt. 352", "array payment", "55079-8850", "Florida" },
                    { 62, 118, "Tristonton", "United States", "5976 Hauck Causeway", "Suite 323", "Apt. 577", "Greenland deposit", "33189-2268", "Oregon" },
                    { 63, 119, "Lake Triston", "United States", "807 Dahlia Drive", "Apt. 587", "Apt. 750", "purple bluetooth", "31842-7418", "Wisconsin" },
                    { 64, 120, "North Suzanne", "United States", "8972 Glover Prairie", null, "Suite 980", "task-force Walk", "37004", "Colorado" },
                    { 65, 123, "Marksborough", "United States", "810 Amina Circle", "Suite 676", "Apt. 922", "Practical Shoes, Movies & Kids", "88931-6997", "Mississippi" },
                    { 66, 125, "East Casandramouth", "United States", "37033 Oceane Cliffs", "Apt. 127", "Suite 529", "Beauty JBOD", "96964", "West Virginia" },
                    { 67, 126, "Koelpinton", "United States", "1845 Feil Circle", null, "Suite 495", "Bulgarian Lev Polarised", "74007-9509", "Ohio" },
                    { 68, 127, "Lake Mozellstad", "United States", "8511 Sydni Valley", null, "Suite 895", "Refined Plastic Fish Unbranded Fresh Shirt", "49247", "New Mexico" },
                    { 69, 131, "Libbieside", "United States", "5586 Stefan Squares", null, "Apt. 475", "Investor AI", "94826-3554", "Alaska" },
                    { 70, 133, "Kassulkeport", "United States", "012 Mabelle Trail", null, "Apt. 331", "Fantastic maximize", "72228", "Wyoming" },
                    { 71, 135, "West Justine", "United States", "078 Schimmel Drives", "Suite 564", "Suite 621", "navigate systems", "03336", "Wisconsin" },
                    { 72, 138, "Aylaland", "United States", "5100 DuBuque Loaf", "Suite 593", "Suite 260", "open-source Trinidad and Tobago", "75476-0060", "Colorado" },
                    { 73, 139, "East Torrey", "United States", "254 Borer Extension", null, "Apt. 750", "bus Maryland", "13399-8960", "Missouri" },
                    { 74, 140, "Walkerview", "United States", "2570 Steuber Parks", null, "Apt. 943", "system-worthy mint green", "35521-3228", "Oregon" },
                    { 75, 141, "Ariellemouth", "United States", "1188 Windler Curve", "Suite 796", "Suite 422", "Investment Account Turnpike", "26692-2664", "Wisconsin" },
                    { 76, 142, "Julioport", "United States", "7346 Hollie Valleys", "Apt. 853", "Suite 806", "Licensed Metal Cheese Accounts", "60156-8263", "Georgia" },
                    { 77, 143, "Lake Stacey", "United States", "95462 White Creek", "Suite 527", "Suite 228", "Bedfordshire Ergonomic", "88012-8487", "North Carolina" },
                    { 78, 144, "South Elissabury", "United States", "93138 Monroe Glens", "Apt. 247", "Apt. 121", "Technician Handmade Cotton Shoes", "74737", "Massachusetts" },
                    { 79, 145, "West Bennettmouth", "United States", "477 Fay Street", null, "Apt. 647", "Texas integrated", "92930", "New York" },
                    { 80, 146, "New Markton", "United States", "27470 Wuckert View", null, "Apt. 899", "tan enable", "55370", "Texas" },
                    { 81, 147, "Bettyberg", "United States", "383 Smitham Harbors", "Suite 355", "Suite 112", "withdrawal CSS", "15721-0955", "Minnesota" },
                    { 82, 148, "West Elyssa", "United States", "39638 Gutkowski Dam", "Suite 915", "Apt. 579", "Berkshire mint green", "73780", "New Hampshire" },
                    { 83, 149, "Trompmouth", "United States", "94886 Jacobi Ville", null, "Apt. 974", "Gorgeous Avenue", "39282", "Alaska" },
                    { 84, 152, "Framitown", "United States", "0155 Cassandre Spurs", "Suite 688", "Suite 313", "pixel Dam", "25920-5928", "Maine" },
                    { 85, 153, "Eladioville", "United States", "313 Isobel Fields", null, "Apt. 486", "transmit Berkshire", "08506", "Vermont" },
                    { 86, 154, "North Shaniemouth", "United States", "6250 Grady Brooks", null, "Suite 428", "synergies Small Wooden Chair", "73592-5044", "Michigan" },
                    { 87, 156, "Rodfort", "United States", "222 Lilyan Trail", "Suite 619", "Apt. 898", "auxiliary Field", "66747", "Kansas" },
                    { 88, 157, "New Laverna", "United States", "51377 Josiah Alley", null, "Suite 534", "Rustic Rubber Shoes backing up", "17407-0617", "Maryland" },
                    { 89, 158, "Shemarchester", "United States", "63620 Kuvalis Oval", null, "Apt. 636", "olive navigating", "96787", "Oklahoma" },
                    { 90, 160, "Mannbury", "United States", "387 Trycia Cliff", "Suite 417", "Apt. 180", "Awesome Metal Keyboard National", "59585", "West Virginia" },
                    { 91, 161, "South Edward", "United States", "662 Rowe Isle", "Apt. 088", "Suite 176", "Program Analyst", "16495-4278", "Louisiana" },
                    { 92, 164, "Schimmelfort", "United States", "6531 Fleta Mill", null, "Suite 554", "Rapid Terrace", "61782-9414", "Colorado" },
                    { 93, 165, "New Giovanni", "United States", "02691 Spinka Mountains", null, "Apt. 403", "distributed uniform", "11965-0576", "Virginia" },
                    { 94, 166, "Mitchelland", "United States", "945 Gleason Shoals", "Apt. 646", "Apt. 204", "niches Connecticut", "30317-5486", "Maryland" },
                    { 95, 167, "Kozeyberg", "United States", "10450 Kessler Loop", null, "Suite 789", "National online", "79588-7648", "Maryland" },
                    { 96, 168, "Nikolasville", "United States", "07348 Erwin Summit", null, "Suite 499", "Extension Hawaii", "62934-1035", "Missouri" },
                    { 97, 172, "Cadenchester", "United States", "13896 Kuvalis Forges", null, "Apt. 648", "Walks North Dakota", "97153", "Pennsylvania" },
                    { 98, 173, "Lake Adahport", "United States", "017 Bradtke Mills", null, "Apt. 839", "Berkshire revolutionize", "42323-5181", "Missouri" },
                    { 99, 175, "Gislasonshire", "United States", "309 Purdy Tunnel", null, "Apt. 426", "Ghana Dale", "79415", "New Mexico" },
                    { 100, 176, "East Carole", "United States", "01148 Audie Knolls", null, "Apt. 755", "Investor deposit", "07415-0511", "Vermont" },
                    { 101, 178, "Ethanbury", "United States", "386 Stamm Corners", null, null, "TCP Sports", "98862-9011", "Illinois" },
                    { 102, 179, "North Rod", "United States", "4721 Keanu Village", null, "Suite 949", "deliverables Metrics", "65690", "Alabama" },
                    { 103, 181, "East Lillie", "United States", "394 Wisozk Vista", null, "Suite 431", "AI Colorado", "37837-8133", "West Virginia" },
                    { 104, 182, "MacGyverville", "United States", "86192 Metz Mill", "Suite 526", null, "maroon leverage", "26346", "Arkansas" },
                    { 105, 184, "Clarefort", "United States", "73835 Ray Springs", null, "Apt. 499", "synthesizing CFA Franc BEAC", "22362-4783", "Minnesota" },
                    { 106, 185, "Alessialand", "United States", "27403 Maybelle Ramp", null, "Apt. 362", "Producer Rustic Granite Cheese", "68124", "Colorado" },
                    { 107, 188, "Arielleton", "United States", "230 Jayde Square", "Suite 940", "Apt. 399", "Tools Generic Cotton Chair", "36262", "New York" },
                    { 108, 189, "Yundtburgh", "United States", "0787 Sigrid Valleys", null, "Suite 063", "Operations Pa'anga", "79855", "Wisconsin" },
                    { 109, 190, "Isacfort", "United States", "58390 Xander View", "Apt. 955", "Suite 617", "Ergonomic Frozen Bike deposit", "11269-5579", "Connecticut" },
                    { 110, 192, "North Napoleon", "United States", "4403 Willis Wall", "Apt. 044", "Apt. 856", "Wisconsin Cotton", "69471-5955", "Massachusetts" },
                    { 111, 193, "Metzborough", "United States", "8022 Ludie Ville", null, "Suite 673", "Pre-emptive systems", "78714-8220", "Wyoming" },
                    { 112, 194, "Port Caleb", "United States", "34763 Heidenreich Hills", "Apt. 097", "Suite 402", "Universal lavender", "83240-6566", "Colorado" },
                    { 113, 195, "South Willie", "United States", "6041 Aric Mill", "Apt. 351", "Suite 589", "Sports Money Market Account", "56632", "Idaho" },
                    { 114, 198, "Yoshikoberg", "United States", "328 Kuhic Throughway", "Apt. 448", "Apt. 230", "pixel Jewelery, Home & Industrial", "89714", "West Virginia" },
                    { 115, 199, "Murphyton", "United States", "251 Zachariah Fort", null, "Suite 415", "navigate interface", "23741-1817", "Kansas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BookEntryId",
                table: "Addresses",
                column: "BookEntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BookEntries");
        }
    }
}
