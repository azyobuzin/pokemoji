Imports System.IO
Imports System.Xml.Serialization

Public Class settings
    Private Sub New()
    End Sub

    Public Shared ReadOnly settingsFile As String = Application.StartupPath & "\settings.xml"

    Public Shared ReadOnly Property Instance() As settings
        Get
            Static _instance As settings
            If _instance Is Nothing Then
                Try
                    Using sr As New StreamReader(settingsFile)
                        Dim xs As New XmlSerializer(GetType(settings))
                        _instance = xs.Deserialize(sr)
                        sr.Close()
                    End Using
                Catch ex As Exception
                    MsgBox("設定が読み込めませんでした。" & vbNewLine & "既定の設定で続行します。", MsgBoxStyle.Exclamation, "ポケット文字チェッカー - エラー")
                    _instance = New settings
                    _instance.font = New xmlFont With {.name = "ＭＳ ゴシック", .size = 72.0F}
                    _instance.size = New Size(284, 130)
                End Try
            End If
            Return _instance
        End Get
    End Property

    Public font As xmlFont
    Public size As Size

    Public Shared Sub Save()
        Using sw As New StreamWriter(settingsFile)
            Dim xs As New XmlSerializer(GetType(settings))
            xs.Serialize(sw, Instance)
            sw.Close()
        End Using
    End Sub
End Class

<System.Serializable()> Public Structure xmlFont
    Public name As String
    Public size As Single

    Public Function ToFont() As Font
        Return New Font(name, size, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
    End Function
End Structure
