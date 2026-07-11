using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ReactAPI.Models;
using System.Web.Http.Cors;
using System.IO;
using Newtonsoft.Json;

namespace ReactAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000,http://localhost:3001",
                headers: "*",
                methods: "*")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Employee> Get(string name = "")
        {
            //var employees = new List<Employee>()
            //{
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "สมชาย",
            //        Department = "IT",
            //        Salary = 50000
            //    },

            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "สมหญิง",
            //        Department = "HR",
            //        Salary = 45000
            //    },
            //    new Employee
            //    {
            //        Id = 3,
            //        Name = "มาลี",
            //        Department = "IT",
            //        Salary = 50000
            //    },

            //    new Employee
            //    {
            //        Id = 4,
            //        Name = "วีนา",
            //        Department = "Sale",
            //        Salary = 45000
            //    },
            //    new Employee
            //    {
            //        Id = 5,
            //        Name = "ปิติ",
            //        Department = "Engineer",
            //        Salary = 23442
            //    },

            //    new Employee
            //    {
            //        Id = 6,
            //        Name = "ปรีดา",
            //        Department = "คลัง",
            //        Salary = 14002
            //    },
            //    new Employee
            //    {
            //        Id = 7,
            //        Name = "ปรึดิ",
            //        Department = "WH",
            //        Salary = 21123
            //    },

            //    new Employee
            //    {
            //        Id = 8,
            //        Name = "กิริ",
            //        Department = "จัดซื้อ",
            //        Salary = 43000
            //    },
            //    new Employee
            //    {
            //        Id = 9,
            //        Name = "ทวิ",
            //        Department = "Prod",
            //        Salary = 42211
            //    },

            //    new Employee
            //    {
            //        Id = 10,
            //        Name = "กริติ",
            //        Department = "TOD",
            //        Salary = 12532
            //    }

            //};


            // ถ้ามีการค้นหา
            //if (!string.IsNullOrEmpty(name))
            //{
            //    employees = employees
            //        .Where(x => x.Name.Contains(name))
            //        .ToList();
            //}

            string file = System.Web.Hosting.HostingEnvironment
                .MapPath("~/App_Data/employees.json");

            string json = File.ReadAllText(file);

            List<Employee> employees =
                JsonConvert.DeserializeObject<List<Employee>>(json);

            if (!string.IsNullOrEmpty(name))
            {
                employees = employees
                    .Where(x => x.Name.Contains(name))
                    .ToList();
            }

            return employees;
        }

        [HttpPost]
        public IHttpActionResult Post(Employee emp)
        {
            string file = System.Web.Hosting.HostingEnvironment
                .MapPath("~/App_Data/employees.json");

            string json = File.ReadAllText(file);

            List<Employee> employees =
                JsonConvert.DeserializeObject<List<Employee>>(json);

            // ตรวจสอบข้อมูลซ้ำตาม Id
            if (employees.Any(x => x.Id == emp.Id))
            {
                return BadRequest("Employee ID already exists.");
            }

            employees.Add(emp);

            json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            File.WriteAllText(file, json);

            return Ok(emp);
        }

        [HttpPut]
        public IHttpActionResult Put(Employee emp)
        {
            string file = System.Web.Hosting.HostingEnvironment
                .MapPath("~/App_Data/employees.json");

            string json = File.ReadAllText(file);

            List<Employee> employees =
                JsonConvert.DeserializeObject<List<Employee>>(json);

            Employee oldEmp = employees.FirstOrDefault(x => x.Id == emp.Id);

            if (oldEmp == null)
            {
                return NotFound();
            }

            oldEmp.Name = emp.Name;
            oldEmp.Department = emp.Department;
            oldEmp.Salary = emp.Salary;

            json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            File.WriteAllText(file, json);

            return Ok(oldEmp);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            string file = System.Web.Hosting.HostingEnvironment
                .MapPath("~/App_Data/employees.json");

            string json = File.ReadAllText(file);

            List<Employee> employees =
                JsonConvert.DeserializeObject<List<Employee>>(json);

            Employee emp = employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            employees.Remove(emp);

            json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            File.WriteAllText(file, json);

            return Ok();
        }

    }
}