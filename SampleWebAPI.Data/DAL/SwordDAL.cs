using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class SwordDAL : ISword
    {
        private readonly SamuraiContext _context;
        public SwordDAL(SamuraiContext context)
        {
            _context = context;
        }
        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
                   
        }
        public async Task<Sword> AddSwordType(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var sw = await _context.Swords.FirstOrDefaultAsync(e => e.Id == id);
                if (sw == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Swords.Remove(sw);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteElementInSw(int id)
        {
            var deleteSw = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            foreach (var ele in deleteSw.Elements)
            {
                
                var elem = new Element
                {
                    Id = ele.Id
                };
                _context.Elements.Attach(elem);
                deleteSw.Elements.Remove(elem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var result = await _context.Swords.OrderBy(s => s.Weight).ToListAsync();
            return result;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;

        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var re = await _context.Swords.Where(s => s.Name.Contains(name))
                .OrderBy(s => s.Name).ToListAsync();
            return re;
        }

        public async Task<IEnumerable<Sword>> GetSwordAll()
        {
            var result = await _context.Swords.Include(s => s.TypeEl)
                
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Sword>> GetSwordType()
        {
            var result = await _context.Swords.Include(s => s.TypeEl).ToListAsync();
            return result;
        }
        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var updataSw = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updataSw == null)
                    throw new Exception($"Data Sword dengan {obj.Id} tidak bisa ditemukan");
                updataSw.Name = obj.Name;
                updataSw.Weight = obj.Weight;
                updataSw.SamuraiId = obj.SamuraiId;

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }

        }
        public async Task<Sword> AddToExistingElement(Sword obj)
        {
            var sw = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.Id);
            var ele = await _context.Elements.FirstOrDefaultAsync(s => s.Id == obj.Id);

            if (sw == null)
                throw new Exception($"Data Sword dengan {obj.Id} tidak bisa ditemukan");

           // sw.Elements.Add(ele);
            //sw.Elements.Add(new Element { ElementName =  });
            foreach (var e in sw.Elements.ToList())
             {
                 var elem = new Element()
                 {
                     ElementName = ele.ElementName,
                 };

                 sw.Elements.Add(elem);
             }
            await _context.SaveChangesAsync();
            return sw;


        }

       
    }
}
