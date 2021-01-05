Imports Oracle.DataAccess.Client
Public Class MateriaPorCarrera
    Private idMateria As Integer
    Private idCarrera As Integer
    Private nombre As String
    Public Sub New()
        Me.idCarrera = 0
        Me.nombre = ""
    End Sub
    Public Sub New(idMateria As Integer, idCarrera As Integer, nombre As String)
        Me.idMateria = idMateria
        Me.idCarrera = idCarrera
        Me.nombre = nombre
    End Sub
    Public Property getSetIdMateria() As Integer
        Get
            Return idMateria
        End Get
        Set(value As Integer)
            idMateria = value
        End Set
    End Property
    Public Property getSetIdCarrera() As Integer
        Get
            Return idCarrera
        End Get
        Set(value As Integer)
            idCarrera = value
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
        If idMateria <> 0 And idCarrera <> 0 And nombre <> "" Then
            query = "INSERT INTO MateriaPorCarrera VALUES(" & idMateria & ", " & idCarrera & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idMateria <> 0 And idCarrera <> 0 And nombre <> "" Then
            query = "UPDATE MateriaPorCarrera set descripcion = '" & nombre & "' WHERE idCarrera = " & idCarrera & " AND idMateria = " & idMateria
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idMateria <> 0 And idCarrera <> 0 Then
            query = "DELETE FROM MateriaPorCarrera WHERE idCarrera = " & idCarrera & " AND idMateria = " & idMateria
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
        query = "Select * FROM CargaMateria WHERE idCarrera = " & idCarrera & " AND idMateria = " & idMateria
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CInt(dataT.Rows(0)("idMateria"))
            End If
            validacion = True
        End If
    End Function
    Sub consultarID()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "SELECT MateriaPorCarrera.idMateria AS ""Id Materia"", Carrera.nombre AS ""Carrera"", MateriaPorCarrera.descripcion AS Materia 
                FROM Carrera, MateriaPorCarrera WHERE Carrera.idCarrera = MateriaPorCarrera.idCarrera AND idMateria = " & FormMateriaPorCarrera.txtIdMateria.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("Id Materia")) Then
                idMateria = 0
            Else
                idMateria = CInt(dataT.Rows(0)("Id Materia"))
                FormMateriaPorCarrera.cmbCarrera.Text = CStr(dataT.Rows(0)("Carrera"))
                FormMateriaPorCarrera.cmbNombre.Text = CStr(dataT.Rows(0)("Materia"))
            End If
        End If
    End Sub
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM MateriaPorCarrera WHERE idCarrera = " & idCarrera & " AND idMateria = " & idMateria
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CStr(dt.Rows(0)("idMateria"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT MateriaPorCarrera.idMateria AS ""Id Materia"", Carrera.nombre AS ""Carrera"", MateriaPorCarrera.descripcion AS Materia 
                FROM Carrera, MateriaPorCarrera WHERE Carrera.idCarrera = MateriaPorCarrera.idCarrera ORDER BY MateriaPorCarrera.idMateria"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 115
        dgv.Columns.Item(1).Width = 200
        dgv.Columns.Item(2).Width = 200
    End Sub
    Public Sub comboCarrera(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM Carrera"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboMateria(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT MateriaPorCarrera.descripcion FROM Carrera, MateriaPorCarrera WHERE Carrera.idCarrera = MateriaPorCarrera.idCarrera AND Carrera.nombre = '" &
                FormMateriaPorCarrera.cmbCarrera.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Function consultaIdCarrera() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idCarrera FROM Carrera WHERE nombre = '" & FormMateriaPorCarrera.cmbCarrera.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCarrera")) Then
                idCarrera = 0
            Else
                idCarrera = CStr(dt.Rows(0)("idCarrera"))
            End If
        End If
        Return idCarrera
    End Function
End Class