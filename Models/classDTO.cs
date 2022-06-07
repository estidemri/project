using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class classDTO
    {
        public int c_code { get; set; }
        public string ClassName { get; set; }
        public string NumberOfStudents { get; set; }

        public classDTO CONVERTtODTO(@class C)
        {
            return new classDTO()
            {
                c_code = C.c_code,
                ClassName = C.ClassName,
                NumberOfStudents = C.NumberOfStudents,

            };

        }

        public @class CONVERTFROMDTO(classDTO C)
        {
            return new @class()
            {
                c_code = C.c_code,
                ClassName = C.ClassName,
                NumberOfStudents = C.NumberOfStudents,

            };

        }

    }
} 