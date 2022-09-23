namespace WebAppEvaluacionEmanuel.Data.Models
{
    public class Cliente : Abstractions.Persona<Guid>
    {
        public string NoCliente { get; set; }
        public string Domicilio { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
