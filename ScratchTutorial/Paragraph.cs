namespace ScratchTutorial
{
    public class Paragraph
    {
        public Paragraph(string text, string image)
        {
            this.Text = text;
            this.Image = image;
        }

        public string Text { get; }

        public string Image { get; }
    }
}
