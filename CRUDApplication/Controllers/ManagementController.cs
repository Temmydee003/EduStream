using CRUDApplication.Data;
using CRUDApplication.Models;
using CRUDApplication.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Controllers
{
    public class ManagementController : Controller
    {
        // constructor class
        private readonly CRUDDBContext studentRecordsDbContext;

        public ManagementController(CRUDDBContext StudentRecordsDbContext)
        {
            studentRecordsDbContext = StudentRecordsDbContext;
        }


        [HttpGet]
        public IActionResult GeneralLandingPage()
        {
            return View();
        }

        // handles the display all student records that are in the database(sql)
        [HttpGet]
        public async Task<IActionResult> ViewAllRecord(){
            var student = await studentRecordsDbContext.FnsStudentsRecord.ToListAsync();
            return View(student);
        }


        // handles the display of form where new student record can be added 
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // handles sending(saving) all of the input to the database
        [HttpPost]
        public async Task<IActionResult> Add(AddRecordViewModel addStudentRequest)
        {
            var student = new StudentsRecord()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                MatricNumber = addStudentRequest.MatricNumber,
                Department = addStudentRequest.Department,
                Level = addStudentRequest.Level
            };

            await studentRecordsDbContext.FnsStudentsRecord.AddAsync(student);
            await studentRecordsDbContext.SaveChangesAsync();
            return RedirectToAction("ViewAllRecord");
        }


        // handles the display all student records with a button to update
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.ToListAsync();
            return View(student);
        }


        // handles the display of a single student record
        [HttpGet]
        public async Task<IActionResult>  UpdateRecord(Guid id)
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.FirstOrDefaultAsync(x => x.Id == id);

            if(student != null)
            {
                var updateModel = new UpdateRecordViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    MatricNumber = student.MatricNumber,
                    Department = student.Department,
                    Level = student.Level
                };
               return await Task.Run(() => View("UpdateRecord", updateModel));
            }
            return RedirectToAction("ViewAllRecord");
        }

        // handles the saving of the new update to the database
        [HttpPost]
        public async Task<IActionResult> UpdateRecord(UpdateRecordViewModel updateStudentRequest)
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.FindAsync(updateStudentRequest.Id);

            if (student != null)
            {
                student.Name = updateStudentRequest.Name;
                student.Email = updateStudentRequest.Email;
                student.MatricNumber = updateStudentRequest.MatricNumber;
                student.Department = updateStudentRequest.Department;
                student.Level = updateStudentRequest.Level;

                await studentRecordsDbContext.SaveChangesAsync();
                return RedirectToAction("ViewAllRecord");
            }
            return RedirectToAction("ViewAllRecord");
        }


        // handles the display all student records with a button to delete
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.ToListAsync();
            return View(student);
        }


        // handles the display of single record about to be deleted
        [HttpGet]
        public async Task<IActionResult> ConfirmDeleteRecord(Guid id)
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.FirstOrDefaultAsync(x => x.Id == id);

            if (student != null)
            {
                var updateModel = new UpdateRecordViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    MatricNumber = student.MatricNumber,
                    Department = student.Department,
                    Level = student.Level
                };
                return await Task.Run(() => View("ConfirmDeleteRecord", updateModel));
            }
            return RedirectToAction("ViewAllRecord");
        }


        // handles the deletion of student record
        [HttpPost]
        public async Task<IActionResult> DeleteRecord(UpdateRecordViewModel model)
        {
            var student = await studentRecordsDbContext.FnsStudentsRecord.FindAsync(model.Id);

            if (student != null)
            {
                studentRecordsDbContext.FnsStudentsRecord.Remove(student);
                await studentRecordsDbContext.SaveChangesAsync();
                return RedirectToAction("ViewAllRecord");
            }

            return RedirectToAction("ViewAllRecord");
        }



    }

}

