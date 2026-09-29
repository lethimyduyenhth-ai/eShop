using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_coreBusiness.models
{
    public class Person
    {
		[Required(ErrorMessage = "Vui lòng nhập tên (First Name).")]
		[StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Vui lòng nhập họ (Last Name).")]
		[StringLength(50, ErrorMessage = "Họ không được vượt quá 50 ký tự.")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Vui lòng nhập mã nhân viên.")]
		[Range(1, 99999, ErrorMessage = "Mã nhân viên phải lớn hơn 0.")]
		public int EmployeeNumber { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập địa chỉ Email.")]
		[EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
		public string Email { get; set; } = string.Empty;
	}
}
