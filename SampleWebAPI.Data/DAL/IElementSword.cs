﻿using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface IElementSword : ICrud<ElementSword>
    {
        Task<ElementSword> AddElementSword(ElementSword obj);
        Task DeleteElementInSword(int id);

    }
}
