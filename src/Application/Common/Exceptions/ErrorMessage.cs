using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Exceptions
{

    public static class ErrorMessage
    {
        public const string ExceptionConcurrency = "An exception that is thrown when a concurrency violation is encountered while saving to the database. Try to update again";
        public const string ExceptionUpdateData = "An exception that is thrown when an error is encountered while saving to the database";
        public const string Range = "Rango permitido de ";
        public const string MaxFileSize = "Maximo Tamaño {0} permitido superado ";

        public const string Exist = "Ya existe un registro con los datos ingresados ";

        public const string IsRequired = "Campo Requerido";

        public const string MaxLength = "Máximo de caracteres ";

        public const string MinLength = "Mínimo de caracteres ";

        public const string MaxValue = "Valor mínimo ";

        public const string MinValue = "Valor máximo ";

        public const string IsNumeric = "El campo debe ser numérico.";

        public const string IsAlphabetic = "El campo debe ser alfabético.";

        public const string IsAlphaNumeric = "El campo debe contener números y letras.";

        public const string IsDate = "El formato de fecha debe ser DD/MM/AAAA.";

        public const string IsEmail = "El correo eletrónico ingresado no es válido.";

        public const string IsUrl = "La URL ingresada no es válida.";

        public const string BadFormat = "No es un formato válido.";

        public const string DecimalLength = "Maxima longitud de decimales ";

        public const string IsImage = "El formato debe ser tipo imagen.";

        public const string IsPdf = "El formato debe ser pdf.";

        public const string MinDateToday = "La fecha no debe ser mayor a la fecha actual.";

        public const string MinDateMaxDate = "La fecha inicial no debe ser mayor a la fecha fin.";

        public const string MaxDateMinDate = "La fecha fin no debe ser menor a la fecha inicial.";

        public const string IsEnum = "No es un valor del enumerador.";

        public static string NotFound(string entidad)
        {
            return $"No existe {entidad} con los datos ingresados.";
        }
        public static string DeleteFailure(string entidad)
        {
            return $"La eliminacion del objeto {entidad} ha fallado.";
        }
        public static string InUse(string entidad)
        {
            return $"Objeto en uso por {entidad}";
        }
    }
}
