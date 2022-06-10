using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace FinancesWebApi.Models
{
    public class ListFinances
    {
        public ListFinances() { }

        public ListFinances(int id, string description, string category, string account, decimal value,DateTime dateTransaction)
        {
            this.idFinan = id;
            this.descriptionFinan = description;
            this.categoryFinan = category;
            this.accountFinan = account;
            this.valueFinan = value;
            this.dateTransaction = dateTransaction;
        }


        [Key]
        public int idFinan { get; set; }
        public string descriptionFinan { get; set; }
        public string categoryFinan { get; set; }
        public string accountFinan { get; set; }
        public decimal valueFinan { get; set; }
        public DateTime dateTransaction { get; set; }
       
    }
}
