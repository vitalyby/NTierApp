﻿using NTierApp.BLL.Models;
using NTierApp.DAL.Entities;
using NTierApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.BLL.Interfaces
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork database;
        public EmployeeService(IUnitOfWork uow)
        {
            this.database = uow;
        }

        public IEnumerable<EmployeeModel> GetAllEmloyees()
        {
            var employees = database.Employees.GetAll().ToList();
            var mapper = Automapper.GetMapper();
            var employeesModel = employees.Select(x => mapper.Map(x, typeof(Employee), typeof(EmployeeModel)) as EmployeeModel).ToList();
            return employeesModel;
        }

        public void AddEmployee(EmployeeModel model)
        {

            Employee employee = new Employee { FirstName = model.FirstName, LastName = model.LastName };
            database.Employees.Create(employee);
            database.Save();
        }
    }
}
