﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    'à l'aide d'un outil, tel que ResGen ou Visual Studio.
    'Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    'avec l'option /str ou régénérez votre projet VS.
    '''<summary>
    '''  Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("MAP.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Remplace la propriété CurrentUICulture du thread actuel pour toutes
        '''  les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property hardware_infos() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("hardware_infos", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Icon semblable à (Icône).
        '''</summary>
        Friend ReadOnly Property map_icon() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("map_icon", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property music_player() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("music_player", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Icon semblable à (Icône).
        '''</summary>
        Friend ReadOnly Property music_player_icn() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("music_player_icn", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PlayMode_Normal() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayMode_Normal", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PlayMode_Repeat() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayMode_Repeat", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PlayMode_Repeat_one() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayMode_Repeat_one", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une ressource localisée de type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PlayMode_Shuffle() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayMode_Shuffle", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
