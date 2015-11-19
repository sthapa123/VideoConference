﻿
using System.ServiceModel;

namespace VideoConferenceConnection
{
    [ServiceContract]
    public interface IContentReceiver
    {
        [OperationContract]
        string GetName();

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string from);
    }
}