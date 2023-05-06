using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    cedula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: true),
                    dirrecion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cedula);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    tipo_pago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientecedula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_facturas_clientes_clientecedula",
                        column: x => x.clientecedula,
                        principalTable: "clientes",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    Envio = table.Column<bool>(type: "bit", nullable: false),
                    descuento = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    facturaid = table.Column<int>(type: "int", nullable: true),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    camara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular_almacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular_procesador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular_ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procesador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    almacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarjeta_video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarjeta_madre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_producto_facturas_facturaid",
                        column: x => x.facturaid,
                        principalTable: "facturas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_facturas_clientecedula",
                table: "facturas",
                column: "clientecedula");

            migrationBuilder.CreateIndex(
                name: "IX_producto_facturaid",
                table: "producto",
                column: "facturaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
