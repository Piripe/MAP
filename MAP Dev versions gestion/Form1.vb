Imports System.Security.Cryptography
Public Class Form1
    Dim Versions As New List(Of Version)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("versions.xml") Then
            For Each x In XDocument.Load("versions.xml").Element("doc").Element("versions").Elements
                Versions.Add(New Version)
                Versions.Last.Name = x.Element("name").Value
                Versions.Last.Version = x.Element("version").Value
                Versions.Last.URL = x.Element("url").Value
                Versions.Last.Key = x.Element("key").Value
                Versions.Last.UpdateDate = New Date(x.Element("date").Value)
            Next
        Else
            Versions.Add(New Version)
        End If
        RefreshList()
    End Sub
    Sub RefreshList()
        For i = 0 To Versions.Count - 1
            If ListView1.Items.Count > i Then
                If Not ListView1.Items(i).Text = Versions(i).Name Then
                    ListView1.Items(i).Text = Versions(i).Name
                    ListView1.Items(i).SubItems(0).Text = Versions(i).Version
                    ListView1.Items(i).SubItems(1).Text = Versions(i).UpdateDate.ToString("ddd d MMM yyyy ""à"" HH:mm:ss")
                End If
            Else
                ListView1.Items.Add(Versions(i).Name)
                ListView1.Items(i).SubItems.Add(Versions(i).Version)
                ListView1.Items(i).SubItems.Add(Versions(i).UpdateDate.ToString("ddd d MMM yyyy ""à"" HH:mm:ss"))
            End If
        Next
    End Sub

    Private Sub AddVersionButton_Click(sender As Object, e As EventArgs) Handles AddVersionButton.Click
        Versions.Add(New Version)
        Versions.Last.Key = RandomString(16)
        RefreshList()
    End Sub

    Private Sub CheckCodeButton_Click(sender As Object, e As EventArgs) Handles CheckCodeButton.Click
        Dim str = ""
        'If CheckKeyTextBox.Text = "" Then
        'For Each x In Versions
        'str &= New Simple3Des(x.Key).EncryptData("§" & x.Version & "§" & x.URL) & vbCr
        'Next
        'MsgBox(Str)
        'For i = 0 To Versions.Count - 1
        'MsgBox(Versions(i).Name & " : " & New Simple3Des(Versions(i).Key).DecryptData(Str.Split(vbCr)(i)))
        'Next
        'Else
        For Each x In Versions
                str &= New Simple3Des(x.Key).EncryptData("§" & x.Version & "§" & x.URL) & vbCr
            Next
            Dim found_code As Boolean = False
            For i = 0 To Versions.Count - 1
                Try
                    Dim decrypted_str As String = New Simple3Des(CheckKeyTextBox.Text.Replace("-", "")).DecryptData(str.Split(vbCr)(i))
                    If decrypted_str.StartsWith("§") Then
                        MsgBox(Versions(i).Name & " : " & decrypted_str)
                        found_code = True
                    End If
                Catch

                End Try
            Next
            If Not found_code Then
                MsgBox("This beta does not exist.")
            End If
        'End If
    End Sub
    Function RandomString(Lenght As Integer)
        Dim s = "ABCDEFTHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim sb As New Text.StringBuilder
        Dim rnd As New Random
        For i = 1 To Lenght
            sb.Append(s.Substring(rnd.Next(0, s.Length), 1))
        Next
        Return sb.ToString
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        KeyTextBox.UseSystemPasswordChar = True
        ShowHideCodeButton.Text = "Show"
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            NameTextBox.Text = Versions(si).Name
            VersionTextBox.Text = Versions(si).Version
            URLTextBox.Text = Versions(si).URL
            KeyTextBox.Text = Versions(si).Key
        Else
            NameTextBox.Text = ""
            VersionTextBox.Text = ""
            URLTextBox.Text = ""
            KeyTextBox.Text = ""
        End If
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions(si).Name = NameTextBox.Text
            ListView1.Items(si).Text = NameTextBox.Text
        End If
    End Sub

    Private Sub VersionTextBox_TextChanged(sender As Object, e As EventArgs) Handles VersionTextBox.TextChanged
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions(si).Version = VersionTextBox.Text
            ListView1.Items(si).SubItems(1).Text = VersionTextBox.Text
        End If
    End Sub

    Private Sub URLTextBox_TextChanged(sender As Object, e As EventArgs) Handles URLTextBox.TextChanged
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions(si).URL = URLTextBox.Text
        End If
    End Sub

    Private Sub KeyTextBox_TextChanged(sender As Object, e As EventArgs) Handles KeyTextBox.TextChanged
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions(si).Key = KeyTextBox.Text
        End If
    End Sub

    Private Sub ShowHideCodeButton_Click(sender As Object, e As EventArgs) Handles ShowHideCodeButton.Click
        KeyTextBox.UseSystemPasswordChar = Not KeyTextBox.UseSystemPasswordChar
        ShowHideCodeButton.Text = If(KeyTextBox.UseSystemPasswordChar, "Show", "Hide")
    End Sub

    Private Sub UpdateTimeButton_Click(sender As Object, e As EventArgs) Handles UpdateTimeButton.Click
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions(si).UpdateDate = Date.Now
            ListView1.Items(si).SubItems(2).Text = Versions(si).UpdateDate.ToString("ddd d MMM yyyy ""à"" HH:mm:ss")
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim xDoc As New XDocument(New XElement("doc",
                                               New XElement("versions")
                                               ))
        For Each x In Versions
            xDoc.Element("doc").Element("versions").Add(New XElement("version",
                                                                     New XElement("name", x.Name),
                                                                     New XElement("version", x.Version),
                                                                     New XElement("url", x.URL),
                                                                     New XElement("key", x.Key),
                                                                     New XElement("date", x.UpdateDate.Ticks)
))
        Next
        xDoc.Save("versions.xml")
    End Sub

    Private Sub CopyCodeButton_Click(sender As Object, e As EventArgs) Handles CopyCodeButton.Click
        Dim Str = ""
        For Each x In Versions
            Str &= New Simple3Des(x.Key).EncryptData("§" & x.Version & "§" & x.URL) & vbCr
        Next
        My.Computer.Clipboard.SetText(Str)
        Label5.Visible = True
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Visible = False
        Timer1.Stop()
    End Sub

    Private Sub DeleteVersionButton_Click(sender As Object, e As EventArgs) Handles DeleteVersionButton.Click
        If ListView1.SelectedIndices.Count >= 1 Then
            Dim si = ListView1.SelectedIndices(0)
            Versions.RemoveAt(si)
            ListView1.Items.Clear()
            RefreshList()
            KeyTextBox.UseSystemPasswordChar = True
            ShowHideCodeButton.Text = "Show"
            NameTextBox.Text = ""
                VersionTextBox.Text = ""
                URLTextBox.Text = ""
            KeyTextBox.Text = ""
        End If
    End Sub
End Class
Class Version
    Property Version As String = "0.0.0.1"
    Property Name As String = "New Beta"
    Property URL As String = "https://exemple.url"
    Property UpdateDate As Date = Date.Now
    Property Key As String = ""
End Class
Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(key As String, lenght As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider

        Dim keyBytes() As Byte = Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ReDim Preserve hash(lenght - 1)
        Return hash
    End Function
    Sub New(key As String)
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    Public Function EncryptData(str As String) As String
        Dim strBytes() As Byte = Text.Encoding.Unicode.GetBytes(str)
        Dim ms As New IO.MemoryStream
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write)
        encStream.Write(strBytes, 0, strBytes.Length)
        encStream.FlushFinalBlock()

        Return Convert.ToBase64String(ms.ToArray)
    End Function
    Public Function DecryptData(str As String)
        Dim strBytes() As Byte = Convert.FromBase64String(str)
        Dim ms As New IO.MemoryStream
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor, CryptoStreamMode.Write)
        decStream.Write(strBytes, 0, strBytes.Length)
        decStream.FlushFinalBlock()

        Return Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function
End Class