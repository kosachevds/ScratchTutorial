using System;
using System.ComponentModel.DataAnnotations;

namespace ScratchTutorial.Data
{
    public class TestStatistic
    {
        [Key]
        public int Id { get; set; }

        public string USername { get; set; }

        public string Title { get; set; }

        public TimeSpan Time { get; set; }

        public int RightCount { get; set; }

        public int Amount { get; set; }
    }
}
