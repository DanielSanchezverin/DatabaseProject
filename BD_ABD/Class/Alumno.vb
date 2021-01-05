Imports Oracle.DataAccess.Client
Public Class Alumno
    Private noControl As String
    Private idCarrera As Integer
    Private idCivil As Integer
    Private idGenero As Integer
    Private idColonia As Integer
    Private nombre As String
    Private paterno As String
    Private materno As String

    Public Sub New()
        Me.noControl = ""
        Me.idCarrera = 0
        Me.idCivil = 0
        Me.idGenero = 0
        Me.idColonia = 0
        Me.nombre = ""
        Me.paterno = ""
        Me.materno = ""
    End Sub
    Public Sub New(noControl As String, idCarrera As Integer, idCivil As Integer, idGenero As Integer, idColonia As Integer, nombre As String, paterno As String, materno As String)
        Me.noControl = noControl
        Me.idCarrera = idCarrera
        Me.idCivil = idCivil
        Me.idGenero = idGenero
        Me.idColonia = idColonia
        Me.nombre = nombre
        Me.paterno = paterno
        Me.materno = materno
    End Sub
    Public Property getSetNoControl() As String
        Get
            Return noControl
        End Get
        Set(value As String)
            noControl = value
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

    Public Property getSetIdCivil() As Integer
        Get
            Return idCivil
        End Get
        Set(value As Integer)
            idCivil = value
        End Set
    End Property

    Public Property getSetIdGenero() As Integer
        Get
            Return idGenero
        End Get
        Set(value As Integer)
            idGenero = value
        End Set
    End Property

    Public Property getSetIdColonia() As Integer
        Get
            Return idColonia
        End Get
        Set(value As Integer)
            idColonia = value
        End Set
    End Property

    Public Property getSetNombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property getSetPaterno() As String
        Get
            Return paterno
        End Get
        Set(value As String)
            paterno = value
        End Set
    End Property

    Public Property getSetMaterno() As String
        Get
            Return materno
        End Get
        Set(value As String)
            materno = value
        End Set
    End Property
    Public Sub insert()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idCarrera <> 0 And idCivil <> 0 And idGenero <> 0 And idColonia <> 0 And nombre <> "" And paterno <> "" And materno <> "" Then
            query = "INSERT INTO Alumno VALUES('" & noControl & "', " & idCarrera & ", " & idCivil & ", " & idGenero & ", " & idColonia & ", '" & nombre & "', '" & paterno & "', 
                    '" & materno & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idCarrera <> 0 And idCivil <> 0 And idGenero <> 0 And idColonia <> 0 And nombre <> "" And nombre <> "" And paterno <> "" And materno <> "" Then
            query = "UPDATE Alumno SET nombre = '" & nombre & "', paterno = '" & paterno & "', materno = '" & materno & "' WHERE idCarrera = " & idCarrera & "AND idCivil = " & idCivil &
                " AND idGenero = " & idGenero & " AND idColonia = " & idColonia & " AND noControl = '" & noControl & "'"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idCarrera <> 0 And idCivil <> 0 And idGenero <> 0 And idColonia <> 0 And nombre <> "" And nombre <> "" And paterno <> "" And materno <> "" Then
            query = "DELETE FROM Alumno WHERE idCarrera = " & idCarrera & "AND idCivil = " & idCivil & " AND idGenero = " & idGenero & " AND idColonia = " & idColonia &
                    " AND noControl = '" & noControl & "'"
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
        query = "Select * FROM CargaMateria WHERE noControl = '" & noControl & "'"
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
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "Select Alumno.noControl
            From Alumno
            INNER Join Carrera ON Alumno.idCarrera = Carrera.idCarrera
            And Carrera.nombre = '" & FormAlumno.cmbCarrera.Text & "'
            INNER Join EstadoCivil ON Alumno.idCivil = EstadoCivil.idCivil
            And EstadoCivil.nombre = '" & FormAlumno.cmbEdoCivil.Text & "'
            INNER Join Genero ON Alumno.idGenero = Genero.idGenero
            And Genero.nombre = '" & FormAlumno.cmbGenero.Text & "'
            INNER Join Colonia ON Alumno.idColonia = Colonia.idColonia
            And Colonia.nombre = '" & FormAlumno.cmbColonia.Text & "'
            INNER Join Ciudad ON Colonia.idCiudad = Ciudad.idCiudad
            And Ciudad.nombre = '" & FormAlumno.cmbCiudad.Text & "'
            INNER Join Estado ON Ciudad.idEstado = Estado.idEstado
            And Estado.nombre = '" & FormAlumno.cmbEstado.Text & "'
            INNER Join Pais ON Estado.idPais = Pais.idPais
            And Pais.nombre = '" & FormAlumno.cmbPais.Text & "'
            WHERE Alumno.noControl = '" & FormAlumno.cmbNoControl.Text & "'"
        '"SELECT * FROM Alumno WHERE noControl = '" & noControl & "' AND idCarrera = " & idCarrera & " AND idCivil = " & idCivil & " AND idGenero = " & idGenero &
        '    " AND idColonia = " & idColonia & " AND nombre = '" & nombre & "' AND paterno = '" & paterno & "' AND materno = '" & materno & "'"
        '"SELECT * FROM Alumno WHERE noControl = '" & noControl & "' AND idCarrera = " & idCarrera & " AND idCivil = " & idCivil & " AND idGenero = " & idGenero & " AND idColonia = " & idColonia
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
        query = "SELECT * FROM Alumno WHERE noControl = '" & noControl & "'"
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("noControl"))
            End If
            consultarID = True
        End If
    End Function
    Public Sub consultarID2()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Alumno.noControl AS ""No Control"", Carrera.nombre AS Carrera, EstadoCivil.nombre AS ""Estado Civil"", Genero.nombre AS Genero, Colonia.nombre AS Colonia, 
	            Ciudad.nombre AS Ciudad, Estado.nombre AS Estado, Pais.nombre AS Pais, Alumno.nombre AS Nombre, Alumno.paterno AS Paterno, Alumno.materno AS Materno
                FROM Alumno
                INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
                INNER JOIN EstadoCivil ON Alumno.idCivil = EstadoCivil.idCivil
                INNER JOIN Genero ON Alumno.idGenero = Genero.idGenero
                INNER JOIN Colonia ON Alumno.idColonia = Colonia.idColonia
                INNER JOIN Ciudad ON Colonia.idCiudad = Ciudad.idCiudad
                INNER JOIN Estado ON Ciudad.idEstado = Estado.idEstado
                INNER JOIN Pais ON Estado.idPais = Pais.idPais
		        WHERE Alumno.noControl = '" & FormAlumno.cmbNoControl.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("No Control")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("No Control"))
                FormAlumno.cmbCarrera.Text = CStr(dt.Rows(0)("Carrera"))
                FormAlumno.cmbEdoCivil.Text = CStr(dt.Rows(0)("Estado Civil"))
                FormAlumno.cmbGenero.Text = CStr(dt.Rows(0)("Genero"))
                FormAlumno.cmbColonia.Text = CStr(dt.Rows(0)("Colonia"))
                FormAlumno.cmbCiudad.Text = CStr(dt.Rows(0)("Ciudad"))
                FormAlumno.cmbEstado.Text = CStr(dt.Rows(0)("Estado"))
                FormAlumno.cmbPais.Text = CStr(dt.Rows(0)("Pais"))
                FormAlumno.txtNombre.Text = CStr(dt.Rows(0)("Nombre"))
                FormAlumno.txtPaterno.Text = CStr(dt.Rows(0)("Paterno"))
                FormAlumno.txtMaterno.Text = CStr(dt.Rows(0)("Materno"))
            End If
        End If
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT Alumno.noControl AS ""No Control"", Carrera.nombre AS Carrera, EstadoCivil.nombre AS ""Estado Civil"", Genero.nombre AS Genero, Colonia.nombre AS Colonia, 
	            Ciudad.nombre AS Ciudad, Estado.nombre AS Estado, Pais.nombre AS Pais, Alumno.nombre AS Nombre, Alumno.paterno AS Paterno, Alumno.materno AS Materno
                FROM Alumno
                INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
                INNER JOIN EstadoCivil ON Alumno.idCivil = EstadoCivil.idCivil
                INNER JOIN Genero ON Alumno.idGenero = Genero.idGenero
                INNER JOIN Colonia ON Alumno.idColonia = Colonia.idColonia
                INNER JOIN Ciudad ON Colonia.idCiudad = Ciudad.idCiudad
                INNER JOIN Estado ON Ciudad.idEstado = Estado.idEstado
                INNER JOIN Pais ON Estado.idPais = Pais.idPais
                ORDER BY Alumno.noControl"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 60
        dgv.Columns.Item(1).Width = 100
        dgv.Columns.Item(2).Width = 60
        dgv.Columns.Item(3).Width = 60
        dgv.Columns.Item(4).Width = 100
        dgv.Columns.Item(5).Width = 60
        dgv.Columns.Item(6).Width = 60
        dgv.Columns.Item(7).Width = 60
        dgv.Columns.Item(8).Width = 100
        dgv.Columns.Item(9).Width = 100
        dgv.Columns.Item(10).Width = 100
    End Sub
    Public Function consultaIdCarrera() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT  idCarrera FROM Carrera WHERE nombre = '" & FormAlumno.cmbCarrera.Text & "'"
        '"SELECT Carrera.idCarrera FROM Carrera, Alumno WHERE Carrera.idCarrera = Alumno.idCarrera AND Carrera.nombre = '" & FormAlumno.cmbCarrera.Text & "' 
        '    AND Alumno.noControl = '" & FormAlumno.txtNoControl.Text & "'"
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
    Public Function consultaIdCivil() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idCivil FROM EstadoCivil WHERE nombre = '" & FormAlumno.cmbEdoCivil.Text & "'"
        '"SELECT EstadoCivil.idCivil FROM EstadoCivil, Alumno WHERE EstadoCivil.idCivil = Alumno.idCivil AND EstadoCivil.nombre = '" & FormAlumno.cmbEdoCivil.Text & "' 
        '    AND Alumno.noControl = '" & FormAlumno.txtNoControl.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCivil")) Then
                idCivil = 0
            Else
                idCivil = CStr(dt.Rows(0)("idCivil"))
            End If
        End If
        Return idCivil
    End Function
    Public Function consultaIdGenero() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idGenero FROM Genero WHERE nombre = '" & FormAlumno.cmbGenero.Text & "'"
        '"SELECT Genero.idGenero FROM Genero, Alumno WHERE Genero.idGenero = Alumno.idGenero AND Genero.nombre = '" & FormAlumno.cmbGenero.Text & "' AND Alumno.noControl = '" &
        '        FormAlumno.txtNoControl.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idGenero")) Then
                idGenero = 0
            Else
                idGenero = CStr(dt.Rows(0)("idGenero"))
            End If
        End If
        Return idGenero
    End Function
    Public Function consultaIdColonia() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Colonia.idColonia FROM Pais, Estado, Ciudad, Colonia
                WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = Colonia.idCiudad AND
                Pais.nombre = '" & FormAlumno.cmbPais.Text & "' AND Estado.nombre = '" & FormAlumno.cmbEstado.Text & "' AND Ciudad.nombre = '" & FormAlumno.cmbCiudad.Text & "'
                AND Colonia.nombre = '" & FormAlumno.cmbColonia.Text & "'"
        '"SELECT Colonia.idColonia FROM Pais, Estado, Ciudad, Colonia, Alumno
        '    WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Ciudad.idCiudad = Colonia.idCiudad AND Colonia.idColonia = Alumno.idColonia
        '    AND Pais.nombre = '" & FormAlumno.cmbPais.Text & "' AND Estado.nombre = '" & FormAlumno.cmbEstado.Text & "' AND Ciudad.nombre = '" & FormAlumno.cmbCiudad.Text & "'
        '    AND Colonia.nombre = '" & FormAlumno.cmbColonia.Text & "' AND Alumno.noControl = '" & FormAlumno.txtNoControl.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idColonia")) Then
                idColonia = 0
            Else
                idColonia = CStr(dt.Rows(0)("idColonia"))
            End If
        End If
        Return idColonia
    End Function

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
    Public Sub comboEstadoCivil(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM EstadoCivil"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboGenero(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM Genero"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
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
        query = "SELECT Estado.nombre FROM Pais, Estado WHERE Pais.idPais = Estado.idPais AND Pais.nombre = '" & FormAlumno.cmbPais.Text & "'"
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
        query = "SELECT Ciudad.nombre FROM Pais, Estado, Ciudad WHERE Pais.idPais = Estado.idPais AND Estado.idEstado = Ciudad.idEstado AND Pais.nombre = '" & FormAlumno.cmbPais.Text &
                "' AND Estado.nombre = '" & FormAlumno.cmbEstado.Text & "'"
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
                AND Pais.nombre = '" & FormAlumno.cmbPais.Text & "' AND Estado.nombre = '" & FormAlumno.cmbEstado.Text & "' AND Ciudad.nombre = '" & FormAlumno.cmbCiudad.Text & "'"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub combonoControl(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT noControl from Alumno"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
End Class
