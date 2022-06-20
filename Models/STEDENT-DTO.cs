using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class STEDENT_DTO
    {
        //קוד תלמידה (מיספור אוטומטי ),כ
        public int st_code { get; set; }
        //תעודת זהות 
        public string id { get; set; }
        //שם פרטי
        public string firstName { get; set; }
        //שם מישפחה
        public string lastName { get; set; }
        //מיקצוע:
        // מכיל קוד מיקצוע:1= מגמת הנדסת תוכנה,2= מגמת חשבונאות, 3=מגמת משאבי אנוש
        public int profession { get; set; }
        //מוצא:
        //מכיל קוד מוצא:1=ישראל, 2=אמריקה, 3=אירופה
        public int origin { get; set; }
        //מנטליות:
        //מכיל קוד מנטליות:1=חוזרות בתשובה, 2=מתחזקות,3=חרדיות מבית
        public int mentally { get; set; }
        //לא להתייחס למשתנה זה!
        public int PersonalFilecCode { get; set; }
        //שכבת גיל:
        //מכיל קוד כיתה:1=ט, 2=י, 3=יא, 4=יב
        public int classCode { get; set; }
        public static STEDENT_DTO CONVERTtOdto(STEDENT S)
        {
            return new STEDENT_DTO()
            {
                 st_code = S.st_code,
                id = S.id,
                firstName = S.firstName,
                lastName = S.lastName,
                profession = S.profession,
                origin = S.origin,
                mentally = S.mentally,
                PersonalFilecCode = S.PersonalFilecCode,
                classCode = S.classCode,
            };
        }
        public STEDENT CONVERTFROMDTO()
        {
            return new STEDENT()
            {
                st_code = this.st_code,
                id = this.id,
                firstName = this.firstName,
                lastName = this.lastName,
                profession = this.profession,
                origin = this.origin,
                mentally = this.mentally,
                PersonalFilecCode = this.PersonalFilecCode,
                classCode = this.classCode,

            };
        }
    }
}
