'Tin klasi ayti tin dimourgisame oste na apothikeyoume se antikeimena ton typo kai to onoma tou epilegmenou pediou
'kai ta textboxes pou emfanizontai sti forma 3 opou o xristis tha grapsei to filtro .

Public Class Tables
    Dim fields As New TextBox   'kratame ta textbox tis form3 pou anaferontai sta pedia tou epilegmenou pinaka
    Dim ftype As New Label      'edo kratame ton typo ton epilegmenon pedion
    Dim fname As New Label

    'edo kratame ta checkboxes tis form 3
    Dim beginLCheckBox As New CheckBox
    Dim containsLCheckBox As New CheckBox
    Dim endLCheckbox As New CheckBox
    Dim greaterThanCheckBox As New CheckBox
    Dim lowerThanCheckBox As New CheckBox

    'methodos set gia ti metavliti fields
    Public Sub setFields(ByRef f As TextBox)
        Me.fields = f
    End Sub

    'methodos get gia ti metavliti fields
    Public Function getFields() As TextBox
        getFields = fields
    End Function

    'methodos set gia ti metavliti ftype
    Public Sub setFtype(ByVal f As Label)
        Me.ftype = f
    End Sub

    'methodos get gia ti metavliti ftype
    Public Function getFtype() As Label
        getFtype = ftype
    End Function

    'methodos set gia ti metavliti beginLCheckBox
    Public Sub setBeginLCheckboxes(ByRef f As CheckBox)
        Me.beginLCheckBox = f
    End Sub

    'methodos get gia ti metavliti beginLCheckBox
    Public Function getBeginLCheckboxes() As CheckBox
        getBeginLCheckboxes = beginLCheckBox
    End Function

    'methodos set gia ti metavliti containsLCheckBox
    Public Sub setContainsLCheckboxes(ByRef f As CheckBox)
        Me.containsLCheckBox = f
    End Sub

    'methodos get gia ti metavliti containsLCheckBox
    Public Function getContainsLCheckboxes() As CheckBox
        getContainsLCheckboxes = containsLCheckBox
    End Function

    'methodos set gia ti metavliti endLCheckbox
    Public Sub setEndLCheckboxes(ByRef f As CheckBox)
        Me.endLCheckbox = f
    End Sub

    'methodos get gia ti metavliti endLCheckbox
    Public Function getEndLCheckboxes() As CheckBox

        getEndLCheckboxes = endLCheckbox
    End Function


    'methodos set gia ti metavliti greaterThanCheckBox
    Public Sub setGreaterThanCheckBoxes(ByRef f As CheckBox)
        Me.greaterThanCheckBox = f
    End Sub

    'methodos get gia ti metavliti greaterThanCheckBox
    Public Function getGreaterThanCheckBoxes() As CheckBox
        getGreaterThanCheckBoxes = greaterThanCheckBox
    End Function


    'methodos set gia ti metavliti lowerThanCheckBox
    Public Sub setLowerThanCheckBoxes(ByRef f As CheckBox)
        Me.lowerThanCheckBox = f
    End Sub


    'methodos get gia ti metavliti lowerThanCheckBox
    Public Function getLowerThanCheckBoxes() As CheckBox
        getLowerThanCheckBoxes = lowerThanCheckBox
    End Function






    'methodos set gia ti metavliti fname
    Public Sub setFname(ByRef f As Label)
        Me.fname = f
    End Sub

    'methodos get gia ti metavliti fname
    Public Function getFname() As Label
        getFname = fname
    End Function
End Class
