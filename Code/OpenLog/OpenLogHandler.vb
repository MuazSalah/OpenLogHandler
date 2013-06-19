Public Class OpenLogHandler

    Private Const _ls As String = "ls" & Chr(13)
    Private Const _read As String = "read "
    Private Const _delete As String = "rm "
    Private _EscapeSequence() As Byte = {26, 26, 26}
    Private Const _disk As String = "disk" & Chr(13)

    Public InCommandMode As Boolean = False

    Private _LogFiles As List(Of LogFile)



    Sub New(Optional ByVal p1 As Integer = 0)
        ' TODO: Complete member initialization 
        _LogFiles = New List(Of LogFile)
    End Sub



#Region "Properties"
    Public Property LogFiles() As List(Of LogFile)
        Get
            Return _LogFiles
        End Get
        Set(ByVal value As List(Of LogFile))
            _LogFiles = value
        End Set
    End Property
#End Region





    Public Sub ListFiles()
        MySerialPort.Write(_ls)
    End Sub

    Public Sub CommandMode()
        MySerialPort.Write(_EscapeSequence, 0, _EscapeSequence.Length)
        MySerialPort.Write(Chr(13))
    End Sub

    Private Sub ReadFile(ByVal FileName As String)
        MySerialPort.Write(_read & FileName & Chr(13))
    End Sub

    Public Sub DeleteFile(ByVal FileName As String)
        MySerialPort.Write(_delete & FileName & Chr(13))
    End Sub

    Private Sub GetSDInfo()
        MySerialPort.Write(_disk)
    End Sub




    ' Returns SD card size in KB
    Public Function ReadSDSize() As Integer


        Dim line_seperator As Char() = " "
        Dim tmp_arr As String()
        Dim tmp_arr2 As String()
        Dim tmp_arr_size As Integer

        Try
            'Open the selected COM port
            RS232.OpenSerial()

            'Get the OpenLOG to Command Mode
            CommandMode()

            'Read the initial text after going to command mode " ~>"
            RS232.ReadSerial()

            'Command to read SD card info from OpenLOG
            GetSDInfo()

            'Read the SD Info
            tmp_arr = DataParser.GetTextLines(RS232.ReadSerial())

            'Read the line containing the size info
            tmp_arr2 = tmp_arr(9).Split(line_seperator)

            'Read the size fields, e.g. 128000 KB
            tmp_arr_size = CInt(tmp_arr2(2))


            Return tmp_arr_size

        Catch ex As Exception
            FrmMain.LogMessage(ex.Message, FrmMain.LogMessageState._Error)
            Return 1
        End Try






    End Function







    Public Sub ReadFilesList()
        Dim str1(), str2() As String




        If Not InCommandMode Then
            CommandMode()
            InCommandMode = True
        End If

        ListFiles()


        'First read, its going to read the 12<~> string, 
        ' you need to read a second time to get the list of files
        ' You can use the str1 to check if things are going as expected
        str1 = DataParser.GetTextLines(RS232.ReadSerial)
        str1 = DataParser.GetTextLines(RS232.ReadSerial)

        'starting at four because:
        ' 0: ls
        ' 1: \r
        ' 2: volume fat blah blah
        ' 3: CONFIG.txt
        ' 4: xxxxxxx
        '
        ' and we end at count-2 (count-1 -1) because the last string is ">" again



        Dim i As Integer = 0
        For index = 4 To str1.Count - 2
            str2 = DataParser.GetLineParts(str1(index))
            _LogFiles.Add(New LogFile)
            _LogFiles(i).Name = str2(0).Substring(1)
            _LogFiles(i).Size = CInt(str2(1))
            i += 1
        Next




    End Sub








    Public Function ReadData(FileName As String, fileSize As Integer) As String ''()

        Dim tmpstr As String


        ' Here we need to ignore the first and second lines:
        ' "read LOG00167.TXT"
        ' " "



        'Send command for OpenLog to output file contents
        ReadFile(FileName)



        'Read the file content and continously update the progress bar
        tmpstr = RS232.ReadSerialWithUpdate(fileSize)

        'remove the above said extra string
        tmpstr = tmpstr.Substring(_read.Length + FileName.Length + 2)



        Return tmpstr

    End Function



End Class
