namespace Comunidades.ApiService.Models.Enums
{
    /// <summary>
    /// Estados de dados no banco.
    /// </summary>
    public enum DataStatus
    {
        /// <summary>
        /// O dado encontra-se ativo.
        /// </summary>
        Active = 1,
        /// <summary>
        /// O dado encontra-se inativo.
        /// </summary>
        Inactive = 2,
        /// <summary>
        /// O dado encontra-se suspenso.
        /// </summary>
        Suspended = 3,
        /// <summary>
        /// O dado encontra-se banido.
        /// </summary>
        Banned = 4,
        /// <summary>
        /// O dado está pronto para ser deletado
        /// </summary>
        Deleted = 5
    }
}
