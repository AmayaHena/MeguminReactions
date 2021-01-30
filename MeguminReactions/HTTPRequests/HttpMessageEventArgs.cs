using System;
using System.Net;

namespace MeguminReactions.Events
{
    class HttpMessageEventArgs : EventArgs
    {
        public HttpListenerRequest Request;
        public HttpListenerResponse Response;
    }
}