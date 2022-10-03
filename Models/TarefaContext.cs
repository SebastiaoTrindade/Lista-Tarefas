using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Models
{
    public class TarefaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {}
    }
}
