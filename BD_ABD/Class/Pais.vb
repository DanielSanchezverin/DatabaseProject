﻿Imports Oracle.DataAccess.Client
Public Class Pais
    Private idPais As Integer
    Private nombre As String
    Public Sub New()
        Me.idPais = 0
        Me.nombre = ""
    End Sub

    Public Sub New(idPais As Integer, nombre As String)
        Me.idPais = idPais
        Me.nombre = nombre
    End Sub

    Public Property getSetIdPais As Integer
        Get
            Return idPais
        End Get
        Set(value As Integer)
            idPais = value
        End Set
    End Property

    Public Property getSetNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Sub insert()
        Dim query As String
        Dim conOracle As New Oracle
        If idPais <> 0 And nombre <> "" Then
            query = "INSERT INTO Pais VALUES (" & idPais & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idPais <> 0 And nombre <> "" Then
            query = "UPDATE Pais SET nombre = '" & nombre & "' WHERE idPais = " & idPais
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idPais <> 0 Then
            query = "DELETE FROM Pais WHERE idPais = " & idPais
            conOracle.objetoCommand(query)
            MessageBox.Show("Registro Eliminado")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Pais WHERE idPais = " & idPais
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idPais")) Then
                idPais = 0
            Else
                idPais = CStr(dt.Rows(0)("idPais"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Estado WHERE idPais = " & idPais
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idPais")) Then
                idPais = 0
            Else
                idPais = CInt(dataT.Rows(0)("idPais"))
            End If
            validacion = True
        End If
    End Function
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT idPais AS ""Id Pais"", nombre AS Pais FROM Pais ORDER BY idPais"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Sub consultarID()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Pais WHERE idPais = " & FormPais.txtIdPais.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idPais")) Then
                idPais = 0
            Else
                idPais = CInt(dataT.Rows(0)("idPais"))
                FormPais.cmbNombre.Text = CStr(dataT.Rows(0)("nombre"))
            End If
        End If
    End Sub
    Public Sub comboPais(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM Pais"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 250
        dgv.Columns.Item(1).Width = 265
    End Sub
End Class
