using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DTO SimpleURI.
    /// </summary>
    public class DTOSimpleURI
    {
        /// <summary>
        /// URI scheme.
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// URI host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// URI segments.
        /// </summary>
        public IList<string> Segments { get; set; }

        /// <summary>
        /// URI parameters.
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Gets a string representation of URI.
        /// </summary>
        /// <returns>String URI.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder($"{ Scheme }://{ Host }");

            if (Segments.Count > 0)
            {
                foreach (var segment in Segments)
                {
                    builder.Append('/');
                    builder.Append(segment);
                }
            }

            if (Parameters.Count > 0)
            {
                var parameters = from key in Parameters.Keys select $"{ key }={ Parameters[key] }";
                builder.Append('?');
                builder.Append(string.Join("&", parameters));
            }

            return builder.ToString();
        }
    }
}
