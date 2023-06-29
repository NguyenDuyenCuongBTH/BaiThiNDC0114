using System.ComponentModel.DataAnnotations;

namespace BaiThiNDC.Models
{
    public class NDCCau3
    {
        [Key]
        [Display(Name ="Mã sinh viên")]
        public string StudentID { get; set; }

        [Display(Name ="Tên sinh viên")]
        public string StudentName { get; set; }
        
        [Display(Name ="Số điện thoại")]
        public int Sdt { get; set; }
    }
}