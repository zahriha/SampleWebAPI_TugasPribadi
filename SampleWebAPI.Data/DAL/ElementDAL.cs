using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class ElementDAL : IElement
    {
        private readonly SamuraiContext _context;

        public ElementDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var element = await _context.Elements.FirstOrDefaultAsync(e => e.Id == id);
                if (element == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Elements.Remove(element);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteElementInSw(int id)
        {
            var deleteSw = await _context.Elements.FirstOrDefaultAsync(s => s.Id == id);
            foreach (var ele in deleteSw.Swords)
            {

                var elem = new Sword
                {
                    Id = ele.Id
                };
                _context.Swords.Attach(elem);
                deleteSw.Swords.Remove(elem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Element>> GetAll()
        {
            var element = await _context.Elements.OrderBy(s => s.ElementName).ToListAsync();
            return element;
        }

        public async Task<Element> GetById(int id)
        {
            var element = await _context.Elements.FirstOrDefaultAsync(s => s.Id == id);
            if (element == null)
                throw new Exception($"Data Element dengan id {id} tidak ditemukan");
            return element;
        }

        public async Task<IEnumerable<Element>> GetByName(string name)
        {
            var element = await _context.Elements.Where(e => e.ElementName.Contains(name))
                .OrderBy(s => s.ElementName).ToListAsync();
            return element;
        }

        public async Task<Element> Insert(Element obj)
        {
            _context.Elements.Add(obj);
            await _context.SaveChangesAsync();
            return obj;

        }

        public async Task<Element> Update(Element obj)
        {
            var upElement = await _context.Elements.FirstOrDefaultAsync(e => e.Id == obj.Id);
            if (upElement == null)
                throw new Exception($"Data Element dengan id {obj.Id} tidak bisa ditemukan");
            upElement.ElementName = obj.ElementName;
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
