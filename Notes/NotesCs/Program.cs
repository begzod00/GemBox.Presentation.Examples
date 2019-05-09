using System.Linq;
using GemBox.Presentation;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        var presentation = new PresentationDocument();

        // Add a blank slide to the presentation.
        var slide = presentation.Slides.AddNew(SlideLayoutType.Blank);

        // Add a text box with some content to the slide.
        var text = slide.Content.AddTextBox(3, 2, 22, 2, LengthUnit.Centimeter);
        text.AddParagraph().AddRun("This is my presentation with notes");

        // Add notes to the slide.
        var notes = slide.AddNotes();

        // Using LINQ, find shape that contains notes text.
        var notesText = notes.Content.Drawings.OfType<Shape>().
            Single(sp => sp.Placeholder.PlaceholderType == PlaceholderType.Text).Text;

        // Start adding notes text and formatting.
        notesText.AddParagraph().AddRun("These are my notes:");

        var noteParagraph = notesText.AddParagraph();
        // Paragraph will be numbered.
        noteParagraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        // Move paragraph content a little bit from its number.
        noteParagraph.Format.IndentationSpecial =
            Length.From(-0.64, LengthUnit.Centimeter);
        noteParagraph.AddRun("My first note");

        noteParagraph = notesText.AddParagraph();
        noteParagraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        noteParagraph.Format.IndentationSpecial =
            Length.From(-0.64, LengthUnit.Centimeter);
        noteParagraph.AddRun("My second note");

        noteParagraph = notesText.AddParagraph();
        noteParagraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        noteParagraph.Format.IndentationSpecial =
            Length.From(-0.64, LengthUnit.Centimeter);
        noteParagraph.AddRun("My third note");

        presentation.Save("Notes.pptx");
    }
}