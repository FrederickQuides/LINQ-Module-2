using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data storage
            List<Employee> employees = new List<Employee>();

            // Menu for the user
            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddEmployee(employees);
                        break;
                    case "2":
                        ViewAllEmployees(employees);
                        break;
                    case "3":
                        FindEmployeeById(employees);
                        break;
                    case "4":
                        UpdateEmployee(employees);
                        break;
                    case "5":
                        DeleteEmployee(employees);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to add a new employee
        static void AddEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            if (employees.Any(e => e.Id == id))
            {
                Console.WriteLine("Employee with this ID already exists.");
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Employee Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
            Console.WriteLine("Employee added successfully.");
        }

        // Method to view all employees
        static void ViewAllEmployees(List<Employee> employees)
        {
            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\nEmployee List:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary:C}");
            }
        }

        // Method to find an employee by ID
        static void FindEmployeeById(List<Employee> employees)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary:C}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Method to update an employee's details
        static void UpdateEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                Console.Write("Enter New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) employee.Name = name;

                Console.Write("Enter New Position (leave blank to keep current): ");
                string position = Console.ReadLine();
                if (!string.IsNullOrEmpty(position)) employee.Position = position;

                Console.Write("Enter New Salary (leave blank to keep current): ");
                string salaryInput = Console.ReadLine();
                if (decimal.TryParse(salaryInput, out decimal salary)) employee.Salary = salary;

                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Method to delete an employee
        static void DeleteEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
