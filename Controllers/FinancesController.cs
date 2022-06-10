using FinancesWebApi.Data;
using FinancesWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesWebApi.Controllers
{
    [ApiController]
    [Route("Finances")] 
    public class FinancesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<ListFinances> finances = GetFinances();
            return Ok(finances);
        }

        [HttpPost]
        public IActionResult Post(ListFinances finance)
        {
            using(var contexto = new DataContext())
            {
                contexto.Financas.Add(finance);
                contexto.SaveChanges();
            }
            return Ok(finance);
        }

        [HttpPut("{idFinan}")]
        public IActionResult Put(int idFinan,ListFinances finance)
        {
            using (var contexto = new DataContext())
            {
                var fin = contexto.Financas.FirstOrDefault(d => d.idFinan == idFinan);
                if(fin == null)
                {
                    return StatusCode(404, "registro não encontrado");
                }

                fin.descriptionFinan = finance.descriptionFinan;
                fin.categoryFinan = finance.categoryFinan;
                fin.accountFinan = finance.accountFinan;
                fin.valueFinan = finance.valueFinan;
                fin.dateTransaction = finance.dateTransaction;
                contexto.Financas.Update(fin);
                contexto.SaveChanges();
            }
            return Ok(finance);
        }

        [HttpDelete("{idFinan}")]
        public IActionResult Delete(int idFinan)
        {
            using(var contexto = new DataContext())
            {
                var finResult = contexto.Financas.FirstOrDefault(d => d.idFinan == idFinan);
                
                contexto.Remove(finResult);
                contexto.SaveChanges();
            }
            return Ok("ok");
        }
        public List<ListFinances> GetFinances()
        {
            List<ListFinances> finances = new List<ListFinances>();
            using (var repo = new DataContext())
            {
                IList<ListFinances> financas = repo.Financas.ToList();
                foreach (var item in financas)
                {
                    finances.Add(item);
                }
            }
            return finances;
        }

        public static void Post()
        {

        }
    }

}
