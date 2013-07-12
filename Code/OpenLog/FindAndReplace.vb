Public Class FrmFindAndReplace


    Private Sub CmdReplace_Click(sender As System.Object, e As System.EventArgs) Handles CmdReplace.Click

        Dim C1_tmp, C2_tmp As String


        C1_tmp = TxtFind.Text
        C2_tmp = TxtReplace.Text

        If (C1_tmp = "\r") Then
            C1_tmp = vbCrLf
        ElseIf (C1_tmp = "\t") Then
            C1_tmp = vbTab
        End If

        If (C2_tmp = "\r") Then
            C2_tmp = vbCrLf
        ElseIf (C2_tmp = "\t") Then
            C2_tmp = vbTab
        End If



        FrmMain.TxtTerminal.Text = FrmMain.TxtTerminal.Text.Replace(C1_tmp, C2_tmp)


    End Sub

    Private Sub CmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub FrmFindAndReplace_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class