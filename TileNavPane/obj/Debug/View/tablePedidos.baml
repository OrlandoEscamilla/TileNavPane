   M S B A M L   `   `   `  ����F  BTileNavPane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TileNavPane.ViewTileNavPane.View  5
      3clr-namespace:TileNavPane.ViewTileNavPane.View  5      #    TileNavPane.View.tablePedidos   5      a ]DevExpress.Xpf.Core.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ] YDevExpress.Mvvm.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      )viewclr-namespace:TileNavPane.View  5
      *localclr-namespace:TileNavPane.View  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6;   2  ,DevExpress.Mvvm.UI.Interactivity.Interaction    	Behaviors  5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -   5          Name$ 	AlertaDlg��5   !   '  !DevExpress.Xpf.Core.DialogService  5   
   -   5          Name$ OrdenDlg��5      "   DialogWindowStartupLocation$ CenterOwner=�6-   (  "DevExpress.Mvvm.UI.ViewServiceBase   ViewTemplate 5      �� 5      .R�5         TileNavPane.View.Orden  5         DialogStyle 5      �� 5       �� 
TargetType(  "DevExpress.Xpf.Core.DXDialogWindow"  6   .�5      ��  �� Property �@�SizeToContent �� Value$ WidthAndHeight=�66   5      5      .��5%      $  DevExpress.Xpf.Bars.BarManager  	   Items	 5&   
   '  !DevExpress.Xpf.Bars.BarButtonItem  5'      -   5        
  Name$
 BarItemGuardar��5'       !	  DevExpress.Xpf.Bars.BarItem 	  BarItemDisplayMode$ ContentAndGlyph=�6d    	  Command 68   �� *RefrescarPedidosCommand+��5(      �� 5)      "  6   .�5*      ��  �@	 Content)
  #DevExpress.Xpf.Core.ObjectConverter$ Recargar Pedidos
 64   �� 5+       �@	 
LargeGlyph 67   ��  �� Source *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Recurrence_32x32.png  �� Triggers 5,      ^� 5-       ^� 
Conditions 5.   "   �� 5/   &    �� Binding 60   �� *Id_Servicio+ �� Value 336P   �� 50   &    60   �� *Id_Solicitud+ 06Q   .0�52   "   ��  �@	 Content$ Generar Solicitudes
 6<   �� 53   "    �@	 
LargeGlyph 6?   ��    $ SavePageSetup_32x32.png 54      56      58        5:      -   5        $
 BotonEditarPedido��5:        � ToolTip$ Editar Pedido��6;    	  Content$ Editar Pedido
 6�   $ ContentAndGlyph=�6�    6S   �� *EditarPedidoCommand+ 	  CommandParameter 6{   ��  �� ElementName$ 	gcPedidos�� �� Path$ SelectedItem� 	  
LargeGlyph 6�     $ EditTask_32x32.png  	  Glyph 63    $ EditTask_32x32.png   5<      -   5        $
 BotonEnElaboracion��5<       $ Marcar en elaboración��6<   $ Marcar en Elaboración
 6�   $ ContentAndGlyph=�6�    6\   �� *EnProcesoCommand+ 6�   �� $ 	gcPedidos��$ SelectedItem� 6    $ HandTool_32x32.png  6A    $ HandToo_16x16.png   5>      -   5        $
 BotonTerminado��5>       $ Pasar a terminar pedido��68   $ Terminar Pedido
 6�   $ ContentAndGlyph=�6�    6Z   �� *TerminarPedidoCommand+ 6�   �� $ 	gcPedidos��$ SelectedItem� 6	    $ BO_Validation_32x32.png  6C    $ BO_Validation_16x16.png   5@      -   5        $
 BarItemCerrar��5@       $ Cancelar Pedido��67   $ Cancelar Pedido
 6�   $ ContentAndGlyph=�6�    6Q   �� *CancelarPedidoCommand+ 6{   �� $ 	gcPedidos��$ SelectedItem� 6     $ Delete_32x32.png  61    $ Delete_32x32.png   5B      -   5        $
 btnHelp��5B       $ 1��6Q    61   �� *HelpCommand+6Q      Bars 5F   
     DevExpress.Xpf.Bars.Bar  5G         Caption$
 bar1��6      AllowCustomizationMenu .     AllowQuickCustomization]	 YDevExpress.Data.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6D      	AllowHide$ False 6d      UseWholeRow$
 True 6v       DockInfo  5H      %  DevExpress.Xpf.Bars.BarDockInfo  5I      !   ContainerType$	! Top=�6&   /  )DevExpress.Xpf.Bars.BarItemLinkHolderBase"   Items." 5K      %  DevExpress.Xpf.Bars.BarItemLink  )  #DevExpress.Xpf.Bars.BarItemLinkBase#   BarItemName$# BarItemGuardar��6"     5L      $# BotonEditarPedido��6"     5M      $# BotonEnElaboracion��6"     5N      $# BotonTerminado��6"     5O      $# BarItemCerrar��6"   +  %DevExpress.Xpf.Bars.BarButtonItemLink  5P      $# btnHelp��6(   $   	Alignment$	$ Far=�6>   %   RibbonStyle$% SmallWithoutText=�6N   5Q      ._�5W   
   � .+�5X      %  DevExpress.Xpf.Grid.GridControl  -	   5        &  Name$& 	gcPedidos��5X   A   $	��540��6T   $
��auto��6a   $
��10,0q�6n   '   AutoExpandAllGroups' . )  #DevExpress.Xpf.Grid.DataControlBase(   ItemsSource( 6   �� *
DataSource+)   Columns) 5Y      $  DevExpress.Xpf.Grid.GridColumn  5Z      $  DevExpress.Xpf.Grid.ColumnBase*   	FieldName$* 	ID_PEDIDO��6%   $  DevExpress.Xpf.Grid.BaseColumn+   Header$+ 	ID_PEDIDO
 6;   ,   ReadOnly, . 6N     5[      $* USUARIO_CAPTURA��6%   $+ CAPTURADO POR
 6A   , . 6X     5\      $* 
FECHA_HORA��6%   $+ 
FECHA_HORA
 6<   , . -   CellTemplate- 5]      �� 5^      .R�5_   "   %  DevExpress.Xpf.Editors.TextEdit  $��PART_Editor��6/   %  DevExpress.Xpf.Editors.BaseEdit.   DisplayFormatString$. dd/MM/yyyy HH:mm:ss��6B   5`      5b        5c      $* ESTATUS��6%   $+ ESTATUS
 69   , . /   
GroupIndex$/ 1��6Z     5d      $* PARA_LLEVAR��6%   $+ PARA LLEVAR
 6=   , . 6R     5e      $* NOMBRE_CLIENTE��6%   $+ NOMBRE_CLIENTE
 6@   , . 6X     5f      $* TELEFONO_CLIENTE��6%   $+ TELEFONO_CLIENTE
 6B   , . 6\     5g      $* COMENTARIOS��6%   $+ COMENTARIOS
 6=   , . 6R     5h      $* TOTAL��6%   $+ TOTAL
 67   , . 6F   0   DetailDescriptor0 5k      5  /DevExpress.Xpf.Grid.DataControlDetailDescriptor  5l      1   ItemsSourceBinding1 66   �� *	Ordenes+2   DataControl.2 5m        3   AutoGenerateColumns$
3 None=�6*   ) 5n        5o   "   $* 	ID_PEDIDO��61   $+ 	ID_PEDIDO
 6G   , . 6Z     5p   "   $* ID_ORDEN��61   $+ ID_ORDEN
 6F   , . 6X     5q   "   $* ID_PRODUCTO��61   $+ ID_PRODUCTO
 6I   , . 6^     5r   "   $* NOMBRE_PRODUCTO��61   $+ NOMBRE_PRODUCTO
 6M   , . 6f     5s   "   $* CANTIDAD��61   $+ CANTIDAD
 6F   , . 6X     5t   "   $* CON_TODO��61   $+ CONTODO
 6F   , . 6W     5u   "   $* CON_TODO_MENOS��61   $+ CON TODO MENOS
 6L   , . 6d     5v   "   $* COMENTARIOS��61   $+ COMENTARIOS
 6I   , . 6^     5w   "   $* TOTAL_ORDEN��61   $+ TOTAL
 6I   , . 6X   5y      5z      5|      5}      5~      5      