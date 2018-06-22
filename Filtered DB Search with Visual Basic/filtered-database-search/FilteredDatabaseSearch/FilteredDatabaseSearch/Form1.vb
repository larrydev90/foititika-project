Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common
Public Class Form1
    'Metavliti gia na kratame se oli tin efarmogi pio filter einai otan kanoume save to filter
    Public filtercounter1 As Integer = 1
    Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
        'Sto pathma tou koumpiou Next ths Form1 emfanizetai h Form2 kai exafanizetai h trexousa forma (Form1)
        'kai metaferoume tin timi tou filtercounter1 stin filtercounter2 tis form2
        Form2.Show()
        Me.Visible = False
        Form2.filtercounter2 = filtercounter1
    End Sub

    Private Sub CheckedListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedValueChanged
        'Otan epilegetai h apoepilegetai ena checkbox apo to CheckedListBox1 sthn Form1, an to plithos twn epilegmenwn checkboxes einai megalytero
        'tou 0 tote energopoieitai to koumpi Next, alliws apenergopoieitai
        If CheckedListBox1.CheckedItems.Count > 0 Then
            ButtonNext.Enabled = True
        ElseIf CheckedListBox1.CheckedItems.Count = 0 Then
            ButtonNext.Enabled = False
        End If

    End Sub

    Private Sub ButtonBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBrowse.Click
        'Sto pathma tou koumpiou Browse ths Form1 kaleite i methodos OpenFile() oste na epileksei o xristis ti vasi pou theli. H methodos epistrefei to path
        'tou arxeiou ths vashs ston disko kai to topothetoume sto TextPath
        Dim path As String = OpenFile()
        TextPath.Text = path

    End Sub

    'edo arxizei i methodos pou tha epileksei o xristis apo ton ypologisti tou ti vasi pou thelei aytos
    Public Function OpenFile() As String
        Dim strFileName = ""

        'dimiourgoume ena neo antikeimeno OpenFileDialog oste na anoiksei to parathyro gia na epileksei o xristis ti vasi pou thelei
        Dim fileDialogBox As New OpenFileDialog()

        'prosthetoume filtra sto parathyro open file, diladi ola ta arxeia * kai arxeia pou exoun tin kataliksi .mdb
        fileDialogBox.Filter = "Microsoft Access Databases (*.mdb)|*.mdb|" _
            & "All Files(*.*)|"

        'i grammi ayti orizei to default filtro pou dimiourgisame parapano, an den orisoume ena  
        'FilterIndex tote aytomata tha oristei se 1
        fileDialogBox.FilterIndex = 3

        'ayti i grammi orizei poios fakelos tha emfanizetai otan patisoume to koubi browse
        'emeis epileksame ton fakelo "ta eggrafa mou"
        fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)

        'ginete elegxos gia to an o xristis patise to koubi open
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then              'an exei patisei to open
            strFileName = fileDialogBox.FileName                          'tote vazoume sto strFileName to path tou arxeiou pou epelekse o xristis
        Else
            MsgBox("You did not select a file!")              'an den exei patisei to open o xristis tote emfanizoume ena message box
        End If

        Return strFileName      'epistrefoume to path tou epilegmenou arxeiou
    End Function


    Private Sub ButtonConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConnect.Click
        'Sto pathma tou koumpiou Connect energopoieitai h syndesh sthn vash kai emfanizoume ta onomata twn pinakwn ths vashs sto CheckedListBox1

        'Ginetai elegxos wste an to TextPath einai keno na emfanizetai ena mhnyma protrophs ston xrhsth gia na epilexei vash
        If TextPath.Text = vbNullString Then
            MsgBox("Select a database first", MessageBoxIcon.Information)

        Else
            Dim myconn As OleDbConnection
            Dim ConnectionString As String

            'Dinetai timh sto ConnectionStrnig.Synnenwnetai to string pou deixnei ton paroxo me to text apo to TextPath.
            'Me ayto ton tropo mporoume na xrhsimopoihsoume opoiadhpote vash gia na syndethoume arkei na antistoixei ston sygkekrimeno paroxo.
            'Dhmiourgoume thn sydesh me vash to ConnectionString
            ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & TextPath.Text
            myconn = New OleDb.OleDbConnection(ConnectionString)



            'Energopoihsh ths syndeshs sthn vash.Xrhsimopoihsh Try-Catch wste an to path den antistoixei se arxeio vashs na emfanistei antistoixo mhnyma
            Try
                myconn.Open()
            Catch ex As Exception
                MsgBox("The file doesn't match to a database file", MessageBoxIcon.Warning)
            End Try

            'O pinakas condition dhlwnei tous periorismous pou xrhsimopoiountai gia na perioristei to megethos ths plitroforias pou epistrefetai apo to schema.
            'Emeis theloume na epistrafoun oi pinakes gia ayto orizoume sto 4o keli to "TABLE" (to 4o keli antisoixei sto TABLE_TYPE).
            Dim condition As String() = New String() {Nothing, Nothing, Nothing, "TABLE"}
            Dim DataTable1 As DataTable
            Try

                'Gemizoume to Datatable1 me ta dedomena pou epoistrefontai apo to schema Tables me vash tous periorismous pou orisame sto condition, kleinoume
                'thn syndesh sthn vash kai adeiazoume ta periexomena tou CheckedListBox1

                DataTable1 = myconn.GetSchema("Tables", condition)
                myconn.Close()
                CheckedListBox1.Items.Clear()


                'Prospelazoume oles tis grammes tou DataTable1.Apo kathe grammh tou Datatable1 pairnoume
                'to onoma tou pinaka kai to prosthetoume sto CheckedListBox1
                For Each r As DataRow In DataTable1.Rows
                    CheckedListBox1.Items.Add(r("Table_Name"))
                Next


            Catch ex As Exception
            End Try



        End If
    End Sub

    Private Sub ButoonClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButoonClearAll.Click
        'Sto pathma tou koumpiou Clear All svhnetai oti periexei to TextPath kai to CheckedListBox1 ths Form1 kai apenergopoieitai to koumpi Next
        TextPath.Text = vbNullString
        CheckedListBox1.Items.Clear()
        ButtonNext.Enabled = False

    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        'Sto pathma tou koumpiou Clear svhnetai oti yparxei sto TextPath
        TextPath.Text = vbNullString
    End Sub

    Private Sub ButtonSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelectAll.Click
        'Sto pathma tou koumpiou Select All, an yparxei estw kai ena stoixeio sto CheckedListBox1 energopoieitai to koumpi Next kai tsekarontai 
        'ola ta checkboxes poy yparxoun sto CheckedListBox1
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, True)
        Next
        If CheckedListBox1.Items.Count > 0 Then
            ButtonNext.Enabled = True
        End If

    End Sub

    Private Sub ButtonDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeselectAll.Click
        'Sto pathma tou koumpiou Deselect All ksetsekarontai ola ta checkboxes tou CheckedListBox1 kai to koumpi Next apenergopoieitai
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
        ButtonNext.Enabled = False
    End Sub

    'i methodos ayti ekteleite otan paei o xristis na kleisei tin efarmogi
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        'vazoume se mia metavliti to minima pou theloume na emfanisoume otan o xristis paei na termatisei tin efarmogi
        Dim message As String = _
                "Are you sure that you would like to close the Application?"

        'sto caption vazoume ayto pou theloume na emfanizete sto MessageBox
        Dim caption As String = "Application Closing"

        'sto result apothikeyoume tin energeia tou xristi diladi an patise to "yes" i to "no" sto MessageBox 
        Dim result = MessageBox.Show(message, caption, _
                                     MessageBoxButtons.YesNo, _
                                     MessageBoxIcon.Asterisk)

        'edo ginete elegxos gia to ti exei epileksei o xristis sto MessageBox
        If (result = DialogResult.No) Then
            e.Cancel = True                            'an exei epilextei to "no" tote i efarmogi den termatizetai 
        End If                                         'allios termatizetai i efarmogi

    End Sub

End Class
