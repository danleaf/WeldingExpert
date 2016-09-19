using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Data.Entity;

namespace WeldingExpert.Models
{
    public class User
    {
        [Key]
        [Display(Name="用户名")]
        public string UserName { get; set; }
        
        [ScaffoldColumn(false)]
        public string Password { get; set; }

        [Display(Name = "用户角色")]
        public int Role { get; set; }   //enum UserRole

        [Display(Name = "真实姓名")]
        public string RealName { get; set; }

        [Display(Name = "工号")]
        public int WorkerID { get; set; }

        public DeleteUserModel ToDeleteUserModel()
        {
            return new DeleteUserModel() { RealName = this.RealName, Role = this.Role, UserName = this.UserName, WorkerID = this.WorkerID };
        }
    }

    public class CreateUserModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "用户角色")]
        public int Role { get; set; }   //enum UserRole

        [Required]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }

        [Required]
        [Display(Name = "工号")]
        public int WorkerID { get; set; }

        public User ToUser()
        {
            return new User() { Password = this.Password, RealName = this.RealName, Role = this.Role, UserName = this.UserName, WorkerID = this.WorkerID };
        }

        public CreateUserOkModel ToCreateUserOkModel()
        {
            return new CreateUserOkModel() { RealName = this.RealName, Role = this.Role, UserName = this.UserName, WorkerID = this.WorkerID };
        }
    }

    public class CreateUserOkModel
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "用户角色")]
        public int Role { get; set; }   //enum UserRole

        [Required]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }

        [Required]
        [Display(Name = "工号")]
        public int WorkerID { get; set; }
    }

    public class DeleteUserModel
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "用户角色")]
        public int Role { get; set; }   //enum UserRole

        [Required]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }

        [Required]
        [Display(Name = "工号")]
        public int WorkerID { get; set; }
    }


    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}
