using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DAL
{
    public class CustomerDAL : ICustomer
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> lstCustomer = new List<Customer>
            {
                new Customer{CustomerID=Guid.NewGuid().ToString(),CustomerName="Budi",Address="Jl Rajawali"},
                new Customer{CustomerID=Guid.NewGuid().ToString(),CustomerName="Erick",Address="Jl Merdeka"}
            };


            return lstCustomer;
        }

        public Customer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByNama(string nama)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
