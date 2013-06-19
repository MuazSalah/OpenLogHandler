Module DataParser


    'Public RawText As String
    'Public Lines() As String

    Public str1(), str2() As String

    Dim LineSeperator() As Char = {Chr(13)}
    Dim FileNameToSizeSeperator() As Char = {"   "}
    Dim LCLineDataSeparator() As Char = {","}
    Dim LCLineDataCount As Integer = 4

    Public Function GetTextLines(ByVal str As String) As String()

        Return str.Split(LineSeperator)

    End Function



    Public Function GetLineParts(ByVal str As String) As String()
        Return str.Split(FileNameToSizeSeperator, StringSplitOptions.RemoveEmptyEntries)
    End Function


    Public Function SeparateLCLineData(ByVal str As String) As String()
        Return str.Split(FileNameToSizeSeperator, LCLineDataCount, StringSplitOptions.RemoveEmptyEntries)
    End Function
    


End Module
