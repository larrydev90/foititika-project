'I klassi yparxei oste na kratame se ena antikeimeno enan pinaka me ta epilegmena pedia
'kai ena String me to onoma tou pinaka.
'I klassi ayti dimiourgithike oste na kratame ta parapano dedomena gia tin eksagogi tou filtrou

Public Class SelectedFields

    Dim tableName As String                 'edo kratame to onoma tou pinaka
    Dim selFields() As String               'edo kratame enan pinaka me ta epilegmena pedia

    'methodos set gia ti metavliti tableName
    Public Sub setTableName(ByRef n As String)
        Me.tableName = n
    End Sub


    'methodos get gia ti metavliti tableName
    Public Function getTableName() As String
        getTableName = tableName
    End Function


    'methodos set gia ti metavliti selFields
    Public Sub setSelFields(ByRef s() As String)
        Me.selFields = s
    End Sub


    'methodos get gia ti metavliti selFields
    Public Function getSelFields() As String()
        getSelFields = selFields
    End Function

End Class