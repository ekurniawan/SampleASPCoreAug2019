using BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPraContract : ICrud<PraContract>
    {
        IEnumerable<PraContract> GetByName(string name);
    }
}
