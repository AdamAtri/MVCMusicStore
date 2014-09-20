using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore.Models
{
    public class Order {
        public virtual int OrderID { get; set; }
        public virtual int CustomerID { get; set; }
        public virtual DateTime OrderTime { get; set; }
        public virtual decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail {
        public virtual int OrderDetailID { get; set; }
        public virtual int AlbumID {get;set;}
        public virtual Album Album { get; set; }
        public virtual int Quantity { get; set; }
    }

    public class Customer {
        public virtual int CustomerID { get; set; }
        public virtual string Username { get; set; }
        [Required(ErrorMessage="{0} is required.")]
        [StringLength(100, ErrorMessage = "There are too many letters in the {0}. Please limit to 100 characters")]
        public virtual string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100, ErrorMessage = "There are too many letters in the {0}. Please limit to 100 characters")]
        public virtual string LastName { get; set; }
        public virtual int AddressID {get; set;}
        public virtual string Phone { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-] + @[A-Za-z0-9._%+-] + \.[A-Za-z]{2,4}", 
                            ErrorMessage="The email address does supplied not look like a regular email address. Take another look.")]
        public virtual string Email { get; set; }
        public virtual Address Address { get; set; }
    }

    public class Address {
        public virtual int AddressID {get;set;}
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Country { get; set; }
    }
}