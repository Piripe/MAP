Imports System.Management
Module HardwareInfosModule
	Public CPU_percent As Single
	Public CPU_PreformanceCounter As PerformanceCounter
	Public RAM_usage As String = "0 B"
	Public RAM_percent As String = "0"
	Public RAM_total As String = CDbl(My.Computer.Info.TotalPhysicalMemory).ToFileSize()
	Public GPU As Object
	Public CPU As Object = Nothing
	Public Loaded As Boolean = False

	Public Sub Load(code As XElement)
		If code Is Nothing Then

		End If
		If Not Loaded Then
			'Throw New NotImplementedException()
			'MsgBox("Load HardwareInfosModule...")
			Loaded = True
		Dim context = TaskScheduler.FromCurrentSynchronizationContext
			Task.Run(Sub() LoadCPUAndGPU(context))
		End If
	End Sub
	Sub LoadCPUAndGPU(context As TaskScheduler)
		Dim CPU_ = New ManagementObjectSearcher("select * from Win32_Processor").Get()(0)
		Dim GPU_ = New ManagementObjectSearcher("select * from Win32_VideoController").Get()(0)
		Dim CPU_PreformanceCounter_ As PerformanceCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")
		Task.Factory.StartNew(Sub()
								  CPU = CPU_
								  GPU = GPU_
								  CPU_PreformanceCounter = CPU_PreformanceCounter_
							  End Sub, Threading.CancellationToken.None, TaskCreationOptions.None, context)
	End Sub

	Public Function Save() As XElement
		'Throw New NotImplementedException()
		Return New XElement("settings")
	End Function

	Public Sub TickFrame()
	End Sub

	Public Sub TickMS100()
		If CPU_PreformanceCounter IsNot Nothing Then HardwareInfosModule.CPU_percent = HardwareInfosModule.CPU_PreformanceCounter.NextValue()
		HardwareInfosModule.RAM_percent = CInt(Math.Round(CDbl((CLng((My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory)))) / My.Computer.Info.TotalPhysicalMemory * 100.0))
		HardwareInfosModule.RAM_usage = CDbl(My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory).ToFileSize()
	End Sub

	Public Sub TickMS1000()
	End Sub
End Module
