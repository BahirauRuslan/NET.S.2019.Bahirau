using System;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Class that represent exporter.
    /// </summary>
    public class Exporter : IExporter
    {
        /// <summary>
        /// Creates Exporter object.
        /// </summary>
        /// <param name="fromRepository">Input repository.</param>
        /// <param name="toRepository">Output repository.</param>
        /// <param name="logger">Logger.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when fromRepository is null. -or- toRepository is null.
        /// </exception>
        public Exporter(
            IReadableRepository<string> fromRepository, 
            IWriteableRepository<DTOSimpleURI> toRepository, 
            ILogger logger = null)
        {
            FromRepository = fromRepository ?? throw new ArgumentNullException("FromRepository must not be null");
            ToRepository = toRepository ?? throw new ArgumentNullException("ToRepository must not be null");
            StringToURIMapper.Logger = logger;
        }

        /// <summary>
        /// Input repository.
        /// </summary>
        public IReadableRepository<string> FromRepository { get; }

        /// <summary>
        /// Output repository.
        /// </summary>
        public IWriteableRepository<DTOSimpleURI> ToRepository { get; }

        /// <summary>
        /// Exports all URIs.
        /// </summary>
        public void ExportAll()
        {
            var uris = FromRepository.GetAll().ToSimpleURIs();
            ToRepository.WriteAll(uris.ToDTOSimpleURIs());
        }
    }
}
