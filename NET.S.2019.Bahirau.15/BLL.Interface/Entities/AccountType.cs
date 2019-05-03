using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class AccountType : IEquatable<AccountType>
    {
        private string _typeName;

        public AccountType(string typeName, AccountEvent accountEvent = null)
        {
            TypeName = typeName;
            AccountEvent = accountEvent;
        }

        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Type name must not be null");
                }

                if (value.Trim().Length < 1)
                {
                    throw new ArgumentException("Type name length must be more than zero");
                }

                _typeName = value;
            }
        }

        public AccountEvent AccountEvent { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AccountType);
        }

        public bool Equals(AccountType other)
        {
            return other != null &&
                   _typeName == other._typeName &&
                   EqualityComparer<AccountEvent>.Default.Equals(AccountEvent, other.AccountEvent);
        }

        public override int GetHashCode()
        {
            var hashCode = -1253467863;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_typeName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<AccountEvent>.Default.GetHashCode(AccountEvent);
            return hashCode;
        }

        public override string ToString()
        {
            return _typeName;
        }
    }
}
