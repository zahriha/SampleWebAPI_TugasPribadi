using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SampleWebAPI.Data.DAL
{
    public class ElementSwordDAL : IElementSword
    {
        private readonly SamuraiContext _context;

        public ElementSwordDAL(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<ElementSword>> GetAll()
        {
            var all = await _context.ElementSword.OrderBy(s => s.DateMade).ToListAsync();
            return all;

        }

        public Task<ElementSword> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ElementSword> Insert(ElementSword obj)
        {
            try
            {
                _context.ElementSword.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Task<ElementSword> Update(ElementSword obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ElementSword> AddElementSword(ElementSword obj)
        {
            ElementSword elsw = new ElementSword();
            var ele = await _context.Elements.FirstOrDefaultAsync(b => b.Id == obj.ElementId);
            var sw = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.SwordId);
            if (ele != null && sw != null)
            {
                ele.Swords.Add(sw);
                await _context.SaveChangesAsync();
                elsw = await _context.ElementSword.Where
                    (es => es.SwordId == obj.SwordId && es.ElementId == obj.ElementId).FirstOrDefaultAsync();

            }
            return elsw;
        }

        public async Task DeleteElementInSword(int id)
        {
            try
            {
                var deleteES = await _context.ElementSword.Where(es => es.SwordId == id).ToListAsync();
                _context.ElementSword.RemoveRange(deleteES);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }
    }
}

