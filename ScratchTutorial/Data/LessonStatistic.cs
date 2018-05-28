using System;
using System.ComponentModel.DataAnnotations;

namespace ScratchTutorial.Data
{
    public class LessonStatistic
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public TimeSpan Time { get; set; }
    }
}
