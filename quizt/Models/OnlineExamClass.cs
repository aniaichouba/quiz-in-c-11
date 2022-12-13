using System.ComponentModel.DataAnnotations;

namespace quizt.Models
{
    public class OnlineExamClass
    {
        [Key]
        public int Qid { get; set; }
        public string Question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string Correctans { get; set; }
    }
}
