using System.ComponentModel.DataAnnotations;

namespace TvcLesson09Annotation.Models.DataViewModels
{
    public class TvcMemberRegister
    {
        public int TvcMemberId { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Tên đăng nhập phải từ 5 đến 20 ký tự")]
        public string TvcUserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự")]
        public string TvcPassword { get; set; }
        public string TvcEmail { get; set; }
        public string TvcPhoneNumber { get; set; }
        public string TvcFullName { get; set; }
        public DateTime TvcBirthday { get; set; }
    }
}
