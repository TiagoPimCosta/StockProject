using AutoMapper;
using StockProject.Entities;
using StockProject.Models;
using StockProject.Repositories;
using System;
using System.Collections.Generic;

namespace StockProject.Business
{
    public class StoreBusiness : IBusinessStore
    {
        private readonly IRepositoryStore _storeRepository;
        private readonly IMapper _mapper;

        public StoreBusiness(IRepositoryStore repository, IMapper mapper)
        {
            _storeRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<StoreDto> GetStores()
        {
            var stores = _storeRepository.GetStores();
            return _mapper.Map<IEnumerable<StoreDto>>(stores);
        }
        public StoreDto GetStore(string name)
        {
            var store = _storeRepository.GetStore(name);
            return _mapper.Map<StoreDto>(store);
        }
        public void AddStore(StoreDto storeDto)
        {
            var store = _storeRepository.GetStore(storeDto.Name);
            if(store != null)
            {
                throw new Exception($"{storeDto.Name} Store already exist.");
            }

            _storeRepository.AddStore(_mapper.Map<Store>(storeDto));
        }
        public void RemoveStore(DeleteStoreDto deleteStoreDto)
        {
            _storeRepository.RemoveStore(_mapper.Map<DeleteStoreDto>(deleteStoreDto));

        }

        public void UpdateStore(StoreDto storeDto)
        {
            _storeRepository.UpdateStore(_mapper.Map<Store>(storeDto));
        }
    }
}
