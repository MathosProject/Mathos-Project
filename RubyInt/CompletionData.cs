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
            _Description = description;
        }

        public System.Windows.Media.ImageSource Image
        {
            get { return null; }
        }

        public string Text { get; private set; }

        public string _Description { get; private set; }

        public object Content
        {
            get { return Text; }
        }

        public object Description
        {
            get { return _Description;}
        }

        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, Text);
        }

        public double Priority { get; set; }
    }
}