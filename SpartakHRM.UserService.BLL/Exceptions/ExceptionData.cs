namespace SpartakHRM.UserService.BLL.Services
{
    public class UserDraftServiceException : Exception
    {
        public UserDraftServiceException(string message) : base(message)
        {
        }
    }

    public class UserServiceException : Exception
    {
        public UserServiceException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : UserServiceException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class CreationException : UserServiceException
    {
        public CreationException(string message) : base(message)
        {
        }
    }

    public class UpdateException : UserServiceException
    {
        public UpdateException(string message) : base(message)
        {
        }
    }

    public class DeletionException : UserServiceException
    {
        public DeletionException(string message) : base(message)
        {
        }
    }
}
