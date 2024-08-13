using System.ComponentModel;

namespace Comunidades.ApiService.Services
{
    public enum ErrorEnum
    {
        [Description("O nome do usuário deve ser informado.")]
        UserCreateInvalidName = 100
    }
}
