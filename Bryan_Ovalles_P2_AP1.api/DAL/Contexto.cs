using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Bryan_Ovalles_P2_AP1.api.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> option) : base(option) { }

	public DbSet<Personas> Personas { get; set; }
	public DbSet<PersonasDetalles> PersonasDetalles { get; set; }
	public DbSet<TiposTelefonos> TiposTelefonos { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<TiposTelefonos>().HasData(
			new TiposTelefonos() { TipoId = 1, Descripcion = "Teléfono" },
			new TiposTelefonos() { TipoId = 2, Descripcion = "Celular" }
		);
		base.OnModelCreating(modelBuilder);
	}
}