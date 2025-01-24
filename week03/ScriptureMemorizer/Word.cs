class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    // if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

     public void Restore()
    {
        _isHidden = false; 
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    public string GetOriginalText()
    {
        return _text;
    }
}