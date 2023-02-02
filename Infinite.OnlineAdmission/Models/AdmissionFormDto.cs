using System;

namespace Infinite.OnlineAdmission.Models
{
    public class AdmissionFormDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Qualification { get; set; }
        public double EntranceTestScore { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
