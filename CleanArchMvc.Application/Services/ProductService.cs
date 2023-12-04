using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var categoryEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(categoryEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var categoryEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(categoryEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var categoriesEntity = await _productRepository.GetAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(categoryEntity);

        }

        public async Task Update(ProductDTO productDTO)
        {

            var categoryEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(categoryEntity);
        }
    }
}
