using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pruebatecnica.Models;
using Refit;

namespace pruebatecnica.Data.Network.Interfaces
{
    public interface IProducts
    {
        
        [Get("/Products")]
        Task<List<Root>> GetProducts();



    }
}


