using lab6.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petrol_Station.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeAndExpensesOfGsmsController : ControllerBase
    {
        Petrol_StationContext context;
        public IncomeAndExpensesOfGsmsController(Petrol_StationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<IncomeAndExpensesOfGsmViewModel> Get()
        {
            var income = context.IncomeAndExpensesOfGsm.Include(p => p.Staff).Select(s =>
            new IncomeAndExpensesOfGsmViewModel
            {
                StaffId = s.StaffId,
                IncomeAndExpenseOfGsmid = s.IncomeAndExpenseOfGsmid,
                NumberOfCapacity = s.NumberOfCapacity,
                ContainerId = s.ContainerId,
                IncomeOrExpensePerliter = s.IncomeOrExpensePerliter,
                DateAndTimeOfTheOperationIncomeOrExpense = s.DateAndTimeOfTheOperationIncomeOrExpense,
                ResponsibleForTheOperation = s.ResponsibleForTheOperation,
                FullName = s.Staff.FullName
            });
            return income.ToList();
        }
        [HttpGet("staffs")]
        public IEnumerable<Staff> GetStaffs()
        {
            return context.Staff.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IncomeAndExpensesOfGsm income = context.IncomeAndExpensesOfGsm.FirstOrDefault(x => x.IncomeAndExpenseOfGsmid == id);
            if (income == null)
                return NotFound();
            return new ObjectResult(income);
        }
        [HttpPost]
        public IActionResult Post([FromBody] IncomeAndExpensesOfGsm income)
        {
            if(income == null)
            {
                return BadRequest();
            }
            context.IncomeAndExpensesOfGsm.Add(income);
            context.SaveChanges();
            return Ok(income);
        }
        [HttpPut]
        public IActionResult Put([FromBody] IncomeAndExpensesOfGsm income)
        {
            if(income == null)
            {
                return BadRequest();
            }
            if(!context.IncomeAndExpensesOfGsm.Any(x => x.IncomeAndExpenseOfGsmid == income.IncomeAndExpenseOfGsmid))
            {
                return NotFound();
            }
            context.Update(income);
            context.SaveChanges();
            return Ok(income);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IncomeAndExpensesOfGsm income = context.IncomeAndExpensesOfGsm.FirstOrDefault(x => x.IncomeAndExpenseOfGsmid == id);
            if (income == null)
            {
                return NotFound();
            }
            context.IncomeAndExpensesOfGsm.RemoveRange(income);
            context.SaveChanges();
            return Ok(income);
        }
    }
}
