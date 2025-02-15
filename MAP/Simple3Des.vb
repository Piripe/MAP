Imports System.Security.Cryptography
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