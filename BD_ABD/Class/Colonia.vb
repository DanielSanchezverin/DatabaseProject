Imports Oracle.DataAccess.Client
Public Class Colonia
    Private idColonia As Integer
    Private idCiudad As Integer
    Private nombre As String
    Public Sub New()
        Me.idColonia = 0
        Me.idCiudad = 0
        Me.nombre = ""
    End Sub
    Public Sub New(idColonia As Integer, idCiudad As Integer, nombre As String)
        Me.idColonia = idColonia
        Me.idCiudad = idCiudad
        Me.nombre = nombre
    End Sub
    Public Property getSetIdColonia() As Integer
        Get
            Return idColonia
        End Get
        Set(value As Integer)
            idColonia = value
        End Set
    End Property
    Public Property getSetIdCiudad As Integer
        Get
            Return idCiudad
        End Get
        Set(value As Integer)
            idCiudad = value
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
        If idColonia <> 0 And idCiudad <> 0 And nombre <> "" Then
            query = "INSERT INTO Colonia VALUES(" & idColonia & "," & idCiudad & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idColonia <> 0 And idCiudad <> 0 And nombre <> "" Then
            query = "UPDATE Colonia set nombre = '" & nombre & "' WHERE idCiudad = " & idCiudad & " AND idColonia = " & idColonia
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idColonia <> 0 And idCiudad <> 0 Then
            query = "DELETE FROM Colonia WHERE idCiudad = " & idCiudad & " AND idColonia = " & idColonia
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
        query = "SELECT * FROM Colonia WHERE idCiudad = " & idCiudad & " AND idColonia = " & idColonia
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idColonia")) Then
                idColonia = 0
            Else
                idColonia = CStr(dt.Rows(0)("idColonia"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarID() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Colonia WHERE idColonia = " & idColonia
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idColonia")) Then
                idColonia = 0
            Else
                idColonia = CStr(dt.Rows(0)("idColonia"))
            End If
            consultarID = True
        End If
    End Function
    Public Sub consultarID2()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Colonia.idColonia AS ""Id Colonia"", Pais.nombre AS Pais, Estado.nombre AS Estado, Ciudad.nombre AS Ciudad, Colonia.nombre AS Colonia FROM Pais, Estado, Ciudad, Colonia
                WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = Colonia.idCiudad AND Colonia.idColonia = " & FormColonia.txtIdColonia.Text
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("Id Colonia")) Then
                idColonia = 0
            Else
                idColonia = CStr(dt.Rows(0)("Id Colonia"))
                FormColonia.cmbPais.Text = CStr(dt.Rows(0)("Pais"))
                FormColonia.cmbEstado.Text = CStr(dt.Rows(0)("Estado"))
                FormColonia.cmbCiudad.Text = CStr(dt.Rows(0)("Ciudad"))
                FormColonia.cmbNombre.Text = CStr(dt.Rows(0)("Colonia"))
            End If
        End If
    End Sub
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Alumno WHERE idColonia = " & idColonia
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idColonia")) Then
                idColonia = 0
            Else
                idColonia = CInt(dataT.Rows(0)("idColonia"))
            End If
            validacion = True
        End If
    End Function
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Colonia.idColonia AS ""Id Colonia"", Pais.nombre AS Pais, Estado.nombre AS Estado, Ciudad.nombre AS Ciudad, Colonia.nombre AS Colonia FROM Pais, Estado, Ciudad, Colonia
                WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = Colonia.idCiudad ORDER BY Colonia.idColonia"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 85
        dgv.Columns.Item(1).Width = 100
        dgv.Columns.Item(2).Width = 100
        dgv.Columns.Item(3).Width = 100
        dgv.Columns.Item(4).Width = 110
    End Sub
    Public Function consultaIdCiudad() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Ciudad.idCiudad FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Pais.nombre = '" & FormColonia.cmbPais.Text &
                "' And Estado.nombre = '" & FormColonia.cmbEstado.Text & "' AND Ciudad.nombre = '" & FormColonia.cmbCiudad.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCiudad")) Then
                idCiudad = 0
            Else
                idCiudad = CStr(dt.Rows(0)("idCiudad"))
            End If
        End If
        Return idCiudad
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
        query = "SELECT Estado.nombre FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Pais.nombre = '" & FormColonia.cmbPais.Text & "'"
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
        query = "SELECT Ciudad.nombre FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Pais.nombre = '" & FormColonia.cmbPais.Text &
                "' AND Estado.nombre = '" & FormColonia.cmbEstado.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboColonia(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Colonia.nombre FROM Pais, Estado, Ciudad, Colonia WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = Colonia.idCiudad
                AND Pais.nombre = '" & FormColonia.cmbPais.Text & "' AND Estado.nombre = '" & FormColonia.cmbEstado.Text & "' AND Ciudad.nombre = '" & FormColonia.cmbCiudad.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
End Class
