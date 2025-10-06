using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Models
{
    public class UpdateRecordViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name should only contain Letters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Student Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Student Matric Number is required")]
        [RegularExpression("^[0-9]+[a-zA-Z]+[0-9]+", ErrorMessage = "Matric number should follow the format '21N02023' ")]
        public string MatricNumber { get; set; }


        [Required(ErrorMessage = "Student Department is required")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Student Level is required")]
        public int Level { get; set; }
    }
}
