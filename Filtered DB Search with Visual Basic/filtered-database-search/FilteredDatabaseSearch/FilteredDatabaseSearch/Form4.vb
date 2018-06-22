Imports System.IO
Public Class Form4
    'Metavliti gia na kratame se oli tin efarmogi pio filter einai otan kanoume save to filter
    Public filtercounter As Integer = 1
    Private Sub ButtonBackForm3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackForm3.Click
        'Sto pathma tou koumpiou Back ths Form4 emfanizetai h Form3, kleinei h trexousa forma (Form4), apenergopoieitai to koumpi 
        'Show Results ths Form3 kai metaferoume tin timi tou filtercounter stin filtercounter3 tis form3
        Form3.Visible = True
        Me.Close()
        Form3.ButtonResults.Enabled = False
        Form3.filtercounter3 = filtercounter
    End Sub

    Private Sub Form4_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Afou patithei to koumpi Close kai kleisei h Form4, emfanizetai h Form3, apenergopoieitai to koumpi 
        'Show Results ths Form3 kai metaferoume tin timi tou filtercounter stin filtercounter3 tis form3
        Form3.Visible = True
        Form3.ButtonResults.Enabled = False
        Form3.filtercounter3 = filtercounter
    End Sub

    Private Sub SaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveItem.Click
        Try


            'orismos tou save dialog
            Dim save_file As New SaveFileDialog
            'orismos tou titlou pou tha fainetai otan anoixei to save dialog
            save_file.Title = "Save Results to a File"
            'orizoume pou apothikeyetai to arxeio
            save_file.InitialDirectory = "C:/"

            'dinoume tis epektaseis arxeiwn pou tha yparxoun ws epiloges sto SaveDialog gia tin apothikeysi tou arxeioy.
            'dld ousiastika prosthetoume filtra sto parathyro tou save Dialog
            '(ola ta arxeia * kai arxeia pou exoun tin katalixi .xml) 
            save_file.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"


            'i grammi ayti orizei to default filtro pou dimiourgisame parapanw. An den orisoume ena  
            'filtro tote aytomata tha oristei to FilterIndex se 1 dld All files(*.*)|*.*
            'Etsi exoume dyo epiloges kai epilegoume tin deyteri epilogi me FilterIndex=2 dld apothikeysi arxeiou se morfi xml(*.xml)
            save_file.FilterIndex = 2


            'dimiourgia enos datatable
            Dim my_datatable As New DataTable

            'Otan sto SaveDialog patisoume OK tote....
            If save_file.ShowDialog() = DialogResult.OK Then

                'pairnoume tin pigi tou datagridview se datatable kai tin apothikeyoume.
                my_datatable = CType(DataGridView1.DataSource, DataTable)


                'apothikeyoume to datatable se xml morfi sto arxeio 
                'pou tha dimiourgithei kai tha exei ws onoma ayto pou tou exoume dwsei
                my_datatable.WriteXml(save_file.FileName)


            End If
            MsgBox("File Saved Sucessfully!") 'ean to arxeio apothikeytei swsta tote emfanizetai to mynima ayto
        Catch ex As Exception
            MsgBox("File Error!") 'ean synvei sfalma stin apothikeysi tou arxeiou tote emfanizetai to mynima ayto.
        End Try
    End Sub



    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'me to patima tou koumpiou (|>) metakinoumaste stin prwti grammi twn apotelesmatwn tou DataGridview
        Me.BindingSource1.MoveFirst()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'me to patima tou koumpiou (<) metakinoumaste stin proigoumeni kathe fora grammi 
        'twn apotelesmatwn tou DataGridview apo aytin pou hdh vriskomaste
        Me.BindingSource1.MovePrevious()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'me to patima tou koumpiou (>) metakinoumaste stin eponeni kathe fora grammi 
        'twn apotelesmatwn tou DataGridview apo aytin pou hdh vriskomaste
        Me.BindingSource1.MoveNext()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        'me to patima tou koumpiou (|<) metakinoumaste stin teleytaia grammi twn apotelesmatwn tou DataGridview
        Me.BindingSource1.MoveLast()
    End Sub

    Private Sub ButtonSaveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveFilter.Click
        Dim selectedPedia() As Tables = Form2.getselectedPedia
        Dim selFields() As SelectedFields = Form2.getSelFields()
        Dim savepath As String
        Dim strSQL As String
        'Orizoume 5 flags
        Dim f1 As Integer = 0
        Dim f2 As Integer = 0
        Dim f3 As Integer = 0
        Dim f4 As Integer = 0
        Dim f5 As Integer = 0
        'Orizoume enan counter opote kanei save o xristis na anevainei kai na exoun diaforetika onomata ta arxeia
        Dim counter As Integer = 1

        strSQL = Form3.getsqlstring

        'orismoume ton titlo pou tha fainetai otan anoixei to save dialog
        filesave.Title = "Save Filter to a File"
        'orizoume pou apothikeyetai to arxeio
        filesave.InitialDirectory = "C:/"
        'orizoume to onoma pou tha exei to arxeio otan apothikeutei
        filesave.FileName = "Filter" & filtercounter
        'dinoume tis epektaseis arxeiwn pou tha yparxoun ws epiloges sto SaveDialog gia tin apothikeysi tou arxeioy.
        'dld ousiastika prosthetoume filtra sto parathyro tou save Dialog
        '(ola ta arxeia * kai arxeia pou exoun tin katalixi .txt)
        filesave.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        Try
            If filesave.ShowDialog() = Windows.Forms.DialogResult.OK Then
                savepath = filesave.FileName
                Dim fstream As FileStream
                Dim writer As StreamWriter
                filtercounter += 1
                fstream = New FileStream(savepath, FileMode.Create, FileAccess.Write)
                writer = New StreamWriter(fstream)
                Dim contents2 As String
                writer.WriteLine("This filter file created at:")
                writer.WriteLine(Date.UtcNow) 'emfanisi tis imerominias kai tis wras pou dmiourgithike to filtro
                writer.WriteLine()
                writer.WriteLine("Your SQL query is:")
                'emfanisi tou sql query sto filtro pou dmiourgithike
                writer.WriteLine(strSQL)
                writer.WriteLine()
                contents2 = "You selected these fields:"
                'emfanisi ton fields pou epilextikan kai to ti balame sta textboxes sto filtro pou dmiourgithike
                writer.WriteLine(contents2)
                Try
                    For i = 0 To selFields.Length - 2
                        Dim str As String
                        str = selFields(i).getTableName
                        writer.WriteLine("From " + str + ":")
                        For j = 0 To selFields(i).getSelFields.Length - 2
                            Dim contents As String
                            contents = selFields(i).getSelFields(j)
                            writer.Write(contents + "=")
                            contents = selectedPedia(counter).getFields.Text
                            If contents = "Unusable" Then
                                writer.Write("'" + contents + "'")
                            ElseIf contents = "" Then
                                writer.Write("'" + "NULL" + "'")
                            Else
                                writer.Write(contents)
                            End If
                            counter += 1
                            writer.Write("  ")
                        Next
                        writer.WriteLine()
                    Next
                Catch ex As Exception
                End Try
                Try
                    writer.WriteLine()
                    writer.WriteLine()
                    Try
                        For i = 1 To selectedPedia.Length - 1
                            'Elegxoume poio apo ta checkboxes tis form3 einai check kai alazoume tin antistoixi flag 
                            If selectedPedia(i).getBeginLCheckboxes.Checked Then
                                f1 = 1
                            End If
                            If selectedPedia(i).getContainsLCheckboxes.Checked Then
                                f2 = 1
                            End If
                            If selectedPedia(i).getEndLCheckboxes.Checked Then
                                f3 = 1
                            End If
                            If selectedPedia(i).getGreaterThanCheckBoxes.Checked Then
                                f4 = 1
                            End If
                            If selectedPedia(i).getLowerThanCheckBoxes.Checked Then
                                f5 = 1
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    If f1 = 1 Then
                        'An i f1 einai 1 tote emfanizoume gia poia pedia theloume na arxizoun me kapious xaraktires kai pious xaraktires kai tous apothikeuome sto filter
                        writer.WriteLine("You checked:")
                    End If
                    For i = 1 To selectedPedia.Length - 1
                        Dim contents As String
                        contents = selectedPedia(i).getFname.Text
                        If selectedPedia(i).getBeginLCheckboxes.Checked Then
                            writer.Write("For " + contents + " to begin with: " + selectedPedia(i).getFields.Text)
                            writer.WriteLine()
                        End If
                    Next
                Catch ex As Exception
                End Try
                Try
                    writer.WriteLine()

                    If f2 = 1 Then
                        'An i f2 einai 1 tote emfanizoume gia poia pedia theloume na periexoun kapious xaraktires kai pious xaraktires kai tous apothikeuome sto filter
                        writer.WriteLine("You checked:")
                    End If
                    For i = 1 To selectedPedia.Length - 1
                        Dim contents As String
                        contents = selectedPedia(i).getFname.Text
                        If selectedPedia(i).getContainsLCheckboxes.Checked Then
                            writer.Write("For " + contents + " to contains: " + selectedPedia(i).getFields.Text)
                            writer.WriteLine()
                        End If
                    Next
                Catch ex As Exception
                End Try
                Try
                    writer.WriteLine()

                    If f3 = 1 Then
                        'An i f3 einai 1 tote emfanizoume gia poia pedia theloume na teleionoun me kapious xaraktires kai pious xaraktires kai tous apothikeuome sto filter
                        writer.WriteLine("You checked:")
                    End If
                    For i = 1 To selectedPedia.Length - 1
                        Dim contents As String
                        contents = selectedPedia(i).getFname.Text
                        If selectedPedia(i).getEndLCheckboxes.Checked Then
                            writer.Write("For " + contents + " to end with: " + selectedPedia(i).getFields.Text)
                            writer.WriteLine()
                        End If
                    Next
                Catch ex As Exception
                End Try
                Try
                    writer.WriteLine()

                    If f4 = 1 Then
                        'An i f4 einai 1 tote emfanizoume gia poia pedia theloume na einai megalitera apo kapio noumero kai pio noumero einai kai ta apothikeuome sto filter
                        writer.WriteLine("You checked:")
                    End If
                    For i = 1 To selectedPedia.Length - 1
                        Dim contents As String
                        contents = selectedPedia(i).getFname.Text
                        If selectedPedia(i).getGreaterThanCheckBoxes.Checked Then
                            writer.Write("For " + contents + " to be greater than: " + selectedPedia(i).getFields.Text)
                            writer.WriteLine()
                        End If
                    Next
                Catch ex As Exception
                End Try
                Try
                    writer.WriteLine()

                    If f5 = 1 Then
                        'An i f5 einai 1 tote emfanizoume gia poia pedia theloume na einai mikrotera apo kapio noumero kai pio noumero einai kai ta apothikeuome sto filter
                        writer.WriteLine("You checked:")
                    End If
                    For i = 1 To selectedPedia.Length - 1
                        Dim contents As String
                        contents = selectedPedia(i).getFname.Text
                        If selectedPedia(i).getLowerThanCheckBoxes.Checked Then
                            writer.Write("For " + contents + " to be lower than: " + selectedPedia(i).getFields.Text)
                            writer.WriteLine()
                        End If
                    Next
                Catch ex As Exception
                End Try
                writer.Close()
                MsgBox("File Saved Sucessfully")
                f1 = 0
                f2 = 0
                f3 = 0
                f4 = 0
                f5 = 0
            End If
        Catch
            Return
        End Try
    End Sub
End Class