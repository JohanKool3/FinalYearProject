using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.Exceptions
{
    public class InputDeviceNotSetException : Exception
    {
        public InputDeviceNotSetException()
        {

        }

        public InputDeviceNotSetException(string message) : base(message)
        {

        }
    }
}
