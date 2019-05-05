using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// SimpleURIMapper static class.
    /// </summary>
    public static class SimpleURIMapper
    {
        /// <summary>
        /// Converts SimpleURI to DTOSimpleURI.
        /// </summary>
        /// <param name="simpleURI">SimpleURI object.</param>
        /// <returns>DTOSimpleURI object.</returns>
        public static DTOSimpleURI ToDTOSimpleURI(this SimpleURI simpleURI)
        {
            return new DTOSimpleURI
            {
                Scheme = simpleURI.Scheme,
                Host = simpleURI.Host,
                Segments = simpleURI.Segments,
                Parameters = simpleURI.Parameters
            };
        }

        /// <summary>
        /// Converts DTOSimpleURI to SimpleURI.
        /// </summary>
        /// <param name="dtoSimpleURI">DTOSimpleURI object.</param>
        /// <returns>SimpleURI object.</returns>
        public static SimpleURI ToSimpleURI(this DTOSimpleURI dtoSimpleURI)
        {
            return new SimpleURI(
                dtoSimpleURI.Scheme, 
                dtoSimpleURI.Host, 
                dtoSimpleURI.Segments, 
                dtoSimpleURI.Parameters);
        }

        /// <summary>
        /// Converts SimpleURIs to DTOSimpleURIs.
        /// </summary>
        /// <param name="simpleURIs">SimpleURI objects.</param>
        /// <returns>DTOSimpleURI object.</returns>
        public static IEnumerable<DTOSimpleURI> ToDTOSimpleURIs(this IEnumerable<SimpleURI> simpleURIs)
        {
            foreach (var simpleURI in simpleURIs)
            {
                yield return simpleURI.ToDTOSimpleURI();
            }
        }

        /// <summary>
        /// Converts DTOSimpleURI to SimpleURI.
        /// </summary>
        /// <param name="dtoSimpleURIs">DTOSimpleURI object.</param>
        /// <returns>SimpleURI objects.</returns>
        public static IEnumerable<SimpleURI> ToSimpleURIs(this IEnumerable<DTOSimpleURI> dtoSimpleURIs)
        {
            foreach (var dtoSimpleURI in dtoSimpleURIs)
            {
                yield return dtoSimpleURI.ToSimpleURI();
            }
        }
    }
}
