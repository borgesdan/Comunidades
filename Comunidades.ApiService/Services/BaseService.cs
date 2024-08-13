using System.Net;

namespace Comunidades.ApiService.Services
{
    /// <summary>
    /// Classe base para os serviços.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Retorna um objeto ServiceResult com status 200.
        /// </summary>
        protected ServiceResult Ok(string? message = null) { return new ServiceResult(true, message, HttpStatusCode.OK); }
        /// <summary>
        /// Retorna um objeto ServiceResult com status 400.
        /// </summary>
        protected ServiceResult BadRequest(string? message = null) { return new ServiceResult( false, message, HttpStatusCode.BadRequest); }
        /// <summary>
        /// Retorna um objeto ServiceResult com status 500.
        /// </summary>
        protected ServiceResult InternalError(string? message = null) { return new ServiceResult(false, message, HttpStatusCode.InternalServerError); }

        /// <summary>
        /// Retorna um objeto com status 200.
        /// </summary>
        protected ServiceResult<T> Ok<T>(T? data, string? message = null) where T : class { return new ServiceResult<T>(true, message, HttpStatusCode.OK, data); }
        /// <summary>
        /// Retorna um objeto ServiceResult com status 400.
        /// </summary>
        protected ServiceResult<T> BadRequest<T>(T? data, string? message = null) where T : class { return new ServiceResult<T>(true, message, HttpStatusCode.BadRequest, data); }
        /// <summary>
        /// Retorna um objeto ServiceResult com status 500.
        /// </summary>
        protected ServiceResult<T> InternalError<T>(T? data, string? message = null) where T : class { return new ServiceResult<T>(true, message, HttpStatusCode.InternalServerError, data); }
    }
}
