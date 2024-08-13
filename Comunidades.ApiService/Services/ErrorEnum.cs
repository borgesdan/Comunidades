using System.ComponentModel;

namespace Comunidades.ApiService.Services
{
    public enum ErrorEnum
    {
        [Description("Ocorreu um erro interno.")]
        InternalError = 0,

        [Description("Ocorreu um erro interno de acesso ao banco.")]
        InternalDbError,

        [Description("O nome do usuário deve ser informado.")]
        UserCreateInvalidName = 100
    }
}
