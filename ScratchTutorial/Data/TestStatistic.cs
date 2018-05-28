using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchTutorial.Data
{
    public class TestStatistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public TimeSpan Time { get; set; }

        public int RightCount { get; set; }

        public int Amount { get; set; }
    }
}
