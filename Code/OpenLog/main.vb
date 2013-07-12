Public Class FrmMain





    'Variables Global to the program, and global to the file
#Region "Variables#"
    Private SD_FULL_Size As Integer
    Private SD_USED_Size As Integer = 0

    Public OpenLog As OpenLogHandler = New OpenLogHandler
#End Region

    



#Region "Main window functions"


    'Initilizations of user objects at Form start
    Private Sub FrmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        LogMessage("Initializing ...", LogMessageState._Normal)

        'Initialize variables from program setttings
        AutoFindOpenLOGToolStripMenuItem.Checked = My.Settings.AutoFindOpenLOG
        CmbCOM.Text = My.Settings.COMPort

        Try
            'Attempt to Auto-find the COM Port
            If (My.Settings.AutoFindOpenLOG) Then
                'Force showing the main windows as the next operation will take time
                Me.Show()
                AutoFindOpenLOG()

            Else
                'Try to open last used port
                ReadAvailableCOMPorts()
                LogMessage("Checking previous port selection [" + My.Settings.COMPort + "] ...", LogMessageState._Normal)

                'Check the previously selected COM port if it is available
                ' If so, it is most probably the correct COM port
                If (CheckAndSelectCOMPort(My.Settings.COMPort)) Then
                    CheckIsOpenLOGPort(My.Settings.COMPort)
                End If

            End If






        Catch ex As Exception

            LogMessage(ex.Message, LogMessageState._Error)

        End Try

    End Sub


    'Reshape the controls when the user changes the window size
    Private Sub FrmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        LstLogFiles.Height = Me.Height - 245

        TxtTerminal.Height = Me.Height - 245
        TxtTerminal.Width = Me.Width - 220

        LineShape1.X1 = 0
        LineShape1.X2 = Me.Width - 10
        LineShape1.Y1 = Me.Height - 158
        LineShape1.Y2 = Me.Height - 158

        TxtLog.Top = Me.Height - 151
        TxtLog.Width = Me.Width - 36
    End Sub




#Region "Main: Window Controls"

    'COM Ports Combo Box
    Private Sub CmbCOM_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbCOM.SelectedIndexChanged
        Try

            If (CheckAndSelectCOMPort(CmbCOM.SelectedItem)) Then
                CheckIsOpenLOGPort(My.Settings.COMPort)
            End If

        Catch ex As Exception
            LogMessage(ex.Message, LogMessageState._Error)
        End Try
    End Sub


    'User activated referesh of the list
    Private Sub CmdRead_Click(sender As System.Object, e As System.EventArgs) Handles CmdRead.Click

        Me.Cursor = Cursors.WaitCursor

        LogMessage("Downloading files list ...", LogMessageState._Normal)

        RefereshFilesList()

        LogMessage("Done donwloading!", LogMessageState._Normal)

        Me.Cursor = Cursors.Default

    End Sub


    'When the user double clicks on an item on the list box, open and read it to the text box
    Private Sub LstLogFiles_DoubleClick(sender As Object, e As System.EventArgs) Handles LstLogFiles.DoubleClick

        Me.Cursor = Cursors.WaitCursor

        ReadOpenLogFile(LstLogFiles.SelectedItems.Item(0).Index, LstLogFiles.SelectedItems.Item(0).Text)

        Me.Cursor = Cursors.Default

    End Sub


    'Progress Bar controller
    Public Sub UpdateProgress(ByVal val As Integer)
        If (val > 100) Then
            val = 100
        ElseIf (val < 0) Then
            val = 0
        End If
        PrgReadProgress.Value = val
        PrgReadProgress.Refresh()
    End Sub




#Region "Log Message Functions"

    'Log Message states which are specified by the calling function
    Enum LogMessageState
        _Normal
        _Ok
        _Warning
        _Error
    End Enum


    'Log message will take a message string and a message state and will display it
    ' for the user color coded according to the message state, the message will be timed
    ' as well
    Public Sub LogMessage(ByVal message As String, ByVal state As LogMessageState)

        Dim tmp1, tmp2 As Integer
        Dim TimeStringLength As Integer = 11

        ' Get the text from your rich text box
        Dim tmpstr As String = TxtLog.Rtf

        'Get a string of the current time HH:MM:SS, append the message followed by new line
        TxtLog.AppendText(GetTime() & " | " & message & Environment.NewLine)

        'Select the last line
        tmp1 = TxtLog.Text.Length - message.Length - TimeStringLength - 1
        tmp2 = TxtLog.Text.Length - tmp1 - 1

        TxtLog.Select(tmp1, tmp2)


        ' color the text according to the message state
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




        'Put the cursor at the end of the text box
        TxtLog.Select(TxtLog.Text.Length, 0)

        'Scroll down to the cursor to keep the last lines visible
        TxtLog.ScrollToCaret()
        'TxtLog.Refresh()

    End Sub


    'Function to format the current time into a user friendly look "HH:MM:SS"
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
            tmpstr += "0" + System.DateTime.Now.Second.ToString()
        Else
            tmpstr += System.DateTime.Now.Second.ToString()
        End If

        Return tmpstr

    End Function


#End Region






#End Region




#Region "Main: Menu Items"



#Region "Delete Files"
    'Menu option, when selected it will enable selecting files to be deleted from the SD card
    Private Sub MarkForDeletionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MarkForDeletionToolStripMenuItem.Click
        'Enable check boxes on the list
        LstLogFiles.CheckBoxes = True
        'Enable supporting menu items
        DeleteFileToolStripMenuItem.Enabled = True
        CancelDeletionToolStripMenuItem.Enabled = True
    End Sub

    'Delete the selected files on the list box from OpenLOG
    Private Sub DeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteFileToolStripMenuItem.Click

        Dim FilesToBeDeleted As String = ""

        Try
            For Each item In LstLogFiles.CheckedIndices
                FilesToBeDeleted += LstLogFiles.Items.Item(item).text + vbNewLine
            Next


            If (MessageBox.Show("Are you sure you want to delete these files?" + vbNewLine + FilesToBeDeleted, "Confirm file deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes) Then
                For Each item In LstLogFiles.CheckedIndices
                    'Delete the file from OpenLog
                    OpenLog.DeleteFile(LstLogFiles.Items.Item(item).text)
                    'Remove the check mark as the entry has been processed
                    LstLogFiles.Items.Item(item).checked = False
                    'Remove the file entry from the list
                    LstLogFiles.Items.RemoveAt(item)
                Next
            Else 'If the user selects not to delete
                CancelDeletionToolStripMenuItem_Click(sender, e)
            End If
        Catch ex As Exception
            LogMessage(ex.Message, LogMessageState._Error)
        End Try

    End Sub

    'Cancel deletion sequence and return to normal state
    Private Sub CancelDeletionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelDeletionToolStripMenuItem.Click
        LstLogFiles.CheckBoxes = False
        DeleteFileToolStripMenuItem.Enabled = False
        CancelDeletionToolStripMenuItem.Enabled = False
    End Sub

#End Region


#Region "Options"
    'Menue item: AutoFind OpenLOG
    Private Sub AutoFindOpenLOGToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AutoFindOpenLOGToolStripMenuItem.Click
        If (AutoFindOpenLOGToolStripMenuItem.CheckState = CheckState.Checked) Then
            My.Settings.AutoFindOpenLOG = True
        Else
            My.Settings.AutoFindOpenLOG = False
        End If
    End Sub

#End Region




#End Region





#End Region










#Region "Serial Stuff"


    'Refresh the COM ports list, clear and read current
    Private Sub CmdReadCOMPorts_Click(sender As System.Object, e As System.EventArgs) Handles CmdReadCOMPorts.Click
        ReadAvailableCOMPorts()

        If (My.Settings.AutoFindOpenLOG) Then
            AutoFindOpenLOG()
        End If

    End Sub



    'Read the available COM ports and add them to the Combo Box
    Private Sub ReadAvailableCOMPorts()
        LogMessage("Reading available COM Ports ...", LogMessageState._Normal)
        CmbCOM.Items.Clear()
        CmbCOM.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
        LogMessage("Done!", LogMessageState._Ok)
    End Sub



    'Take a COM port name, then check if it is Open-able
    ' if so, do open and select it
    Private Function CheckAndSelectCOMPort(ByVal _PortName As String, Optional ByVal _SilentMode As Boolean = False) As Boolean

        If (CheckSerialPort(_PortName, _SilentMode)) Then
            'if opening succeded, select the port
            ' and log success
            SelectCOMPort(_PortName, _SilentMode)

            Return True
        Else
            If (Not _SilentMode) Then
                LogMessage("Port is unavailable, please choose correct COM port from the list", LogMessageState._Warning)
            End If

            CmdRead.Enabled = False

            Return False
        End If

    End Function

 


    'Try to open a serual port to see if it is available
    Private Function CheckSerialPort(ByVal PortName As String, Optional ByVal _SilentMode As Boolean = False) As Boolean

        Try
            'Close any previous open COM port if any
            If (COMSerialPort.PortName <> "") Then
                If (COMSerialPort.IsOpen) Then
                    COMSerialPort.Close()
                End If
            End If

            COMSerialPort.PortName = PortName
            COMSerialPort.Open()
            COMSerialPort.Close()
        Catch ex As Exception 'Opening the port Failed
            If (Not _SilentMode) Then
                LogMessage("CheckSerialPort:" + ex.Message, LogMessageState._Error)
            End If
            Return False
        End Try

        Return True

    End Function



    'Open and select a COM port
    Private Sub SelectCOMPort(ByVal _PortName As String, Optional ByVal _SilentMode As Boolean = False)

        Try
            'Set the PortName, this is not really needed, because if we are here
            ' we have already used CheckPort functions which needs to set
            ' the same Port Name
            COMSerialPort.PortName = _PortName

            'Assign the SerialPort object MySerialPort (used by RS232.vb)
            MySerialPort = COMSerialPort

            If (Not _SilentMode) Then
                LogMessage("[" + _PortName + "] selected", LogMessageState._Normal)
                LogMessage("Ready to read serial data", LogMessageState._Ok)
            End If

            'Save the selection
            My.Settings.COMPort = _PortName



        Catch ex As Exception
            If (Not _SilentMode) Then
                LogMessage(ex.Message, LogMessageState._Error)
            End If
        End Try


    End Sub

#End Region









#Region "OpenLog Check & AutoFind"

    'Function to check weither this port is an OpenLOG port by trying to read the SD card size
    Private Function CheckIsOpenLOGPort(ByVal _PortName As String, Optional ByVal SilentMode As Boolean = False) As Boolean
        Try
            'Prepare OpenLog object with the current Port
            OpenLog.Prepare(_PortName)
            'This is the first step which assumes that the serial IS connected to OpenLOG
            ' The success of this can be used to auto-detect the correct COM port
            ' If it failes, we should not continue
            SD_FULL_Size = OpenLog.ReadSDSize()

            'If the attempt to read the SD size returned -1 that means
            ' it encountered an error, because it is not OpenLOG
            ' Return False immediately, which tells that this is not an OpenLOG Port
            If (SD_FULL_Size = -1) Then
                Return False
            End If

            ' Assuming that it IS openLOG
            RefereshFilesList()

            'Maybe the button is not needed any more if we are automatically refreshing
            ' the files list
            CmdRead.Enabled = True
            CmdRead.Focus()


            Return True

        Catch ex As Exception
            If (Not SilentMode) Then
                LogMessage("Port [" + _PortName + "] is not connected to OpenLOG or serial port settings are incorrect", LogMessageState._Warning)
                LogMessage("Serial Settings: ", LogMessageState._Warning)
                LogMessage("Baud Rate: " + COMSerialPort.BaudRate.ToString, LogMessageState._Warning)
            End If
            Return False

        End Try
    End Function



    'Function to Automatically find OpenLog by trying to read the SD card size
    Private Sub AutoFindOpenLOG()
        Dim FoundOpenLog As Boolean = False
        Dim i As Integer = 0

        'Get a list of all available COM ports
        ReadAvailableCOMPorts()

        LogMessage("Attempting to auto-find OpenLOG ...", LogMessageState._Warning)

        UpdateProgress(0)

        Me.Cursor = Cursors.WaitCursor

        For Each item In CmbCOM.Items
            'Check If the port is openable, Run the commands in silent mode 
            ' (no text will be displayed for the user) till done
            If (CheckAndSelectCOMPort(item, True)) Then
                'Check If the port is OpenLOG
                If (CheckIsOpenLOGPort(item, True)) Then
                    'Log Success, flag, and exit the for loop
                    LogMessage("OpenLog Found on [" + item + "]", LogMessageState._Ok)
                    FoundOpenLog = True
                    Exit For
                End If
            End If

            'User Visual
            i += 1
            UpdateProgress((i / CmbCOM.Items.Count) * 100)
        Next

        UpdateProgress(100)
        Me.Cursor = Cursors.Default

        If (Not FoundOpenLog) Then
            LogMessage("OpenLog Not Found!", LogMessageState._Error)
        End If
    End Sub


#End Region








#Region "Reading files list"

    'Function to refresh the files list
    ' it will read the current files from OpenLog and list them on the
    ' list box
    Private Sub RefereshFilesList()

        Dim i As Integer = 0
        Dim Used_SD_Percentage As Double


        Try

            'Update the OpenLog object with the latest data on the SD card
            OpenLog.ReadFilesList()

            'Visual on the ProgressBar on the main window
            UpdateProgress(0)


            'Reset the contents of the FilesList list box
            LstLogFiles.Items().Clear()


            'Add the file names and sizes to the List box
            For Each item In OpenLog.LogFiles

                LstLogFiles.Items.Add(OpenLog.LogFiles(i).Name)
                LstLogFiles.Items.Item(i).SubItems.Add(OpenLog.LogFiles(i).Size)
                SD_USED_Size += CInt(OpenLog.LogFiles(i).Size)

                i += 1
                UpdateProgress((i / OpenLog.LogFiles.Count) * 100)
            Next





            'Convert the read files sizes to KB (file size is returned in bytes)
            SD_USED_Size /= 1000


            'Calculate the used percentage of the SD
            Used_SD_Percentage = (SD_USED_Size / SD_FULL_Size) * 100
            ToolStripPrgBarSDSpace.Value = Used_SD_Percentage
            ToolStripLblSDSpaceInfo.Text = Math.Round(Used_SD_Percentage, 2).ToString() +
                "% is used"

            'If we get to here, we are definetly ONLINE with the OpenLog
            ToolStripLblOnlineState.Text = "Online"
            ToolStripLblOnlineState.ForeColor = Color.Green



        Catch ex As Exception
            LogMessage(ex.Message, LogMessageState._Error)
        End Try


    End Sub


#End Region








#Region "Reading a file from the list"

    'Read the contents of a single file to the Terminal Text box
    Private Sub ReadOpenLogFile(ByVal _FileIndex As Integer, ByVal _FileName As String)
        Dim tmpstr As String


        Try

            LogMessage("Reading file '" + _FileName + "' from SD Card...", LogMessageState._Normal)

            UpdateProgress(0)

            'Store the text in a temporary string, this so as to separate the 
            ' process of reading serial from the process of putting the string 
            ' on the text box, both takes time!
            tmpstr = OpenLog.ReadData(_FileIndex)

            LogMessage("Displaying file Data", LogMessageState._Normal)

            'Put the contents of the file on the text box
            TxtTerminal.Text = tmpstr

            LogMessage("Done!", LogMessageState._Ok)



        Catch ex As Exception

            LogMessage(ex.Message, LogMessageState._Error)

            ToolStripLblOnlineState.Text = "Offline"
            ToolStripLblOnlineState.ForeColor = Color.Red

        End Try
    End Sub

#End Region








End Class
