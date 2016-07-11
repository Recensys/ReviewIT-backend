using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecensysBLL.Exceptions
{
    internal class StrategyNotFoundException : Exception
    {
        public StrategyNotFoundException()
        {
        }

        public StrategyNotFoundException(string message) : base(message)
        {
        }

        public StrategyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StrategyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
