using System;

using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

namespace RubyInt
{
    public class CompletionData : ICompletionData
    {
        public CompletionData(string text,string description)
        {
            Text = text;
            Description = description;
        }

        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, Text);
        }

        public System.Windows.Media.ImageSource Image
        {
            get { return null; }
        }

        public object Content
        {
            get { return Text; }
        }

        public double Priority { get; set; }

        public string Text { get; private set; }

        public object Description { get; private set; }
    }
}