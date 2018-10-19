Imports System.Data.SqlClient

Public Class EditSecuencial
    Dim oDataSet As New DataSet()

    Private Sub EditSecuencial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' crear el objeto de conexión con la cadena de conexión 
            Dim oConexion As New SqlConnection("server=HOTBLOODED\SQLEXPRESS2008R2;database=bancarota;Integrated Security=True;")
            ' crear el objeto command
            Dim oCmd As New SqlCommand("ClientesGetAll", oConexion)
            'ejecutar un SP
            oCmd.CommandType = CommandType.StoredProcedure
            ' abrir conexión 
            oConexion.Open()

            ' crear un data adapter con un comando
            Dim oDataAdapter As New SqlDataAdapter(oCmd)
            ' crar un dataset
            ' enlazar dataset con el dataadapter
            oDataAdapter.Fill(oDataSet, "clientes")
            ' cerrar la conexion
            oConexion.Close()
            mostrarDatos(0)

        Catch ex As Exception
            MessageBox.Show("Error en conexión")
        End Try
    End Sub

    Private Sub mostrarDatos(value As Integer)
        Try
            ' info de regs
            total.Text = oDataSet.Tables("clientes").Rows.Count
            ' creo un dataRow
            Dim oDataRow As DataRow
            Select Case value
                Case 0  'primer
                    oDataRow = oDataSet.Tables("clientes").Rows(0)
                    actual.Text = 1
                Case 1 ' anterior
                    oDataRow = oDataSet.Tables("clientes").Rows(actual.Text - 2)
                    actual.Text = actual.Text - 1
                Case 2 'siguiente
                    oDataRow = oDataSet.Tables("clientes").Rows(actual.Text)
                    actual.Text = actual.Text + 1
                Case 3 'ultimo
                    oDataRow = oDataSet.Tables("clientes").Rows(total.Text - 1)
                    actual.Text = total.Text
            End Select
            id.Text = oDataRow("id_cliente")
            nombre.Text = oDataRow("nombre")
            domicilio.Text = oDataRow("domicilio")
        Catch ex As Exception
            MessageBox.Show("Error de lectura")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mostrarDatos(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mostrarDatos(1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mostrarDatos(2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mostrarDatos(3)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        oDataSet.Tables("clientes").Rows.RemoveAt(actual.Text - 1)
        mostrarDatos(0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        oDataSet.Tables("clientes").Rows.Add()
        mostrarDatos(3)
    End Sub
End Class
