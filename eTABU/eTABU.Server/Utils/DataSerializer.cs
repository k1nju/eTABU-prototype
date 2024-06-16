using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Todo.Server.Utils
{
    public static class DataSerializer
    {
        /// <summary>
        ///     Сериализовать объект в строку JSON.
        /// </summary>
        /// <param name="rawData">Объект.</param>
        /// <returns>Строка JSON.</returns>
        public static string Serialize(object? rawData)
        {
            return JsonConvert.SerializeObject(rawData, Configuration);
        }

        /// <summary>
        ///     Десериализовать строку JSON в объект указанного типа данных.
        /// </summary>
        /// <param name="serializedData">Строка JSON.</param>
        /// <typeparam name="T">Выходной тип данных.</typeparam>
        /// <returns>Объект указанного выходного типа данных.</returns>
        public static T? Deserialize<T>([StringSyntax("Json")] string serializedData)
        {
            return JsonConvert.DeserializeObject<T>(serializedData, Configuration);
        }

        /// <summary>
        ///     Конфигурация.
        /// </summary>
        private static JsonSerializerSettings Configuration { get; } = new()
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
    }
}
