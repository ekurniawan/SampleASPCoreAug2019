using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DAL
{
    public class CustomerDAL : ICustomer
    {
        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> lstCustomer = new List<Customer>
            {
                new Customer{CustomerID="CC01",CustomerName="Budi",Address="Jl Rajawali"},
                new Customer{CustomerID="CC02",CustomerName="Erick",Address="Jl Merdeka"}
            };
            return lstCustomer;
        }
    }
}
