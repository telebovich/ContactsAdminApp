using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactsAdminApp.Models
{
    [Bind(Exclude = "Id")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone")]
        public string LandlinePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        public string CellPhone { get; set; }
        public string ImageUrl { get; set; }
        public int? PositionId { get; set; }
        public virtual Position Position { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}