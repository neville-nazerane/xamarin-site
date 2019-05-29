using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DbApp
{
    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

    }
}
