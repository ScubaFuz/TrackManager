Module sec
    Friend LicensedName As String = "Thicor Services Demo License"
    Friend MajorVersion As Integer = 1
    Friend ExpiryDate As Date = "2015-01-01"
    'Friend ApplicationName As String = "Sequenchel"
    Friend blnLicensedName As Boolean = True
    Friend blnMajorVersion As Boolean = True
    Friend blnExpiryDate As Boolean = False
    Friend blnLicenseValidated = False

    Private ReadOnly _strKeyCharacters As String = "AB2C7DE3FGHJ4KL8MNP5QRSTUV96WXYZ"

    Private ReadOnly Property strKeyCharacters() As String
        Get
            Return _strKeyCharacters
        End Get
    End Property

    Private Function KeyAlgorythm(ByVal strInput As String) As String
        Dim intStringLenght As Integer
        Dim intCharacter As Integer
        Dim intKeyValue As Integer
        Dim strNextKey As String
        Dim strLicenseKey As String = ""
        Dim intCharCount As Integer = 0

        intStringLenght = Len(strInput)

        For intCharCount = 1 To intStringLenght
            intCharacter = Asc(Mid(strInput, intCharCount, 1))
            intKeyValue += intCharacter
        Next
        intKeyValue += intStringLenght
        intCharCount = 0

        Do While Len(strLicenseKey) < 29
            Do While intKeyValue > Len(strKeyCharacters)
                intKeyValue -= Len(strKeyCharacters)
            Loop
            strNextKey = Mid(strKeyCharacters, intKeyValue, 1)
            strLicenseKey &= strNextKey
            If Len(strLicenseKey) = 5 Or Len(strLicenseKey) = 11 Or Len(strLicenseKey) = 17 Or Len(strLicenseKey) = 23 Then
                strLicenseKey &= "-"
            End If
            For intCharCount = 1 To Len(strLicenseKey)
                intKeyValue = intKeyValue + Asc(Mid(strLicenseKey, intCharCount, 1))
            Next
        Loop
        KeyAlgorythm = strLicenseKey
    End Function

    Friend Function CheckLicenseKey(ByVal strLicenseKey As String, Optional ByVal strLicensedName As String = "Thicor Services Demo License", Optional ByVal intMajorVersion As Integer = 1, Optional ByVal datExpiryDate As Date = Nothing) As Boolean
        Dim strLicenseText As String = ""
        If blnMajorVersion = True Then strLicenseText &= intMajorVersion
        If blnExpiryDate = True And datExpiryDate = Nothing Then Return False
        If blnExpiryDate = True And datExpiryDate <> Nothing Then strLicenseText &= datExpiryDate.Year & datExpiryDate.Month & datExpiryDate.Day
        If blnLicensedName = True Then strLicenseText &= strLicensedName
        If strLicenseText.Length = 0 Then strLicenseText = "Thicor Services Demo License"
        If strLicenseKey = KeyAlgorythm(strLicenseText) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
