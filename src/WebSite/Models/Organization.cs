using System.Collections.Generic;

namespace NNUG.WebSite.Models
{
    public class Organization
    {
        public List<Chapter> Chapters { get; set; }

        public static Organization Create()
        {
            var organization = new Organization();
            organization.Chapters = new List<Chapter>
                           {
                               //new Chapter("Online"),
                               new Chapter("Oslo", "nnugoslo"),
                               new Chapter("Bergen"),
                               new Chapter("Trondheim"),
                               new Chapter("Stavanger"),
                               new Chapter("Kristiansand"),
                               new Chapter("Haugesund"),
                               new Chapter("Vestfold")
                           };
            return organization;
        }
    }
}