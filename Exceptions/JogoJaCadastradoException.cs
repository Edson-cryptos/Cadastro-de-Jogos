using System;

namespace IdentificadorApiCatalogoJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException()
            : base("Este jogo está cadastrado")
        { }
    }
}
