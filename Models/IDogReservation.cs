using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.Models
{
    public interface IDogReservation
    {
        int Id { get; set; }

        [Required]
        [Display(Name = "Check In Date")]
        [DataType(DataType.Date)]
            DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check Out Date")]
        [DataType(DataType.Date)]
            DateTime CheckOutDate { get; set; }

        [Display(Name = "Owner's Name")]
            string OwnerName { get; set; }
        [Required]
            string Address { get; set; }
        [Required]
            string City { get; set; }
        [Required]
            string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
            string ZipCode { get; set; }
        [Required]
            string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
            string PhoneNumber { get; set; }
        [Display(Name = "Dog's Name")]
            string DogName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
            DateTime DateOfBirth { get; set; }
        [Required]
            string Breed { get; set; }
        [Required]
            string Sex { get; set; }
        [Display(Name = "Is your dog spayed/neutered?")]
        [Required]
            bool SpayedOrNeutered { get; set; }
        [Display(Name = "Are your dog's vaccinations up-to-date?")]
        [Required]
            bool Vaccinated { get; set; }
        [Display(Name = "Will your dog require a special accommodation?")]
        [Required]
            bool SpecialAccommodation { get; set; }
            string? AccommodationDetails { get; set; }

        int CalculateTotalCost();
        void DogReservation();        
    }
}
