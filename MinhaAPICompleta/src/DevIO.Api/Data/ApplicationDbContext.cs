using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Caso existir mais de um contexto no projeto, DbContextOptions<ApplicationDbContext>
        // é bom deixar a configuração assim, especializando qual contexto o Migrations irá utilizar.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
