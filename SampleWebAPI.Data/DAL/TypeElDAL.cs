using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class TypeElDAL : ITypeEl
    {
        private readonly SamuraiContext _context;

        public TypeElDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var deleteType = await _context.TypeEls.FirstOrDefaultAsync(s => s.Id == id);
            if (deleteType == null)
                throw new Exception($"Data Sword dengan {id} tidak ditemukan");
            _context.TypeEls.Remove(deleteType);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<TypeEl>> GetAll()
        {
            var result= await _context.TypeEls.OrderBy(s => s.TypeE).ToListAsync();  
            return result;
        }

        public async Task<TypeEl> GetById(int id)
        {
            var result = await _context.TypeEls.FirstOrDefaultAsync(t => t.Id == id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;
        }

        public async Task<TypeEl> Insert(TypeEl obj)
        {
            try
            {
                _context.TypeEls.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<TypeEl> Update(TypeEl obj)
        {
            try
            {
                var updateType = await _context.TypeEls.FirstOrDefaultAsync(t => t.Id == obj.Id);
                if (updateType == null)
                    throw new Exception($"Data Sword dengan {obj.Id} tidak bisa ditemukan");
                updateType.TypeE = obj.TypeE;
                updateType.SwordId=obj.SwordId;

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");

            }
        }
    }
}
