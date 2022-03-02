using AutoMapper;
using StockProject.Entities;
using StockProject.Models;
using StockProject.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
            return _mapper.Map<IEnumerable<StoreDto>>(_storeRepository.GetStores());
        }

        public StoreDto GetStore(string name)
        {
            return _mapper.Map<StoreDto>(_storeRepository.GetStore(name));
        }
        public StoreDto GetStore(Guid guid)
        {
            return _mapper.Map<StoreDto>(_storeRepository.GetStore(guid));
        }

        public void AddStore(StoreDto storeDto)
        {
            var store = _storeRepository.GetStore(storeDto.Code);
            if(store != null)
            {
                throw new Exception($"{storeDto.Name} Store already exist.");
            }

            _storeRepository.AddStore(_mapper.Map<Store>(storeDto));
        }
        public void RemoveStore(Guid code)
        {
            var store = _storeRepository.GetStore(code).Code;

            if (store == null)
            {
                throw new Exception();
            }

            _storeRepository.RemoveStore(code);

        }

        public void UpdateStore(StoreDto storeDto)
        {
            var checkStore = _storeRepository.GetStore(storeDto.Code).Name;

            if (checkStore == null)
            {
                throw new Exception($"{storeDto.Name} Store was not found.");
            }

            _storeRepository.UpdateStore(_mapper.Map<Store>(storeDto));
        }
    }
}
