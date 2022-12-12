using AuroraProject.Core.Exceptions;
using System.Text.RegularExpressions;

namespace AuroraProject.Core.Validations
{
    public class ExceptionValidate
    {
        public static void IfEqual(object object1, object object2, string mensagem)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void NotEqual(object object1, object object2, string mensagem)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void NotEqual(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void Size(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void Size(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>      
        /// Validar se o objeto é nulo, se sim, lance uma exceção.
        /// </summary>
        /// <param name="object1">Objeto para ser comparado</param>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <exception cref="DomainException"></exception>
        public static void EqualNull(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeFalso(bool boolvalor, string mensagem)
        {
            if (!boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVerdadeiro(bool boolvalor, string mensagem)
        {
            if (boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}