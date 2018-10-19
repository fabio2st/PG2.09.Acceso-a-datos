Imports System.Data.SqlClient
Module ConexionTest

    Sub Main()
        Try
            ' crear el objeto de conexión 
            Dim oConexion As New SqlConnection()
            ' pasar la cadena de conexión 
            'oConexion.ConnectionString = "server=(local);database=Xnorthwind;uid=sa;pwd=;"
            oConexion.ConnectionString = "server=HOTBLOODED\SQLEXPRESS2008R2;database=bancarota;Integrated Security=True;"
            ' abrir conexión 
            oConexion.Open()
            ' si abre muestra data de la misma si no atrapa la excepción
            Console.WriteLine("Conectado")
            Console.WriteLine("Versión del servidor: " & oConexion.ServerVersion)
            Console.WriteLine("Status: " & oConexion.State.ToString)
            ' cerrar conexión 
            oConexion.Close()
            Console.WriteLine("Desconectado")
        Catch oExcep As SqlException
            ' si se produce algún error, 
            ' lo capturamos mediante el objeto 
            ' de excepciones particular para 
            ' el proveedor de SQL Server 
            Console.WriteLine("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)
        Finally
            Console.ReadKey()
        End Try
    End Sub

End Module
