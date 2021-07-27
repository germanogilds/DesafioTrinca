namespace Churrasco.Domain.Entities
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Usuario user, string token)
        {
            Id = user.Id;
            NomeDeUsuario = user.NomeDeUsuario;
            Token = token;
        }
    }
}
