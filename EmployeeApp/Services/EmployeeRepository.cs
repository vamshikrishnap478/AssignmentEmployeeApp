using EmployeeApp.Application.Interfaces;
using EmployeeApp.Data;
using EmployeeApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace EmployeeApp.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext _context;

        public EmployeeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _context.Employee.OrderByDescending(x => x.Createdate).ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) =>
            await _context.Employee.FindAsync(id);

        public async Task AddAsync(EmployeeModel employee)
        {
            Employee record = new Employee();
            record.Name = employee.Name;
            record.Salary = employee.Salary;
            record.DateOfBirth = employee.DateOfBirth;
            record.DateOfJoin = employee.DateOfJoin;
            record.Designation = employee.Designation;  
            record.State = employee.State;
            record.Gender = employee.Gender;
            record.Createdate = DateTime.Now;
            await _context.Employee.AddAsync(record);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Employee employee)
        {
             _context.Employee.Update(employee);
             _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employee.FindAsync(id);
            if (emp != null)
            {
                _context.Employee.Remove(emp);
                _context.SaveChanges();
            }
        }

        public async Task DeleteMultipleAsync(int[] ids)
        {
            var employees = _context.Employee.Where(e => ids.Contains(e.Id));
            _context.Employee.RemoveRange(employees);
            _context.SaveChanges();
        }

        public async Task<bool> IsDuplicateAsync(string name, DateTime dob)
        {
            return await _context.Employee.AnyAsync(e => e.Name == name && e.DateOfBirth == dob);
        }

        public async Task<byte[]> GeneratePdf()
        {
            var employees = _context.Employee.ToList();

            using var stream = new MemoryStream();
            var document = new PdfDocument();

            var fontTitle = new XFont("Verdana", 16, XFontStyle.Bold);
            var fontText = new XFont("Verdana", 12, XFontStyle.Regular);

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            double margin = 40;
            double yPoint = margin;

            double lineHeight = 20;
            double blockSpacing = 30;
            double bottomMargin = 60;

            void AddHeader()
            {
                gfx.DrawString("Employee List", fontTitle, XBrushes.Black,
                    new XRect(0, yPoint, page.Width, page.Height), XStringFormats.TopCenter);
                yPoint += 40;
            }

            AddHeader();

            foreach (var emp in employees)
            {
                // Check if adding the next block would exceed the page height
                if (yPoint + (8 * lineHeight) + bottomMargin > page.Height)
                {
                    // Create a new page and reset graphics
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = margin;
                    AddHeader(); // Add header on each new page
                }

                // Draw each line for the employee
                gfx.DrawString($"ID: {emp.Id}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Name: {emp.Name}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Designation: {emp.Designation}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Date of Joining: {emp.DateOfJoin:yyyy-MM-dd}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Date of Birth: {emp.DateOfBirth:yyyy-MM-dd}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Salary: {emp.Salary}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"Gender: {emp.Gender}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += lineHeight;

                gfx.DrawString($"State: {emp.State}", fontText, XBrushes.Black, new XPoint(margin, yPoint));
                yPoint += blockSpacing; // space between employees
            }

            document.Save(stream, false);
            return stream.ToArray();
        }


    }
}
