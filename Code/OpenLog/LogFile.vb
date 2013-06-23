' LogFile Class
' Each File in the OpenLog SD card is accessed as a LogFile object
' This object is defined as LogFile class, and has mainly three (3)
' properties:
' File Name (full name)
' File Size (in KB)
' File Data (as a single string)

Public Class LogFile


#Region "Variables"

    ' _Name: Stores the current File Name
    Private _Name As String
    ' _Size: Stores the current File Size
    Private _Size As Integer
    ' _Data: stores the current file string
    Private _Data As String


#End Region





#Region "Properties"


    'Get and Set File Name
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property


    ' Get and Set File Size
    Public Property Size() As Integer
        Get
            Return _Size
        End Get
        Set(ByVal value As Integer)
            _Size = value
        End Set
    End Property


    ' Get and Set File Data
    Public Property Data() As String
        Get
            Return _Data
        End Get
        Set(ByVal value As String)
            _Data = value
        End Set
    End Property


#End Region





End Class
