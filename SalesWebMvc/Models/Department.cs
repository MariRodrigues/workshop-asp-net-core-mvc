using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        // Utiliza-se o ICollection pois é a lista mais genérica. 
        // Faz a associação de Departamento, com o vendedor (seller)
        // Pois, cada departamento terá vários vendedores. 

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller (Seller seller)
        { //Adiciona um vendedor no departamento
            Sellers.Add(seller);
        }

        public double TotalSales (DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
            // Para todos os vendedores do departamento, de Seller, chama o método TotalSales 
            // mandando como argumento as datas desejadas, e soma os resultados
        }

    }
}
