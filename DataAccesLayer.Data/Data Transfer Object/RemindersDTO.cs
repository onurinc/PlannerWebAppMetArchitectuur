using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Data.Data_Transfer_Object
{
    class RemindersDTO
    {
        public int ReminderId { get; set; }
        public int UserId { get; set; }
        public string ReminderName { get; set; }
        public string ReminderDescription { get; set; }
    }
}
