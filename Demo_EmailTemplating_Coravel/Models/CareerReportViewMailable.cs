using Coravel.Mailer.Mail;

namespace Demo_EmailTemplating_Coravel.Models
{
    public class CareerReportViewMailable : Mailable<Student>
    {
        private Student _student;

        public CareerReportViewMailable(Student student)
        {
            _student = student;
        }

        public override void Build()
        {
            this.To("arthur1610@live.com")
                .From("arthur1610@live.com")
                .View("~/Views/Mailing/CareerReport.cshtml", this._student);
        }
    }
}
