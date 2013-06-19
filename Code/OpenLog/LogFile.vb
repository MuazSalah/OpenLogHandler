Public Class LogFile


    Private FileName As String
    Private FileSize As Integer
    Private FileData As String
    Private IsLCEntry As Boolean
    Private _NumEntries As Integer






    Public Property Name() As String
        Get
            Return FileName
        End Get
        Set(ByVal value As String)
            FileName = value
        End Set
    End Property



    Public Property Size() As Integer
        Get
            Return FileSize
        End Get
        Set(ByVal value As Integer)
            FileSize = value
        End Set
    End Property




    Public Property Data() As String
        Get
            Return FileData
        End Get
        Set(ByVal value As String)
            FileData = value
        End Set
    End Property


    Public Property IsLC() As Boolean
        Get
            Return IsLCEntry
        End Get
        Set(ByVal value As Boolean)
            IsLCEntry = value
        End Set
    End Property



    Public Property LCCount() As Integer
        Get
            Return _NumEntries
        End Get
        Set(ByVal value As Integer)
            _NumEntries = value
        End Set
    End Property





End Class
