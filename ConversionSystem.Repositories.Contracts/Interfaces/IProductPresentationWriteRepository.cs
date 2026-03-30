using ConversionSystem.Context.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionSystem.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий записи <see cref="ProductPresentation"/>
    /// </summary>
    public interface IProductPresentationWriteRepository : IRepositoryWriter<ProductPresentation> { }
}
