using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace POC.DataTables.UI.Data.Models;


    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(2)]
        public string PersonType { get; set; }

        [Required]
        public bool NameStyle { get; set; }  // Assuming NameStyle is a boolean as no type is given

        [StringLength(8)]
        public string? Title { get; set; }

        [Required]
        public string? FirstName { get; set; } // Assuming "Name" is a string

        public string? MiddleName { get; set; }  // Assuming "Name" is a string

        [Required]
        public string? LastName { get; set; }  // Assuming "Name" is a string

        [StringLength(10)]
        public string? Suffix { get; set; }

        [Required]
        public int EmailPromotion { get; set; }

      
        [Required]
        public Guid RowGuid { get; set; }  // Mapping the uniqueidentifier type

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
