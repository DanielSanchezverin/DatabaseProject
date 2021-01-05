Imports Oracle.DataAccess.Client
Public Class Estado
    Private idEstado As Integer
    Private idPais As Integer
    Private nombre As String
    Public Sub New()
        Me.idEstado = 0
        Me.idPais = 0
        Me.nombre = ""
    End Sub

    Public Sub New(idEstado As Integer, idPais As Integer, nombre As String)
        Me.idEstado = idEstado
        Me.idPais = idPais
        Me.nombre = nombre
    End Sub

    Public Property getSetIdEstado As Integer
        Get
            Return idEstado
        End Get
        Set(value As Integer)
            idEstado = value
        End Set
    End Property

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
        If idEstado <> 0 And idPais <> 0 And nombre <> "" Then
            query = "INSERT INTO Estado VALUES (" & idEstado & ", " & idPais & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idEstado <> 0 And idPais <> 0 And nombre <> "" Then
            query = "UPDATE Estado SET nombre = '" & nombre & "' WHERE idEstado = " & idEstado & " AND idPais = " & idPais
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idEstado <> 0 And idPais <> 0 Then
            query = "DELETE FROM Estado WHERE idEstado = " & idEstado & " AND idPais = " & idPais
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
        query = "SELECT * FROM Estado WHERE idPais = " & idPais & " AND idEstado = " & idEstado
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idEstado")) Then
                idEstado = 0
            Else
                idEstado = CStr(dt.Rows(0)("idEstado"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarID() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Estado WHERE idEstado = " & idEstado
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idEstado")) Then
                idEstado = 0
            Else
                idEstado = CStr(dt.Rows(0)("idEstado"))
            End If
            consultarID = True
        End If
    End Function
    Sub consultarID2()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "SELECT Estado.idEstado AS ""Id Estado"", Pais.nombre AS Pais, Estado.nombre AS Estado FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = " & FormEstado.txtIdEstado.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("Id Estado")) Then
                idEstado = 0
            Else
                idEstado = CInt(dataT.Rows(0)("Id Estado"))
                FormEstado.cmbPais.Text = CStr(dataT.Rows(0)("Pais"))
                FormEstado.cmbNombre.Text = CStr(dataT.Rows(0)("Estado"))
            End If
        End If
    End Sub
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Ciudad WHERE idEstado = " & idEstado
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idEstado")) Then
                idEstado = 0
            Else
                idEstado = CInt(dataT.Rows(0)("idEstado"))
            End If
            validacion = True
        End If
    End Function
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Estado.idEstado AS ""Id Estado"", Pais.nombre AS Pais, Estado.nombre AS ESTADO FROM Pais, Estado WHERE Pais.idPais = Estado.idPais 
                ORDER BY Estado.idEstado"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
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
    Public Sub comboEstado(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Estado.nombre FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Pais.nombre = '" & FormEstado.cmbPais.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 115
        dgv.Columns.Item(1).Width = 200
        dgv.Columns.Item(2).Width = 200
    End Sub
    Public Function consultaIdPais() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idPais FROM Pais WHERE nombre = '" & FormEstado.cmbPais.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idPais")) Then
                idPais = 0
            Else
                idPais = CStr(dt.Rows(0)("idPais"))
            End If
        End If
        Return idPais
    End Function
End Class
