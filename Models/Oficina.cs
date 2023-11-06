
namespace CitasClinicas
{
    public class Oficina
    {
        public string? Numero { get; set; } = string.Empty;

        public Medico Medico { get; set; } = new Medico();
    }
}