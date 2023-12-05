using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            ProductCreateCommand command = _mapper.Map<ProductCreateCommand>(productDTO);
            var result = await _mediator.Send(command);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            GetProductByIdQuery productByIdQuery = new GetProductByIdQuery(id.Value);

            if(productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
            {
                throw new ApplicationException($"Entity could not be loaded.");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int? id)
        {

            ProductRemoveCommand productCommand = new ProductRemoveCommand(id.Value);

            if(productCommand == null)
            {
                throw new Exception($"Entity cou ld not be loaded");
            }

            await _mediator.Send(productCommand); 

        }

        public async Task Update(ProductDTO productDTO)
        {
            ProductUpdateCommand command = _mapper.Map<ProductUpdateCommand>(productDTO);
            var result = await _mediator.Send(command);
        }
    }
}
