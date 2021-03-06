﻿Imports System.Data.SqlClient

Module AgregarDatos
    Sub Main()
        Dim nombre As String
        Dim domicio As String
        Console.Write("Nombre: ")
        nombre = Console.ReadLine
        Console.Write("Domicilio: ")
        domicio = Console.ReadLine
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
            ' crear el objeto command
            Dim oCmd As New SqlCommand
            ' asignar la conexion 
            oCmd.Connection = oConexion
            'ejecutar un SP
            oCmd.CommandType = CommandType.StoredProcedure
            'nombre del SP
            oCmd.CommandText = "clienteAdd"
            'establecer los parámetros de la coneccion
            oCmd.Parameters.AddWithValue("@nombre", nombre)
            oCmd.Parameters.AddWithValue("@domicilio", domicio)
            ' ejecuta el comando
            Dim x As Integer
            x = oCmd.ExecuteNonQuery()
            Console.WriteLine(x & " filas agregadas")
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

