using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.infrstructure.common.Wrappers
{
    public struct Optional<T>
    {
        private readonly T value;
        private bool isEmpty;
        public bool IsEmpty { get { return isEmpty; } }
        private string noneErrorMessage;
        private Optional(T value,bool isEmpty,String noneErroMessage)
        {
            this.value = value;
            this.isEmpty = isEmpty;
            this.noneErrorMessage = noneErroMessage;
        }
        public static Optional<T> Some(T value)
        {
            return new Optional<T>(value, false, string.Empty);
        }
        public static Optional<T> None(String noneMessage)
        {
            return new Optional<T>(default(T), true, noneMessage);
        }

        public static Optional<T> None()
        {
            return new Optional<T>(default(T), true,string.Empty);
        }
        public T Get()
        {
            return GetOrThrow(message => new ApplicationException(message));
        }
        public T GetOrThrow(Func<string, Exception> onNone)
        {
            if (IsEmpty)
                throw onNone(noneErrorMessage);
            return value;
        }
    }
}
