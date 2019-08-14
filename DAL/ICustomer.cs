using BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomer:ICrud<Customer>
    {
        IEnumerable<Customer> GetByNama(string nama);
    }
}
