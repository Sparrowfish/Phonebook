using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Datalayer.DTOs
{
    public class PeopleViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }

        [Display(Name = " نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Family { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Sex { get; set; }


        [Display(Name = "تاریخ تولد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string BirthDay { get; set; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Mobile { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
    }
}
