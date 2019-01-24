using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context; // Dependência para o DbContext

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
            // Acessa a fonte de dados da tabela de vendedores, e converter para uma lista
            // Opração síncrona = Quando executada, a aplicação fica bloqueada até que termine a operação.
        }

        public void Insert (Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById (int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove (int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges(); //Entities Framework confirma a operação no banco de dados
        }
    }
}
