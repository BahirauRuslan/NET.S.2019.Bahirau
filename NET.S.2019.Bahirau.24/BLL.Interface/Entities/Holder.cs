using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface.Entities
{
    public class Holder : IComparable<Holder>, IEquatable<Holder>
    {
        private string _name;
        private string _surname;
        private IList<long> _accounts;

        public Holder()
        {
            Id = 0;
            _name = string.Empty;
            _surname = string.Empty;
            _accounts = new List<long>();
        }

        public Holder(long id, string name, string surname, IList<long> accounts)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Accounts = accounts;
        }

        public long Id { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value ?? throw new ArgumentNullException("Holder name must not be null");
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = value ?? throw new ArgumentNullException("Holder surname must not be null");
            }
        }

        public IList<long> Accounts
        {
            get
            {
                return _accounts;
            }

            set
            {
                _accounts = value ?? throw new ArgumentNullException("Holder accounts list must not be null");
            }
        }

        public int CompareTo(Holder other)
        {
            if (other == null)
            {
                return 1;
            }

            return _name.CompareTo(other._name);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Holder);
        }

        public bool Equals(Holder other)
        {
            return other != null &&
                   _name == other._name &&
                   _surname == other._surname &&
                   EqualityComparer<IList<long>>.Default.Equals(_accounts, other._accounts) &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 1974344722;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_surname);
            hashCode = (hashCode * -1521134295) + EqualityComparer<IList<long>>.Default.GetHashCode(_accounts);
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var builder = new StringBuilder($"Holder #{ Id }: { _name } { _surname }");

            foreach (var account in Accounts)
            {
                builder.Append('\n');
                builder.Append($"Account #{ account }");
            }

            return builder.ToString();
        }
    }
}
