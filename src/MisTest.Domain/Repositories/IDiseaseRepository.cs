using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Domain.Repositories
{
    public interface IDiseaseRepository
    {
        public Task CreateDiseaseAsync(DiseaseEntity diseaseEntity);
        public Task<PagedResult<DiseaseEntity>> GetDiseasesPageAsync(PageParams? pageParams);
        public Task<DiseaseEntity?> GetDisease(string name);
        public Task DeleteDiseaseAsync(Guid id);
    }
}
