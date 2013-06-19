Module RS232

    Public ReadSuccessful As Boolean

    Public MySerialPort As System.IO.Ports.SerialPort


    Enum OpenSerialState
        Ok
        AlreadyOpen
        CannotOpen
    End Enum


    Public Function OpenSerial(Optional ByVal _ReadTimeOut As Integer = 1000) As Integer


        'MySerialPort.ReadBufferSize = 1000000

        Try
            If (Not MySerialPort.IsOpen) Then
                MySerialPort.Open()
                MySerialPort.ReadTimeout = _ReadTimeOut
                Return OpenSerialState.Ok
            End If
            Return OpenSerialState.AlreadyOpen

        Catch ex As Exception

            Return OpenSerialState.CannotOpen

        End Try


    End Function






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


    Public Function ReadSerialWithUpdate(fileSize As Integer) As String
        Dim c As Char
        Dim str As String = ""
        Dim CharCntr As Integer = 0





        Try
            While (Not (c = ">"))
                c = Chr(MySerialPort.ReadChar)

                If (c = ",") Then
                    c = vbTab
                ElseIf (c = ";") Then
                    c = vbNewLine
                End If

                str += c

                CharCntr += 1

                FrmMain.UpdateProgress(CharCntr / fileSize * 100)

            End While

            If (CharCntr - 21) <> fileSize Then   'Due to improper reading of the streams, extra strings such as ">read DATA25.txt" are added to the actual file text, causing the file counter to read more than it should
                FrmMain.LogMessage("File not read fully!! " + (fileSize - (CharCntr - 21)).ToString() + " bytes missing", FrmMain.LogMessageState._Error)
            End If


            Return str

        Catch ex As Exception
            FrmMain.LogMessage(ex.Message, FrmMain.LogMessageState._Error)
            Return "Error in Reading Text, review the log"
        End Try
    End Function

    Public Sub CloseSerial()
        MySerialPort.Close()
    End Sub

End Module
