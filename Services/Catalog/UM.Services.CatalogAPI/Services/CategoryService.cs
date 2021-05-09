using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UM.Services.CatalogAPI.Dtos;
using UM.Services.CatalogAPI.Models;
using UM.Services.CatalogAPI.Settings;
using UM.Shared.SharedLib.Dtos;

namespace UM.Services.CatalogAPI.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(I => I.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Response<CategoryDto>.Fail("Category not found", 404);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(categoryCreateDto));
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(categoryCreateDto), 200);
        }

    }
}
