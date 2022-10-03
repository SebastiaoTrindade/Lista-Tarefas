namespace ListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Importancia { get; set; }
    }
}
