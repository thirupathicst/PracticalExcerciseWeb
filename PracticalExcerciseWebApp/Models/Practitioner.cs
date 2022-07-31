namespace PracticalExcerciseWebApp.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public string date { get; set; }
        public string client_name { get; set; }
        public string appointment_type { get; set; }
        public int duration { get; set; }
        public int revenue { get; set; }
        public int cost { get; set; }
        public int practitioner_id { get; set; }
    }

    public class Practitioner
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}