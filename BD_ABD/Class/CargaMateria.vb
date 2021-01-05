Imports Oracle.DataAccess.Client
Public Class CargaMateria
    Private noControl As String
    Private idMateria As Integer
    Private idCarrera As Integer

    Public Sub New()
        Me.noControl = ""
        Me.idMateria = 0
        Me.idCarrera = 0
    End Sub

    Public Sub New(noControl As String, idMateria As Integer, idCarrera As Integer)
        Me.noControl = noControl
        Me.idMateria = idMateria
        Me.idCarrera = idCarrera
    End Sub

    Public Property getSetNoControl As String
        Get
            Return noControl
        End Get
        Set(value As String)
            noControl = value
        End Set
    End Property

    Public Property getSetIdMateria As Integer
        Get
            Return idMateria
        End Get
        Set(value As Integer)
            idMateria = value
        End Set
    End Property

    Public Property getSetIdCarrera As Integer
        Get
            Return idCarrera
        End Get
        Set(value As Integer)
            idCarrera = value
        End Set
    End Property

    Public Sub insert()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 Then
            query = "INSERT INTO CargaMateria VALUES ('" & noControl & "', " & idMateria & ", " & idCarrera & ")"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 Then
            query = "Update CargaMateria SET idMateria = " & idMateria & " WHERE noControl = '" & noControl & "' AND idCarrera = " & idCarrera & " 
                    AND idMateria = " & idMateria
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 Then
            query = "DELETE FROM CargaMateria WHERE noControl = '" & noControl & "' AND idMateria = " & idMateria & " AND idCarrera = " & idCarrera
            conOracle.objetoCommand(query)
            MessageBox.Show("Registro Eliminado")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub

    Public Function consultaIdMateria() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idMateria FROM MateriaPorCarrera WHERE descripcion = '" & FormCargaMateria.cmbMateria.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CStr(dt.Rows(0)("idMateria"))
            End If
        End If
        Return idMateria
    End Function
    Public Function consultaIdCarrera() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idCarrera FROM Carrera WHERE nombre = '" & FormCargaMateria.cmbCarrera.Text & "'"
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

    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM CargaMateria WHERE noControl = '" & noControl & "' AND idMateria = " & idMateria &
                    " AND idCarrera = " & idCarrera
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("noControl"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarID() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT noControl, idCarrera FROM Alumno WHERE noControl = '" & noControl & "' AND idCarrera = " & idCarrera
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("noControl"))
                idCarrera = CInt(dt.Rows(0)("idCarrera"))
            End If
            consultarID = True
        End If
    End Function
    Public Function consultarID2() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idMateria, idCarrera FROM MateriaPorCarrera WHERE idMateria = " & idMateria & " AND idCarrera = " & idCarrera
        consultarID2 = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CStr(dt.Rows(0)("idMateria"))
                idCarrera = CInt(dt.Rows(0)("idCarrera"))
            End If
            consultarID2 = True
        End If
    End Function
    Public Sub consultarID3()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Alumno.noControl AS ""No Control"", Carrera.nombre AS Carrera
            FROM CargaMateria 
            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
            WHERE Alumno.noControl = '" & FormCargaMateria.cmbNoControl.Text & "'
            GROUP BY Alumno.noControl, Carrera.nombre"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("No Control")) Then
                noControl = 0
            Else
                FormCargaMateria.cmbCarrera.Text = CStr(dt.Rows(0)("Carrera"))
            End If
        End If
    End Sub
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "SELECT * FROM Calificacion WHERE noControl = '" & FormCargaMateria.cmbNoControl.Text & "' AND idMateria = " & idMateria & " AND idCarrera = " & idCarrera
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CInt(dataT.Rows(0)("noControl"))
            End If
            validacion = True
        End If
    End Function

    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Alumno.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, Carrera.nombre AS Carrera
            FROM CargaMateria 
            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
            ORDER BY Alumno.noControl"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub comboNoControl(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT noControl FROM Alumno
                    INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
                    WHERE Carrera.nombre = '" & FormCargaMateria.cmbCarrera.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
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
        query = "SELECT descripcion FROM MateriaPorCarrera, Carrera
            WHERE Carrera.idCarrera = MateriaPorCarrera.idCarrera
            AND Carrera.nombre = '" & FormCargaMateria.cmbCarrera.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(1).Width = 200
        dgv.Columns.Item(2).Width = 195
    End Sub
End Class
