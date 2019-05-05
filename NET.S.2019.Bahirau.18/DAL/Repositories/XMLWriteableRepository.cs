using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Repository that can write URI to xml file.
    /// </summary>
    public class XMLWriteableRepository : FileRepository, IWriteableRepository<DTOSimpleURI>
    {
        /// <summary>
        /// Creates XMLWriteableRepository.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when filePath is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when filePath is empty. -or- file doesn't exist.
        /// </exception>
        public XMLWriteableRepository(string filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Write all DTOSimpleURIs.
        /// </summary>
        /// <param name="items">DTOSimpleURIs.</param>
        public void WriteAll(IEnumerable<DTOSimpleURI> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Items must not be null");
            }

            var document = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(
                    "urlAddresses",
                    items.Select(item =>
                        new XElement(
                            "urlAddress",
                            new XElement("scheme", new XAttribute("name", item.Scheme)),
                            new XElement("host", new XAttribute("name", item.Host)),
                            new XElement(
                                "uri",
                                item.Segments.Select(segment =>
                                    new XElement("segment", segment))),
                            new XElement(
                                "parameters",
                                item.Parameters.Select(param =>
                                    new XElement(
                                        "parameter",
                                        new XAttribute("key", param.Key),
                                        new XAttribute("value", param.Value))))))));
            document.Save(this.FilePath);
        }
    }
}
