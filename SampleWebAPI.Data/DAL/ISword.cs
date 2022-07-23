﻿using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface ISword : ICrud<Sword>
    {
        Task<IEnumerable<Sword>> GetByName(string name);
        Task<IEnumerable<Sword>> GetSwordType();
        Task<IEnumerable<Sword>> GetSwordAll();
        Task DeleteElementInSw(int id);
        Task <Sword> AddSwordType(Sword obj);
        Task <Sword> AddToExistingElement(Sword obj);
    }
}
