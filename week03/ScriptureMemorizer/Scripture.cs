using System.Reflection.Metadata.Ecma335;

class Scripture
{   // we call the classes
    Reference _reference;
    public List<Word> _words;
    private List<Word> _lastHiddenWords; // We keep in a list the lasted deleted words

    // reference
    public Scripture (Reference Reference, string text)
    {
        _reference = Reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _lastHiddenWords = new List<Word>();
    }

    //We hide random words
    public void HideRandomWords(int numbertoHide)
    {
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        Random random = new Random();

        _lastHiddenWords.Clear();

        for (int i = 0; i < numbertoHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            var word = visibleWords[index];
            word.Hide(); // we hidde the word
            _lastHiddenWords.Add(word); // We add to the list the 3 words
            visibleWords.RemoveAt(index);
        }
    }

    // We restore all the words in case the user types "return"
    public void RestoreTheLastWords()
    {
        int wordsToRestore = Math.Min(3, _lastHiddenWords.Count);
        for (int i = 0; i < wordsToRestore; i++)
        {
            var wordToRestore = _lastHiddenWords[_lastHiddenWords.Count - 1]; 
            wordToRestore.Restore();
            _lastHiddenWords.RemoveAt(_lastHiddenWords.Count - 1);
        }
    }


    // we retunr the words visible and the hides
    public string GetDisplayText(bool showLastHiddenWords = false)
    {
        var displayWords = _words.Select(word => word.GetDisplayText()).ToList();

        if (showLastHiddenWords && _lastHiddenWords.Count > 0)
        {
            int hiddenIndex = 0;

            for (int i = 0; i < displayWords.Count; i++)
            {
                if (displayWords[i] == "___" && hiddenIndex < _lastHiddenWords.Count)
                {
                    displayWords[i] = _lastHiddenWords[hiddenIndex].GetOriginalText();
                    hiddenIndex++;
                }
            }
        }
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", displayWords)}";
    }


    //We see if all the words are hidden or not
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public List<string> GetLastHiddenWord()
    {
        return _lastHiddenWords.Select(word => word.GetOriginalText()).ToList();
    }
}