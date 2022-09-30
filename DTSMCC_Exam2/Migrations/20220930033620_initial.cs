using Microsoft.EntityFrameworkCore.Migrations;

namespace DTSMCC_Exam2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jenisKelamins",
                columns: table => new
                {
                    idJK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jenisKelamin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jenisKelamins", x => x.idJK);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namaRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "statusBekerjas",
                columns: table => new
                {
                    idSB = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusBekerjas", x => x.idSB);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    idKaryawan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namaLengkap = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    alamat = table.Column<string>(nullable: true),
                    noTelp = table.Column<string>(nullable: true),
                    idJK = table.Column<int>(nullable: false),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.idKaryawan);
                    table.ForeignKey(
                        name: "FK_accounts_jenisKelamins_idJK",
                        column: x => x.idJK,
                        principalTable: "jenisKelamins",
                        principalColumn: "idJK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pengajuans",
                columns: table => new
                {
                    idPengajuan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idKaryawan = table.Column<int>(nullable: false),
                    idStatusBekerja = table.Column<int>(nullable: false),
                    namaPerusahaan = table.Column<string>(nullable: true),
                    alamatPerusahaan = table.Column<string>(nullable: true),
                    statusPengajuan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pengajuans", x => x.idPengajuan);
                    table.ForeignKey(
                        name: "FK_pengajuans_accounts_idKaryawan",
                        column: x => x.idKaryawan,
                        principalTable: "accounts",
                        principalColumn: "idKaryawan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pengajuans_statusBekerjas_idStatusBekerja",
                        column: x => x.idStatusBekerja,
                        principalTable: "statusBekerjas",
                        principalColumn: "idSB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_idJK",
                table: "accounts",
                column: "idJK");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_roleId",
                table: "accounts",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_pengajuans_idKaryawan",
                table: "pengajuans",
                column: "idKaryawan");

            migrationBuilder.CreateIndex(
                name: "IX_pengajuans_idStatusBekerja",
                table: "pengajuans",
                column: "idStatusBekerja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pengajuans");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "statusBekerjas");

            migrationBuilder.DropTable(
                name: "jenisKelamins");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
