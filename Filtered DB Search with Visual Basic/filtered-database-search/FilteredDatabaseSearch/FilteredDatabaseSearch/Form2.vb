Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Text.RegularExpressions
Public Class Form2
    'Metavliti gia na kratame se oli tin efarmogi pio filter einai otan kanoume save to filter
    Public filtercounter2 As Integer = 1
    Public Shared selectedPedia() As Tables
    Dim selectedTables() As String
    'Dynamikos pinakas typou CheckedListBox, ston opoio pername ola ta CheckedListBoxes pou dhmiourgountai dynamika sthn Form2
    Public checkedListBoxesVector() As CheckedListBox = {}
    'Didiastastos pinakas.Sthn prwth sthlh tou apothikeyontai ta onomata twn sthlwn gia tous epilegmenous pinakes apo to CheckedListBox1
    'ths Form1 enw sthn deyterh oi antisoixoi kwdikoi twn typwn twn sthlwn. 
    Dim fieldTypesVector(400, 2) As String

    Dim selFields() As SelectedFields

    Public Function getSelFields() As SelectedFields()
        getSelFields = selFields
    End Function

    Public Function getselectedPedia() As Tables()
        getselectedPedia = selectedPedia
    End Function


    Private Sub showDataTypeAsString(ByRef type As String)
        'Methodos gia thn metatroph tou periexomenou tou string pou periexei ton kwdiko tou typou tou epilegmenou pediou sto onoma tou typou

        If type = "130" Or type = "202" Then
            type = "Text"

        ElseIf type = "203" Then
            type = "Memo/Hyperlink"

        ElseIf type = "17" Then
            type = "Number:Byte"

        ElseIf type = "2" Then
            type = "Number:Integer"

        ElseIf type = "3" Then
            type = "Number:Long/Auto Number"

        ElseIf type = "4" Then
            type = "Number:Single"

        ElseIf type = "5" Then
            type = "Number:Double"

        ElseIf type = "72" Then
            type = "Number:Replica"

        ElseIf type = "131" Then
            type = "Number:Decimal"

        ElseIf type = "7" Then
            type = "Date/Time"

        ElseIf type = "6" Then
            type = "Currency"

        ElseIf type = "11" Then
            type = "Yes/No"

        ElseIf type = "205" Or type = "128" Then
            type = "OLE Object"

        ElseIf type = "204" Then
            type = "Attachment/ReplicationID"

        End If



    End Sub




    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Otan fortwnetai h Form2 emfanizontai se ayth, gia kathe epilegmeno checkbox apo to CheckListBox1 ths Form1, ena label me to onoma tou pinaka 
        'kai ena CheckedListBox pou periexei ta onomata olwn twn pediwn tosu sygkekrimenou pinaka

        Dim counterCheckList As Integer = 1 'Metavliti pou xrhsimopoieitai gia na orizoume dynamika to Location gia ton orizontio aksona tou kathe ChekedListBox pou dhmiourgeitai sthn Form2
        Dim counterName As Integer = 1 'Metavliti pou xrhsimopoieitai gia na orisoume dynamika thn idiothta Name tou kathe Label pou dhmiourgeitai sthn Form2
        Dim counterLabel As Integer = 1 'Metavliti pou xrhsimopoieitai gia na orizoume dynamika to Location gia ton orizontio aksona tou kathe Label pou dhmiourgeitai sthn Form2

        Dim j As Integer = 0 'Deikths gia thn trexousa grammh tou pinaka fieldTypesVector.

        Dim selectedTablesLength As Integer = 0
        Dim counterTableArray As Integer = 1
        For Each checkeditem In Form1.CheckedListBox1.CheckedItems
            selectedTablesLength += 1
        Next
        selectedTables = New String(selectedTablesLength) {}


        For Each checkeditem In Form1.CheckedListBox1.CheckedItems
            'Trexei ena loop gia ola ta epilegmena pedia tou CheckedListBox1 ths Form1, kai gia kathe ane apo ayta dhmiourgeitai ena Label me to onoma tou 
            'antistoixou pinaka kai ena CheckedListBox pou periexei ta onomata tvn pediwn tou antistoixou pinaka

            'Dhmiourgia tou Label. Sthn idiothta Text dinetai to onoma tou pinaka pou antistoixei sto sygkekrimeno CheckBox apo to CheckedListBox1 ths Form1
            Dim nameoftable As String = checkeditem
            Dim lbl As New Label
            lbl.Name = "Label" & counterName
            lbl.Size = New Size(100, 20)
            lbl.Location = New Point(30 * counterLabel, 36)
            lbl.Text = nameoftable
            lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            'Dhmiourgia tou CheckedListbox pou periexei ta pedia tou epilegmenou pinaka. Sthn idiothta Name dinetai to onoma tou pinaka pou 
            'antistoixei sto sygkekrimeno CheckBox apo to CheckedListBox1 ths Form1
            Dim chklistbox As New CheckedListBox
            chklistbox.Name = nameoftable
            chklistbox.Size = New Size(120, 275)
            chklistbox.Location = New Point(21 * counterCheckList, 80)
            chklistbox.CheckOnClick = True



            Dim myconn As OleDbConnection
            Dim ConnectionString As String
            Dim schemaTable As DataTable
            Dim i As Integer

            'Dinetai timh sto ConnectionStrnig.Synnenwnetai to string pou deixnei ton paroxo me to text apo to TextPath.
            'Me ayto ton tropo mporoume na xrhsimopoihsoume opoiadhpote vash gia na syndethoume arkei na antistoixei ston sygkekrimeno paroxo.
            'Dhmiourgoume thn sydesh me vash to ConnectionString kai epeita thn anoigoume.
            ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Form1.TextPath.Text
            myconn = New OleDb.OleDbConnection(ConnectionString)
            myconn.Open()


            'Gemizoume to schemaTable pou einai typou DataTable me ta onomata twn sthlwn gia ton pinaka pou dinetai ws parametros sto trito keli tou
            'periorismou pou einai to deytero orisma sthn methodo GetOleDbSchemaTable. To prwto orisma orizei ton typo ths plhroforias pou theloume,
            'dhladh sthles. Sthn synexeia kleinoume thn syndesh me thn vash
            schemaTable = myconn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, _
                          New Object() {Nothing, Nothing, nameoftable, Nothing})
            myconn.Close()


            'Prospelazoume oles tis grammes tou pinaka  schemaTable. Pairnoume apo kathe grammh to onoma ths sthlhs kai to topothetoume sto CheckedListBox 
            'pou exei dhmiourgithei dynamika kai sthn prwth sthlh tou pinaka fieldTypesVector. Episis apo kathe grammh pernoume ton kwdiko typou ths 
            'antistoixhs sthlhs kai ton apothikeyoume sthn deyterh sthlh tou pinaka fieldTypesVector.
            For i = 0 To schemaTable.Rows.Count - 1
                chklistbox.Items.Add(schemaTable.Rows(i)!COLUMN_NAME.ToString)

                fieldTypesVector(j, 0) = schemaTable.Rows(i)!COLUMN_NAME.ToString
                fieldTypesVector(j, 1) = schemaTable.Rows(i)!DATA_TYPE.ToString
                j += 1
            Next i

            'Prosthetoume to Label kai to CheckedListBox pou dhmiourghsame sto TablePanel ths trexousas formas (Form2)
            Me.TablePanel.Controls.Add(lbl)
            Me.TablePanel.Controls.Add(chklistbox)

            selectedTables(counterTableArray) = nameoftable
            counterTableArray += 1

            'Aykshsh tou megethous tou dynamikou pinaka checkedListBoxesVector kata 1, diatirwntas anepafa ta dedomena pou exei hdh kai epeita perasma
            'se ayton to CheckedListBox pou dhmiourghsame dynamika.
            ReDim Preserve checkedListBoxesVector(checkedListBoxesVector.Length)
            checkedListBoxesVector(counterName - 1) = chklistbox
            counterCheckList += 7
            counterName += 1
            counterLabel += 5
        Next

    End Sub
    Private Sub ButtonBackForm1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackForm1.Click
        'Sto pathma tou koumpiou Back ths Form2 emfanizetai h Form1 kai kleinei h trexousa forma (Form2)
        'kai metaferoume tin timi tou filtercounter2 stin filtercounter1 tis form1
        Form1.Visible = True
        Me.Close()
        Form1.filtercounter1 = filtercounter2

    End Sub

    Private Sub ButtonNextForm3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNextForm3.Click
        'Sto pathma tou koumpiou Next ths Form2 emfanietai h Form3 kai exafanizetai h trexousa forma (Form2).Akoma dhmiourgeitai sthn Form3 gia kathe epilegmeno
        'pedio apo ola ta CheckedListBoxes ths Form2 (pou antisoixoun stous pinakes) ena Label me to onoma tou pediou, ena Textbox gia na oirsei o xrhsths timh
        'gia to sygkekrimeno pedio, ena Label me ton typo tou pediou kai pente Checkboxes gia dynatothtes filtrarismatos me xrhsh twn telestwn LIKE (gia arxh, telos,
        'h endiamesa), > kai <.Episis dhmiourgountai kai 5 Labels gia thn epexhghsh ths leitourgias twn Checkboxes. Telos dhmiourgountai Labels me ta onomata twn 
        'pinakwn gia ton  kalytero diaxwrismo twn pediwn sthn Form3
        Form3.Show()
        Form3.filtercounter3 = filtercounter2


        Dim nameWithoutSpaces As String 'Metavliti gia thn apothikeysh onomatos pinaka ths vashs xwris kena (gia onomata pinakwn me perissoteres ths mias lexhs)
        Dim fullNameOfField As String 'Metavliti gia thn apothikeysh tou onomatos epilegmenou pediou me thn morfh onomaPinaka.onomaPediou wste na fainetai kai o pinakas ston opoio anhkei
        Dim j As Integer 'Metavliti pou xrhsimopoieitai ws deikths grammhs gia thn prospelash tou pinaka fieldTypesVector
        Dim counter As Integer = 1 'Metavliti pou xrhsimopoieitai gia na orisoume dynamika thn idiothta Name gia diafora controls ths Form3
        Dim counterTableArray As Integer = 1
        Dim checkedfieldscounter As Integer = 0 'Metavliti gia thn metrhsh sou synolou twn epilegmenwn pediwn apo ola ta CheckedListBoxes ths Form2
        Dim flag As Boolean = False 'Flag pou deixnei an to onoma enos pinaka periexei keno h oxi

        Dim selectedPediaLength As Integer = 0
        Dim counterPediaArray As Integer = 1
        For i = 0 To checkedListBoxesVector.Length - 1
            If (checkedListBoxesVector(i).CheckedItems.Count <> 0) Then
                selectedPediaLength += checkedListBoxesVector(i).CheckedItems.Count
            End If
        Next
        selectedPedia = New Tables(selectedPediaLength) {}



        'Emfwleymeno loop gia thn prospelash kathe epilegmenou pediou apo kathe epilegmeno pinaka kai thn dhmiourgia kai emfanish gia ayto twn antistoixwn controls sthn Form3
        'Gia kathe CheckedListBox ths Form2
        For i = 0 To checkedListBoxesVector.Length - 1

            'Dhmiourgia tou Label me to onoma tou pinaka.
            Dim tlbl As New Label
            tlbl.Name = "TableLabel" & counter
            tlbl.Size = New Size(150, 25)
            tlbl.Location = New Point(21, 35 * counter)
            tlbl.Text = selectedTables(counterTableArray)
            tlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Prosthiki tou Label sto FieldPanel ths Form3
            Form3.FieldPanel.Controls.Add(tlbl)
            counterTableArray += 1
            counter += 1

            'Gia kathe epilegmeno pedio tou trexontos CheckedListBox
            For Each checkeditem In checkedListBoxesVector(i).CheckedItems
                checkedfieldscounter += 1

                'Dhmiourgia tou Label me to onoma tou pediou.
                Dim nameOfField As String = checkeditem
                Dim lbl As New Label
                lbl.Name = "FieldLabel" & counter
                lbl.Size = New Size(150, 25)
                lbl.Location = New Point(21, 35 * counter)
                lbl.Text = nameOfField
                lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                'An to onoma tou pinaka periexei keno tote
                If Regex.IsMatch(checkedListBoxesVector(i).Name, "^.*[ ].*") Then

                    'afaireitai to keno kai to neo onoma (xwris keno) apothikeyetai sthn metavliti nameWithoutSpaces.H metavliti ayth xrhsimopoieitai ws allias tou
                    'onomatos tou pinaka sto query
                    nameWithoutSpaces = Replace(checkedListBoxesVector(i).Name, " ", vbNullString)
                    'H metavliti fullNameOfField apothikeyei to onoma tou epilegmenou pediou me thn morfh onomaPinaka.onomaPediou
                    fullNameOfField = nameWithoutSpaces & "." & nameOfField
                    'To flag ginetai True gia na oristei to onoma tou pinaka me thn xrhsh allias.To onoma katopin tha perasei sto FROM clause tou query
                    flag = True

                    'An to onoma tou pinaka den periexei keno tote to onoma tou pediou grafetai me thn morfh onomaPinak.onomaPediou xrhsimopoiwntas to
                    'onoma tou pinaka 
                Else
                    fullNameOfField = checkedListBoxesVector(i).Name & "." & nameOfField
                End If




                'Prosthiki tou plhrous onomatos tou epilegmenou pediou sto CheckedListBox allSelectedFields ths Form3
                Form3.allSelectedFields.Items.Add(fullNameOfField)

                'Dhmiourgia tou Textbox sto opoio o xrhsths tha exei thn dynatothta na orisei kapoia timh gia to sygkekrimeno pedio
                Dim text As New TextBox
                text.Name = "ValueTextBox" & counter
                text.Size = New Size(180, 25)
                text.Location = New Point(180, 35 * counter)
                text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                AddHandler text.TextChanged, AddressOf Form3.text_TextChanged

                'Dhmiourgia tou pinaka myTable ths klashs Tables. Se ayton ton pinaka pername ta pente Checkboxes pou dhmiourgoume gia to antistoixo pedio, to antistoixo
                'Textbox , to Label me to onoma tou pediou kai to Label me ton typo tou pediou
                Dim myTable As New Tables

                'Perasma tou Textbox kai tou Label me to onoma tou pediou ston pinaka myTable
                myTable.setFields(text)
                myTable.setFname(lbl)


                'Dhmiourgia tou Checkbox gia dynatothta xrhshs tou telesth LIKE gia lexeis pou na ksekinane me tous xarakthres pou orizei o xrhsths
                'MONO gia typous Text, Memo kai HyperLink
                Dim beginChklbox As New CheckBox
                beginChklbox.Name = "BeginCheckboxL" & counter
                beginChklbox.Size = New Size(51, 17)
                beginChklbox.Location = New Point(687, 35 * counter)
                beginChklbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                beginChklbox.Enabled = True
                beginChklbox.Select()
                AddHandler beginChklbox.CheckStateChanged, AddressOf Form3.checkbox_CheckedChanged1

                'Dhmiourgia tou Checkbox gia dynatothta xrhshs tou telesth LIKE gia lexeis pou na periexoun endiamesa tous xarakthres pou orizei o xrhsths
                'MONO gia typous Text, Memo kai HyperLink
                Dim containsChklbox As New CheckBox
                containsChklbox.Name = "ContainsCheckboxL" & counter
                containsChklbox.Size = New Size(51, 17)
                containsChklbox.Location = New Point(787, 35 * counter)
                containsChklbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                containsChklbox.Enabled = True
                containsChklbox.Select()
                AddHandler containsChklbox.CheckStateChanged, AddressOf Form3.checkbox_CheckedChanged2

                'Dhmiourgia tou Checkbox gia dynatothta xrhshs tou telesth LIKE gia lexeis pou na teleiwnoun me tous xarakthres pou orizei o xrhsths
                'MONO gia typous Text, Memo kai HyperLink
                Dim endChklbox As New CheckBox
                endChklbox.Name = "BeginCheckboxL" & counter
                endChklbox.Size = New Size(51, 17)
                endChklbox.Location = New Point(887, 35 * counter)
                endChklbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                endChklbox.Enabled = True
                endChklbox.Select()
                AddHandler endChklbox.CheckStateChanged, AddressOf Form3.checkbox_CheckedChanged3

                'Dhmiourgia tou Checkbox gia dynatothta xrhshs tou telesth >. MONO gia typous Number kai Date
                Dim greaterCheckBox As New CheckBox
                greaterCheckBox.Name = "GreaterCheckBox" & counter
                greaterCheckBox.Size = New Size(51, 17)
                greaterCheckBox.Location = New Point(987, 35 * counter)
                greaterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                greaterCheckBox.Enabled = True
                greaterCheckBox.Select()
                AddHandler greaterCheckBox.CheckStateChanged, AddressOf Form3.checkbox_CheckedChanged4

                'Dhmiourgia tou Checkbox gia dynatothta xrhshs tou telesth <. MONO gia typous Number kai Date
                Dim lowerCheckBox As New CheckBox
                lowerCheckBox.Name = "LowerCheckBox" & counter
                lowerCheckBox.Size = New Size(51, 17)
                lowerCheckBox.Location = New Point(1087, 35 * counter)
                lowerCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lowerCheckBox.Enabled = True
                lowerCheckBox.Select()
                AddHandler lowerCheckBox.CheckStateChanged, AddressOf Form3.checkbox_CheckedChanged5


                Dim counterTypeLabelName As Integer = 1 'Metavliti pou xrhsimopoieitai  gia na orisoume dynamika thn idothta Name gia kathe Label gia typo pediou pou dhmiourgeitai sthn Form3


                'Prospelash tou pinaka fieldTypesVector
                For j = 0 To 399
                    'An to onoma tou epilegmenou pediou isoutai me thn timh tou onomatos sthn trexousa thseh tou pinaka tote
                    If fieldTypesVector(j, 0) = checkeditem Then

                        'Dhmiourgeitai ena Label pou exei ws Text to onoma tou typou tou antisoixou pediou
                        Dim typeLabel As New Label
                        typeLabel.Name = "FieldTypeLabel" & counterTypeLabelName
                        typeLabel.Size = New Size(240, 25)
                        typeLabel.Location = New Point(380, 35 * counter)
                        'Kaleitai h methodos showDataTypeAsString, gia thn metatroph tou kwdikou tou typou pediou sto antistoixo onoma tou typou,
                        'me parametro ton kwdiko typou pou antistoixei sto onoma tou sygkekrimenou pediou
                        showDataTypeAsString(fieldTypesVector(j, 1))
                        typeLabel.Text = "(" & fieldTypesVector(j, 1) & ")"
                        typeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                        'An o typos pediou einai Ole Object tote to antistoixo Textbox apenergopoieitai kai den mporei na to xrhsimopoihsei ws periorismo o xrhsths
                        If typeLabel.Text = "(OLE Object)" Then
                            text.Enabled = False
                        End If

                        'Perasma tou Label me to onoma tou typou tou pediou ston pinaka myTable kai sto FieldPanel ths Form3
                        myTable.setFtype(typeLabel)
                        Form3.FieldPanel.Controls.Add(typeLabel)


                        'An o typos pediou DEN einai Text, Memo h Hyperlink tote apenergopoiountai ta Checkboxes pou sxetizontai me ton telesth LIKE
                        If typeLabel.Text <> "(Text)" And typeLabel.Text <> "(Memo/Hyperlink)" Then
                            beginChklbox.Enabled = False
                            containsChklbox.Enabled = False
                            endChklbox.Enabled = False
                        End If



                        'An o typos pediou DEN einai Number h Date tote apenergopoountai ta Checkboxes pou sxetizontai me tous telestes > kai <
                        If typeLabel.Text <> "(Number:Byte)" And typeLabel.Text <> "(Number:Integer)" And typeLabel.Text <> "(Number:Long/Auto Number)" _
                            And typeLabel.Text <> "(Number:Single)" And typeLabel.Text <> "(Number:Double)" And typeLabel.Text <> "(Number:Replica)" _
                            And typeLabel.Text <> "(Number:Decimal)" And typeLabel.Text <> "(Date/Time)" Then
                            greaterCheckBox.Enabled = False
                            lowerCheckBox.Enabled = False
                        End If


                        'Perasma twn Checkboxes pou sxetizontia me ton telesth LIKE ston pinaka myTable
                        myTable.setBeginLCheckboxes(beginChklbox)
                        myTable.setContainsLCheckboxes(containsChklbox)
                        myTable.setEndLCheckboxes(endChklbox)
                        counterTypeLabelName += 1
                    End If
                Next







                'Perasma twn Checkboxes pou sxetizontai me tous telestes > kai  < ston pinaka myTable
                myTable.setGreaterThanCheckBoxes(greaterCheckBox)
                myTable.setLowerThanCheckBoxes(lowerCheckBox)

                'Perasma twn Checkboxes pou sxetizontai me tous telestes > kai  < sto FieldPanel ths Form3
                Form3.FieldPanel.Controls.Add(greaterCheckBox)
                Form3.FieldPanel.Controls.Add(lowerCheckBox)

                'Perasma toy Textbox, twn Checkboxes pou sxetizontai me ton telesth LIKE kai tou Label me to onoma tu pediou sto FieldPanel ths Form3 
                Form3.FieldPanel.Controls.Add(lbl)
                Form3.FieldPanel.Controls.Add(text)
                Form3.FieldPanel.Controls.Add(beginChklbox)
                Form3.FieldPanel.Controls.Add(containsChklbox)
                Form3.FieldPanel.Controls.Add(endChklbox)
                selectedPedia(counterPediaArray) = myTable
                counterPediaArray += 1
                counter += 1

            Next

            'An yparxei pinakas me keno sto onoma tou tote to onoma mpainei se agkyles kai seynnenwnetai me thn lexh AS kai thn metavlhth nameWithoutSpaces
            'wste na dhmiourghsoume enan allias gia ton pinaka ayto
            If flag = True Then
                checkedListBoxesVector(i).Name = "[" & checkedListBoxesVector(i).Name & "]" & " AS " & nameWithoutSpaces
                flag = False
            End If

        Next


        'An exei epilegei estw kai ena pedio apo ola ta CheckedListBoxes ths Form2 tote
        If checkedfieldscounter > 0 Then


            'Dhmiourgeitai ena Label pou ypodeiknyei oti ta Checkboxes pou vriskontai apo katw energopoioun ton telesth LIKE gia thn arxh ths lexhs
            Dim beginChecklabel As New Label
            beginChecklabel.Name = "BeginCheckBoxLabel"
            beginChecklabel.Text = "Begins with character(s)"
            beginChecklabel.Size = New Size(90, 48)
            beginChecklabel.Location = New Point(658, 21)
            beginChecklabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            'Dhmiourgeitai ena Label pou ypodeiknyei oti ta Checkboxes pou vriskontai apo katw energopoioun ton telesth LIKE gia xarakthres mesa sthn lexh 
            Dim containsChecklabel As New Label
            containsChecklabel.Name = "ContainsCheckBoxLabel"
            containsChecklabel.Text = "Contains character(s)"
            containsChecklabel.Size = New Size(90, 48)
            containsChecklabel.Location = New Point(758, 21)
            containsChecklabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            'Dhmiourgeitai ena Label pou ypodeiknyei oti ta Checkboxes pou vriskontai apo katw energopoioun ton telesth LIKE gia to telos ths lexhs
            Dim endChecklabel As New Label
            endChecklabel.Name = "EndCheckBoxLabel"
            endChecklabel.Text = "Ends with character(s)"
            endChecklabel.Size = New Size(90, 48)
            endChecklabel.Location = New Point(858, 21)
            endChecklabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            'Dhmiourgeitai ena Label pou ypodeiknyei oti ta Checkboxes pou vriskontai apo katw energopoioun ton telesth >
            Dim greaterThanCheckLabel As New Label
            greaterThanCheckLabel.Name = "GreaterThanCheckboxLabel"
            greaterThanCheckLabel.Text = "Greater than"
            greaterThanCheckLabel.Size = New Size(90, 48)
            greaterThanCheckLabel.Location = New Point(958, 21)
            greaterThanCheckLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            'Dhmiourgeitai ena Label pou ypodeiknyei oti ta Checkboxes pou vriskontai apo katw energopoioun ton telesth <
            Dim lowerThanCheckLabel As New Label
            lowerThanCheckLabel.Name = "LowerThanCheckboxLabel"
            lowerThanCheckLabel.Text = "Lower than"
            lowerThanCheckLabel.Size = New Size(90, 48)
            lowerThanCheckLabel.Location = New Point(1058, 21)
            lowerThanCheckLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))



            'Perasma twn Labels gia tous telestes LIKE, > kai < sto FieldPanel ths Form3
            Form3.FieldPanel.Controls.Add(greaterThanCheckLabel)
            Form3.FieldPanel.Controls.Add(lowerThanCheckLabel)
            Form3.FieldPanel.Controls.Add(endChecklabel)
            Form3.FieldPanel.Controls.Add(containsChecklabel)
            Form3.FieldPanel.Controls.Add(beginChecklabel)

        End If


        Dim selFieldsLength As Integer = 0

        For i = 0 To checkedListBoxesVector.Length - 1
            If (checkedListBoxesVector(i).CheckedItems.Count <> 0) Then       'Sto for elegxo apo poia checklistbox tou vector exei epileksei o xristis pedia
                selFieldsLength = selFieldsLength + 1
            End If
        Next

        selFields = New SelectedFields(selFieldsLength) {}                   'Dilono to megethos tou pinaka antikeimenon
        Dim sfcount As Integer = 0
        Dim dokimi As Integer = selFields.Length - 1

        For i = 0 To checkedListBoxesVector.Length - 1
            If (checkedListBoxesVector(i).CheckedItems.Count <> 0) Then

                Dim str(checkedListBoxesVector(i).CheckedItems.Count) As String
                Dim c1 As Integer = 0
                Dim strname As String = checkedListBoxesVector(i).Name

                For Each checkeditem In checkedListBoxesVector(i).CheckedItems
                    str(c1) = checkeditem
                    c1 += 1
                Next

                Dim slf As New SelectedFields
                slf.setTableName(strname)
                slf.setSelFields(str)
                selFields(sfcount) = slf
                sfcount += 1
            End If
        Next

        Me.Visible = False
    End Sub
    Private Sub Form2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Afou kleisei h Form2 emfanizetai h Form1 kai metaferoume tin timi tou filtercounter2 stin filtercounter1 tis form1
        Form1.Visible = True
        Form1.filtercounter1 = filtercounter2
    End Sub


    Private Sub ButtonSelectAllForm2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectAllForm2.Click
        'Sto pathma tou koumpiou DSelect All tsekarontai ola ta checkboxes se ola ta CheckedListBoxes ths Form2
        For i = 0 To checkedListBoxesVector.Length - 1
            For j = 0 To checkedListBoxesVector(i).Items.Count - 1
                checkedListBoxesVector(i).SetItemChecked(j, True)
            Next
        Next

    End Sub

    Private Sub ButtonDeselectAllForm2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeselectAllForm2.Click
        'Sto pathma tou koumpiou Deselect All ths Form2 ksetsekarontai ola ta checkboxes apo ola ta CheckedListBoxes ths Form2
        For i = 0 To checkedListBoxesVector.Length - 1
            For j = 0 To checkedListBoxesVector(i).Items.Count - 1
                checkedListBoxesVector(i).SetItemChecked(j, False)

            Next
        Next

    End Sub
End Class