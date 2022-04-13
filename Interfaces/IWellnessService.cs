using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssayMe.Core.ViewModels.Cells;

namespace AssayMe.Core.Services.Abstaction
{
    public interface IWellnessService
    {
        Task<List<WellnessItem>> GetItems(string id,bool isTestData);
    }
}
