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

        public bool IntentarGuardar(string clave, TimeSpan expiracion)
        {
            if (_cache.TryGetValue(clave, out _))
                return false;

            _cache.Set(clave, true, expiracion);
            return true;
        }

        public void EliminarCache(string clave)
        {
            _cache.Remove(clave);
        }
    }
}
