using BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomer();
    }
}
