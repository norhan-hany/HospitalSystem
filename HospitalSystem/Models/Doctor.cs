namespace HospitalSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
