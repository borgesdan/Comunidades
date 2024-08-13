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
        Active,
        /// <summary>
        /// O dado encontra-se inativo.
        /// </summary>
        Inactive,
        /// <summary>
        /// O dado está pronto para ser deletado
        /// </summary>
        Deleted
    }
}
