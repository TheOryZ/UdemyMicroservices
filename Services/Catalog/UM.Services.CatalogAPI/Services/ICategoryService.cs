using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UM.Services.CatalogAPI.Dtos;
using UM.Shared.SharedLib.Dtos;

namespace UM.Services.CatalogAPI.Services
{
    internal interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
