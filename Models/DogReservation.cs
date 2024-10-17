using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.Models
{
    [Serializable]
    public class DogReservation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Check In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Display(Name = "Owner's Name")]
        public string OwnerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Dog's Name")]
        public string DogName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Sex { get; set; }
        [Display(Name = "Is your dog spayed/neutered?")]
        [Required]
        public bool SpayedOrNeutered { get; set; }
        [Display(Name = "Are your dog's vaccinations up-to-date?")]
        [Required]
        public bool Vaccinated { get; set; }
        [Display(Name = "Will your dog require a special accommodation?")]
        [Required]
        public bool SpecialAccommodation { get; set; }
        public string? AccommodationDetails { get; set; }

        public int CalculateTotalCost()
        {
            const int PricePerNight = 40;
            int totalCost = (CheckOutDate - CheckInDate).Days * PricePerNight;
            return totalCost;
        }

        public DogReservation()
        {
            CheckInDate = DateTime.Now.Date;
            CheckOutDate = CheckInDate.AddDays(1);
        }
    }
}