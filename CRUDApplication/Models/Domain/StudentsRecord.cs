namespace CRUDApplication.Models.Domain
{
    public class StudentsRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MatricNumber { get; set; }
        public string Department { get; set; }
        public int Level { get; set; }
    }
}
