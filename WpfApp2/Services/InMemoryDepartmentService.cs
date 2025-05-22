using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfApp2.DBModels;

namespace WpfApp2.Services
{
    public class InMemoryDepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments;
        private readonly List<Person> _persons;
        private readonly List<Position> _positions;
        private readonly List<Child> _children;
        private readonly List<Salary> _salaries;
        private readonly List<Vacation> _vacations;

        public InMemoryDepartmentService()
        {
            // Тестовые отделы
            _departments = new List<Department>
            {
                new Department { Id = 1, Name = "IT Department", Description = "IT and support", CreateAt = DateTime.Now.AddYears(-5) },
                new Department { Id = 2, Name = "HR Department", Description = "Human Resources", CreateAt = DateTime.Now.AddYears(-3) }
            };

            // Тестовые должности
            _positions = new List<Position>
            {
                new Position { Id = 1, Name = "Ведущий инженер", CreateAt = DateTime.Now.AddYears(-5) },
                new Position { Id = 2, Name = "Менеджер", CreateAt = DateTime.Now.AddYears(-3) }
            };

            // Тестовые дети
            _children = new List<Child>
            {
                new Child { Id = 1, FirstName = "Аня", LastName = "Иванова", MidleName = "Ивановна", Birthday = new DateTime(2015, 8, 20), CreateAt = DateTime.Now.AddYears(-8) }
            };

            // Тестовые зарплаты
            _salaries = new List<Salary>
            {
                new Salary { Id = 1, Amount = 70000, BeginDate = new DateTime(2023, 1, 1), CreateAt = DateTime.Now.AddYears(-1) },
                new Salary { Id = 2, Amount = 75000, BeginDate = new DateTime(2023, 7, 1), CreateAt = DateTime.Now.AddMonths(-10) },
                new Salary { Id = 3, Amount = 60000, BeginDate = new DateTime(2022, 1, 1), CreateAt = DateTime.Now.AddYears(-2) },
                new Salary { Id = 4, Amount = 65000, BeginDate = new DateTime(2023, 1, 1), CreateAt = DateTime.Now.AddMonths(-11) }
            };

            // Тестовые отпуска
            _vacations = new List<Vacation>
            {
                new Vacation { Id = 1, BeginDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2023, 6, 14), VacationType = "Ежегодный", CreateAt = DateTime.Now.AddMonths(-12) },
                new Vacation { Id = 2, BeginDate = new DateTime(2022, 7, 10), EndDate = new DateTime(2022, 7, 24), VacationType = "Ежегодный", CreateAt = DateTime.Now.AddMonths(-22) }
            };

            // Тестовые сотрудники
            _persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MidleName = "Иванович",
                    Phone = "+7 900 111-22-33",
                    Email = "ivanov@example.com",
                    Birthday = new DateTime(1990, 5, 12),
                    HireDate = new DateTime(2015, 3, 1),
                    IsMarried = true,
                    NowPlaceLiving = "г. Москва, ул. Пушкина, д. 1",
                    PersonPositions = new List<PersonPosition> { new PersonPosition { Position = _positions[0] } },
                    PersonDepartments = new List<PersonDepartment> { new PersonDepartment { Department = _departments[0] } },
                    PersonSalaries = new List<PersonSalary> { new PersonSalary { Salary = _salaries[0] }, new PersonSalary { Salary = _salaries[1] } },
                    PersonVacations = new List<PersonVacation> { new PersonVacation { Vacation = _vacations[0] } },
                    PersonChildren = new List<PersonChild> { new PersonChild { Child = _children[0], Comment = "Дочь" } }
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    MidleName = "Петрович",
                    Phone = "+7 900 222-33-44",
                    Email = "petrov@example.com",
                    Birthday = new DateTime(1985, 11, 3),
                    HireDate = new DateTime(2010, 9, 15),
                    IsMarried = false,
                    NowPlaceLiving = "г. Санкт-Петербург, пр. Ленина, д. 5",
                    PersonPositions = new List<PersonPosition> { new PersonPosition { Position = _positions[1] } },
                    PersonDepartments = new List<PersonDepartment> { new PersonDepartment { Department = _departments[1] } },
                    PersonSalaries = new List<PersonSalary> { new PersonSalary { Salary = _salaries[2] }, new PersonSalary { Salary = _salaries[3] } },
                    PersonVacations = new List<PersonVacation> { new PersonVacation { Vacation = _vacations[1] } },
                    PersonChildren = new List<PersonChild>()
                }
            };
        }

        public Task<List<Department>> GetAllDepartmentsAsync() => Task.FromResult(_departments.ToList());

        public Task<Department> GetDepartmentByIdAsync(long id) => Task.FromResult(_departments.FirstOrDefault(d => d.Id == id));

        public Task<Department> CreateDepartmentAsync(Department department)
        {
            department.Id = _departments.Max(d => d.Id) + 1;
            department.CreateAt = DateTime.Now;
            _departments.Add(department);
            return Task.FromResult(department);
        }

        public Task<Department> UpdateDepartmentAsync(Department department)
        {
            var dep = _departments.FirstOrDefault(d => d.Id == department.Id);
            if (dep != null)
            {
                dep.Name = department.Name;
                dep.Description = department.Description;
                dep.UpdateAt = DateTime.Now;
            }
            return Task.FromResult(dep);
        }

        public Task DeleteDepartmentAsync(long id)
        {
            var dep = _departments.FirstOrDefault(d => d.Id == id);
            if (dep != null) _departments.Remove(dep);
            return Task.CompletedTask;
        }

        // --- Методы для сотрудников и их данных ---
        public Task<List<Person>> GetPersonsByDepartmentIdAsync(long departmentId)
        {
            var persons = _persons.Where(p => p.PersonDepartments.Any(pd => pd.Department != null && pd.Department.Id == departmentId)).ToList();
            return Task.FromResult(persons);
        }

        public Task<List<PersonSalary>> GetSalariesByPersonIdAsync(long personId)
        {
            var person = _persons.FirstOrDefault(p => p.Id == personId);
            return Task.FromResult(person?.PersonSalaries.ToList() ?? new List<PersonSalary>());
        }

        public Task<List<PersonVacation>> GetVacationsByPersonIdAsync(long personId)
        {
            var person = _persons.FirstOrDefault(p => p.Id == personId);
            return Task.FromResult(person?.PersonVacations.ToList() ?? new List<PersonVacation>());
        }

        public Task<List<PersonChild>> GetChildrenByPersonIdAsync(long personId)
        {
            var person = _persons.FirstOrDefault(p => p.Id == personId);
            return Task.FromResult(person?.PersonChildren.ToList() ?? new List<PersonChild>());
        }

        public Task<List<string>> GetPositionsByPersonIdAsync(long personId)
        {
            var person = _persons.FirstOrDefault(p => p.Id == personId);
            var positions = person?.PersonPositions?.Select(pp => pp.Position?.Name).Where(n => !string.IsNullOrEmpty(n)).ToList() ?? new List<string>();
            return Task.FromResult(positions);
        }
    }
} 