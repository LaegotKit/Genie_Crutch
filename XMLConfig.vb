Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.XPath
Imports System.IO

Public Class XMLConfig
    Private _configFile As XmlDocument
    Private _host As GeniePlugin.Interfaces.IHost
    Private _plugin As GeniePlugin.Interfaces.IPlugin
    Private _configName As String
    Private _fileName As String
    Private _filePath As String
    Private _fullPath As String

    Public Sub New(ByVal Host As GeniePlugin.Interfaces.IHost, ByVal PlugIn As GeniePlugin.Interfaces.IPlugin)
        _host = Host
        _plugin = PlugIn
        _configFile = New XmlDocument()
        _configName = _plugin.Name.Replace(" ", "_")
        _fileName = _configName & ".xml"
    End Sub
    Public Sub SetPath()
        If Not IsNothing(_host) Then
            _filePath = _host.Variable("PluginPath")
        End If

        ' Fix for Genie versions previous to 3.2
        If IsNothing(_filePath) OrElse _filePath.Length = 0 Then
            _filePath = Application.StartupPath & "\Plugins\"
        End If

        If Not _filePath.EndsWith("\") Then
            _filePath += "\"
        End If

        _fullPath = _filePath + _fileName
    End Sub

    Public Sub SaveConfig()
        If _configFile Is Nothing Then
            Exit Sub
        End If
        Try
            _configFile.Save(_fullPath)
        Catch ex As Exception
            _host.EchoText((_plugin.Name & ".SaveConfig: ") + ex.Message & vbLf)
        End Try
    End Sub

    Public Sub OpenConfig()
        If IsNothing(_fullPath) Then
            Exit Sub
        End If

        If _configFile Is Nothing Then
            _configFile = New XmlDocument()
        End If

        Try
            _configFile.Load(_fullPath)
        Catch ex As Exception
            If Directory.Exists(_filePath) Then
                'Any number of problems, but we'll just build a new file. 
                _configFile = New XmlDocument()
                _configFile.AppendChild(_configFile.CreateXmlDeclaration("1.0", Nothing, Nothing))
                _configFile.AppendChild(_configFile.CreateElement(_configName))
            Else
                _host.EchoText((_plugin.Name & ".OpenConfig: ") + _filePath & " is not a valid path." & vbLf)
            End If
        End Try
    End Sub
    'OpenConfig 
#Region "GetSectionList"
    Public Function GetSectionList() As Dictionary(Of String, String)
        Return GetSectionList("")
    End Function

    Public Function GetSectionList(ByVal sectionName As String) As Dictionary(Of String, String)
        Dim retVal As New Dictionary(Of String, String)()
        Dim nav As XPathNavigator
        Dim iter As XPathNodeIterator
        If _configFile Is Nothing Then
            Return Nothing
        End If

        If sectionName <> String.Empty Then
            sectionName += "/"
        Else
            sectionName = "/" & _configName & "/"
        End If
        Try
            nav = DirectCast(_configFile, IXPathNavigable).CreateNavigator()
            iter = nav.[Select](sectionName & "*")

            While iter.MoveNext()
                If iter.Current.IsNode Then
                    retVal.Add(iter.Current.Name, sectionName + iter.Current.Name)
                End If
            End While
        Catch ex As Exception
            _host.EchoText((_plugin.Name & ".GetSectionList: ") + ex.Message & vbLf)
            Return Nothing
        End Try
        Return retVal
    End Function
#End Region

    Public Function GetSection(ByVal sectionName As String) As XmlNode
        Return GetKey(("/" & _configName & "/") + sectionName)
    End Function

#Region "GetKey"
    Public Function GetKey(ByVal sectionName As String, ByVal keyName As String) As XmlNode
        Return GetKey(GetSection(sectionName), keyName)
    End Function

    Public Function GetKey(ByVal keyName As String) As XmlNode
        If _configFile Is Nothing Then
            Return Nothing
        End If
        Return _configFile.SelectSingleNode(keyName)
    End Function

    Public Function GetKey(ByVal node As XmlNode, ByVal keyName As String) As XmlNode
        Return node.SelectSingleNode(keyName)
    End Function
#End Region

#Region "GetKeyValue"
    Public Function GetKeyValue(ByVal sectionName As String, ByVal keyName As String, ByVal defValue As String) As String
        Dim node As XmlNode
        node = GetKey(sectionName, keyName)
        If node IsNot Nothing Then
            Return GetKeyValue(node, defValue)
        Else
            Return defValue
        End If
    End Function

    Public Function GetKeyValue(ByVal Key As XmlNode, ByVal defValue As String) As String
        Try
            Return Key.InnerText
        Catch
            Return defValue
        End Try
    End Function
    Public Function GetKeyValue(ByVal Section As XmlNode, ByVal keyName As String, ByVal defValue As String) As String
        Try
            Return Section.SelectSingleNode(keyName).InnerText
        Catch
            Return defValue
        End Try
    End Function
    Public Function GetKeyValue(ByVal Key As String, ByVal defValue As String) As String
        Try
            Return _configFile.SelectSingleNode(Key).InnerText
        Catch
            Return defValue
        End Try
    End Function
#End Region

#Region "SetKeyValue"
    Public Sub SetKeyValue(ByVal Section As XmlNode, ByVal key As String, ByVal Value As String)
        Dim node As XmlNode
        Dim element As XmlElement
        Try
            node = Section.SelectSingleNode(key)
            node.InnerText = Value
        Catch ex As Exception
            If _configFile IsNot Nothing Then
                element = _configFile.CreateElement(key)
                Section.AppendChild(element)
                element.AppendChild(_configFile.CreateTextNode(Value))
            End If

        End Try
    End Sub
    Public Sub SetKeyValue(ByVal Key As String, ByVal Value As String)
        Dim node As XmlNode
        Dim element As XmlElement
        Try
            node = _configFile.SelectSingleNode(Key)
            node.InnerText = Value
        Catch ex As Exception
            If _configFile IsNot Nothing Then
                element = _configFile.CreateElement(Key)
                element.AppendChild(_configFile.CreateTextNode(Value))
            End If
        End Try
    End Sub
#End Region

    Public Sub SetAttribute(ByVal node As XmlNode, ByVal attribute As String, ByVal value As String)
        Dim nodeAtt As XmlAttribute
        nodeAtt = _configFile.CreateAttribute(attribute)
        nodeAtt.Value = value
        DirectCast(node, XmlElement).SetAttributeNode(nodeAtt)
    End Sub

    Public Function GetAttribute(ByVal node As XmlNode, ByVal attribute As String) As String
        Return node.Attributes(attribute).Value
    End Function

    Public Function AddSection(ByVal sectionName As String) As XmlNode
        Dim node As XmlNode
        node = _configFile.CreateElement(sectionName)
        _configFile.SelectSingleNode(_configName).AppendChild(node)
        Return node
    End Function

    Public Function GetComplexKey(ByVal Section As XmlNode, ByVal key As String, ByVal name As String) As XmlNode
        Return Section.SelectSingleNode((key & "[@name='") + name & "']")
    End Function

    Public Function AddComplexKey(ByVal Section As XmlNode, ByVal key As String, ByVal name As String, ByVal attributes As Dictionary(Of String, String)) As XmlNode
        Dim node As XmlNode
        Dim attr As XmlAttribute
        node = _configFile.CreateElement(key)

        attr = _configFile.CreateAttribute("name")
        attr.Value = name
        DirectCast(node, XmlElement).SetAttributeNode(attr)
        For Each s As String In attributes.Keys
            attr = _configFile.CreateAttribute(s)
            attr.Value = attributes(s)
            DirectCast(node, XmlElement).SetAttributeNode(attr)
        Next

        Section.AppendChild(node)
        Return node
    End Function

End Class
