using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class which is a simple URI.
    /// </summary>
    public class SimpleURI
    {
        /// <summary>
        /// Creates a SimpleURI with empty segments and parameters.
        /// </summary>
        /// <param name="scheme">URI scheme.</param>
        /// <param name="host">URI host.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when scheme is null. -or- host is null.
        /// </exception>
        public SimpleURI(string scheme, string host) 
            : this(scheme, host, new List<string>(), new Dictionary<string, string>())
        {
        }

        /// <summary>
        /// Creates a SimpleURI.
        /// </summary>
        /// <param name="scheme">URI scheme.</param>
        /// <param name="host">URI host.</param>
        /// <param name="segments">URI segments.</param>
        /// <param name="parameters">URI parameters.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when scheme is null. -or- host is null. -or- segments is null. -or- parameters is null.
        /// </exception>
        public SimpleURI(string scheme, string host, IList<string> segments, IDictionary<string, string> parameters)
        {
            Scheme = scheme ?? throw new ArgumentNullException("Scheme must not be null");
            Host = host ?? throw new ArgumentNullException("Host must not be null");
            Segments = segments ?? throw new ArgumentNullException("Segments list must not be null");
            Parameters = parameters ?? throw new ArgumentNullException("Parameters must not be null");
        }

        /// <summary>
        /// URI scheme.
        /// </summary>
        public string Scheme { get; }

        /// <summary>
        /// URI host.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// URI segments.
        /// </summary>
        public IList<string> Segments { get; }

        /// <summary>
        /// URI parameters.
        /// </summary>
        public IDictionary<string, string> Parameters { get; }

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
