'OpenLog Handler, this is the class which takes care of the communication
' with the OpenLog module.
' Only the contents of this class is eligible to the low level OpenLog commands
' Any other user should use this class to access OpenLog
' This class assumes an external defined serial port called "MySerialPort"


Public Class OpenLogHandler

#Region "OpenLog Command Strings"
    Private Const _ls As String = "ls" & Chr(13)
    Private Const _read As String = "read "
    Private Const _delete As String = "rm "
    Private _EscapeSequence() As Byte = {26, 26, 26}
    Private Const _disk As String = "disk" & Chr(13)
#End Region



#Region "Variables"

    ' _LogFiles: stores the list of files which are read from OpenLog
    ' mainly, it contains the file name, file size, and file data
    Private _LogFiles As List(Of LogFile)

    ' Stores the settings of the Serial COM port to be used
    Private _COMPort As IO.Ports.SerialPort


#End Region


#Region "New"

    Sub New(Optional ByVal p1 As Integer = 0)
        ' Initilization of the list
        _LogFiles = New List(Of LogFile)

    End Sub



#End Region





#Region "Properties"

    ' LogFiles() Property
    Public Property LogFiles() As List(Of LogFile)
        Get
            Return _LogFiles
        End Get
        Set(ByVal value As List(Of LogFile))
            _LogFiles = value
        End Set
    End Property

    '_COMPort property
    Public Property COMPort() As IO.Ports.SerialPort
        Get
            Return _COMPort
        End Get
        Set(ByVal value As IO.Ports.SerialPort)
            _COMPort = value
        End Set
    End Property


#End Region













#Region "OpenLog Write Functions"

    ' Sends "ls" command to list the files
    Public Sub ListFiles()
        MySerialPort.Write(_ls)
    End Sub

    ' Sends "Ctrl+Z", ASCII 26 three times
    Public Sub CommandMode()
        MySerialPort.Write(_EscapeSequence, 0, _EscapeSequence.Length)
        'Just to make sure that we are ready for next command, in case
        ' that we are already in command mode
        MySerialPort.Write(Chr(13))

    End Sub

    ' Sends "read"  command followed by file name to read a file
    Private Sub ReadFile(ByVal FileName As String)
        MySerialPort.Write(_read & FileName & Chr(13))
    End Sub

    ' Sends "rm" command followed by file name to delete a file
    Public Sub DeleteFile(ByVal FileName As String)
        MySerialPort.Write(_delete & FileName & Chr(13))
    End Sub

    ' Sends "disk" command to read SD info from OpenLog
    Private Sub GetSDInfo()
        MySerialPort.Write(_disk)
    End Sub


#End Region










    Public Sub Prepare(ByVal _PortName As String)
        'Open the selected COM port
        RS232.OpenSerial(_PortName)
    End Sub







#Region "OpenLog Read Functions"



    ' Returns SD card size in KB
    Public Function ReadSDSize() As Integer

        Dim line_seperator As Char() = "   "
        Dim tmp_arr As String()
        Dim tmp_arr2 As String()
        Dim tmp_arr_size As Integer

        Try


            'Get the OpenLOG to Command Mode
            CommandMode()

            'Read the initial text after going to command mode " ~>"
            RS232.ReadSerial()

            'Command to read SD card info from OpenLOG
            GetSDInfo()

            ' The received string is usually in the form:
            '------------------------------------------
            '~>disk
            '
            'Card type: SDHC
            'Manufacturer ID: 3
            'OEM ID: SD
            'Product: SU08G
            'Version: 8.0
            'Serial number: 1492104369
            'Manufacturing date: 3/2013
            'Card Size: 7761920 KB
            '>


            'Read the SD Info
            tmp_arr = DataParser.SeparateString(RS232.ReadSerial(), {Chr(13)})

            'Read the line containing the size info
            tmp_arr2 = tmp_arr(9).Split(line_seperator)

            'The result is:
            ' "Card"
            ' "Size:"
            ' xxxxxx    <----- index 2
            ' "KB"

            'Read the size fields and convert to integer
            tmp_arr_size = CInt(tmp_arr2(2))


            Return tmp_arr_size

        Catch ex As Exception
            'FrmMain.LogMessage(ex.Message, FrmMain.LogMessageState._Error)
            Return -1
        End Try






    End Function






    'Read Files List by sending the "ls" command,
    ' The result is stored in _LogFile list and is accessible through
    ' the property "LogFiles
    Public Sub ReadFilesList()

        Dim str1(), str2() As String


        'Reset the Files List
        _LogFiles.Clear()


        ' Send command to list the files "ls"
        ListFiles()


        'First read, its going to read the 12<~> string, 
        ' you need to read a second time to get the list of files
        ' You can use the str1 to check if things are going as expected
        str1 = DataParser.SeparateString(RS232.ReadSerial, {Chr(13)})

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
            str2 = DataParser.SeparateString(str1(index), "   ", StringSplitOptions.RemoveEmptyEntries)
            _LogFiles.Add(New LogFile)
            _LogFiles(i).Name = str2(0).Substring(1)
            _LogFiles(i).Size = CInt(str2(1))
            i += 1
        Next




    End Sub






    'Reads the file contents and returns it on a string
    Public Function ReadData(LogFileIndex As Integer) As String

        'Dim tmpstr As String

        'Send command for OpenLog to output file contents
        ReadFile(_LogFiles(LogFileIndex).Name)

        'Read the file content and continously update the progress bar
        _LogFiles(LogFileIndex).Data = RS232.ReadSerialWithUpdate(_LogFiles(LogFileIndex).Name, _LogFiles(LogFileIndex).Size)


        'Return the obtained string
        Return _LogFiles(LogFileIndex).Data

    End Function


#End Region










End Class
