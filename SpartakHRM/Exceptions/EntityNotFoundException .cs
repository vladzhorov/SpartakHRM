using System.Net;
using System.Runtime.Serialization;

namespace SpartakHRM.UserService.API.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
            : base(message, statusCode)
        {
            Code = ErrorCodes.EntityNotFound;
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Code = ErrorCodes.EntityNotFound;
        }

        public override string Code { get; }
    }
}
