Imports System
Imports System.Threading

Imports Sinumerik.Advanced

Namespace App
    Public Class Program
        Public Shared Sub Main()
            Dim device = New SinumerikDevice("192.168.0.80")

            Using connection = device.CreateConnection()
                connection.Open()

                While True
                    Dim position = connection.ReadDouble("/Channel/MachineAxis/measPos1[u1, 1]")
                    Console.WriteLine("Current Position of Axis 1 is {0} mm", position)
                    
                    Thread.Sleep(1000)
                End While
            End Using
        End Sub
    End Class
End Namespace
