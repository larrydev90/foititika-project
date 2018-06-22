Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Text.RegularExpressions
Public Class Form3
    'Metavliti gia na kratame se oli tin efarmogi pio filter einai otan kanoume save to filter
    Public filtercounter3 As Integer = 1
    Dim flagn() As Integer
    Dim flagt() As Integer
    Dim flagd() As Integer
    Dim flagy() As Integer
    Dim flagc() As Integer
    Dim flagm() As Integer
    Dim strSQL As String

    Public Function getsqlstring() As String
        'Methodos gia na boroume na pairnoume to sql string stin form4
        getsqlstring = strSQL
    End Function
    Private Sub ButtonBackForm2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackForm2.Click
        'Sto pathma tou koumpiou Back ths Form3 emfanizetai h Form2 kai kleinei h trexousa forma (Form3)
        'kai metaferoume tin timi tou filtercounter3 stin filtercounter2 tis form2
        Form2.Visible = True
        Me.Close()
        Form2.filtercounter2 = filtercounter3
    End Sub

    Private Sub Form3_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Afou kleisei h Form3 emfanizetai h Form2 kai metaferoume tin timi tou filtercounter3 stin filtercounter2 tis form2
        Form2.Visible = True
        Form2.filtercounter2 = filtercounter3
    End Sub


    Private Sub ButtonResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResults.Click
        'Sto pathma tou koumpiou Show Results emfanizetai h Form 4 kai exafanizetai h trexousa forma (Form3).Xtizetai dynamika vhma pros vhma to query me 
        'vash tis epiloges tou xrhsth apo ta controls twn prohgoumenwn formwn kai to apotelesma tou query emfanizetai sto DataGridView ths Form4

        Form4.Show()
        Me.Visible = False
        Form4.filtercounter = filtercounter3

        'Orismos twn string tables, selectedfields kai wherefields pou tha xrhsimopoiithoun gia na apothikeysoume to FROM clause tou query, to SELECT clause tou
        'query kai to WHERE clause tou query antistoixa
        Dim tables As String
        Dim selectedfields As String
        Dim whereFields As String



        'Loop gia thn prospelash tou dynamikou pinaka pou periexei ta CheckedListBoxes (antistoixoun se pinakes) ths Form2
        For i = 0 To Form2.checkedListBoxesVector.Length - 1
            'An to i isoutai me thn thesi tou teleytaiou stoixeiou tou pinaka tote
            If i = Form2.checkedListBoxesVector.Length - 1 Then
                'sto string tables synnenwnetai to onoma tou pinaka pou periexetai sthn idiothta Name tou antistoixou CheckedListBox gia to sygkekrimeno i
                tables = tables & Form2.checkedListBoxesVector(i).Name
                'alliws sto string tables synnenwnetai to onoma tou pinaka pou periexetai sthn idiothta Name tou antistoixou CheckedListBox akolouthoumeno 
                'apo ena komma gia na to diaxwrisei apo to onoma tou epomenou pianka
            Else
                tables = tables & Form2.checkedListBoxesVector(i).Name & ", "
            End If

        Next


        'Metavliti pou apothikeyei to plithos twn tsekarismenwn checkboxes apo to CheckedListBox allSelectedFields. To sygkekrimeno CheckedListBox xrhsimopoieitai
        'gia na dialexei o xrhsths poia pedia apo olous tous pinakes thelei na emfanisei
        Dim selectedfieldscount As Integer = allSelectedFields.CheckedItems.Count

        'Metriths xrhsimopoieitai gia na elegxoume an exetazoume to teleytaio epilegmeno stoixeio apo to allSelectedFields.Ayxanetai kata ena gia kathe diaforetiko
        'epilegmeno stoixeio pou exetazoume
        Dim j As Integer = 1


        'Loop gia thn prospelash twn epilegmenwn Checkboxes (pediwn) apo to allSelectedFields
        For Each checked In allSelectedFields.CheckedItems
            'An o metritis j einai isos me to plithos twn CheckedItems, ara antistoixei sto teleytaio epilegmeno stoixeio tote
            If j = selectedfieldscount Then
                'sto string selectedfields synnenwnetai to plhres onoma tou antistoixou epilegmenou pediou (me thn morfh onomaPinaka.onomaPediou)
                selectedfields = selectedfields & checked
                'alliws sto string selectedfields synnenwnetai to plhres onoma tou antistoixou epilegmenou pediou akolouthoumeno 
                'apo ena komma gia na to diaxwrisei apo to onoma tou epomenou pediou
            Else
                selectedfields = selectedfields & checked & ", "
            End If

            j += 1
        Next

        'Dhmiourgia tou pinaka table1 me ta antikeimena myTable apo ton pinaka SelectedPedia ths Form2
        Dim table1() As Tables = Form2.getselectedPedia

        'Metritis pou xrhsimopoieitai gia thn apothikeysh tou plithous twn pediwn pou tha mpoun sto WHERE clause, dhladh aytwn pou exoun kapoia timh (periorismo)
        'sto antistoixo Textbox
        Dim metritis As Integer = 0


        For i = 1 To table1.Length - 1
            'An h trexousa thesi tou pinaka table1 einai kenh tote vgainoume apo thn domh epanalhpshs
            If table1(i) Is Nothing Then
                Exit For
            End If
            'An to Textbox tou pediou pou antisoixei se ayth thn thesi tou pinaka DEN einai keno tote ayksanetai o metritis kata 1
            If table1(i).getFields.Text <> String.Empty Then
                metritis += 1
            End If
        Next



        'Xrhgsimopoieitai gia na na apothikeysoume thn hmeromhnia afou thn spasoume se mera, mhna , xrono
        Dim splitdate() As String
        'String pou perilamvanei thn hmeromhnia pou egrapse o xrhsths sto Textbox afou exei metatrapei to substring pou deixnei to mhna to substring pou deixnei thn mera
        Dim firstchange As String
        'String pou perilamvanei thn hmeromhnia pou egrapse o xrhsths sto Textbox afou exei ginei enallagh ths meras me ton mhna
        Dim result As String
        'Flag pou ypodhlwnei an exei alaxtei h hmeromhnia pou egrapse o xrhsths sto Textbox
        Dim dateFlag As Boolean = False


        'Metraei ta stoixeia pou mpainoun sto WHERE clause tou query.Ayxanetai kata ena otan prostithetai ena pedio sto string wherefields
        Dim var As Integer = 1

        'Xrhsimopoieitai gia na apothikeysoume thn timh pou egrapse o xrhsths sto Textbox gia to kathe pedio
        Dim textvalue As String

        'Diatrexoume olon ton pinaka table1.An h trexousa thesi einai kenh vgainoume apo thn domh epanalhpshs.
        For i = 1 To table1.Length - 1
            If table1(i) Is Nothing Then
                Exit For
            End If

            'An gia to sygkekrimneo pedio to Textbox einai keno den mpainoume sto if kai pame sthn epomenh epanalhpsh
            If table1(i).getFields.Text <> String.Empty Then

                'alliws elegxoume an to sygkekrimeno pedio einai to teleytaio pou exei periorismo
                If var = metritis Then

                    'kai meta elegxoume ton typo tou pediou. An einai Text, Yes/No h Memo/HyperLink tote elegxoume an exei epilexthei kapoio apo ta Checkboxes
                    'pou antistoixoun ston telesth LIKE
                    If table1(i).getFtype.Text = "(Text)" Or table1(i).getFtype.Text = "(Memo/Hyperlink)" Or table1(i).getFtype.Text = "(Yes/No)" Then

                        'An exei tsekaristei to Checkbox Like gia thn arxh ths lexhs tote sto wherefields synnenwnwtai to onomma tou pediou kai h syntaxh LIKE me to antistoixo
                        'format gia thn arxh ths lexhs
                        If table1(i).getBeginLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '" & textvalue & "%'"
                            var += 1

                            'An exei tsekaristei to Checkbox Like gia enidamesous xarakthres ths lexhs tote sto wherefields synnenwnwtai to onomma tou pediou kai h syntaxh LIKE me to antistoixo
                            'format 
                        ElseIf table1(i).getContainsLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '%" & textvalue & "%'"
                            var += 1

                            'An exei tsekaristei to Checkbox Like gia to telos ths lexhs tote sto wherefields synnenwnwtai to onomma tou pediou kai h syntaxh LIKE me to antistoixo
                            'format
                        ElseIf table1(i).getEndLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '%" & textvalue & "'"
                            var += 1


                            'alliws sto wherefields synnenwnetai to onoma tou pediou kai to symvolo = akolouthoumeno apo thn timh (h timh vrisketai mesa se ')
                        Else
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "= '" & textvalue & "'"
                            var += 1
                        End If


                        'An to pedio einai typou Number tote elegxoume an exei epilexei o xrhsths kapoio apo ta Checkboxes pou antistoixoun stous telestes > h <
                    ElseIf table1(i).getFtype.Text.Contains("Number") Then

                        'An exei tsekaristei o telseths > tote sto wherefields synnenwnetai to onoma tou pediou kai meta o telesths > akolouthoumenos apo thn timh
                        If table1(i).getGreaterThanCheckBoxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "> " & textvalue
                            var += 1

                            'an exei tsekaristei o telesths < tote sto wherefields synnenwnetai to onoma tou pediou kai meta o telesths < akolouthoumenos apo thn timh
                        ElseIf table1(i).getLowerThanCheckBoxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "< " & textvalue
                            var += 1

                            'alliws sto wherefields synnenwnetai to onoma tou pediou kai to symvolo = akolouthoumeno apo thn timh
                        Else
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "= " & textvalue
                            var += 1
                        End If


                        'An to pedio einai typou Date/Time
                    ElseIf table1(i).getFtype.Text = "(Date/Time)" Then

                        'Elegxoume an sto Textbox h hmeromhnia pou exei orisei o xrhsths exei monopsifio arithmo gia thn hmera kai tote
                        If Regex.IsMatch(table1(i).getFields.Text, "^[0-9]{1}/[0-9]{1,2}/[0-9]{1,4}") Then

                            Dim textboxvalue As String = table1(i).getFields.Text
                            'Xwrizoume to string ths hmeromhnias me diaxwristh to /
                            splitdate = textboxvalue.Split("/")
                            'kai allazoume to substring pou deixnei thn mera me to substring pou deixnei to mhna.To apotelesma apothikeyetai sthn metavliti
                            'result kai ginetai True h metavliti dateFlag
                            firstchange = Regex.Replace(textboxvalue, splitdate(1), splitdate(0))
                            result = Regex.Replace(firstchange, "^[0-9]", splitdate(1))
                            dateFlag = True

                        End If



                        'An exei tsekaristei o telseths > tote 
                        If table1(i).getGreaterThanCheckBoxes.Checked Then

                            'An to dateFlag einai True dinoume thn timh tou result sto textvalue alliws exei thn arxikh tou timh
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If
                            'kai sto wherefields synnenwnetai to onoma tou pediou kai meta o telesths > akolouthoumenos apo thn timh pou perikleietai stous 
                            'xarakthres #. Oi xarakthres aytoi einai gia na dhlwwsoume oti to pedio einai hmeromhnia
                            whereFields = whereFields & table1(i).getFname.Text & "> #" & textvalue & "#"
                            var += 1


                            'An exei tsekaristei o telseths < tote 
                        ElseIf table1(i).getLowerThanCheckBoxes.Checked Then

                            'An to dateFlag einai True dinoume thn timh tou result sto textvalue alliws exei thn arxikh tou timh
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If

                            'kai sto wherefields synnenwnetai to onoma tou pediou kai meta o telesths < akolouthoumenos apo thn timh pou perikleietai stous 
                            'xarakthres #. Oi xarakthres aytoi einai gia na dhlwwsoume oti to pedio einai hmeromhnia
                            whereFields = whereFields & table1(i).getFname.Text & "< #" & textvalue & "#"
                            var += 1


                            'alliws
                        Else

                            'An to dateFlag einai True dinoume thn timh tou result sto textvalue alliws exei thn arxikh tou timh
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If

                            'kai sto wherefields synnenwnetai to onoma tou pediou kai meta o telesths = akolouthoumenos apo thn timh pou perikleietai stous 
                            'xarakthres #. Oi xarakthres aytoi einai gia na dhlwwsoume oti to pedio einai hmeromhnia
                            whereFields = whereFields & table1(i).getFname.Text & "= #" & textvalue & "#"
                            var += 1



                        End If

                    End If

                    'alliws an to pedio den eini to teleytaio pou tha mpei sto where h leitourgia einai akrivws h idia me thn prohgoumenh periptwsh me thn fdiafora 
                    'oti sto wherefields synnenonetai h leksh and sto telos
                Else
                    If table1(i).getFtype.Text = "(Text)" Or table1(i).getFtype.Text = "(Memo/Hyperlink)" Or table1(i).getFtype.Text = "(Yes/No)" Then
                        If table1(i).getBeginLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '" & textvalue & "%'" & " and "
                            var += 1

                        ElseIf table1(i).getContainsLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '%" & textvalue & "%'" & " and "
                            var += 1

                        ElseIf table1(i).getEndLCheckboxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & " LIKE '%" & textvalue & "'" & " and "
                            var += 1

                        Else
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "= '" & textvalue & "'" & " and "
                            var += 1
                        End If


                    ElseIf table1(i).getFtype.Text.Contains("Number") Then


                        If table1(i).getGreaterThanCheckBoxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "> " & textvalue & " and "
                            var += 1


                        ElseIf table1(i).getLowerThanCheckBoxes.Checked Then
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "< " & textvalue & " and "
                            var += 1


                        Else
                            textvalue = table1(i).getFields.Text
                            whereFields = whereFields & table1(i).getFname.Text & "= " & textvalue & " and "
                            var += 1
                        End If

                    ElseIf table1(i).getFtype.Text = "(Date/Time)" Then


                        If Regex.IsMatch(table1(i).getFields.Text, "^[0-9]{1}/[0-9]{1,2}/[0-9]{1,4}") Then

                            Dim textboxvalue As String = table1(i).getFields.Text
                            splitdate = textboxvalue.Split("/")

                            firstchange = Regex.Replace(textboxvalue, splitdate(1), splitdate(0))
                            result = Regex.Replace(firstchange, "^[0-9]", splitdate(1))
                            dateFlag = True

                        End If




                        If table1(i).getGreaterThanCheckBoxes.Checked Then
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If
                            whereFields = whereFields & table1(i).getFname.Text & "> #" & textvalue & "# and "
                            var += 1


                        ElseIf table1(i).getLowerThanCheckBoxes.Checked Then
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If
                            whereFields = whereFields & table1(i).getFname.Text & "< #" & textvalue & "# and "
                            var += 1


                        Else
                            If dateFlag = True Then
                                textvalue = result
                                dateFlag = False
                            Else
                                textvalue = table1(i).getFields.Text
                            End If
                            whereFields = whereFields & table1(i).getFname.Text & "= #" & textvalue & "# and "
                            var += 1


                        End If


                    End If




                End If
            End If

        Next


        'O pinakas xrhsimopoieitai gia na spasoume to plhres onoma tou pediou sto onoma tou pinaka kai sto onoma tou pediou  kai na ta apothiksyoume  se ayton
        Dim onlyFieldName() As String
        Dim k As Integer

        'Flag pou xrhsimopoieitai gia na orisoume an to query tha exei thn desmeymenh leksh DISTINCT
        Dim distinctFlag As Boolean = False

        'Spame to plhres onoma tou pediou sto onoma tou pinaka kai sto onoma tou pediou.Katopinn sygkrinoume to onoma tou pediou me ta text apo ta Labels ston 
        'pinaka selectedpedia kai an einai idia vriskoume ton typo tou pediou apo to text tou Label pou deixnei ton typo sthn idia grammh tou pinaka selectedPedia.
        'An o typos einai OLE Object h Memo/HyperLink tote dinetai h timh True sto distinctFlag
        For Each checked In allSelectedFields.CheckedItems
            For k = 1 To Form2.selectedPedia.Length - 1
                onlyFieldName = checked.ToString().Split(".")
                If onlyFieldName(1) = Form2.selectedPedia(k).getFname.Text And (Form2.selectedPedia(k).getFtype.Text = "(OLE Object)" Or Form2.selectedPedia(k).getFtype.Text = "(Memo/Hyperlink)") Then
                    distinctFlag = True
                End If
            Next
        Next



        'Xtizetai to query me vash ta strings selectedfields, tables kai wherfields.To wherefields xrhsimopoieitai mono an yparxoun periorismoi. An to distinctFlag einai 
        'True tote den xrhsimopoieitai h desmeymenh lskdh DISTINCT giati den mporei na xrhsimopoihthei se pedia typou Ole Object kai Memo/HyperLink
        Try
            If distinctFlag = True And whereFields <> "" Then
                strSQL = "SELECT " & selectedfields & " FROM " & tables & " WHERE " & whereFields
            ElseIf distinctFlag = True And whereFields = "" Then
                strSQL = "SELECT " & selectedfields & " FROM " & tables
            ElseIf distinctFlag = False And whereFields <> "" Then
                strSQL = "SELECT DISTINCT " & selectedfields & " FROM " & tables & " WHERE " & whereFields
            Else

                strSQL = "SELECT DISTINCT " & selectedfields & " FROM " & tables
            End If

            Dim myconn As OleDbConnection
            Dim ConnectionString As String
            ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Form1.TextPath.Text
            myconn = New OleDb.OleDbConnection(ConnectionString)


            Using adapter As New OleDbDataAdapter(strSQL, myconn)

                Dim ds As New DataSet
                adapter.Fill(ds, tables)
                Form4.DataGridView1.DataSource = ds.Tables(tables)
                Form4.BindingSource1.Position += 1 'ayxanoume to position tis trexousas grammis kata 1
                Form4.BindingSource1.DataSource = ds.Tables(tables)
                myconn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("The field you have selected is very big to display or you have selected too many fields")
        End Try
    End Sub

    Private Sub ButtonCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCheck.Click
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        Dim flagsLength As Integer = 0
        'Pairnoume to megethos gia tous pinakes ton flags
        For i = 1 To selectedPedia.Length - 1
            flagsLength += 1
        Next
        'Orizoume ena pinaka flag gia kathe textbox
        flagn = New Integer(flagsLength) {}
        flagt = New Integer(flagsLength) {}
        flagd = New Integer(flagsLength) {}
        flagy = New Integer(flagsLength) {}
        flagc = New Integer(flagsLength) {}
        flagm = New Integer(flagsLength) {}
        'Gemizoume tous pinakes flags me midenika
        For i = 1 To flagsLength - 1
            flagn(i) = 0
            flagt(i) = 0
            flagd(i) = 0
            flagy(i) = 0
            flagc(i) = 0
            flagm(i) = 0
        Next
        'Orizoume ena geniko flag gia kathe textbox
        Dim flagn2 As Integer = 0
        Dim flagt2 As Integer = 0
        Dim flagd2 As Integer = 0
        Dim flagy2 As Integer = 0
        Dim flagc2 As Integer = 0
        Dim flagm2 As Integer = 0
        'Orizoume ena flag gia to checklistbox allSelectedFields
        Dim flagcheckl As Integer = 0

        Try
            For i = 1 To selectedPedia.Length - 1
                'Elegxoume ti exei mesa to textbox kai ama einai number h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Number") Then
                    If IsNumeric(selectedPedia(i).getFields.Text) Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagn(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        flagn(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put Integer at " + selectedPedia(i).getFname.Text)
                    End If
                End If
                'Elegxoume ti exei mesa to textbox kai ama einai text h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Text") Then
                    If IsNumeric(selectedPedia(i).getFields.Text) Then
                        flagt(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put String at " + selectedPedia(i).getFname.Text)
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagt(i) = 0
                    End If
                End If
                'Elegxoume ti exei mesa to textbox kai ama einai date h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Date") Then
                    If IsDate(selectedPedia(i).getFields.Text) Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagd(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        flagd(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put Date at " + selectedPedia(i).getFname.Text)
                    End If

                End If
                'Elegxoume ti exei mesa to textbox kai ama einai (yes or no) h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Yes") Then
                    If IsNumeric(selectedPedia(i).getFields.Text) Then
                        flagy(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put Yes or No at " + selectedPedia(i).getFname.Text)
                    ElseIf selectedPedia(i).getFields.Text = "Yes" Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagy(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "yes" Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagy(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "No" Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagy(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "no" Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagy(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        selectedPedia(i).getFields.BackColor = Color.Red
                        flagy(i) = 1
                        MessageBox.Show("You must put Yes or No at " + selectedPedia(i).getFname.Text)
                    End If
                End If
                'Elegxoume ti exei mesa to textbox kai ama einai currency h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Currency") Then
                    If IsNumeric(selectedPedia(i).getFields.Text) Then
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagc(i) = 0
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        flagc(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put Currency at " + selectedPedia(i).getFname.Text)
                    End If
                End If
                'Elegxoume ti exei mesa to textbox kai ama einai memo h oxi alazoume mia timi ston pinaka me to antistoixo flag
                'kai emfanizoume katalilo messagebox
                If selectedPedia(i).getFtype.Text.Contains("Memo") Then
                    If IsNumeric(selectedPedia(i).getFields.Text) Then
                        flagm(i) = 1
                        selectedPedia(i).getFields.BackColor = Color.Red
                        MessageBox.Show("You must put String at " + selectedPedia(i).getFname.Text)
                    ElseIf selectedPedia(i).getFields.Text = "" Then
                        selectedPedia(i).getFields.BackColor = Color.Yellow
                    Else
                        selectedPedia(i).getFields.BackColor = Color.White
                        flagm(i) = 0
                    End If
                End If
                'Apenergopoioume to textbox tipou ole object
                If selectedPedia(i).getFtype.Text.Contains("OLE Object") Then
                    selectedPedia(i).getFields.Enabled = False
                End If
            Next
        Catch ex As Exception
        End Try

        If allSelectedFields.CheckedItems.Count = 0 Then
            'Elegxoume ama den iparxei toulaxiston 1 epilegmeno checkbox sto checklistbox, an ontos den iparxei tote
            'to koubi show results den energopoieitai kai emfanizoume katalilo messagebox
            flagcheckl = 1
            MessageBox.Show("You must select at least one field for display ")
        End If

        For i = 1 To flagsLength
            'Elegxoume olous tous pinakes flags, opoios pinakas exei mesa toulaxiston ena 1 tote kanoume to antistoixo geniko flag apo 0 se 1
            If flagn(i) = 0 Then
                flagn2 = 0
            Else
                flagn2 = 1
                Exit For
            End If
            If flagt(i) = 0 Then
                flagt2 = 0
            Else
                flagt2 = 1
                Exit For
            End If
            If flagd(i) = 0 Then
                flagd2 = 0
            Else
                flagd2 = 1
                Exit For
            End If
            If flagy(i) = 0 Then
                flagy2 = 0
            Else
                flagy2 = 1
                Exit For
            End If
            If flagc(i) = 0 Then
                flagc2 = 0
            Else
                flagc2 = 1
                Exit For
            End If
            If flagm(i) = 0 Then
                flagm2 = 0
            Else
                flagm2 = 1
                Exit For
            End If
        Next

        If flagn2 = 0 And flagt2 = 0 And flagd2 = 0 And flagy2 = 0 And flagc2 = 0 And flagm2 = 0 And flagcheckl = 0 Then
            'Elegxoume ola ta genika flags ama ola einai 0 tote energopoieitai to koubi show results
            ButtonResults.Enabled = True
        Else
            ButtonResults.Enabled = False
        End If

    End Sub


    Private Sub ButtonSelectAllForm3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectAllForm3.Click
        For i = 0 To allSelectedFields.Items.Count - 1
            'Epilegoume ola ta checkboxes apo to checklistbox allSelectedFields
            allSelectedFields.SetItemChecked(i, True)
        Next

    End Sub

    Public Sub text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Otan alajei to text mesa se ena textbox apenergopoioume to koubi show results
        ButtonResults.Enabled = False
    End Sub
    Public Sub checkbox_CheckedChanged1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Elegxoume an ginetai check ena BeginLCheckbox, an nai tote apenergopoioume ta ContainsLCheckbox kai EndLCheckbox
        'kai otan ginetai uncheck to BeginLCheckbox tote energopoiounte ta ContainsLCheckbox kai EndLCheckbox
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        For i = 1 To selectedPedia.Length - 1
            If sender.CheckState = CheckState.Checked Then
                If sender.name = selectedPedia(i).getBeginLCheckboxes.Name Then
                    selectedPedia(i).getContainsLCheckboxes.Enabled = False
                    selectedPedia(i).getEndLCheckboxes.Enabled = False
                End If
            Else
                If sender.name = selectedPedia(i).getBeginLCheckboxes.Name Then
                    selectedPedia(i).getContainsLCheckboxes.Enabled = True
                    selectedPedia(i).getEndLCheckboxes.Enabled = True
                End If
            End If
        Next
    End Sub
    Public Sub checkbox_CheckedChanged2(ByVal sender As Object, ByVal e As System.EventArgs)
        'Elegxoume an ginetai check ena ContainsLCheckbox, an nai tote apenergopoioume ta BeginLCheckbox kai EndLCheckbox
        'kai otan ginetai uncheck to ContainsLCheckbox tote energopoiounte ta BeginLCheckbox kai EndLCheckbox
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        For i = 1 To selectedPedia.Length - 1
            If sender.CheckState = CheckState.Checked Then
                If sender.name = selectedPedia(i).getContainsLCheckboxes.Name Then
                    selectedPedia(i).getBeginLCheckboxes.Enabled = False
                    selectedPedia(i).getEndLCheckboxes.Enabled = False
                End If
            Else
                If sender.name = selectedPedia(i).getContainsLCheckboxes.Name Then
                    selectedPedia(i).getBeginLCheckboxes.Enabled = True
                    selectedPedia(i).getEndLCheckboxes.Enabled = True
                End If
            End If
        Next
    End Sub
    Public Sub checkbox_CheckedChanged3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Elegxoume an ginetai check ena EndLCheckbox, an nai tote apenergopoioume ta BeginLCheckbox kai ContainsLCheckbox
        'kai otan ginetai uncheck to EndLCheckbox tote energopoiounte ta BeginLCheckbox kai ContainsLCheckbox
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        For i = 1 To selectedPedia.Length - 1
            If sender.CheckState = CheckState.Checked Then
                If sender.name = selectedPedia(i).getEndLCheckboxes.Name Then
                    selectedPedia(i).getBeginLCheckboxes.Enabled = False
                    selectedPedia(i).getContainsLCheckboxes.Enabled = False
                End If
            Else
                If sender.name = selectedPedia(i).getEndLCheckboxes.Name Then
                    selectedPedia(i).getBeginLCheckboxes.Enabled = True
                    selectedPedia(i).getContainsLCheckboxes.Enabled = True
                End If
            End If
        Next
    End Sub
    Public Sub checkbox_CheckedChanged4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Elegxoume an ginetai check to GreaterThanCheckBox, an nai tote apenergopoioume to LowerThanCheckBox
        'kai otan ginetai uncheck to GreaterThanCheckBox tote energopoiounte ta LowerThanCheckBox
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        For i = 1 To selectedPedia.Length - 1
            If sender.CheckState = CheckState.Checked Then
                If sender.name = selectedPedia(i).getGreaterThanCheckBoxes.Name Then
                    selectedPedia(i).getLowerThanCheckBoxes.Enabled = False
                End If
            Else
                If sender.name = selectedPedia(i).getGreaterThanCheckBoxes.Name Then
                    selectedPedia(i).getLowerThanCheckBoxes.Enabled = True
                End If
            End If
        Next
    End Sub
    Public Sub checkbox_CheckedChanged5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Elegxoume an ginetai check to LowerThanCheckBox, an nai tote apenergopoioume to GreaterThanCheckBox
        'kai otan ginetai uncheck to LowerThanCheckBox tote energopoiounte ta GreaterThanCheckBox
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        For i = 1 To selectedPedia.Length - 1
            If sender.CheckState = CheckState.Checked Then
                If sender.name = selectedPedia(i).getLowerThanCheckBoxes.Name Then
                    selectedPedia(i).getGreaterThanCheckBoxes.Enabled = False
                End If
            Else
                If sender.name = selectedPedia(i).getLowerThanCheckBoxes.Name Then
                    selectedPedia(i).getGreaterThanCheckBoxes.Enabled = True
                End If
            End If
        Next
    End Sub

    Private Sub allSelectedFields_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allSelectedFields.SelectedValueChanged
        ' Otan to plithos twn epilegmenwn checkboxes tou allSelectedFields einai 0 tote to koumpi Show Results apenergopoieitai
        If allSelectedFields.CheckedItems.Count = 0 Then
            ButtonResults.Enabled = False
        End If
    End Sub
End Class