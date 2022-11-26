using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.Exceptions;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }
        public async Task<Setting> CreateAsync(Setting setting)
        {
            if (await _unitOfWork.SettingRepository.IsExistAsync(x => x.Key.ToLower().Trim() == setting.Key.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Value already exist with name " + setting.Key);
            }
            if (setting.ImageFile != null)
            {
                setting.Value = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.ImageFile);
            }

            await _unitOfWork.SettingRepository.AddAsync(setting);
            await _unitOfWork.CommitAsync();

            return setting;
        }

        public PaginatedListDto<Setting> GetAllProd(int page)
        {
            var query = _unitOfWork.SettingRepository.GetAll();
            int pageSize = 3;

            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<Setting>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            var setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);

            if (setting == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return setting;
        }


        public async Task UpdateAsync(int id, Setting setting)
        {
            var existSetting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);

            if (existSetting == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.SettingRepository.IsExistAsync(x => x.Id != id && x.Key.ToLower().Trim() == setting.Key.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Value already exist with name " + setting.Key);
            }
            if (setting.ImageFile != null)
            {
                setting.Value = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.ImageFile);

                FileManager.Delete(_env.WebRootPath,"uploads/settings",existSetting.Value);
            }

            existSetting.Value = setting.Value;
            existSetting.Key = setting.Key;

            await _unitOfWork.CommitAsync();
        }
    }
}
