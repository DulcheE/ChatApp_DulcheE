using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Models
{

    [Serializable]
    public abstract class CommunicationException : Exception, ICommunication {

        protected readonly DateTime creation_date;

        public CommunicationException() : base() 
        { 
            this.creation_date = DateTime.Now; 
        }

        public CommunicationException(string message) : base(message)
        {
            this.creation_date = DateTime.Now;
        }

        //For Deserialization
        protected CommunicationException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        {
            this.creation_date = DateTime.Now;
        }


    }


    [Serializable]
    public class InvalidCredentialsException : CommunicationException
    {

        public InvalidCredentialsException() : base() { }

        public InvalidCredentialsException(string message) : base(message) { }

        //For Deserialization
        protected InvalidCredentialsException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class DataNotFoundException : CommunicationException
    {

        public DataNotFoundException() : base() { }

        public DataNotFoundException(string message) : base(message) { }

        //For Deserialization
        protected DataNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class NoUniqueException : CommunicationException
    {

        public NoUniqueException() : base() { }

        public NoUniqueException(string message) : base(message) { }

        //For Deserialization
        protected NoUniqueException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class UserAlreadyInTopicException : CommunicationException
    {

        public UserAlreadyInTopicException() : base() { }

        public UserAlreadyInTopicException(string message) : base(message) { }

        //For Deserialization
        protected UserAlreadyInTopicException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class UserNotInTopicException : CommunicationException
    {

        public UserNotInTopicException() : base() { }

        public UserNotInTopicException(string message) : base(message) { }

        //For Deserialization
        protected UserNotInTopicException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class UserNotOwnerOfTopicException : CommunicationException
    {

        public UserNotOwnerOfTopicException() : base() { }

        public UserNotOwnerOfTopicException(string message) : base(message) { }

        //For Deserialization
        protected UserNotOwnerOfTopicException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }


    [Serializable]
    public class NoUserConnectedException : CommunicationException
    {
        public NoUserConnectedException() : base() { }

        public NoUserConnectedException(string message) : base(message) { }

        protected NoUserConnectedException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class SecurityException : CommunicationException
    {
        public SecurityException() : base() { }

        public SecurityException(string message) : base(message) { }

        protected SecurityException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class ClientCredentialsInvalidException : SecurityException
    {
        public ClientCredentialsInvalidException() : base() { }

        public ClientCredentialsInvalidException(string message) : base(message) { }

        protected ClientCredentialsInvalidException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
