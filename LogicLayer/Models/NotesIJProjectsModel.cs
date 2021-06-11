using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace LogicLayer.Models
{
    public class NotesIJProjectsModel
    {
        public int NoteId { get; set; }
        public string ProjectName { get; set; }
        public string NoteName { get; set; }
        public string Description { get; set; }
        public string Urgency { get; set; }
        public int ProjectId { get; set; }

        public NotesIJProjectsModel(NotesInnerJoinsProjectsDTO notesIJProjecstDto)
        {
            NoteId = notesIJProjecstDto.NoteId;
            ProjectName = notesIJProjecstDto.ProjectName;
            NoteName = notesIJProjecstDto.NoteName;
            Description = notesIJProjecstDto.Description;
            Urgency = notesIJProjecstDto.Urgency;
        }
    }
}
