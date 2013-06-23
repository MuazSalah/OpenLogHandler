'RS232 Functions are implemented here, this is the only function
' which is eligible to access the COM port directly, other functions
' should come through here and only here

Module RS232


#Region "Variables"
    'Serial port object, should be initialized to the Serial Port object
    ' in the form, or can be accessed directly on the other functions
    Public MySerialPort As System.IO.Ports.SerialPort

#End Region



#Region "Enums"

    ' Name self-explanatory!
    Enum OpenSerialState
        Ok
        AlreadyOpen
        CannotOpen
    End Enum


#End Region


#Region "Functions"


    'Initialize and attempt to open the Serial Port
    Public Function OpenSerial(Optional ByVal _COMPort As String = "COM39", Optional ByVal _BaudRate As Integer = 57600, Optional ByVal _ReadBufferSize As Integer = 10000000, Optional ByVal _ReadTimeOut As Integer = 1000) As Integer

        'Intialize the COM port
        MySerialPort.PortName = _COMPort
        MySerialPort.BaudRate = _BaudRate
        MySerialPort.ReadBufferSize = _ReadBufferSize
        MySerialPort.ReadTimeout = _ReadTimeOut


        'Attempt to open
        Try
            If (Not MySerialPort.IsOpen) Then
                MySerialPort.Open()
                Return OpenSerialState.Ok
            End If
            Return OpenSerialState.AlreadyOpen

        Catch ex As Exception
            Return OpenSerialState.CannotOpen
        End Try


    End Function




    'ReadSerial function, it will read characters till the first ">"
    Public Function ReadSerial() As String
        Dim c As Char
        Dim str As String = ""
        Dim CharCntr As Integer = 0


        Try
            While (Not (c = ">"))
                c = Chr(MySerialPort.ReadChar)
                str += c
            End While
            Return str
        Catch ex As Exception
            Return ex.Message
        End Try


    End Function





    'ReadSerialWithUpdate function, it will read characters till the first ">"
    ' it will also update the main form progress bar with current progress
    Public Function ReadSerialWithUpdate(fileName As String, fileSize As Integer) As String
        Dim c As Char
        Dim str As String = ""
        Dim CharCntr As Integer = 0
        Dim ExtraCharacters As Integer


        ' 5: "read "
        ' FileName
        ' 3: CR, LF and something else
        ExtraCharacters = 5 + fileName.Length + 3


        Try

            For index = 1 To ExtraCharacters
                c = Chr(MySerialPort.ReadChar)
            Next


            While ((Not (c = ">")) And (Not (CharCntr = fileSize)))
                'Read a Char
                c = Chr(MySerialPort.ReadChar)
                'Add it to a temporary string
                str += c
                'Increment the counter
                CharCntr += 1
                'Update the main window
                FrmMain.UpdateProgress(CharCntr / fileSize * 100)

            End While

            'Report that there is a difference in the read file
            If CharCntr <> fileSize Then   'Due to improper reading of the streams, extra strings such as ">read DATA25.txt" are added to the actual file text, causing the file counter to read more than it should
                FrmMain.LogMessage("File not read fully!! " + (fileSize - (CharCntr - 21)).ToString() + " bytes missing", FrmMain.LogMessageState._Error)
            End If


            Return str

        Catch ex As Exception
            FrmMain.LogMessage(ex.Message, FrmMain.LogMessageState._Error)
            Return "Error in Reading Text, review the log"
        End Try
    End Function





    'Close serial port
    Public Sub CloseSerial()
        MySerialPort.Close()
    End Sub





#End Region










End Module
