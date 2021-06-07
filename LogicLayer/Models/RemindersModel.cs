using DataAccesLayer.Data.Data_Transfer_Object;

namespace LogicLayer.Models
{
    class RemindersModel
    {
        public int ReminderId { get; set; }
        public int UserId { get; set; }
        public string ReminderName { get; set; }
        public string ReminderDescription { get; set; }

        public RemindersModel(RemindersDTO remindersDto)
        {
            ReminderId = remindersDto.ReminderId;
            UserId = remindersDto.UserId;
            ReminderName = remindersDto.ReminderName;
            ReminderDescription = remindersDto.ReminderDescription;
        }
    }
}
