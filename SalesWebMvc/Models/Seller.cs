﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; } // Adicionada para que o ID seja uma Foreign Key (not null)
        public ICollection<SalesRecord> Sales { get; set; } = new LinkedList<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        { //Método para adicionar vendas
            Sales.Add(sr);
        }

        public void RemoveSales (SalesRecord sr)
        { //Remove vendas do vendedor
            Sales.Remove(sr);
        }

        public double TotalSales (DateTime initial, DateTime final) 
        { //Calcula o total de vendas (em dinheiro) do vendedor
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final). // Filtra as datas
                Sum(sr => sr.Amount); // Soma os 'amounts' referentes à data filtrada
        }


    }
}
