using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SkinTypeRepository
    {
        private readonly SkincareShopContext _context;

        public SkinTypeRepository()
        {
            _context = new SkincareShopContext();
        }

        public List<SkinType> GetAllSkinTypes()
        {
            return _context.SkinTypes.ToList();
        }
    }
}
