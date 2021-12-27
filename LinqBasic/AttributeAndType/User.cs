using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static AttributeAndType.Program;

namespace AttributeAndType
{ 
    class User
    {
        [Required(ErrorMessage = "Name ko duoc de null")]
        [StringLength(50,ErrorMessage ="Length Max = 50 kí tự")]
        public string Name { set; get; }
        [Range (18,80,ErrorMessage ="Tuoi gioi han tu 18 den 80")]
        public int Age { set; get; }
        [Phone]
        public string PhoneNumber { set; get; }
        [EmailAddress(ErrorMessage ="Email khong dung dinh dang")]
        public string Email { set; get; }
       
    }
}
