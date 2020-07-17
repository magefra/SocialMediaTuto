using System;

namespace SocialMedia.Core.src.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string mensaje) : base (mensaje)
        {

        }
    }
}
