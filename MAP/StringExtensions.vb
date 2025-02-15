Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text

Module StringExtensions
    <System.Runtime.InteropServices.DllImport("shlwapi", CharSet:=CharSet.Auto)>
    Private Function StrFormatByteSize(ByVal fileSize As Long, ByVal buffer As StringBuilder, ByVal bufferSize As Integer) As Long
    End Function

    ' Return a file size created by the StrFormatByteSize API function.
    <Extension()>
    Public Function ToFileSizeApi(ByVal file_size As Integer) As String
        Dim sb As New StringBuilder(20)
        StrFormatByteSize(file_size, sb, 20)
        Return sb.ToString()
    End Function

    ' Return a string describing the value as a file size.
    ' For example, 1.23 MB.
    <Extension()>
    Public Function ToFileSize(ByVal value As Double) As String
        Dim suffixes As String() = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}
        For i As Integer = 0 To suffixes.Length - 1
            If (value <= (Math.Pow(1024, i + 1))) Then
                Return ThreeNonZeroDigits(value / Math.Pow(1024, i)) & " " & suffixes(i)
            End If
        Next i

        Return ThreeNonZeroDigits(value / Math.Pow(1024, suffixes.Length - 1)) &
            " " & suffixes(suffixes.Length - 1)
    End Function

    ' Return the value formatted to include at most three
    ' non-zero digits and at most two digits after the
    ' decimal point. Examples:
    '         1
    '       123
    '        12.3
    '         1.23
    '         0.12
    Private Function ThreeNonZeroDigits(ByVal value As Double) As String
        If (value >= 100) Then
            ' No digits after the decimal.
            Return value.ToString("0,0")
        ElseIf (value >= 10) Then
            ' One digit after the decimal.
            Return value.ToString("0.0")
        Else
            ' Two digits after the decimal.
            Return value.ToString("0.00")
        End If
    End Function
End Module
