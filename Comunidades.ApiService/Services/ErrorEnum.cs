using System.ComponentModel;

namespace Comunidades.ApiService.Services
{
    public enum ErrorEnum
    {
        //
        // Internal
        //

        [Description("Ocorreu um erro interno.")]
        InternalError = 0,
        [Description("Ocorreu um erro interno de acesso ao banco.")]
        InternalDbError,
        [Description("Ocorreu um erro não experado ao realizar a inserção de dados.")]
        InternalCreateDbError,

        //
        // User
        //

        [Description("O nome deve ser informado.")]
        UserInvalidFullName = 100,
        [Description("O nome do usuário excedeu os limites de caracteres.")]
        UserFullNameOutOfRange,
        [Description("O nome de usuário deve ser informado.")]
        UserInvalidUserName,
        [Description("O nome de usuário excedeu os limites de caracteres.")]
        UserUserNameOutOfRange,
        [Description("Um email válido deve ser informado.")]
        UserInvalidEmail,
        [Description("O email excedeu os limites de caracteres")]
        UserEmailOutOfRange,
        [Description("A senha informada deve ser válida e ter de 8 a 16 caracteres.")]
        UserInvalidPassword,
        [Description("Os dados de entrada são inválidos.")]
        UserInvalidLogin,
        [Description("O email informado já está cadastrado.")]
        UserEmailAlreadyExists,

        //
        // Community
        //

        [Description("O nome da comunidade deve ser informado.")]
        CommunityEmptyName = 200,
        [Description("O nome do comunidade excedeu os limites de caracteres.")]
        CommunityNameOutOfRange,
        [Description("A descrição da comunidade deve ser informada.")]
        CommunityEmptyDescription,
        [Description("A descrição da comunidade excedeu os limites de caracteres.")]
        CommunityDescriptionOutOfRange,
        [Description("O criador da comunidade é inválido ou não foi informado.")]
        CommunityInvalidCreator
    }
}
