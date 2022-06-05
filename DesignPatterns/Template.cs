using System.Text;
namespace TemplateDP
{
    public abstract class PersonalInfo
    {
        private StringBuilder text = new StringBuilder();
        public abstract string GetFullName();
        public abstract string GetEmailAddress();
        public abstract string GetCurrentLocation();
        public abstract string GetInstagramLink();
        public abstract string GetProfile();
        public abstract string GetCourseName();
        public abstract int GetCourseYear();
        public StringBuilder TemplateMethod()
        {
            this.text.Append("**************************************************************************\n");
            this.text.Append("----> Full Name\n");
            this.text.Append($"\t{this.GetFullName().ToUpper()}\n\n");
            this.text.Append("----> Profile\n");
            this.text.Append($"\t{this.GetProfile()}\n\n");
            this.text.Append("----> Personal Email\n");
            this.text.Append($"\t{this.GetEmailAddress()}\n\n");
            this.text.Append("----> Location\n");
            this.text.Append($"\t{this.GetCurrentLocation()}\n\n");
            this.text.Append("----> Instagram link\n");
            this.text.Append($"\t{this.GetInstagramLink()}\n\n");
            this.text.Append("----> Course Name\n");
            this.text.Append($"\t{this.GetCourseName()}\n\n");
            this.text.Append("----> Course Year\n");
            this.text.Append($"\t{this.GetCourseYear()}\n");
            this.text.Append("**************************************************************************\n");
            return this.text;
        }
    }
    public class ConcreteTemplate : PersonalInfo
    {
        public ConcreteTemplate(string fullname, string emailAddress, string currentLocation, string instagramLink, string profile, string courseName, int courseYear)
        {
            this.fullname = fullname;
            this.emailAddress = emailAddress;
            this.currentLocation = currentLocation;
            this.instagramLink = instagramLink;
            this.profile = profile;
            this.courseName = courseName;
            this.courseYear = courseYear;
        }
        private string fullname;
        private string emailAddress;
        private string currentLocation;
        private string instagramLink;
        private string profile;
        private string courseName;
        private int courseYear;
        public override string GetFullName()
        {
            return this.fullname;
        }
        public override string GetEmailAddress()
        {
            return this.emailAddress;
        }
        public override string GetCurrentLocation()
        {
            return this.currentLocation;
        }
        public override string GetInstagramLink()
        {
            return this.instagramLink;
        }
        public override string GetProfile()
        {
            return this.profile;
        }
        public override string GetCourseName()
        {
            return this.courseName;
        }
        public override int GetCourseYear()
        {
            return this.courseYear;
        }
    }
}