using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Company_Management
{
    public class StaffMember
    {
        public int EmployeesId { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public decimal MonthlySalary { get; set; }

        public override string ToString()
        {

            return $"Employees ID: " +
                $"{EmployeesId}, Name: {FullName}, " +
                $"Title: {JobTitle}, " +
                $"Salary: {MonthlySalary:C}";
        }

    }

    public class StaffManagement
    {
        private List<StaffMember> _staffMember = new List<StaffMember>();

        public void AddStaff(StaffMember staff)
        {
            if (_staffMember.Any(s => s.EmployeesId == staff.EmployeesId))
            {
                Console.WriteLine("Error!!! This employee with this ID already exists in the system.");
                return;
            }
            _staffMember.Add(staff);
            Console.WriteLine("Staff Member added successfully.");
        }

        public void DisplayAllStaff()
        {
            if (_staffMember.Count == 0)
            {

                Console.WriteLine("No staff members available.");
                return;
            }
            Console.WriteLine("\nList of staff members:");
            _staffMember.ForEach(s => Console.WriteLine(s));
        }

        public void SearchStaffById(int employeeId)
        {
            var staff = _staffMember.FirstOrDefault(s => s.EmployeesId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("There is no staff member found in the given ID.");
                return;
            }
            Console.WriteLine($"\nStaff Member Found: {staff}");
        }

        public void ModifyStaffDetails(int employeeId, string fullName, string jobTitle, decimal monthlySalary)
        {
            var staff = _staffMember.FirstOrDefault(s => s.EmployeesId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("Error!!! Staff member was not found.");
                return;
            }
            staff.FullName = fullName;
            staff.JobTitle = jobTitle;
            staff.MonthlySalary = monthlySalary;
            Console.WriteLine("Staff member details updated successfully!.");
        }

        public void RemoveStaff(int employeeId)
        {
            var staff = _staffMember.FirstOrDefault(s => s.EmployeesId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("Error!!! Staff member was not found.");
                return;
            }
            _staffMember.Remove(staff);
            Console.WriteLine("Staff member removed successfully!.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var managementSystem = new StaffManagement();
            while (true)
            {
                Console.WriteLine("\nStaff Management System Menu:");
                Console.WriteLine("1. Add a staff member");
                Console.WriteLine("2. View all staff members");
                Console.WriteLine("3. Search staff by ID");
                Console.WriteLine("4. Update staff details");
                Console.WriteLine("5. Remove staff member");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                int choice = int.Parse(Console.ReadLine() ?? "6");
                if (choice == 6) break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter staff ID: ");
                        int employeeId = int.Parse(Console.ReadLine());
                        Console.Write("Enter full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter job title: ");
                        string jobTitle = Console.ReadLine();
                        Console.Write("Enter your monthly salary: ");
                        decimal monthlySalary = decimal.Parse(Console.ReadLine());
                        managementSystem.AddStaff(new StaffMember { EmployeesId = employeeId, FullName = fullName, JobTitle = jobTitle, MonthlySalary = monthlySalary });
                        break;

                    case 2:
                        managementSystem.DisplayAllStaff();
                        break;

                    case 3:
                        Console.Write("Enter Staff ID to Search: ");
                        employeeId = int.Parse(Console.ReadLine());
                        managementSystem.SearchStaffById(employeeId);
                        break;

                    case 4:
                        Console.Write("Enter a Staff ID to update: ");
                        employeeId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Updated Full Name: ");
                        fullName = Console.ReadLine();

                        Console.Write("Enter your Updated Job Title: ");
                        jobTitle = Console.ReadLine();

                        Console.Write("Enter your Updated Monthly Salary: ");
                        monthlySalary = decimal.Parse(Console.ReadLine());

                        managementSystem.ModifyStaffDetails(employeeId, fullName, jobTitle, monthlySalary);
                        break;


                    case 5:
                        Console.Write("Enter a staff ID to Remove: ");
                        employeeId = int.Parse(Console.ReadLine());
                        managementSystem.RemoveStaff(employeeId);

                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}