using Microsoft.EntityFrameworkCore;

namespace Bryan_Ovalles_P2_AP1.api.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> option) : base(option) { }

}
