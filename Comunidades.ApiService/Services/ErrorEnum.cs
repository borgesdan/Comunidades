using System.ComponentModel;

namespace Comunidades.ApiService.Services
{
    public enum ErrorEnum
    {
        [Description("Ocorreu um erro interno.")]
        InternalError = 0,
        [Description("Ocorreu um erro interno de acesso ao banco.")]
        InternalDbError,

        //
        // User
        //

        [Description("O nome deve ser informado.")]
        UserInvalidName = 100,
        [Description("O nome do usuário excedeu os limites de caracteres.")]
        UserNameOutOfRange,
        [Description("O nome de usuário deve ser informado.")]
        UserInvalidUserName,
        [Description("O nome de usuário excedeu os limites de caracteres.")]
        UserUserNameOutOfRange,
        [Description("Um email válido deve ser informado.")]
        UserInvalidEmail,
        [Description("O email excedeu os limites de caracteres")]
        UserEmailOutOfRange,
        [Description("A senha informada não é válida.")]
        UserInvalidPassword,
    }
}
