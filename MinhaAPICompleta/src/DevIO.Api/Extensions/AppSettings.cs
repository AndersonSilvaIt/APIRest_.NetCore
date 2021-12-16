namespace DevIO.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }

        public string Emissor { get; set; } // quem irá emitir o Token, no caso, a aplicação
        public string ValidoEm { get; set; } // Em quais URLs o token é válido;
        // caso a aplicação tiver uma URL (www.algumacoisa.com.br), informa essa URL,
        // no meu caso estou usando o localhost
    }
}
