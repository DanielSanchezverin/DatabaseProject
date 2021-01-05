Imports Oracle.DataAccess.Client
Public Class Ciudad
    Private idCiudad As Integer
    Private idEstado As Integer
    Private nombre As String
    Public Sub New()
        idCiudad = 0
        idEstado = 0
        nombre = ""
    End Sub

    Public Sub New(idCiudad As Integer, idEstado As Integer, nombre As String)
        Me.idCiudad = idCiudad
        Me.idEstado = idEstado
        Me.nombre = nombre
    End Sub
    Public Property getSetIdCiudad As Integer
        Get
            Return idCiudad
        End Get
        Set(value As Integer)
            idCiudad = value
        End Set
    End Property

    Public Property getSetIdEstado As Integer
        Get
            Return idEstado
        End Get
        Set(value As Integer)
            idEstado = value
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
        If idCiudad <> 0 And idEstado <> 0 And nombre <> "" Then
            query = "INSERT INTO Ciudad VALUES(" & idCiudad & "," & idEstado & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idCiudad <> 0 And idEstado <> 0 And nombre <> "" Then
            query = "UPDATE Ciudad SET nombre = '" & nombre & "' WHERE idEstado =" & idEstado & " AND idCiudad = " & idCiudad
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idCiudad <> 0 And idEstado <> 0 Then
            query = "DELETE FROM Ciudad WHERE idEstado = " & idEstado & " AND idCiudad = " & idCiudad
            conOracle.objetoCommand(query)
            MessageBox.Show("Registro Eliminado")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Colonia WHERE idCiudad = " & idCiudad
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idCiudad")) Then
                idCiudad = 0
            Else
                idCiudad = CInt(dataT.Rows(0)("idCiudad"))
            End If
            validacion = True
        End If
    End Function
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Ciudad WHERE idCiudad = " & idCiudad & " AND idEstado = " & idEstado
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCiudad")) Then
                idCiudad = 0
            Else
                idCiudad = CStr(dt.Rows(0)("idCiudad"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarID() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Ciudad WHERE idCiudad = " & idCiudad
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCiudad")) Then
                idCiudad = 0
            Else
                idCiudad = CStr(dt.Rows(0)("idCiudad"))
            End If
            consultarID = True
        End If
    End Function
    Sub consultarID2()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "SELECT Ciudad.idCiudad AS ""Id Ciudad"", Pais.nombre AS Pais, Estado.nombre AS Estado, Ciudad.nombre AS Ciudad FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais
                AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = " & FormCiudad.txtIdCiudad.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("Id Ciudad")) Then
                idCiudad = 0
            Else
                idCiudad = CInt(dataT.Rows(0)("Id Ciudad"))
                FormCiudad.cmbPais.Text = CStr(dataT.Rows(0)("Pais"))
                FormCiudad.cmbEstado.Text = CStr(dataT.Rows(0)("Estado"))
                FormCiudad.cmbNombre.Text = CStr(dataT.Rows(0)("Ciudad"))
            End If
        End If
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Ciudad.idCiudad AS ""Id Ciudad"", Pais.nombre AS Pais, Estado.nombre AS ESTADO, Ciudad.nombre AS Ciudad FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais
                AND Estado.idEstado = Ciudad.idEstado ORDER BY Ciudad.idCiudad"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 85
        dgv.Columns.Item(1).Width = 135
        dgv.Columns.Item(2).Width = 135
        dgv.Columns.Item(3).Width = 140
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
    Public Sub comboEstado(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Estado.nombre FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Pais.nombre = '" & FormCiudad.cmbPais.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboCiudad(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Ciudad.nombre FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Pais.nombre = '" & FormCiudad.cmbPais.Text &
                "' AND Estado.nombre = '" & FormCiudad.cmbEstado.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Function consultaIdEstado() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Estado.idEstado FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Estado.nombre = '" & FormCiudad.cmbEstado.Text & "' AND Pais.nombre = '" &
                FormCiudad.cmbPais.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idEstado")) Then
                idEstado = 0
            Else
                idEstado = CStr(dt.Rows(0)("idEstado"))
            End If
        End If
        Return idEstado
    End Function
End Class
