using System;

namespace Gestalt.Common.Exceptions
{
    /// <summary>
    /// Класс исключения при ненайденных значениях конфигурации.
    /// </summary>
    public class NoConfigurationValueException : Exception
    {
        public NoConfigurationValueException(string key)
            : base($"Value by key '{key}' not found.")
        {
        }
    }
}