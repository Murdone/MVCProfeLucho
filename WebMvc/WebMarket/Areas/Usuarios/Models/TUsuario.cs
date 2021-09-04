namespace WebMarket.Areas.Usuarios.Models
{
    public class TUsuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string IdUser { get; set; }
        public byte[] Image { get; set; }
    }
}
