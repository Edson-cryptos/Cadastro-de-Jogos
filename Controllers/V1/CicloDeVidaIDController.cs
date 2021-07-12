using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace IdentificadorApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CicloDeVidaIDController : ControllerBase
    {
        public readonly IIdentificadorSingleton _IdentificadorSingleton1;
        public readonly IExemploSingleton _IdentificadorSingleton2;

        public readonly IIdentificadorScoped _IdentificadorScoped1;
        public readonly IIdentificadorScoped _IdentificadorScoped2;

        public readonly IIdentificadorTransient _IdentificadorTransient1;
        public readonly IIdentificadorTransient _IdentificadorTransien t2;

        public CicloDeVidaIDController(IIdentificadorSingleton IdentificadorSingleton1,
                                       IIdentificadorSingleton IdentificadorSingleton2,
                                       IIdentificadorScoped IdentificadorScoped1,
                                       IIdentificadorScoped IdentificadorScoped2,
                                       IIdentificadorTransient IdentificadorTransient1,
                                       IIdentificadorTransient IdentificadorTransient2)
        {
            _IdentificadorSingleton1 = IdentificadorSingleton1;
            _IdentificadorSingleton2 = IdentificadorSingleton2;
            _IdentificadorScoped1 = IdentificadorScoped1;
            _IdentificadorScoped2 = IdentificadorScoped2;
            _IdentificadorTransient1 = IdentificadorTransient1;
            _IdentificadorTransient2 = IdentificadorTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_IdentificadorSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_IdentificadorSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_IdentificadorScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_IdentificadorScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_IdentificadorTransient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_IdentificadorTransient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IIdentificadorGeral
    {
        public Guid Id { get; }
    }

    public interface IIdentificadorSingleton :IIdentificadorGeral
    { }

    public interface IIdentificadorScoped : IIdentificadorGeral
    { }

    public interface IIdentificadorTransient : IIdentificadorGeral
    { }

    public class IdentificadorCicloDeVida : IIdentificadorSingleton, IIdentificadorScoped, IIdentificadorTransient
    {
        private readonly Guid _guid;

        public IdentificadorCicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
