using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Data.Data_Transfer_Object
{
    public class NotesInnerJoinsProjectsDTO
    {
        public int NoteId { get; set; }
        public string ProjectName { get; set; }
        public string NoteName { get; set; }
        public string Description { get; set; }
        public string Urgency { get; set; }
    }
}
