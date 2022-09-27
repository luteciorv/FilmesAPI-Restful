namespace UsuariosAPI.Models
{
    public class Token
    {
        public Token(string valor)
        {
            Valor = valor;
        }

        public string Valor { get; }
    }
}
