using FileCrud.Db;
using FileCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyDbContext context;
        private readonly IWebHostEnvironment webHost;

        public StudentController(MyDbContext context,IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            if(ModelState.IsValid)
            {
                
                // File Type Validation
                if (studentViewModel.StdProfile.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("StdProfile", "File Type Must be JPG , JPEG , PNG");
                    return View(studentViewModel);
                }
                //  File Size Validation
                var maxsize = 2 * 1024 * 1024;
                var filesize = studentViewModel.StdProfile.Length;
                if (filesize > maxsize)
                {
                    ModelState.AddModelError("StdProfile", "File Size Must be 2MB");
                    return View(studentViewModel);
                }
                // Create Path wwwroot/uploads
                var uploadfolder = Path.Combine(webHost.WebRootPath, "uploads");
                // Check if directory exist if directory not exists create directoy in www.root
                if (!Directory.Exists(uploadfolder))
                {
                    Directory.CreateDirectory(uploadfolder);
                }
                // Create unique file name Extract file extension in file name create new guid with file extension "0e8b475c-2cef-4b64-8091-b7fa92d52d7b.jpeg"
                var filename = Guid.NewGuid() + Path.GetExtension(studentViewModel.StdProfile.FileName);
                // Create complete path "wwwroot/uploads/0e8b475c-2cef-4b64-8091-b7fa92d52d7b.jpeg"
                var fullpath = Path.Combine(uploadfolder, filename);
                // Write file name in directory
                FileStream stream = new FileStream(fullpath, FileMode.Create);
                // write file name in data base
                studentViewModel.StdProfile.CopyTo(stream);
                stream.Close();

                Student student = new Student()
                {
                    StdId = studentViewModel.StdId,
                    StdName = studentViewModel.StdName,
                    StdAge = studentViewModel.StdAge,
                    StdEmail = studentViewModel.StdEmail,
                    StdProfile = filename
                };
                context.Students.Add(student);
                context.SaveChanges();
                return View();
            }

            return View();
        }
    }
}
