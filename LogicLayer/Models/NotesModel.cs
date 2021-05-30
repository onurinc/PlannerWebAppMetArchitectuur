using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace LogicLayer.Models
{
    class NotesModel
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string Description { get; set; }
        public string Urgency { get; set; }
        public int Id { get; set; }


        public NotesModel(NotesDTO noteDTO)
        {
            NoteId = noteDTO.NoteId;
            NoteName = noteDTO.NoteName;
            Description = noteDTO.Description;
            Urgency = noteDTO.Urgency;
            Id = noteDTO.Id;
        }
    }
}
