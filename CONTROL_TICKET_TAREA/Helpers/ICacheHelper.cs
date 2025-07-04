﻿namespace CONTROL_TICKET_TAREA.Helpers
{
    public interface ICacheHelper
    {
        Task<List<T>> ObtenerListaAsync<T>(string clave, Func<Task<List<T>>> obtenerDatos, TimeSpan expiracion);
        bool IntentarGuardar(string clave, TimeSpan expiracion);
        void EliminarCache(string clave);
    }

}
