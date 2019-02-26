using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application
{
    public class AspectCoreException : Exception
    {
        private string _message;
        public AspectCoreException(string message) {
            _message = message;
        }
        private string getMessage()
        {
            var ss = _message.Substring(1, _message.Length - 1);
            return _message;
        }
        public override string Message => getMessage();
    }
}
