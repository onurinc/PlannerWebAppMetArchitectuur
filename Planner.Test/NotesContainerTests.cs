using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Planner.Test
{
    [TestClass]
    public class NotesContainerTests
    {
        private readonly NotesContainer _notesContainer;

        private readonly Mock<INotesRepository> _mockNotesRepository = new Mock<INotesRepository>();

        public NotesContainerTests()
        {
            _notesContainer = new NotesContainer(_mockNotesRepository.Object);
        }

        List<ProjectsDTO> ProjectList = new List<ProjectsDTO>
        {
            new ProjectsDTO()
            {
                ProjectId = 1, ProjectName = "ProjectOne", ProjectDescription = "ProjectOne Description"
            },
            new ProjectsDTO()
            {
                ProjectId = 2, ProjectName = "ProjectTwo", ProjectDescription = "ProjectTwo Description"
            }
        };

        List<NotesDTO> NotesList = new List<NotesDTO>
        {
            new NotesDTO()
            {
                NoteId= 1, ProjectId = 1, NoteName = "NoteOne", Description = "NoteOne Description", Urgency = "TestUrgent"
            },
            new NotesDTO()
            {
                NoteId= 2, ProjectId = 1, NoteName = "NoteTwo", Description = "NoteTwo Description", Urgency = "TestUrgent"
            }
        };

        [TestMethod]
        public void GetAllNotes_ShouldReturnAllNotes_WhenNotesExist()
        {
            // Arrange
            List<NotesModel> NotesListOne = new List<NotesModel>();
            _mockNotesRepository.Setup(x => x.GetAllNotes()).Returns(NotesList);

            // Act
            NotesListOne = _notesContainer.GetAllNotes();

            // Assert
            Assert.AreEqual(2, NotesListOne.Count);
        }

        [TestMethod]
        public void GetNote()
        {
            // Arrange
            _mockNotesRepository.Setup(x => x.GetNote(It.IsAny<int>()))
                .Returns((int i) => NotesList.Single(x => x.NoteId == i));
            // Act
            var note = _notesContainer.GetNoteById(2);

            // Assert
            Assert.IsInstanceOfType(note, typeof(NotesModel));
            Assert.AreEqual(2, note.NoteId);
            Assert.AreEqual(note.NoteName, "NoteTwo");
            Assert.AreEqual(note.Description, "NoteTwo Description");
            Assert.AreEqual(note.Urgency, "TestUrgent");
        }

        [TestMethod]
        public void AddNote()
        {
            // Arrange
            _mockNotesRepository.Setup(x => x.AddNote(It.IsAny<NotesDTO>())).Callback(
                (NotesDTO note) =>
                {
                    if (note.NoteId.Equals(default(int)))
                    {
                        note.NoteId = NotesList.Count() + 1;
                        NotesList.Add(note);
                    }
                    else
                    {
                        throw new Exception(
                            "Project can not be added, make sure you enter the corresponding information");
                    }
                });

            // Act
            _notesContainer.AddNote("NoteThree", "NoteThreeDescription", "TestUrgent", 1);
            var addedNote = NotesList.Last();

            // Assert
            Assert.IsInstanceOfType(addedNote, typeof(NotesDTO));
            Assert.AreEqual(3, addedNote.NoteId);
            Assert.AreEqual(1, addedNote.ProjectId);
            Assert.AreEqual("NoteThree", addedNote.NoteName);
            Assert.AreEqual("NoteThreeDescription", addedNote.Description);
        }

    }
}