﻿

namespace CesarBmx.Application.Exceptions
{
    public class ForbiddenException : DomainException
    {
        public ForbiddenException(string message) : base(message)
        {}
    }
}
