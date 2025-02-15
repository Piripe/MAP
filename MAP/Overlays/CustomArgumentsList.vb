Public Class CustomArgumentsList
    Dim CategoriesName As New List(Of String)
    Dim ElementsName As New List(Of List(Of String))
    Dim Elements As New List(Of List(Of String))
    Dim ElementsAddedValue As New List(Of List(Of String))

    Private Sub CustomArgumentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CategoriesName = New List(Of String)
        ElementsName = New List(Of List(Of String))
        Elements = New List(Of List(Of String))
        ElementsAddedValue = New List(Of List(Of String))
        CategoriesName.Add("Time")
        ElementsName.Add({"Year", "Month", "Day", "Day of the week", "Hour", "Minute", "Second", "Formatted Date"}.ToList)
        Elements.Add({"{time:yyyy} Display the actual year.", "{time:MM} Display the actual month.", "{time:dd} Display the actual day.", "{time:dddd} Display the actual day of the week.", "{time:HH} Display the hour using a 24-hour clock from 0 to 23..", "{time:mm} Display the minute.", "{time:ss} Display the second.", "{time:format} Display a custom time format :

y - The year, from 0 to 99.
yy - The year, from 00 to 99.
yyy - The year, with a minimum of three digits.
yyyy - The year as a four-digit number.
M - The month, from 1 through 12.
MM - The month, from 01 through 12.
MMM - The abbreviated name of the month.
MMMM - The full name of the month.
d - The day of the month, from 1 through 31.
dd - The day of the month, from 01 through 31.
ddd - The abbreviated name of the day of the week.
dddd - The full name of the day of the week.
h - The hour, using a 12-hour clock from 1 to 12.
hh - The hour, using a 12-hour clock from 01 to 12.
H - The hour, using a 24-hour clock from 0 to 23.
HH - The hour, using a 24-hour clock from 00 to 23.
t - The first character of the AM/PM designator.
tt - The AM/PM designator.
m - The minute, from 0 through 59.
mm - The minute, from 00 through 59.
s - The second, from 0 through 59.
ss - The second, from 00 through 59.
: - The time separator.
/ - The date separator.
""string"" 'string' - Literal string delimiter.
% - Defines the following character as a custom format specifier.
\ - The escape character.
Any other character - The character is copied to the result string unchanged.

Exemple : {time:dddd d""'th"" MMMM yyyy ""at"" hh:mm:ss tt}
Display ""Friday 1'th January 2021 at 09:08:45 AM""

More informations: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings"}.ToList)
        ElementsAddedValue.Add({"{time:yyyy}", "{time:MM}", "{time:dd}", "{time:dddd}", "{time:HH}", "{time:mm}", "{time:ss}", "{time:dddd d""'th"" MMMM yyyy ""at"" hh:mm:ss tt}"}.ToList)

        If OverlayGestion.ActiveModules(0) Then
            CategoriesName.Add("Music Player")
            ElementsName.Add({"Music Title", "Music Artist", "Music Filename", "Music Filename Without Extension", "Music Position"}.ToList)
            Elements.Add({"{musicmodule:title} Display the title of the current music.", "{musicmodule:artist} Display the artist of the current music.", "{musicmodule:artist} Display the artist of the current music.", "{musicmodule:filename} Display the filename of the current music.", "{musicmodule:filename_withoutextension} Display the filename without the extension of the current music.", "{musicmodule:time:format} Display the current time position with a current time format.

d - The number of whole days in the time interval.
h - The number of whole hours in the time interval that aren't counted as part of days. Single-digit hours don't have a leading zero.
hh - The number of whole hours in the time interval that aren't counted as part of days. Single-digit hours have a leading zero.
m - The number of whole minutes in the time interval that aren't included as part of hours or days. Single-digit minutes don't have a leading zero.
mm - The number of whole minutes in the time interval that aren't included as part of hours or days. Single-digit minutes have a leading zero.
s - The number of whole seconds in the time interval that aren't included as part of hours, days, or minutes. Single-digit seconds don't have a leading zero.
ss - The number of whole seconds in the time interval that aren't included as part of hours, days, or minutes. Single-digit seconds have a leading zero.
'string' - Literal string delimiter.
\ - The escape character.
Any other character - The character is copied to the result string unchanged.

Exemple : {musicmodule:time:hh\:mm\:ss/hh\:mm\:ss}
Display ""00:00:00/00:21:54""

More informations: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings"}.ToList)
            ElementsAddedValue.Add({"{musicmodule:title}", "{musicmodule:artist}", "{musicmodule:filename}", "{musicmodule:filename_withoutextension}", "{musicmodule:time:hh\:mm\:ss/hh\:mm\:ss}"}.ToList)
        End If
        CategoriesName.Add("Other")
        ElementsName.Add({"Web Request"}.ToList)
        Elements.Add({"{url:address} Display the URL response."}.ToList)
        ElementsAddedValue.Add({"{url:https://pastebin.com/raw/BN6NAvEy}"}.ToList)
        If OverlayGestion.ActiveModules(1) Then
            Dim infos As New List(Of String)
            Try
                infos.Add(HardwareInfosModule.CPU("Name"))
                infos.Add(HardwareInfosModule.CPU("MaxClockSpeed"))
                infos.Add(HardwareInfosModule.CPU("NumberOfCores"))
                infos.Add(HardwareInfosModule.GPU("Name"))
                infos.Add(HardwareInfosModule.GPU("VideoModeDescription"))
            Catch
                For i = 0 To 4
                    infos.Add("Error while loading hardware infos.")
                Next
            End Try
            CategoriesName.Add("Hardware Infos")
            ElementsName.Add({"Memory Usage", "Memory Total", "Memory Usage Percent", "CPU Usage", "CPU Infos", "GPU Infos"}.ToList)
            Elements.Add({"{hardware:ram_usage} Display the RAM usage.", "{hardware:ram_total} Display the total RAM.", "{hardware:ram_percent} Display the RAM usage in percent.", "{hardware:cpu_usage} Display the CPU usage.", "{hardware:cpu:argument} Display an information of the CPU.

Usefull arguments :
{hardware:cpu:Name} : """ & infos(0) & """
{hardware:cpu:MaxClockSpeed} : """ & infos(1) & """
{hardware:cpu:NumberOfCores} : """ & infos(2) & """

More informations: https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor", "{hardware:gpu:argument} Display an information of the GPU.

Usefull arguments :
{hardware:gpu:Name} : """ & infos(3) & """
{hardware:gpu:VideoModeDescription} : """ & infos(4) & """

More informations: https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-videocontroller?redirectedfrom=MSDN"}.ToList)
            ElementsAddedValue.Add({"{hardware:ram_usage}", "{hardware:ram_total}", "{hardware:ram_percent}", "{hardware:cpu_usage}", "{hardware:cpu:Name}", "{hardware:gpu:Name}"}.ToList)
        End If
        ListBox1.SelectedIndex = -1
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(CategoriesName.ToArray)
        ComboBox1.SelectedIndex = -1
        ComboBox1.Items.Clear()
        AddArgButton.Enabled = False
        ArgumentDescriptionTextBox.Text = ""
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        OverlayGestion.StartIgnoreTopMost()
    End Sub

    Private Sub ComboBox1_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox1.DropDownClosed
        OverlayGestion.StopIgnoreTopMost()
    End Sub

    Private Sub AddArgButton_Click(sender As Object, e As EventArgs) Handles AddArgButton.Click
        Settings.SplitContainer2.Panel2.Controls.Find(0, False)(0).Text &= ElementsAddedValue(ListBox1.SelectedIndex)(ComboBox1.SelectedIndex)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(ElementsName(ListBox1.SelectedIndex).ToArray)
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then
            AddArgButton.Enabled = False
            ArgumentDescriptionTextBox.Text = ""
        Else
            AddArgButton.Enabled = True
            ArgumentDescriptionTextBox.Text = Elements(ListBox1.SelectedIndex)(ComboBox1.SelectedIndex)
        End If
    End Sub
End Class