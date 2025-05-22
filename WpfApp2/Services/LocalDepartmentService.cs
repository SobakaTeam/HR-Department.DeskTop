using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using WpfApp2.DBModels;

namespace WpfApp2.Services
{
    public class LocalDepartmentService : IDepartmentService
    {
        private readonly string _connectionString;

        public LocalDepartmentService()
        {
            _connectionString = "Data Source=hr_department.db";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    // Создание таблиц
                    command.CommandText = @"
CREATE TABLE IF NOT EXISTS Department (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Description TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT
);
CREATE TABLE IF NOT EXISTS Person (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT,
    LastName TEXT,
    MidleName TEXT,
    Phone TEXT,
    Email TEXT,
    Birthday TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT,
    IsWorking INTEGER,
    IsMarried INTEGER,
    NowPlaceLiving TEXT,
    HireDate TEXT
);
CREATE TABLE IF NOT EXISTS Position (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Description TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT
);
CREATE TABLE IF NOT EXISTS PersonPosition (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Person_ID INTEGER NOT NULL,
    Position_ID INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS PersonDepartment (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Person_ID INTEGER NOT NULL,
    Department_ID INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS Salary (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Amount REAL NOT NULL,
    BeginDate TEXT NOT NULL,
    EndDate TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT
);
CREATE TABLE IF NOT EXISTS PersonSalary (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Person_ID INTEGER NOT NULL,
    Salary_ID INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS Vacation (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    BeginDate TEXT NOT NULL,
    EndDate TEXT,
    VacationType TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT
);
CREATE TABLE IF NOT EXISTS PersonVacation (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Person_ID INTEGER NOT NULL,
    Vacation_ID INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS Child (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT,
    LastName TEXT,
    MidleName TEXT,
    Birthday TEXT,
    CreateAt TEXT NOT NULL,
    UpdateAt TEXT
);
CREATE TABLE IF NOT EXISTS PersonChild (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Person_ID INTEGER NOT NULL,
    Child_ID INTEGER NOT NULL,
    Comment TEXT
);
";
                    command.ExecuteNonQuery();

                    // Проверка и добавление тестовых данных
                    command.CommandText = "SELECT COUNT(*) FROM Department;";
                    var depCount = Convert.ToInt32(command.ExecuteScalar());
                    if (depCount == 0)
                    {
                        // Добавляем отделы
                        command.CommandText = "INSERT INTO Department (Name, Description, CreateAt) VALUES ('IT Department', 'IT and support', date('now')), ('HR Department', 'Human Resources', date('now'));";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = "SELECT COUNT(*) FROM Person;";
                    var personCount = Convert.ToInt32(command.ExecuteScalar());
                    if (personCount == 0)
                    {
                        // Добавляем сотрудников
                        command.CommandText = "INSERT INTO Person (FirstName, LastName, MidleName, Phone, Email, Birthday, CreateAt, IsMarried, NowPlaceLiving, HireDate) VALUES " +
                            "('Иван', 'Иванов', 'Иванович', '+7 900 111-22-33', 'ivanov@example.com', '1990-05-12', date('now'), 1, 'г. Москва, ул. Пушкина, д. 1', '2015-03-01')," +
                            "('Петр', 'Петров', 'Петрович', '+7 900 222-33-44', 'petrov@example.com', '1985-11-03', date('now'), 0, 'г. Санкт-Петербург, пр. Ленина, д. 5', '2010-09-15');";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = "SELECT COUNT(*) FROM Position;";
                    var posCount = Convert.ToInt32(command.ExecuteScalar());
                    if (posCount == 0)
                    {
                        command.CommandText = "INSERT INTO Position (Name, Description, CreateAt) VALUES ('Ведущий инженер', 'Инженер отдела', date('now')), ('Менеджер', 'Менеджер отдела', date('now'));";
                        command.ExecuteNonQuery();
                    }

                    // Связи сотрудник-должность
                    command.CommandText = "SELECT COUNT(*) FROM PersonPosition;";
                    var ppCount = Convert.ToInt32(command.ExecuteScalar());
                    if (ppCount == 0)
                    {
                        command.CommandText = "INSERT INTO PersonPosition (Person_ID, Position_ID) VALUES (1, 1), (2, 2);";
                        command.ExecuteNonQuery();
                    }

                    // Связи сотрудник-отдел
                    command.CommandText = "SELECT COUNT(*) FROM PersonDepartment;";
                    var pdCount = Convert.ToInt32(command.ExecuteScalar());
                    if (pdCount == 0)
                    {
                        command.CommandText = "INSERT INTO PersonDepartment (Person_ID, Department_ID) VALUES (1, 1), (2, 2);";
                        command.ExecuteNonQuery();
                    }

                    // Зарплаты
                    command.CommandText = "SELECT COUNT(*) FROM Salary;";
                    var salaryCount = Convert.ToInt32(command.ExecuteScalar());
                    if (salaryCount == 0)
                    {
                        command.CommandText = "INSERT INTO Salary (Amount, BeginDate, CreateAt) VALUES (70000, '2023-01-01', date('now')), (75000, '2023-07-01', date('now')), (60000, '2022-01-01', date('now')), (65000, '2023-01-01', date('now'));";
                        command.ExecuteNonQuery();
                    }
                    // Связи сотрудник-зарплата
                    command.CommandText = "SELECT COUNT(*) FROM PersonSalary;";
                    var psCount = Convert.ToInt32(command.ExecuteScalar());
                    if (psCount == 0)
                    {
                        command.CommandText = "INSERT INTO PersonSalary (Person_ID, Salary_ID) VALUES (1, 1), (1, 2), (2, 3), (2, 4);";
                        command.ExecuteNonQuery();
                    }

                    // Отпуска
                    command.CommandText = "SELECT COUNT(*) FROM Vacation;";
                    var vacCount = Convert.ToInt32(command.ExecuteScalar());
                    if (vacCount == 0)
                    {
                        command.CommandText = "INSERT INTO Vacation (BeginDate, EndDate, VacationType, CreateAt) VALUES ('2023-06-01', '2023-06-14', 'Ежегодный', date('now')), ('2022-07-10', '2022-07-24', 'Ежегодный', date('now'));";
                        command.ExecuteNonQuery();
                    }
                    // Связи сотрудник-отпуск
                    command.CommandText = "SELECT COUNT(*) FROM PersonVacation;";
                    var pvCount = Convert.ToInt32(command.ExecuteScalar());
                    if (pvCount == 0)
                    {
                        command.CommandText = "INSERT INTO PersonVacation (Person_ID, Vacation_ID) VALUES (1, 1), (2, 2);";
                        command.ExecuteNonQuery();
                    }

                    // Дети
                    command.CommandText = "SELECT COUNT(*) FROM Child;";
                    var childCount = Convert.ToInt32(command.ExecuteScalar());
                    if (childCount == 0)
                    {
                        command.CommandText = "INSERT INTO Child (FirstName, LastName, MidleName, Birthday, CreateAt) VALUES ('Аня', 'Иванова', 'Ивановна', '2015-08-20', date('now'));";
                        command.ExecuteNonQuery();
                    }
                    // Связи сотрудник-ребёнок
                    command.CommandText = "SELECT COUNT(*) FROM PersonChild;";
                    var pcCount = Convert.ToInt32(command.ExecuteScalar());
                    if (pcCount == 0)
                    {
                        command.CommandText = "INSERT INTO PersonChild (Person_ID, Child_ID, Comment) VALUES (1, 1, 'Дочь');";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var departments = new List<Department>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department;";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            departments.Add(new Department
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                CreateAt = DateTime.Parse(reader.GetString(3)),
                                UpdateAt = reader.IsDBNull(4) ? (DateTime?)null : DateTime.Parse(reader.GetString(4))
                            });
                        }
                    }
                }
            }
            return departments;
        }

        public async Task<Department> GetDepartmentByIdAsync(long id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department WHERE ID = @ID;";
                    command.Parameters.AddWithValue("@ID", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Department
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                CreateAt = DateTime.Parse(reader.GetString(3)),
                                UpdateAt = reader.IsDBNull(4) ? (DateTime?)null : DateTime.Parse(reader.GetString(4))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO Department (Name, Description, CreateAt)
                        VALUES (@Name, @Description, @CreateAt);
                        SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@Name", department.Name);
                    command.Parameters.AddWithValue("@Description", (object)department.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreateAt", department.CreateAt.ToString("yyyy-MM-dd"));
                    var id = Convert.ToInt64(await command.ExecuteScalarAsync());
                    department.Id = id;
                }
            }
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE Department 
                        SET Name = @Name, 
                            Description = @Description, 
                            UpdateAt = @UpdateAt
                        WHERE ID = @ID;";
                    command.Parameters.AddWithValue("@ID", department.Id);
                    command.Parameters.AddWithValue("@Name", department.Name);
                    command.Parameters.AddWithValue("@Description", (object)department.Description ?? DBNull.Value);
                    object updateAtValue;
                    if (department.UpdateAt.HasValue)
                        updateAtValue = department.UpdateAt.Value.ToString("yyyy-MM-dd");
                    else
                        updateAtValue = DBNull.Value;
                    command.Parameters.AddWithValue("@UpdateAt", updateAtValue);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return department;
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Department WHERE ID = @ID;";
                    command.Parameters.AddWithValue("@ID", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Person>> GetPersonsByDepartmentIdAsync(long departmentId)
        {
            var persons = new List<Person>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT p.* FROM Person p
                        INNER JOIN PersonDepartment pd ON p.ID = pd.Person_ID
                        WHERE pd.Department_ID = @DepartmentId;";
                    command.Parameters.AddWithValue("@DepartmentId", departmentId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            persons.Add(new Person
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("ID")),
                                FirstName = reader["FirstName"] as string,
                                LastName = reader["LastName"] as string,
                                MidleName = reader["MidleName"] as string,
                                Phone = reader["Phone"] as string,
                                Email = reader["Email"] as string,
                                Birthday = reader["Birthday"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["Birthday"].ToString()) : null,
                                CreateAt = DateTime.Parse(reader["CreateAt"].ToString()),
                                UpdateAt = reader["UpdateAt"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["UpdateAt"].ToString()) : null,
                                IsWorking = reader["IsWorking"] != DBNull.Value ? (Convert.ToInt32(reader["IsWorking"]) == 1) : (bool?)null,
                                IsMarried = reader["IsMarried"] != DBNull.Value ? (Convert.ToInt32(reader["IsMarried"]) == 1) : (bool?)null,
                                NowPlaceLiving = reader["NowPlaceLiving"] as string,
                                HireDate = reader["HireDate"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["HireDate"].ToString()) : null
                            });
                        }
                    }
                }
            }
            return persons;
        }

        public async Task<List<PersonSalary>> GetSalariesByPersonIdAsync(long personId)
        {
            var salaries = new List<PersonSalary>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT s.*, ps.ID as PersonSalaryId FROM Salary s
                        INNER JOIN PersonSalary ps ON s.ID = ps.Salary_ID
                        WHERE ps.Person_ID = @PersonId;";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var salary = new Salary
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("ID")),
                                Amount = Convert.ToDecimal(reader["Amount"]),
                                BeginDate = DateTime.Parse(reader["BeginDate"].ToString()),
                                EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["EndDate"].ToString()) : null,
                                CreateAt = DateTime.Parse(reader["CreateAt"].ToString()),
                                UpdateAt = reader["UpdateAt"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["UpdateAt"].ToString()) : null
                            };
                            salaries.Add(new PersonSalary
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("PersonSalaryId")),
                                Salary = salary
                            });
                        }
                    }
                }
            }
            return salaries;
        }

        public async Task<List<PersonVacation>> GetVacationsByPersonIdAsync(long personId)
        {
            var vacations = new List<PersonVacation>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT v.*, pv.ID as PersonVacationId FROM Vacation v
                        INNER JOIN PersonVacation pv ON v.ID = pv.Vacation_ID
                        WHERE pv.Person_ID = @PersonId;";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var vacation = new Vacation
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("ID")),
                                BeginDate = DateTime.Parse(reader["BeginDate"].ToString()),
                                EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["EndDate"].ToString()) : null,
                                VacationType = reader["VacationType"] as string,
                                CreateAt = DateTime.Parse(reader["CreateAt"].ToString()),
                                UpdateAt = reader["UpdateAt"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["UpdateAt"].ToString()) : null
                            };
                            vacations.Add(new PersonVacation
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("PersonVacationId")),
                                Vacation = vacation
                            });
                        }
                    }
                }
            }
            return vacations;
        }

        public async Task<List<PersonChild>> GetChildrenByPersonIdAsync(long personId)
        {
            var children = new List<PersonChild>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT c.*, pc.ID as PersonChildId, pc.Comment FROM Child c
                        INNER JOIN PersonChild pc ON c.ID = pc.Child_ID
                        WHERE pc.Person_ID = @PersonId;";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            children.Add(new PersonChild
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("PersonChildId")),
                                Child = new Child
                                {
                                    Id = reader.GetInt64(reader.GetOrdinal("ID")),
                                    FirstName = reader["FirstName"] as string,
                                    LastName = reader["LastName"] as string,
                                    MidleName = reader["MidleName"] as string,
                                    Birthday = reader["Birthday"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["Birthday"].ToString()) : null
                                },
                                Comment = reader["Comment"] as string
                            });
                        }
                    }
                }
            }
            return children;
        }

        public async Task<List<string>> GetPositionsByPersonIdAsync(long personId)
        {
            var positions = new List<string>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT pos.Name FROM Position pos
                        INNER JOIN PersonPosition pp ON pos.ID = pp.Position_ID
                        WHERE pp.Person_ID = @PersonId;";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            positions.Add(reader["Name"] as string);
                        }
                    }
                }
            }
            return positions;
        }
    }
} 