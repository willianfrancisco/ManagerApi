using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public DomainException()
        {
        }

        public DomainException(string menssage, List<string> errors) : base(menssage)
        {
            _errors = errors;
        }

        public DomainException(string menssagem) : base(menssagem)
        {
        }

        public DomainException(string menssagem, Exception innerException) : base(menssagem, innerException)
        {

        }
    }
}
