using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    /// <summary>
    /// String URI mapper.
    /// </summary>
    public static class StringToURIMapper
    {
        /// <summary>
        /// Simple logger.
        /// </summary>
        public static ILogger Logger { get; set; }

        /// <summary>
        /// Convert strings to SimpleURIs.
        /// </summary>
        /// <param name="uris">URI's.</param>
        /// <returns>Simple URI's</returns>
        public static IEnumerable<SimpleURI> ToSimpleURIs(this IEnumerable<string> uris)
        {
            foreach (var uri in uris)
            {
                if (IsValidURI(uri))
                {
                    yield return uri.ToSimpleURI();
                }
                else
                {
                    Logger?.Log($"{uri} - not valid URI");
                }
            }
        }

        /// <summary>
        /// Validates URI string.
        /// </summary>
        /// <param name="uriString">String representation of URI</param>
        /// <returns>True - valid string URI. False - invalid.</returns>
        private static bool IsValidURI(string uriString)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException("String value must not be null.");
            }

            if (string.IsNullOrWhiteSpace(uriString))
            {
                throw new ArgumentException("String value must not be empty.");
            }

            if (!Uri.TryCreate(uriString, UriKind.Absolute, out _))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parses SimpleURI from string.
        /// </summary>
        /// <param name="uriString">String representation of URI.</param>
        /// <returns>SimpleURI object.</returns>
        private static SimpleURI ToSimpleURI(this string uriString)
        {
            var uri = new Uri(uriString);
            var myUri = new SimpleURI(uri.Scheme, uri.Host);
            ParseSegments(myUri, uri);
            ParseParameters(myUri, uri);
            return myUri;
        }

        /// <summary>
        /// Parses URI segments.
        /// </summary>
        /// <param name="myUri">SimpleURI object.</param>
        /// <param name="uri">System.Uri object.</param>
        private static void ParseSegments(SimpleURI myUri, Uri uri)
        {
            for (var i = 1; i < uri.Segments.Length; i++)
            {
                myUri.Segments.Add(uri.Segments[i].Replace("/", string.Empty));
            }
        }

        /// <summary>
        /// Parses URI parameters.
        /// </summary>
        /// <param name="myUri">SimpleURI object.</param>
        /// <param name="uri">System.Uri object.</param>
        private static void ParseParameters(SimpleURI myUri, Uri uri)
        {
            var query = uri.Query;

            if (query != string.Empty)
            {
                query = query.Substring(1);

                foreach (var param in query.Split('&'))
                {
                    var index = param.IndexOf('=');
                    var key = param.Substring(0, index);
                    var value = param.Substring(index + 1);
                    myUri.Parameters.Add(key, value);
                }
            }
        }
    }
}
