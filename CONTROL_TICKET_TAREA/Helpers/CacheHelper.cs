using Microsoft.Extensions.Caching.Memory;

namespace CONTROL_TICKET_TAREA.Helpers
{
    public class CacheHelper(IMemoryCache cache) : ICacheHelper
    {
        private readonly IMemoryCache _cache = cache;

        public async Task<List<T>> ObtenerListaAsync<T>(string clave, Func<Task<List<T>>> obtenerDatos, TimeSpan expiracion)
        {
            return await _cache.GetOrCreateAsync(clave, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = expiracion;
                return await obtenerDatos();
            }) ?? [];
        }
    }
}
