namespace Shop.Controllers
{
    internal class TokenDto
    {
        public string Token { get; set; }
        public int idUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Message { get; set; }
        public bool Administrador { get; set; }
    }
}