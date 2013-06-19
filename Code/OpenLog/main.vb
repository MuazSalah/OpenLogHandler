Public Class FrmMain

    Private SD_FULL_Size As Integer
    Private SD_USED_Size As Integer = 0

    Public OpenLog As OpenLogHandler = New OpenLogHandler





#Region "Main window functions"



    Private Sub FrmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load



        LogMessage("Initializing ...", LogMessageState._Normal)

        Try 'Try to open last used port,

            LogMessage("Reading available COM Ports ...", LogMessageState._Normal)
            CmbCOM.Items.AddRange(IO.Ports.SerialPort.GetPortNames)

            LogMessage("Checking previous port selection [" + My.Resources.COMPort + "] ...", LogMessageState._Normal)

            If (CheckSerialPort(COMSerialPort, My.Resources.COMPort)) Then
                'if opening succeded, select the port
                ' and log success

                LogMessage("Previously used port [" + COMSerialPort.PortName + "] is available!", LogMessageState._Ok)
                LogMessage("[" + COMSerialPort.PortName + "] selected", LogMessageState._Normal)

                CmbCOM.Text = COMSerialPort.PortName



                MySerialPort = COMSerialPort
                SD_FULL_Size = OpenLog.ReadSDSize()


                CmdRead.Enabled = True
                CmdRead.Focus()

                LogMessage("Ready to read serial data", LogMessageState._Ok)

            Else
                LogMessage("Port is unavailable, please choose correct COM port from the list", LogMessageState._Warning)

                CmdRead.Enabled = False
                CmbCOM.Text = "COM Port"
            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub



    Private Sub FrmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        LstLogFiles.Height = Me.Height - 245

        TxtTerminal.Height = Me.Height - 245
        TxtTerminal.Width = Me.Width - 200

        LineShape1.X1 = 0
        LineShape1.X2 = Me.Width - 10
        LineShape1.Y1 = Me.Height - 158
        LineShape1.Y2 = Me.Height - 158

        TxtLog.Top = Me.Height - 151
        TxtLog.Width = Me.Width - 36
    End Sub



#End Region





#Region "Main: CmbCOM"
    Private Sub CmbCOM_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbCOM.SelectedIndexChanged
        Try

            If (CheckSerialPort(COMSerialPort, CmbCOM.Text)) Then
                LogMessage("Serial port " + CmbCOM.Text + " selected!", LogMessageState._Ok)

                COMSerialPort.PortName = CmbCOM.Text

                MySerialPort = COMSerialPort
                'OpenLog.ReadSDInfo()



                CmdRead.Enabled = True
                CmdRead.Focus()



            Else
                LogMessage("Opening serial port " + CmbCOM.Text + " failed, is the port used by another application?", LogMessageState._Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region








    Public Sub UpdateProgress(ByVal val As Integer)
        If (val > 100) Then
            val = 100
        ElseIf (val < 0) Then
            val = 0
        End If
        PrgReadProgress.Value = val
        PrgReadProgress.Refresh()
    End Sub









    Private Function CheckSerialPort(ByRef SerialPortHandle As System.IO.Ports.SerialPort, ByVal PortName As String) As Boolean

        Try
            COMSerialPort.PortName = PortName
            COMSerialPort.Open()
            COMSerialPort.Close()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function











    Private Sub LstLogFiles_DoubleClick(sender As Object, e As System.EventArgs) Handles LstLogFiles.DoubleClick

        Dim tmpstr As String
        Dim fileSize As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            LogMessage("Reading file '" + LstLogFiles.SelectedItems.Item(0).Text + "' from SD Card...", LogMessageState._Normal)

            UpdateProgress(0)

            fileSize = OpenLog.LogFiles(LstLogFiles.SelectedItems.Item(0).Index).Size

            tmpstr = OpenLog.ReadData(LstLogFiles.SelectedItems.Item(0).Text, fileSize)

            LogMessage("Done!", LogMessageState._Normal)

            TxtTerminal.Text = ""


            LogMessage("Displaying file Data", LogMessageState._Normal)




            TxtTerminal.Text = tmpstr

            LogMessage("Done!", LogMessageState._Ok)

            Me.Cursor = Cursors.Default

        Catch ex As Exception

            LogMessage(ex.Message, LogMessageState._Error)

            ToolStripLblOnlineState.Text = "Offline"
            ToolStripLblOnlineState.ForeColor = Color.Red

        End Try


    End Sub

















#Region "Log Message Functions"


    Enum LogMessageState
        _Normal
        _Ok
        _Warning
        _Error
    End Enum


    Public Sub LogMessage(ByVal message As String, ByVal state As LogMessageState)

        Dim tmp1, tmp2 As Integer
        Dim TimeStringLength As Integer = 11

        ' Get the text from your rich text box
        Dim tmpstr As String = TxtLog.Rtf

        TxtLog.AppendText(GetTime() & message & Environment.NewLine)


        tmp1 = TxtLog.Text.Length - message.Length - TimeStringLength - 1
        tmp2 = TxtLog.Text.Length - tmp1 - 1

        TxtLog.Select(tmp1, tmp2)

        Select Case (state)

            Case LogMessageState._Normal
                TxtLog.SelectionColor = Color.Black

            Case LogMessageState._Ok
                TxtLog.SelectionColor = Color.Green

            Case LogMessageState._Warning
                TxtLog.SelectionColor = Color.Orange

            Case LogMessageState._Error
                TxtLog.SelectionColor = Color.Red

        End Select





        TxtLog.Select(TxtLog.Text.Length, 0)

        TxtLog.ScrollToCaret()
        TxtLog.Refresh()

    End Sub


    Private Function GetTime() As String

        Dim tmpstr As String

        If System.DateTime.Now.Hour < 10 Then
            tmpstr = "0" + System.DateTime.Now.Hour.ToString() + ":"
        Else
            tmpstr = System.DateTime.Now.Hour.ToString() + ":"
        End If

        If System.DateTime.Now.Minute < 10 Then
            tmpstr += "0" + System.DateTime.Now.Minute.ToString() + ":"
        Else
            tmpstr += System.DateTime.Now.Minute.ToString() + ":"
        End If


        If System.DateTime.Now.Second < 10 Then
            tmpstr += "0" + System.DateTime.Now.Second.ToString() + " | "
        Else
            tmpstr += System.DateTime.Now.Second.ToString() + " | "
        End If

        Return tmpstr

    End Function


#End Region






    Private Sub CmdRead_Click(sender As System.Object, e As System.EventArgs) Handles CmdRead.Click

        Me.Cursor = Cursors.WaitCursor

        LogMessage("Downloading files list ...", LogMessageState._Normal)

        RefereshFilesList()

        LogMessage("Done donwloading!", LogMessageState._Normal)

        Me.Cursor = Cursors.Default

        CmdRead.Enabled = False


    End Sub



    Private Sub RefereshFilesList()

        Dim i As Integer = 0
        Dim Used_SD_Percentage As Double


        Try
            OpenLog.ReadFilesList()

            UpdateProgress(0)




            For Each item In OpenLog.LogFiles

                LstLogFiles.Items.Add(OpenLog.LogFiles(i).Name)
                LstLogFiles.Items.Item(i).SubItems.Add(OpenLog.LogFiles(i).Size)
                SD_USED_Size += CInt(OpenLog.LogFiles(i).Size)

                i += 1
                UpdateProgress((i / OpenLog.LogFiles.Count) * 100)
            Next





            'Convert the read files sizes to KB (file size is returned in bytes)
            SD_USED_Size /= 1000



            Used_SD_Percentage = (SD_USED_Size / SD_FULL_Size) * 100
            ToolStripPrgBarSDSpace.Value = Used_SD_Percentage
            ToolStripLblSDSpaceInfo.Text = Math.Round(Used_SD_Percentage, 2).ToString() +
                "% is used"

            ToolStripLblOnlineState.Text = "Online"
            ToolStripLblOnlineState.ForeColor = Color.Green



        Catch ex As Exception
            LogMessage(ex.Message, LogMessageState._Error)
        End Try


    End Sub


    Private Sub LstLogFiles_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LstLogFiles.SelectedIndexChanged

    End Sub

    Private Sub MarkForDeletionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MarkForDeletionToolStripMenuItem.Click
        LstLogFiles.CheckBoxes = True
        DeleteFileToolStripMenuItem.Enabled = True
        CancelDeletionToolStripMenuItem.Enabled = True
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteFileToolStripMenuItem.Click

        Dim FilesToBeDeleted As String = ""

        For Each item In LstLogFiles.CheckedIndices
            FilesToBeDeleted += LstLogFiles.Items.Item(item).text + vbNewLine
        Next


        If (MessageBox.Show("Are you sure you want to delete these files?" + vbNewLine + FilesToBeDeleted, "Confirm file deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes) Then
            For Each item In LstLogFiles.CheckedIndices

                OpenLog.DeleteFile(LstLogFiles.Items.Item(item).text)
                LstLogFiles.Items.Item(item).checked = False
                LstLogFiles.Items.RemoveAt(item)

            Next
        Else
            CancelDeletionToolStripMenuItem_Click(sender, e)
        End If





    End Sub

    Private Sub CancelDeletionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelDeletionToolStripMenuItem.Click
        LstLogFiles.CheckBoxes = False
        DeleteFileToolStripMenuItem.Enabled = False
        CancelDeletionToolStripMenuItem.Enabled = False
    End Sub
End Class
