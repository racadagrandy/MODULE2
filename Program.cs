﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULE_LINQ
{

    class Program
    {
        // Employee list to serve as the database
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. List All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ListAllEmployees();
                            break;
                        case 3:
                            FindEmployeeById();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        // Create: Add a new employee
        static void AddEmployee()
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
            Console.WriteLine("Employee added successfully!");
        }

        // Read: List all employees
        static void ListAllEmployees()
        {
            if (employees.Any())
            {
                Console.WriteLine("\n--- List of Employees ---");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Position: {emp.Position}, Salary: {emp.Salary:C}");
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }

        // Read: Find an employee by ID
        static void FindEmployeeById()
        {
            Console.Write("Enter Employee ID to search: ");
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

        // Update: Update an employee's details by ID
        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.Write("Enter New Name: ");
                employee.Name = Console.ReadLine();

                Console.Write("Enter New Position: ");
                employee.Position = Console.ReadLine();

                Console.Write("Enter New Salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Employee updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Delete: Remove an employee by ID
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
