'Data Pursing Functions



Module DataParser

    'Function which will get a string and return an array of strings
    ' divided according to the sepration options:
    ' _separator: A single or multi-character seperator
    ' _SplitOptions: Weither to ignore or keep empty lines
    Public Function SeparateString(ByVal str As String, ByVal _seprator As Char(), Optional ByVal _SplitOptions As StringSplitOptions = StringSplitOptions.None) As String()
        Return str.Split(_seprator, _SplitOptions)
    End Function


End Module
