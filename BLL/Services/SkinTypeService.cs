using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkinTypeService
    {
        private readonly SkinTypeRepository _skinTypeRepository;

        public SkinTypeService()
        {
            _skinTypeRepository = new SkinTypeRepository();
        }

        public List<SkinType> GetAllSkinTypes()
        {
            return _skinTypeRepository.GetAllSkinTypes();
        }
    }
}
